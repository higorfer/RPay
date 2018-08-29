using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class Lojista
    {
        public Lojista()
        {
            LogTrans = new HashSet<LogTrans>();
            LojistaCfg = new HashSet<LojistaCfg>();
        }

        public int IdLojista { get; set; }
        public string DscLojista { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int BlAtivo { get; set; }

        public virtual ICollection<LogTrans> LogTrans { get; set; }
        public virtual ICollection<LojistaCfg> LojistaCfg { get; set; }
    }
}
