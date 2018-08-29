using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPayGateway.Dalc;
using RPayGateway.Models;

namespace RPayGateway.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private ILogTransDataProvider logTransDataProvider;

        public SalesController(ILogTransDataProvider logTransDataProvider)
        {
            this.logTransDataProvider = logTransDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<LogTransDet>> Get()
        {
            return await this.logTransDataProvider.GetLogTrans();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<LogTransDet>> Get(int id)
        {
            return await this.logTransDataProvider.GetLogTrans(id);
        }

        [HttpPost]
        public async Task Post([FromBody]string strReqJson, [FromQuery(Name = "idLojista")] int idLojista, [FromQuery(Name = "idBandeira")] int idBandeira)
        {
            await this.logTransDataProvider.AddLogTrans(strReqJson, idLojista, idBandeira);
        }
    }
}