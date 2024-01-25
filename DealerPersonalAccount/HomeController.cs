using System.Web.Mvc;

namespace DealerPersonalAccount.Controllers.Home
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}