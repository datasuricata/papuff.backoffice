using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;
using papuff.backoffice.Models.Helpers;
using papuff.backoffice.Models.Request;
using papuff.backoffice.Models.Response;
using papuff.backoffice.Models.Response.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace papuff.backoffice.Controllers {
    [Authorize]
    public class UserController : BaseController {

        public async Task<IActionResult> Index() {
            var user = await Get<List<UserResponse>>("user/all");
            return View(user);
        }

        #region - profile -

        public async Task<IActionResult> Profile() {
            return View(await Get<UserResponse>("user/me"));
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserResponse form, string newPass) {
            var command = (UserRequest)form;

            command.NewPassword = newPass.Encrypt();

            if (ModelState.IsValid)
                await Put<BaseResponse>("user/update", command);

            return RedirectToAction(nameof(Profile));
        }

        #endregion

        #region - general -

        public async Task<IActionResult> General() {
            return View(await Get<GeneralResponse>("general/me"));
        }

        [HttpPost]
        public async Task<IActionResult> General(GeneralResponse form) {
            var command = (GeneralRequest)form;

            if (ModelState.IsValid)
                await Post<BaseResponse>("general/register", command);

            return RedirectToAction(nameof(General));
        }

        #endregion


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
