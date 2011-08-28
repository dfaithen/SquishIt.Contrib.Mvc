using System.Web.Mvc;

namespace Demo.SquishIt.Contrib.Mvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/About

        public ActionResult About()
        {
            return View();
        }
    }
}
