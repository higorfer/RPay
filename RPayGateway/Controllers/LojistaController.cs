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
    public class LojistaController : ControllerBase
    {
        private ILojistaDataProvider lojistaDataProvider;

        public LojistaController(ILojistaDataProvider lojistaDataProvider)
        {
            this.lojistaDataProvider = lojistaDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Lojista>> Get()
        {
            return await this.lojistaDataProvider.GetLojistas();
        }

        [HttpGet("{id}")]
        public async Task<Lojista> Get(int id)
        {
            return await this.lojistaDataProvider.GetLojista(id);
        }

        [HttpPost]
        public async Task Post([FromBody]Lojista lojista)
        {
            await this.lojistaDataProvider.AddLojista(lojista);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Lojista lojista)
        {
            await this.lojistaDataProvider.UpdateLojista(id, lojista);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.lojistaDataProvider.DeleteLojista(id);
        }
    }
}