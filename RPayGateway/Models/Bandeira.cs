using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class Bandeira
    {
        public Bandeira()
        {
            LojistaCfgBandeira = new HashSet<LojistaCfgBandeira>();
        }

        public int IdBandeira { get; set; }
        public string DscBandeira { get; set; }

        public virtual ICollection<LojistaCfgBandeira> LojistaCfgBandeira { get; set; }
    }
}
