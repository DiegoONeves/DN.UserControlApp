using DN.UserControlApp.Domain.Account.Commands;
using DN.UserControlApp.Domain.Account.Services;
using DN.UserControlApp.Presentation.MVC.Models;
using DN.UserControlApp.SharedKernel.Events;
using DN.UserControlApp.SharedKernel.Helpers.Contracts;
using System.Web.Mvc;

namespace DN.UserControlApp.Presentation.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IHandler<DomainNotification> Notifications;
        private readonly IUserApplicationService _userAppService;
        public AccountController(IUserApplicationService userAppService)
        {
            Notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            _userAppService = userAppService;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRegisteredViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new RegisterUserCommand(
                    firstName: model.FirstName,
                    email: model.Email,
                    password: model.Password);

                _userAppService.Register(command);

                if (Notifications.HasNotifications())
                {
                    foreach (var item in Notifications.Notify())
                        ModelState.AddModelError("", item.Value);
                }
                else
                    return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}