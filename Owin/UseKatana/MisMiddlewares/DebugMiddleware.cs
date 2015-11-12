using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MisMiddlewares
{
    using AppFunc = Func<IDictionary<string, object>,Task>;
    public class DebugMiddleware
    {
        private readonly AppFunc _next;

        public DebugMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> enviroment)
        {
            var path = (string) enviroment["owin.RequestPath"];
            Debug.WriteLine("--Incoming request. Path: " + path);
            await _next(enviroment);
            Debug.WriteLine("--Outgoing request. Path: " + path);
        }
    }
}
