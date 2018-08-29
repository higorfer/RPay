using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class LojistaCfgBandeira
    {
        public LojistaCfgBandeira()
        {
            LogTrans = new HashSet<LogTrans>();
        }

        public int IdLojistaCfgBandeira { get; set; }
        public int? IdLojistaCfg { get; set; }
        public int? IdBandeira { get; set; }
        public int? IdAdquirente { get; set; }
        public int BlAntifraude { get; set; }
        public int BlEmail { get; set; }

        public virtual Adquirente IdAdquirenteNavigation { get; set; }
        public virtual Bandeira IdBandeiraNavigation { get; set; }
        public virtual LojistaCfg IdLojistaCfgNavigation { get; set; }
        public virtual ICollection<LogTrans> LogTrans { get; set; }
    }
}
