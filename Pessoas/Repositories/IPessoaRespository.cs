using Pessoas.Models;

namespace Pessoas.Repositories
{
    public interface IPessoaRespository
    {
        IEnumerable<Pessoa> GetAll();
        Pessoa GetById(int id);
        void Add(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(int id);
    }
}
