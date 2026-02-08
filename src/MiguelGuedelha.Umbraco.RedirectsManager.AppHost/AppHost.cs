var builder = DistributedApplication.CreateBuilder(args);

var dashboardClient = builder.AddJavaScriptApp(
        name: "dashboard-watch", 
        appDirectory: "../MiguelGuedelha.Umbraco.RedirectsManager.Client", 
        runScriptName: "watch")
    .WithPnpm(install: false);

var testSite = builder.AddProject(
        name: "test-site",
        projectPath: "../MiguelGuedelha.Umbraco.RedirectsManager.TestSite/MiguelGuedelha.Umbraco.RedirectsManager.TestSite.csproj")
    .WaitFor(dashboardClient);

builder.Build().Run();
