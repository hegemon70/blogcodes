namespace MisMiddlewares
{
    using Owin;

    public static class DebugMiddlewareExtensions
    {
        public static void UseDebug(this IAppBuilder app)
        {
            app.Use<DebugMiddleware>();
        }
    }
}
