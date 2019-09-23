using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using papuff.backoffice.Controllers.Base;
using papuff.backoffice.Models;
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
                await Post<BaseResponse>("general/create", command);

            return RedirectToAction(nameof(General));
        }

        #endregion

        #region - address -

        public async Task<IActionResult> Address() {
            return View(await Get<AddressResponse>("address/me"));
        }

        [HttpPost]
        public async Task<IActionResult> Address(AddressResponse form) {
            var command = (AddressRequest)form;

            if (ModelState.IsValid)
                await Post<BaseResponse>("address/create", command);

            return RedirectToAction(nameof(Address));
        }

        #endregion

        #region - document -

        public async Task<IActionResult> Document() {
            return View(await Get<IEnumerable<DocumentResponse>>("document/me"));
        }

        [HttpPost]
        public async Task<IActionResult> Document(string imageUri, string value, DocumentType type) {
            var command = new DocumentRequest {
                ImageUri = imageUri, Value = value, Type = type
            };

            if (ModelState.IsValid)
                await Post<BaseResponse>("document/create", command);

            return RedirectToAction(nameof(Document));
        }

        public async Task<IActionResult> DocumentDelete(string id) {

            if (ModelState.IsValid)
                await Put<BaseResponse>($"document/delete/{id}", null);

            return RedirectToAction(nameof(Document));
        }

        public async Task<IActionResult> DocumentPadLock(string id) {

            if (ModelState.IsValid)
                await Put<BaseResponse>($"document/padLock/{id}", null);

            return RedirectToAction(nameof(Document));
        }

        #endregion

        #region - wallets -

        public async Task<IActionResult> Wallet() {
            return View(await Get<IEnumerable<WalletResponse>>("wallet/me"));
        }

        [HttpPost]
        public async Task<IActionResult> Wallet(WalletResponse form) {
            var command = (WalletRequest)form;

            if (ModelState.IsValid)
                await Post<BaseResponse>("wallet/create", command);

            return RedirectToAction(nameof(Wallet));
        }

        #endregion

        public IActionResult Companies() {
            return View();
        }
    }
}