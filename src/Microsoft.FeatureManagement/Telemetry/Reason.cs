using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.FeatureManagement.Telemetry
{
    public class Reason
    {
        public bool FlagEnabled { get; set; } // True,False (Was this feature enabled in the portal?)
        public bool EnabledAfterFilters { get; set; } // True,False (Did the filters change the status)
        public bool EnabledAfterVariants { get; set; } // True,False (Did variants override the enabled status) <omitable>
        public string FilterResultType { get; set; } // EnabledByFilter, DisabledByFilter, DisabledByNoFilters
        public int FilterResultIndex { get; set; } // 0,1,2…
        public string VariantResultType { get; set; } // DisabledDefault, FallthroughDefault, UserMatch, GroupMatch, PercentileMatch
        public string VariantMatchName { get; set; } // UsernameA, GroupA

    }
}
