using Pessoas.Models;

namespace Pessoas.Repositories
{
    public class PessoaRepository : IPessoaRespository
    {

        private static List<Pessoa> pessoas = new List<Pessoa>();

        public void Add(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }

        public void Delete(int id)
        {
            var pessoa = GetById(id);
            if(pessoa != null)
            {
                pessoas.Remove(pessoa);
            }
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return pessoas;
        }

        public Pessoa GetById(int id)
        {
            return pessoas.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Pessoa pessoa)
        {

            var existe = GetById(pessoa.Id);
            if(existe != null)
            {
                existe.Nome = pessoa.Nome;
                existe.Idade = pessoa.Idade;
            }
        }
    }
}
