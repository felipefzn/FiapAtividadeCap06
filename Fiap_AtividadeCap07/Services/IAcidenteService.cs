using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap_AtividadeCap07.Services
{
    public interface IAcidenteService
    {
        Task<IEnumerable<AcidenteDTO>> GetAllAcidentesAsync(int page, int pageSize);
        Task<AcidenteDTO> GetAcidenteByIdAsync(int id);
        Task CreateAcidenteAsync(AcidenteDTO acidenteDTO);
        Task UpdateAcidenteAsync(int id, AcidenteDTO acidenteDTO);
        Task<bool> DeleteAcidenteAsync(int id);
        Task<bool> CreateAcidenteAsync(DTOs.AcidenteDTO acidenteDTO);
    }
}
