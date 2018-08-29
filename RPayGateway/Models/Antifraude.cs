using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class Antifraude
    {
        public Antifraude()
        {
            AntifraudeEndpoint = new HashSet<AntifraudeEndpoint>();
        }

        public int IdAntifraude { get; set; }
        public string DscAntifraude { get; set; }

        public virtual ICollection<AntifraudeEndpoint> AntifraudeEndpoint { get; set; }
    }
}
