using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Models
{
    public class Acidente
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public required string Localizacao { get; set; }
        public string? Gravidade { get; internal set; }
    }

}
