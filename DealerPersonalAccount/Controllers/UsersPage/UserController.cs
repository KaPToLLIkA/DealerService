using DealerPersonalAccount.Connections;
using DealerPersonalAccount.Models.Repository;
using DealerPersonalAccount.Models.ViewModels;
using System.Web.Mvc;

namespace DealerPersonalAccount.Controllers.UsersPage
{
    public class UserController : Controller
    {
        public IUserRepository _repository;

        public UserController()
        {
            var defaultConnection = new DefaultSqlConnectionProvider();
            _repository = new UserRepository(defaultConnection);
        }

        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View(_repository.GetAllViewModels());
        }

        [HttpGet]
        public ActionResult Agents()
        {
            return View(_repository.GetAgentAllViewModels());
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model.BuildUser());
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        // GET: User/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
