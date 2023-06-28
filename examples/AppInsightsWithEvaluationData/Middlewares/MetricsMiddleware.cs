using Microsoft.ApplicationInsights;
using System.Diagnostics;

namespace AppInsightsWithEvaluationData.Middlewares
{
    public class MetricsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TelemetryClient _telemetryClient;

        public MetricsMiddleware(RequestDelegate next, TelemetryClient telemetryClient)
        {
            _next = next;
            _telemetryClient = telemetryClient;
        }

        public Task Invoke(HttpContext httpContext)
        {
            _telemetryClient.Context.User.AuthenticatedUserId = httpContext.Request.Cookies["username"]?.ToString();
            return _next(httpContext);
        }
    }

    public static class MetricsMiddlewareExtensions
    {
        public static IApplicationBuilder UseMetricsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MetricsMiddleware>();
        }
    }
}
