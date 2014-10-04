using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebApplication1;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = ConfigureWebApi();
            app.UseWebApi(config);
            app.UseNancy();
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
                );
            return config;
        }
    }
}