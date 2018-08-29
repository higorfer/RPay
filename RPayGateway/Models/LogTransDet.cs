using System;
using System.Collections.Generic;

namespace RPayGateway.Models
{
    public partial class LogTransDet
    {
        public string DscLojista { get; set; }
        public string DscBandeira { get; set; }
        public string DscAdquirente { get; set; }
        public string URL { get; set; }
        public string strReqJson { get; set; }
        public DateTime dtTrans { get; set; }
    }
}
