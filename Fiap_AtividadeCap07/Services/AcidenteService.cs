using Fiap_AtividadeCap07.Models;
using Fiap_AtividadeCap07.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace Fiap_AtividadeCap07.Services
{
    public class AcidenteService : IAcidenteService
    {
        private readonly IAcidenteRepository _acidenteRepository;

        public AcidenteService(IAcidenteRepository acidenteRepository)
        {
            _acidenteRepository = acidenteRepository;
        }

        public async Task<IEnumerable<AcidenteDTO>> GetAllAcidentesAsync(int page, int pageSize)
        {
            var acidentes = await _acidenteRepository.GetAcidentesAsync(page, pageSize);
            return acidentes.Select(a => new AcidenteDTO
            {
                Descricao = a.Descricao,
                DataHora = (DateTime)a.DataHora,
                Localizacao = a.Localizacao
            });
        }

        public async Task<AcidenteDTO> GetAcidenteByIdAsync(int id)
        {
            var acidente = await _acidenteRepository.GetAcidenteByIdAsync(id);
            if (acidente == null)
                throw new KeyNotFoundException("Acidente não encontrado");

            return new AcidenteDTO
            {
                Descricao = acidente.Descricao,
                DataHora = (DateTime)acidente.DataHora,
                Localizacao = acidente.Localizacao
            };
        }

        public async Task CreateAcidenteAsync(AcidenteDTO acidenteDTO)
        {
            var acidente = new Acidente
            {
                Descricao = acidenteDTO.Descricao,
                DataHora = acidenteDTO.DataHora,
                Localizacao = acidenteDTO.Localizacao,
            };
            await _acidenteRepository.CreateAcidenteAsync(acidente);
        }

        public async Task UpdateAcidenteAsync(int id, AcidenteDTO acidenteDTO)
        {
            var acidente = await _acidenteRepository.GetAcidenteByIdAsync(id);
            if (acidente == null)
                throw new KeyNotFoundException("Acidente não encontrado");

            acidente.Descricao = acidenteDTO.Descricao;
            acidente.DataHora = acidenteDTO.DataHora;
            acidente.Localizacao = acidenteDTO.Localizacao;

            await _acidenteRepository.UpdateAcidenteAsync(acidente);
        }

        public async Task<bool> DeleteAcidenteAsync(int id)
        {
            var acidente = await _acidenteRepository.GetAcidenteByIdAsync(id);
            if (acidente == null)
                throw new KeyNotFoundException("Acidente não encontrado");

            try
            {
                await _acidenteRepository.DeleteAcidenteAsync(acidente);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<bool> CreateAcidenteAsync(DTOs.AcidenteDTO acidenteDTO)
        {
            var acidente = new Acidente
            {
                Descricao = acidenteDTO.Descricao,
                DataHora = acidenteDTO.DataHora,
                Localizacao = acidenteDTO.Localizacao,
            };
            try
            {
                await _acidenteRepository.CreateAcidenteAsync(acidente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
