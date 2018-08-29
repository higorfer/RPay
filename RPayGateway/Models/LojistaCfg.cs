using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class LojistaCfg
    {
        public LojistaCfg()
        {
            LogTrans = new HashSet<LogTrans>();
            LojistaCfgBandeira = new HashSet<LojistaCfgBandeira>();
        }

        public int IdLojistaCfg { get; set; }
        public int? IdLojista { get; set; }
        public string DscCfg { get; set; }

        public virtual Lojista IdLojistaNavigation { get; set; }
        public virtual ICollection<LogTrans> LogTrans { get; set; }
        public virtual ICollection<LojistaCfgBandeira> LojistaCfgBandeira { get; set; }
    }
}
