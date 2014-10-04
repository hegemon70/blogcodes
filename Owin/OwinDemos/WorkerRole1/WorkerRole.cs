using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Fix;
using Microsoft.WindowsAzure.ServiceRuntime;
using Nowin;
using Simple.Web;
using Simple.Web.Behaviors;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable _server;

        public override void Run()
        {
            Trace.TraceInformation("WebApiRole entry point called", "Information");
            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // New code:
            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["Endpoint1"];
            string baseUri = string.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);

            Func<IDictionary<string, object>, Task> app = new Fixer()
                .Use((env, next) => Application.Run(env, t => next(env)))
                .Build();

            ServerBuilder builder = ServerBuilder.New()
                .SetAddress(endpoint.IPEndpoint.Address)
                .SetPort(82)
                .SetOwinApp(app);
            _server = builder.Start();

            Trace.TraceInformation(String.Format("Starting OWIN at {0}", baseUri), "Information");

            return base.OnStart();
        }

        public override void OnStop()
        {
            if(_server != null)
                _server.Dispose();
            base.OnStop();
        }
    }

    [UriTemplate("/")]
    public class Index : IGet, IOutput<RawHtml>
    {
        public Status Get()
        {
            return 200;
        }

        public RawHtml Output
        {
            get { return "<h1>¡Hola Azure!</h1>"; }
        }
    }
}