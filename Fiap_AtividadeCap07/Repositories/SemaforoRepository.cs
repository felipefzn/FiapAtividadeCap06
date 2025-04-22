using Fiap_AtividadeCap07.Data;
using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap_AtividadeCap07.Repositories
{
    public class SemaforoRepository : ISemaforoRepository
    {
        private readonly ApplicationDbContext _context;

        public SemaforoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Semaforo>> GetSemaforosAsync(int page, int pageSize)
        {
            return await _context.Semaforos
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<Semaforo> GetSemaforoByIdAsync(int id)
        {
            return await _context.Semaforos
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateSemaforoAsync(Semaforo semaforo)
        {
            await _context.Semaforos.AddAsync(semaforo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSemaforoAsync(Semaforo semaforo)
        {
            _context.Semaforos.Update(semaforo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSemaforoAsync(Semaforo semaforo)
        {
            _context.Semaforos.Remove(semaforo);
            await _context.SaveChangesAsync();
        }
    }
}
