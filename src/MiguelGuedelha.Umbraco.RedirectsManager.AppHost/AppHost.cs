var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject("test-site", "../MiguelGuedelha.Umbraco.RedirectsManager/MiguelGuedelha.Umbraco.RedirectsManager.csproj");

builder.Build().Run();
