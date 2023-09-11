﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement.Telemetry;

namespace Microsoft.FeatureManagement.AppInsightsTelemetryPublisher
{
    /// <summary>
    /// Extensions used to add feature management publisher functionality.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds an event publisher that publishes feature evaluation events to Application Insights.
        /// </summary>
        /// <param name="services">The service collection that feature management services are added to.</param>
        /// <returns>The <see cref="IServiceCollection"/> that was given as a parameter, with the publisher added.</returns>
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
