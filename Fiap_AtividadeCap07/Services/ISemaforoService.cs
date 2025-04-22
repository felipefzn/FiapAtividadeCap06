using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Services
{
    public interface ISemaforoService
    {
        Task<IEnumerable<SemaforoDTO>> GetAllSemaforosAsync(int page, int pageSize);
        Task<SemaforoDTO> GetSemaforoByIdAsync(int id);
        Task<bool> CreateSemaforoAsync(DTOs.SemaforoDTO semaforoDTO);
        Task<bool> UpdateSemaforoAsync(int id, DTOs.SemaforoDTO semaforoDTO);
        Task<bool> DeleteSemaforoAsync(int id);
    }

}
