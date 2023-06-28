using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.FeatureManagement.Telemetry
{
    public class EvaluationEvent
    {
        public string Feature { get; set; } // "NewBanner"
        public bool IsEnabled { get; set; }
        public string Label { get; set; } // Dev/Prod/Staging/etc. <omitable>
        public string Variant { get; set; } // Large,Small <omitable>
        public Reason Reason { get; set; } // Should be able to tell if the flag was “Feature:false” (via the portal)
    }
}
