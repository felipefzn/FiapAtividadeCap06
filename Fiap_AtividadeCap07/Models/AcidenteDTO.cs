using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Models
{
    public class AcidenteDTO
    {
        public required string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public required string Localizacao { get; set; }
    }
}
