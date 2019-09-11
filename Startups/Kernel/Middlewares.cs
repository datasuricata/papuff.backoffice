using Microsoft.AspNetCore.Builder;

namespace papuff.backoffice.Startups.Kernel {
    public static class Middlewares {
        public static IApplicationBuilder MiddleException(this IApplicationBuilder builder) {
            return builder.UseMiddleware<WebException>();
        }
    }
}
