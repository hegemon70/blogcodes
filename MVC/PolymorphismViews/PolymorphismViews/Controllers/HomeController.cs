using System.Web.Mvc;
using PolymorphismViews.ViewModels;

namespace PolymorphismViews.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new FooViewModel());
        }
    }
}