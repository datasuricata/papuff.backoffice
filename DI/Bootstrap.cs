using Microsoft.Extensions.DependencyInjection;
using papuff.backoffice.Services.Notifications.Events;

namespace papuff.backoffice.DI {
    public static class Bootstrap {
        public static void Configure(IServiceCollection services) {
            #region - kernel -

            services.AddScoped(typeof(IEventNotifier), typeof(EventNotifier));

            #endregion
        }
    }
}
