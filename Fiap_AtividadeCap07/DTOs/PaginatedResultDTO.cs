using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.DTOs
{
    public class PaginatedResultDTO<T>
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public required IEnumerable<T> Data { get; set; }
    }
}
