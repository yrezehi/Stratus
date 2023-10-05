using UI.HTML;

namespace UI
{
    public static class ControllerRegistry
    {
        public static void RegisterControllers(this WebApplication application)
        {
            application.Index();
            application.Assets();
        }

        private static void Index(this WebApplication application)
        {
            application.MapGet("/", () => Results.Extensions.Serve("index.html"));
        }

        private static void Assets(this WebApplication application)
        {
            application.MapGet("/Assets/{*asset}", (string asset) => Results.Extensions.Serve("Assets\\" + asset));
        }
    }
}
