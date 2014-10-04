using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Fix;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Hosting.Services;
using Microsoft.Owin.Hosting.Starter;
using Nowin;
using Owin;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Fixer().Use(Start).Build();

            var builder = ServerBuilder.New()
                .SetPort(1234)
                .SetOwinApp(app);

            using (builder.Start())
            {
                Console.WriteLine("Listening on port 8888. Enter to exit.");
                Console.ReadLine();
            }
        }

        private static Task Start(IDictionary<string, object> env, Func<IDictionary<string, object>, Task> next)
        {
            IAppBuilder app = new Microsoft.Owin.Hosting.Builder.AppBuilderFactory().Create();
            app.UseWebApi(ConfigureWebApi());
            var build = app.Build();
            return build(env);
        }

        private static HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
                );
            return config;
        }
    }

    public class TestController : ApiController
    {
        public string Get()
        {
            return "Nicolas";
        }
    }
}

