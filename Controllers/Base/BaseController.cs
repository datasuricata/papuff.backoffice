using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using papuff.backoffice.Models;
using papuff.backoffice.Models.Helpers;
using papuff.backoffice.Services.Requests;
using papuff.backoffice.Services.Requests.Endpoints.Base;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace papuff.backoffice.Controllers.Base {
    public class BaseController : Controller {

        /// <summary>
        /// return user info from current context
        /// </summary>
        /// <returns></returns>
        protected string Me => User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        #region - async -

        private string SessionToken =>
            User?.FindFirst(ClaimTypes.Hash)?.Value;

        protected async Task<T> Get<T>(string uri) {
            var request = new DataRequest<T>(Endpoint.api);
            return await request.Get(uri, SessionToken);
        }

        protected async Task<T> GetById<T>(string uri, string id) {
            var request = new DataRequest<T>(Endpoint.api);
            return await request.GetById(uri, id, SessionToken);
        }

        protected async Task<T> Post<T>(string uri, object obj) {
            var request = new DataRequest<T>(Endpoint.api);
            return await request.Post(uri, obj, SessionToken);
        }

        protected async Task<T> Put<T>(string uri, object obj) {
            var request = new DataRequest<T>(Endpoint.api);
            return await request.Put(uri, obj, SessionToken);
        }

        protected async Task PostAnonymous<T>(string uri, object obj) {
            var request = new DataRequest<T>(Endpoint.api);
            await request.PostAnonymous(uri, obj);
        }

        #endregion

        #region - components -

        protected List<SelectListItem> ToDropDown<T>(IEnumerable<T> list, string text, string value) {
            return Helper.ToDropDown(list, text, value);
        }

        protected List<SelectListItem> ToDropDown<T>() {
            return Helper.ToDropDown<T>();
        }

        /// <summary>
        /// set tempdata messages
        /// </summary>
        /// <param name="msg">Write your message</param>
        /// <param name="msgType">Define your message type</param>
        protected void SetMessage(MessageType type, string msg) {
            switch (type) {
                case MessageType.Success:
                    TempData["Message"] = msg;
                    break;
                case MessageType.Exception:
                    TempData["Error"] = msg;
                    break;
                case MessageType.Info:
                    TempData["Info"] = msg;
                    break;
            }
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        protected IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
