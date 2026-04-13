using Pessoas3.Models;

namespace Pessoas3.Repositories
{
    public interface IPessoaRepositoy
    {
        Task<IEnumerable<Pessoa>> GetAllASync();
        Task<Pessoa?> GetByIdAsync(int id);
        Task AddAsync(Pessoa pessoa);
        Task UpdateAsync(Pessoa pessoa);
        Task DeleteAsync(int id);


    }
}
