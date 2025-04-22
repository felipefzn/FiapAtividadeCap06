using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.DTOs
{
    public class AcidenteDTO
    {
        public required string Descricao { get; set; }
        public required string Localizacao { get; set; }
        public required string Gravidade { get; set; }
        public DateTime DataHora { get; set; }
    }
}
