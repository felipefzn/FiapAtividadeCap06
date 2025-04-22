using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Repositories
{
    public interface IAcidenteRepository
    {
        Task<IEnumerable<Acidente>> GetAcidentesAsync(int page, int pageSize);
        Task<Acidente> GetAcidenteByIdAsync(int id);
        Task CreateAcidenteAsync(Acidente acidente);
        Task UpdateAcidenteAsync(Acidente acidente);
        Task DeleteAcidenteAsync(Acidente acidente);
    }
}
