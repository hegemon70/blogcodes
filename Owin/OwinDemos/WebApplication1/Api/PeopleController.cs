using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Api
{
    public class PeopleController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new {Name = "Nicolas", LastName = "Herrera "});
        }
    }
}