using System.Collections.Generic;
using System.Web.Http;

namespace WebApiSelfHost
{
    public class ValuesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new[] {"valor 1", "valor 1"};
        }
    }
}
