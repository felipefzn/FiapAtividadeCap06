using Fiap_AtividadeCap07.Models;
using Fiap_AtividadeCap07.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Services
{
    public class SemaforoService : ISemaforoService
    {
        private readonly ISemaforoRepository _semaforoRepository;

        public SemaforoService(ISemaforoRepository semaforoRepository)
        {
            _semaforoRepository = semaforoRepository;
        }

        public async Task<IEnumerable<SemaforoDTO>> GetAllSemaforosAsync(int page, int pageSize)
        {
            var semaforos = await _semaforoRepository.GetSemaforosAsync(page, pageSize);
            return semaforos.Select(s => new SemaforoDTO
            {
                Localizacao = s.Localizacao,
                CorAtual = s.CorAtual
            });
        }

        public async Task<SemaforoDTO> GetSemaforoByIdAsync(int id)
        {
            var semaforo = await _semaforoRepository.GetSemaforoByIdAsync(id);
            if (semaforo == null)
                throw new KeyNotFoundException("Semáforo não encontrado");

            return new SemaforoDTO
            {
                Localizacao = semaforo.Localizacao,
                CorAtual = semaforo.CorAtual
            };
        }

        public async Task<bool> CreateSemaforoAsync(DTOs.SemaforoDTO semaforoDTO)
        {
            var semaforo = new Semaforo
            {
                Localizacao = semaforoDTO.Localizacao,
                CorAtual = semaforoDTO.CorAtual,
                UltimaTroca = DateTime.UtcNow
            };

            try
            {
                await _semaforoRepository.CreateSemaforoAsync(semaforo);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public async Task<bool> UpdateSemaforoAsync(int id, DTOs.SemaforoDTO semaforoDTO)
        {
            var semaforo = await _semaforoRepository.GetSemaforoByIdAsync(id);

            if (semaforo == null)
                throw new KeyNotFoundException("Semáforo não encontrado");

            semaforo.Localizacao = semaforoDTO.Localizacao;
            semaforo.CorAtual = semaforoDTO.CorAtual;
            semaforo.UltimaTroca = DateTime.UtcNow;

            try
            {
                await _semaforoRepository.UpdateSemaforoAsync(semaforo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSemaforoAsync(int id)
        {
            var semaforo = await _semaforoRepository.GetSemaforoByIdAsync(id);
            if (semaforo == null)
                throw new KeyNotFoundException("Semáforo não encontrado");

            try
            {
                await _semaforoRepository.DeleteSemaforoAsync(semaforo);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
