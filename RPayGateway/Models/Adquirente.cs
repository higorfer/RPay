using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class Adquirente
    {
        public Adquirente()
        {
            AdquirenteEndpoint = new HashSet<AdquirenteEndpoint>();
            LojistaCfgBandeira = new HashSet<LojistaCfgBandeira>();
        }

        public int IdAdquirente { get; set; }
        public string DscAdquirente { get; set; }

        public virtual ICollection<AdquirenteEndpoint> AdquirenteEndpoint { get; set; }
        public virtual ICollection<LojistaCfgBandeira> LojistaCfgBandeira { get; set; }
    }
}
