using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using papuff.backoffice.Services.Notifications.Events;
using System;
using System.Threading.Tasks;

namespace papuff.backoffice.Startups {
    public class WebException {
        private readonly RequestDelegate _next;

        public WebException(RequestDelegate next) { _next = next; }

        public async Task InvokeAsync(HttpContext httpContext) {
            try { await _next(httpContext); } catch (Exception ex) { await HandleExceptionAsync(httpContext, ex); }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
            var _notify = context.RequestServices
                .GetService(typeof(IEventNotifier)) as IEventNotifier;

            _notify.AddException<WebException>("Ops! Algo deu errado.", exception);
            return context.Response.WriteAsync(JsonConvert.SerializeObject(exception));
        }
    }
}