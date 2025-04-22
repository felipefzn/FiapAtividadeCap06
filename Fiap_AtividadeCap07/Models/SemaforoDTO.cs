using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Models
{
    public class SemaforoDTO
    {
        public required string Localizacao { get; set; }
        public required string CorAtual { get; set; }
    }
}
