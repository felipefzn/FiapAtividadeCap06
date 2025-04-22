using Fiap_AtividadeCap07.DTOs;
using Fiap_AtividadeCap07.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcidenteController : ControllerBase
    {
        private readonly IAcidenteService _acidenteService;

        public AcidenteController(IAcidenteService acidenteService)
        {
            _acidenteService = acidenteService;
        }

        // Endpoint para listar acidentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcidenteDTO>>> GetAcidentes([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var acidentes = await _acidenteService.GetAllAcidentesAsync(page, pageSize);
                return Ok(acidentes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao listar acidentes: {ex.Message}");
            }
        }

        // Endpoint para registrar um novo acidente
        [HttpPost]
        public async Task<ActionResult> CreateAcidente([FromBody] AcidenteDTO acidenteDTO)
        {
            try
            {
                var resultado = await _acidenteService.CreateAcidenteAsync(acidenteDTO);

                if (resultado)
                {
                    return StatusCode(201);
                }
                return BadRequest("Erro ao registrar acidente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao registrar acidente: {ex.Message}");
            }
        }

        // Endpoint para obter detalhes de um acidente específico
        [HttpGet("{id}")]
        public async Task<ActionResult<AcidenteDTO>> GetAcidente(int id)
        {
            try
            {
                var acidente = await _acidenteService.GetAcidenteByIdAsync(id);
                if (acidente == null)
                {
                    return NotFound("Acidente não encontrado.");
                }
                return Ok(acidente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter detalhes do acidente: {ex.Message}");
            }
        }

        // Endpoint para excluir um acidente
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAcidente(int id)
        {
            try
            {
                var sucesso = await _acidenteService.DeleteAcidenteAsync(id);

                if (!sucesso)
                {
                    return NotFound("Acidente não encontrado.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir acidente: {ex.Message}");
            }
        }
    }
}
