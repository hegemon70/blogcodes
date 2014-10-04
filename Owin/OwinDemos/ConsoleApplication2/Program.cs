using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;

namespace ConsoleApplication2
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.ReadLine();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(Manage);
        }

        private Task Manage(IOwinContext context, Func<Task> next)
        {
            var path = context.Get<string>("owin.RequestPath");
            context.Response.ContentType = "text/html";
            return context.Response.WriteAsync("<h1>Hola mundo</h1>");
        }
    }
}
