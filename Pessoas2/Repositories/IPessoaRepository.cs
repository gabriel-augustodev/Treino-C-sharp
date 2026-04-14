using Pessoas2.DTOs;
using Pessoas2.Models;

namespace Pessoas2.Repositories
{
    public interface IPessoasRepository
    {
        Task<IEnumerable<Pessoa>> GetAllAsync();
        Task<Pessoa?> GetByIdAsync(int id);
        Task<Pessoa> AddAsync(Pessoa pessoa);
        Task UpdateAsync(Pessoa pessoa);  // ← Recebe Pessoa, não id + DTO!
        Task DeleteAsync(int id);

        // ⚠️ ADICIONAR ESTE MÉTODO FALTANDO!
        Task<bool> ExistsAsync(int id);  // ← ADICIONE ESTA LINHA
    }
}
