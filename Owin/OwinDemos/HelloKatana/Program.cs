using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Microsoft.Owin.Hosting;
using Owin;

namespace HelloKatana
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string uri = "http://localhost:8888/";
            var t = typeof(Test).GetMethod("TestMethod");
            using (WebApp.Start<Test>(new StartOptions(uri)))
            {
                Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }

    public class Test
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Use(typeof (MiComponente));
            //app.Use(ManageRequest);
            var options = new WelcomePageOptions() { Path = new PathString("/home") };
            app.Use<WelcomePageMiddleware>(options);
        }

        private Task ManageRequest(IOwinContext req, Func<Task> res)
        {
            const string msg = "<h1>Hola Mundo </h1>";
            return req.Response.WriteAsync(msg);
        }
    }
}