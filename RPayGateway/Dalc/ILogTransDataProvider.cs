using RPayGateway.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPayGateway.Dalc
{
    public interface ILogTransDataProvider
    {
        Task<IEnumerable<LogTransDet>> GetLogTrans();

        Task<IEnumerable<LogTransDet>> GetLogTrans(int IdLogTrans);

        //Task GetCfg(int idLojista, int idBandeira);

        Task AddLogTrans(string strReqJson, int idLojista, int idBandeira);
    }
}
