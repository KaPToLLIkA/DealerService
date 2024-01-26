using System.Web.Mvc;

namespace DealerPersonalAccount.Controllers.HomePage
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