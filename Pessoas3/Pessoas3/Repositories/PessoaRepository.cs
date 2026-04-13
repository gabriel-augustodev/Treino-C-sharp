using Pessoas3.Models;

namespace Pessoas3.Repositories
{
    public class PessoaRepository : IPessoaRepositoy
    {

        private static List<Pessoa> pessoas = new();
        private static int _nextId = 1;  // ← CONTADOR DE ID



        public Task AddAsync(Pessoa pessoa)
        {
            pessoa.Id = _nextId++;
            pessoas.Add(pessoa);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa != null) pessoas.Remove(pessoa);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Pessoa>> GetAllASync() => Task.FromResult(pessoas.AsEnumerable());

        public Task<Pessoa?> GetByIdAsync(int id) => Task.FromResult(pessoas.FirstOrDefault(p => p.Id == id));

        public Task UpdateAsync(Pessoa pessoa) => Task.CompletedTask;
    }
}
