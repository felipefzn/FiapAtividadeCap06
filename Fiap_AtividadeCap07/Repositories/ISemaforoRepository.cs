using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Repositories
{
    public interface ISemaforoRepository
    {
        Task<IEnumerable<Semaforo>> GetSemaforosAsync(int page, int pageSize);
        Task<Semaforo> GetSemaforoByIdAsync(int id);
        Task CreateSemaforoAsync(Semaforo semaforo);
        Task UpdateSemaforoAsync(Semaforo semaforo);
        Task DeleteSemaforoAsync(Semaforo semaforo);
    }
}
