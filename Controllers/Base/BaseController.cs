using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using papuff.backoffice.Models;
using papuff.backoffice.Models.Helpers;
using papuff.backoffice.Services.Notifications.Events;
using papuff.backoffice.Services.Requests;
using papuff.backoffice.Services.Requests.Endpoints.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace papuff.backoffice.Controllers.Base {
    public class BaseController : Controller {

        protected IEventNotifier _notify =>
                    (IEventNotifier)HttpContext.RequestServices
                        .GetService(typeof(IEventNotifier));

        #region - async -

        private string GetCurrentToken() =>
            HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Hash)?.Value;

        protected async Task<T> Get<T>(string uri) {
            var request = new DataRequest<T>(Endpoint.api, _notify);
            return await request.Get(uri, GetCurrentToken());
        }

        protected async Task<T> GetById<T>(string uri, string id) {
            var request = new DataRequest<T>(Endpoint.api, _notify);
            return await request.GetById(uri, id, GetCurrentToken());
        }

        protected async Task<T> Post<T>(string uri, object obj) {
            var request = new DataRequest<T>(Endpoint.api, _notify);
            return await request.Post(uri, obj, GetCurrentToken());
        }

        protected async Task<T> Put<T>(string uri, object obj) {
            var request = new DataRequest<T>(Endpoint.api, _notify);
            return await request.Put(uri, obj, GetCurrentToken());
        }

        protected async Task PostAnonymous<T>(string uri, object obj) {
            var request = new DataRequest<T>(Endpoint.api, _notify);
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
        protected void Notify(string msg, MessageType type) {
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
