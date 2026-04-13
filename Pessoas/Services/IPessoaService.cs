using Pessoas.Models;

namespace Pessoas.Services
{
    public interface IPessoaService
    {
        IEnumerable<Pessoa> GetAll();
        Pessoa GetById(int id);
        void Add(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(int id);
    }
}
