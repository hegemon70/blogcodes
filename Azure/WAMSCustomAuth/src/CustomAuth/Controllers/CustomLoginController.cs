using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using CustomAuth.CustomIdentity;
using CustomAuth.ViewModels;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace CustomAuth.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class CustomLoginController : ApiController
    {
        public ApiServices Services { get; set; }
        public IServiceTokenHandler handler { get; set; }


        // POST api/CustomLogin
        public HttpResponseMessage Post(LoginRequest loginRequest)
        {
            //Auth logic here...
            if (loginRequest.username == "foo" && loginRequest.password == "bar")
            {
                var claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginRequest.username));
                var loginResult = new CustomLoginProvider(handler).CreateLoginResult(claimsIdentity, Services.Settings.MasterKey);
                return Request.CreateResponse(HttpStatusCode.OK, loginResult);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password");
        }
    }
}