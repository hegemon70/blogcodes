using System.Security.Claims;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace CustomAuth.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class HelloController : ApiController
    {
        public IHttpActionResult Get()
        {
            var user = ClaimsPrincipal.Current.FindFirst(claim => claim.Type == "uid").Value;
            if (user.Contains(":")) user = user.Split(':')[1];
            return Ok("Hello! " + user);
        }
    }
}