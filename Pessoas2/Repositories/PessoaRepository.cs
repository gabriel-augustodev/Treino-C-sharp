using Microsoft.EntityFrameworkCore;
using Pessoas2.Data;
using Pessoas2.Models;


namespace Pessoas2.Repositories
{
    public class PessoasRepository : IPessoasRepository
    {
        private readonly AppDbContext _context;

        public PessoasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa?> GetByIdAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<Pessoa> AddAsync(Pessoa pessoa)
        {
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task UpdateAsync(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pessoa = await GetByIdAsync(id);
            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
        }

        // ⚠️ IMPLEMENTAR O MÉTODO FALTANDO!
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Pessoas.AnyAsync(p => p.id == id);
        }
    }
}

