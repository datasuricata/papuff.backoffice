using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;
using papuff.backoffice.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace papuff.backoffice.Controllers {
    [Authorize]
    public class UserController : BaseController {

        public async Task<IActionResult> Index() {
            var user = await Get<List<UserResponse>>("user/all");
            return View(user);
        }

        public IActionResult Profile() {
            return View();
        }

        public IActionResult General() {
            return View();
        }

        public IActionResult Address() {
            return View();
        }

        public IActionResult Wallets() {
            return View();
        }

        public IActionResult Companies() {
            return View();
        }

        public IActionResult Documents() {
            return View();
        }
    }
}
