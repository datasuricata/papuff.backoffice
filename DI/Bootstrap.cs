using Microsoft.Extensions.DependencyInjection;

namespace papuff.backoffice.DI {
    public static class Bootstrap {
        public static void Configure(IServiceCollection services) {
            #region - kernel -

            // simple
            //services.AddScoped(typeof(IEventNotifier), typeof(EventNotifier));

            #endregion
        }
    }
}