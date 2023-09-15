﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.FeatureManagement.Telemetry.ApplicationInsights
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
        public static IServiceCollection AddFeatureManagementTelemetryPublisherApplicationInsights(this IServiceCollection services)
        {
            //
            // Add required services
            services.TryAddSingleton<ITelemetryPublisher, TelemetryPublisherApplicationInsights>();

            return services;
        }
    }
}
