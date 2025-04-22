using Fiap_AtividadeCap07.DTOs;
using Fiap_AtividadeCap07.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemaforoController : ControllerBase
    {
        private readonly ISemaforoService _semaforoService;

        public SemaforoController(ISemaforoService semaforoService)
        {
            _semaforoService = semaforoService;
        }

        // Endpoint para listar semáforos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SemaforoDTO>>> GetSemaforos([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var semaforos = await _semaforoService.GetAllSemaforosAsync(page, pageSize);
                return Ok(semaforos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao listar semáforos: {ex.Message}");
            }
        }

        // Endpoint para criar um semáforo
        [HttpPost]
        public async Task<ActionResult> CreateSemaforo([FromBody] SemaforoDTO semaforoDTO)
        {
            try
            {
                await _semaforoService.CreateSemaforoAsync(semaforoDTO);
                return StatusCode(201);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao criar semáforo: {ex.Message}");
            }
        }

        // Endpoint para obter detalhes de um semáforo específico
        [HttpGet("{id}")]
        public async Task<ActionResult<SemaforoDTO>> GetSemaforo(int id)
        {
            try
            {
                var semaforo = await _semaforoService.GetSemaforoByIdAsync(id);
                if (semaforo == null)
                {
                    return NotFound("Semáforo não encontrado.");
                }
                return Ok(semaforo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter semáforo: {ex.Message}");
            }
        }

        // Endpoint para excluir um semáforo
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSemaforo(int id)
        {
            try
            {
                var sucesso = await _semaforoService.DeleteSemaforoAsync(id);
                if (!sucesso)
                {
                    return NotFound("Semáforo não encontrado.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir semáforo: {ex.Message}");
            }
        }
    }
}
