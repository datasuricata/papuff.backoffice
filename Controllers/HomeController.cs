using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;
using papuff.backoffice.Models.Request;
using System.Threading.Tasks;

namespace papuff.backoffice.Controllers {

    [Authorize]
    public class HomeController : BaseController {
        public IActionResult Index() {
            return View();
        }

        public IActionResult InitialStep() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InitialStep(GuideRequest form) {
            if (ModelState.IsValid) {
                await Post<dynamic>("", form);
                return RedirectToAction(nameof(Index), form);
            }

            return RedirectToAction(nameof(InitialStep));
        }
    }
}