using UI.HTML;

namespace UI
{
    public static class ControllerRegistry
    {
        public static void RegisterControllers(this WebApplication application)
        {
            application.MapGet("/", () => Results.Extensions.HTML("index"));
        }
    }
}
