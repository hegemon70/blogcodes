using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fix;
using Nancy;
using Nancy.Owin;
using Nowin;

namespace SimpleNowin
{
    class Program
    {
        static void Main()
        {
            var nancyOptions = new NancyOptions { Bootstrapper = new DefaultNancyBootstrapper() };

            var app = new Fixer()
                .Use((env, next) => new NancyOwinHost(next, nancyOptions).Invoke(env))
                .Build();

            // Set up the Nowin server
            var builder = ServerBuilder.New()
                .SetPort(8888)
                .SetOwinApp(app);

            // Run
            using (builder.Start())
            {
                Console.WriteLine("Listening on port 1337. Enter to exit.");
                Console.ReadLine();
            }
        }

        private static Task OnComponent(IDictionary<string, object> env, Func<IDictionary<string, object>, Task> next)
        {
            var nancyOptions = new NancyOptions { Bootstrapper = new DefaultNancyBootstrapper() };

            var nancyHost = new NancyOwinHost(next, nancyOptions);
            return nancyHost.Invoke(env);
        }
    }


    public class CustomRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return @"C:\Users\nicolocodev\Desktop\OwinDemos\SimpleNowin\";
        }
    }
}
