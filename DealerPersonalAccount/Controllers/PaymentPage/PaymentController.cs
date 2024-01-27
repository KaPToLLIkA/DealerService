using DealerPersonalAccount.Connections;
using DealerPersonalAccount.Models.Entity;
using DealerPersonalAccount.Models.Repository;
using DealerPersonalAccount.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace DealerPersonalAccount.Controllers.PaymentPage
{
    public class PaymentController : Controller
    {
        public IRepository<Payment> _paymentRepository;
        public IRepository<Operator> _operatorRepository;
        public IUserRepository _userRepository;

        public PaymentController()
        {
            var defaultConnection = new DefaultSqlConnectionProvider();
            _paymentRepository = new PaymentRepository(defaultConnection);
            _operatorRepository = new OperatorRepository(defaultConnection);
            _userRepository = new UserRepository(defaultConnection);
        }

        // GET: Payment
        [HttpGet]
        public ActionResult Index()
        {
            return View(_paymentRepository.GetAllViewModels());
        }

        // GET: Payment/Pay/5
        [HttpGet]
        public ActionResult Pay(int id)
        {
            Payment payment = _paymentRepository.Get(id);

            if (payment.OperatorId is null || payment.AgentId is null)
            {
                Operator op = _operatorRepository.GetAll().ElementAt(0);
                User user = _userRepository
                    .GetAll()
                    .Where(u => u.RoleType == RoleType.Agent)
                    .ElementAt(0);

                payment.OperatorId = op.Id;
                payment.AgentId = user.Id;

                _paymentRepository.Update(payment);
            }

            return RedirectToAction("Index");
        }

        // GET: Payment/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _paymentRepository.Insert(model.BuildPayment());
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        // GET: Payment/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _paymentRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
