using RPayGateway.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPayGateway.Dalc
{
    public interface ILojistaDataProvider
    {
        Task<IEnumerable<Lojista>> GetLojistas();

        Task<Lojista> GetLojista(int IdLojista);

        Task AddLojista(Lojista lojista);

        Task UpdateLojista(int idLojista, Lojista lojista);

        Task DeleteLojista(int IdLojista);
    }
}
