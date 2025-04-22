using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Models
{
    public class Semaforo
    {
        public int Id { get; set; }
        public required string Localizacao { get; set; }
        public required string CorAtual { get; set; }
        public DateTime UltimaTroca { get; set; }
    }
}
