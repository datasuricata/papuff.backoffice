using Newtonsoft.Json;
using papuff.backoffice.Models;
using papuff.backoffice.Services.Notifications;
using papuff.backoffice.Services.Notifications.Events;
using papuff.backoffice.Services.Requests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace papuff.backoffice.Services.Requests {
    public class DataRequest<T> : BaseRequest {

        private readonly IEventNotifier _notify;

        public DataRequest(string baseUri, IEventNotifier notify) : base(baseUri) {
            _notify = notify;
        }

        private async Task HandleResponse(HttpResponseMessage response) {
            if (!response.IsSuccessStatusCode) {

                var content = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<List<Notification>>(content);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new Exception("Endpoint não encontrado, contate o suporte.");

                if (response.StatusCode == HttpStatusCode.BadRequest)
                    if (errors.Any())
                        throw new Exception(string.Join("#", errors.Select(x => x.Value).ToArray()));
            }
        }

        public async Task<T> Get(string endpoint, string token = "") {
            var response = await SendAsync(RequestMethod.Get, endpoint, null, token);
            var retorno = await response.Content.ReadAsStringAsync();
            await HandleResponse(response);
            return JsonConvert.DeserializeObject<T>(retorno);
        }

        public async Task<T> GetById(string endpoint, string id, string token = "") {
            var response = await SendAsync(RequestMethod.Get, $"{endpoint}?id={id}", null, token);
            var retorno = await response.Content.ReadAsStringAsync();
            await HandleResponse(response);
            return JsonConvert.DeserializeObject<T>(retorno);
        }

        public async Task<T> Post(string endpoint, object obj, string token = "") {
            var response = await SendAsync(RequestMethod.Post, endpoint, obj, token);
            var retorno = await response.Content.ReadAsStringAsync();
            await HandleResponse(response);
            return JsonConvert.DeserializeObject<T>(retorno);
        }

        public async Task PostAnonymous(string endpoint, object obj, string token = "") {
            var response = await SendAsync(RequestMethod.Post, endpoint, obj, token);
            var retorno = await response.Content.ReadAsStringAsync();
            await HandleResponse(response);
        }

        public async Task<T> Put(string endpoint, object obj, string token) {
            var response = await SendAsync(RequestMethod.Put, endpoint, obj, token);
            var retorno = await response.Content.ReadAsStringAsync();
            await HandleResponse(response);
            return JsonConvert.DeserializeObject<T>(retorno);
        }
    }
}
