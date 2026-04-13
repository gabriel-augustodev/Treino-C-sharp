using Pessoas.Models;
using Pessoas.Repositories;

namespace Pessoas.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRespository _repository;

        public PessoaService(IPessoaRespository repository)
        {
            _repository = repository;
        }

        public void Add(Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Nome))
            {
                throw new ArgumentException("O nome da pessoa é obrigatório.");
            }
            _repository.Add(pessoa);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _repository.GetAll();
        }

        public Pessoa GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Pessoa pessoa)
        {
            _repository.Update(pessoa);
        }
    }
}
