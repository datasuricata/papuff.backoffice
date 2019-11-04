using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;
using papuff.backoffice.Models.Request;
using papuff.backoffice.Services.Notifications;

namespace papuff.backoffice.Controllers {

    [Authorize]
    public class HomeController : BaseController {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Kingdom() {
            return View();
        }

        [HttpPost]
        public IActionResult KingdomPost(GuideRequest form) {
            if (ModelState.IsValid)
                return RedirectToAction(nameof(Treasure), form);

            Notify.When(!ModelState.IsValid, 
                "Verifique as informações e tente novamente.");

            return RedirectToAction(nameof(Kingdom));
        }

        public IActionResult Treasure(GuideRequest form) {
            return View(form);
        }

        [HttpPost]
        public IActionResult TreasurePost(GuideRequest form) {
            if (ModelState.IsValid)
                return RedirectToAction(nameof(Kingdom), form);

            Notify.When(!ModelState.IsValid,
                "Verifique as informações e tente novamente.");

            return RedirectToAction(nameof(Kingdom));
        }
    }
}