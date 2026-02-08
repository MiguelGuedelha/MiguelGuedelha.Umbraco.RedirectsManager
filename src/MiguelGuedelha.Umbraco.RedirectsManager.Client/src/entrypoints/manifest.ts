export const manifests: Array<UmbExtensionManifest> = [
  {
    name: "Miguel Guedelha Umbraco Redirects Manager Entrypoint",
    alias: "MiguelGuedelha.Umbraco.RedirectsManager.Entrypoint",
    type: "backofficeEntryPoint",
    js: () => import("./entrypoint.js"),
  },
];
