using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement.Telemetry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.FeatureManagement.AppInsightsTelemetryPublisher
{
    /// <summary>
    /// Extensions used to add feature management functionality.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds required feature management services.
        /// </summary>
        /// <param name="services">The service collection that feature management services are added to.</param>
        /// <returns>A <see cref="IFeatureManagementBuilder"/> that can be used to customize feature management functionality.</returns>
        public static IServiceCollection AddFeatureManagementTelemetryPublisherAppInsights(this IServiceCollection services)
        {
            //
            // Add required services
            services.AddSingleton<ITelemetryPublisher>(serviceProvider =>
                new TelemetryPublisherAppInsights(serviceProvider.GetRequiredService<TelemetryClient>())
            );

            return services;
        }
    }
}
