using System.Web.Mvc;

namespace CustomerManager.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
