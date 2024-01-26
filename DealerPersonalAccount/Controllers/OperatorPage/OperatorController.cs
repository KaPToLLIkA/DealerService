using DealerPersonalAccount.Connections;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository;
using System.Web.Mvc;

namespace DealerPersonalAccount.Controllers.OperatorPage
{
    public class OperatorController : Controller
    {
        public IRepository<Operator> _repository;

        public OperatorController()
        {
            var defaultConnection = new DefaultSqlConnectionProvider();
            _repository = new OperatorRepository(defaultConnection);
        }

        // GET: Operator/Index
        [HttpGet]
        public ActionResult Index()
        {
            return View(_repository.GetAllViewModels());
        }

        // GET: Operator/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Operator model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        // GET: Operator/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
