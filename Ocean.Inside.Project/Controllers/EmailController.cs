using System.Web.Mvc;

namespace Ocean.Inside.Project.Controllers
{
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    using Ocean.Inside.Project.Models;

    public class EmailController : Controller
    {
        private ApplicationUserManager userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        [HttpPost]
        public ActionResult SendRecallEmail(AddPhoneNumberViewModel model)
        {
            this.UserManager.EmailService.SendAsync(
                new IdentityMessage
                    {
                        Body =
                            "Встречай нового клиента! " + model.Number + "\n\r" + "Тур: "
                            + model.TourTitle,
                        Destination = "okeanvnutry@gmail.com",
                        Subject = "Новый клиент"
                    });

            return RedirectToAction("Index", "Home");
        }
    }
}