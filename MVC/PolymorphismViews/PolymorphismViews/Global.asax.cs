using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PolymorphismViews.CustomModelBinders;
using PolymorphismViews.ViewModels;

namespace PolymorphismViews
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof (BaseViewModel), new BaseViewModelBinder());
        }
    }
}