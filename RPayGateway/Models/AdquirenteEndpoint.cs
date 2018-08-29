using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class AdquirenteEndpoint
    {
        public int IdAdquirenteEndpoint { get; set; }
        public int? IdAdquirente { get; set; }
        public string Url { get; set; }
        public string DscUrl { get; set; }

        public virtual Adquirente IdAdquirenteNavigation { get; set; }
    }
}
