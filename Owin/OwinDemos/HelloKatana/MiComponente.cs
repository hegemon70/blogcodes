using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloKatana
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class MiComponente
    {
        private readonly AppFunc _next;

        public MiComponente(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            Console.WriteLine("Path requested: {0}", environment["owin.RequestPath"]);
            return _next(environment);
        }
    }
}