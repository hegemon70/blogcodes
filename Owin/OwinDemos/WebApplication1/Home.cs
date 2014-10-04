using Nancy;

namespace WebApplication1
{
    public class Home : NancyModule
    {
        public Home()
        {
            Get["/"] = _ =>
                       {
                           var model = new
                                       {
                                           Name = "Nicolas",
                                           LastName = "Herrera",
                                           Twitter = "@nicolocodev"
                                       };
                           return View["index", model];
                       };
        }
    }
}