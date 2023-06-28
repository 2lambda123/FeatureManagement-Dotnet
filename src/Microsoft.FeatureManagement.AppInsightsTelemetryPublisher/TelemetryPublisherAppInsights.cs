using Microsoft.ApplicationInsights;
using Microsoft.FeatureManagement.Telemetry;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.FeatureManagement.AppInsightsTelemetryPublisher
{
    public class TelemetryPublisherAppInsights : ITelemetryPublisher
    {
        private readonly string eventName = "FeatureEvaluation";
        private readonly TelemetryClient _telemetryClient;

        public TelemetryPublisherAppInsights(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public ValueTask PublishEvent(EvaluationEvent evaluationEvent, CancellationToken cancellationToken)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>()
            {
                { "Feature", evaluationEvent.Feature },
                { "IsEnabled", evaluationEvent.IsEnabled.ToString() },
                { "FlagEnabled", evaluationEvent.Reason.FlagEnabled.ToString() },
                { "EnabledAfterFilters", evaluationEvent.Reason.EnabledAfterFilters.ToString() },
                { "FilterResultType", evaluationEvent.Reason.FilterResultType },
                { "FilterResultIndex", evaluationEvent.Reason.FilterResultIndex.ToString() }
            };
            _telemetryClient.TrackEvent(eventName, properties);

            return new ValueTask();
        }
    }
}