using Fiap_AtividadeCap07.Data;
using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap_AtividadeCap07.Repositories
{
    public class AcidenteRepository : IAcidenteRepository
    {
        private readonly ApplicationDbContext _context;

        public AcidenteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Acidente>> GetAcidentesAsync(int page, int pageSize)
        {
            return await _context.Acidentes
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<Acidente> GetAcidenteByIdAsync(int id)
        {
            return await _context.Acidentes
                                 .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateAcidenteAsync(Acidente acidente)
        {
            await _context.Acidentes.AddAsync(acidente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAcidenteAsync(Acidente acidente)
        {
            _context.Acidentes.Update(acidente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAcidenteAsync(Acidente acidente)
        {
            _context.Acidentes.Remove(acidente);
            await _context.SaveChangesAsync();
        }
    }
}
