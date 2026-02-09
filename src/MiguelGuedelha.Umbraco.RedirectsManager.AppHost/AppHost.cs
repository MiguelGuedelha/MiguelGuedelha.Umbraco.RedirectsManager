var builder = DistributedApplication.CreateBuilder(args);

var useSqlServer = bool.Parse(Environment.GetEnvironmentVariable("USE_SQL_SERVER") ?? "false");
var sqlServerOnly = bool.Parse(Environment.GetEnvironmentVariable("SQL_ONLY") ?? "false");

const string baseBindPath = "../../local-data/v17/";

IResourceBuilder<SqlServerServerResource>? sqlServer = null;
IResourceBuilder<SqlServerDatabaseResource>? umbracoDb = null;

if (useSqlServer)
{
    // Local only + need to use it in app settings to reliably generate migrations, so add it to source control
    var sqlPasswordParam = builder.AddParameter("SqlPassword");
    
    sqlServer = builder
        .AddSqlServer("umbraco-db-server")
        .WithDataBindMount(Path.Join(baseBindPath, "database/sql-server/data"))
        .WithContainerRuntimeArgs("--user", "root")
        .WithUrlForEndpoint("tcp", x => { x.DisplayLocation = UrlDisplayLocation.DetailsOnly; })
        .WithPassword(sqlPasswordParam);
    
    umbracoDb = sqlServer.AddDatabase("umbraco-db", "umbraco-cms");
}

if (sqlServerOnly && sqlServer is not null)
{
    builder.Build().Run();
    return;
}

var dashboardClient = builder.AddJavaScriptApp(
        name: "dashboard-watch", 
        appDirectory: "../MiguelGuedelha.Umbraco.RedirectsManager.Client", 
        runScriptName: "watch")
    .WithPnpm(install: false);

var testSite = builder.AddProject(
        name: "test-site",
        projectPath: "../MiguelGuedelha.Umbraco.RedirectsManager.TestSite/MiguelGuedelha.Umbraco.RedirectsManager.TestSite.csproj")
    .WaitFor(dashboardClient);

if (useSqlServer && sqlServer is not null && umbracoDb is not null)
{
    testSite
        .WithReference(umbracoDb, connectionName: "umbracoDbDSN")
        .WithEnvironment("ConnectionStrings__umbracoDbDSN_ProviderName", "Microsoft.Data.SqlClient")
        .WaitFor(umbracoDb);
}
else
{
    testSite
        .WithEnvironment("ConnectionStrings__umbracoDbDSN", "Data Source=|DataDirectory|/Umbraco.sqlite.db;Cache=Shared;Foreign Keys=True;Pooling=True")
        .WithEnvironment("ConnectionStrings__umbracoDbDSN_ProviderName", "Microsoft.Data.Sqlite");
}

builder.Build().Run();
