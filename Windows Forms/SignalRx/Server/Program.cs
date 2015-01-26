using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace Server
{
    class Program
    {
        static void Main()
        {
            const string url = "http://localhost:8088";
            using (WebApp.Start(url))
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                Console.WriteLine("Servidor corriendo en: {0}", url);
                while (true) context.Clients.All.AddMessage(Console.ReadLine());
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map => map.RunSignalR(new HubConfiguration()));
        }
    }
    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.AddMessage(name, message);
        }
    }
}
