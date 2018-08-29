using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class LogTrans
    {
        public int IdLogTrans { get; set; }
        public int? IdLojista { get; set; }
        public int? IdLojistaCfg { get; set; }
        public int? IdLojistaCfgBandeira { get; set; }
        public string StrReqJson { get; set; }
        public DateTime DtTrans { get; set; }

        public virtual LojistaCfgBandeira IdLojistaCfgBandeiraNavigation { get; set; }
        public virtual LojistaCfg IdLojistaCfgNavigation { get; set; }
        public virtual Lojista IdLojistaNavigation { get; set; }
    }
}
