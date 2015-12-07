using System.Web.Mvc;

namespace MVC_5_Skeleton1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}