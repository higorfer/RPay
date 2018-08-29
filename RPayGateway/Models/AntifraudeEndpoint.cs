using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class AntifraudeEndpoint
    {
        public int IdAntifraudeEndpoint { get; set; }
        public int? IdAntifraude { get; set; }
        public string Url { get; set; }
        public string DscEndpoint { get; set; }

        public virtual Antifraude IdAntifraudeNavigation { get; set; }
    }
}
