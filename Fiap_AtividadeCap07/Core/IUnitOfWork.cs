using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Core
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Rollback();
    }
}
