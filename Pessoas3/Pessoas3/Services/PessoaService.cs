using Pessoas3.DTOs;
using Pessoas3.Models;
using Pessoas3.Repositories;

namespace Pessoas3.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepositoy _repository;

        public PessoaService(IPessoaRepositoy repository)
        {
            _repository = repository;
        }


        public async Task<PessoaResponseDTO> AddAsync(PessoaCreateDTO createDTO)
        {
            if (string.IsNullOrEmpty(createDTO.Nome))
                throw new Exception("Nome obrigatório");
            var pessoa = new Pessoa
            {
                Nome = createDTO.Nome,
                Idade = createDTO.Idade,
            };

            await _repository.AddAsync(pessoa);

            return new PessoaResponseDTO
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PessoaResponseDTO>> GetAllAsync()
        {
            var pessoas = await _repository.GetAllASync();

            return pessoas.Select(p => new PessoaResponseDTO { Id = p.Id, Nome = p.Nome, Idade = p.Idade });
        }

        public async Task<PessoaResponseDTO> GetByIdAsync(int id)
        {
            var pessoa = await _repository.GetByIdAsync(id);
            if (pessoa == null) return null;

            return new PessoaResponseDTO
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade
            };
        }

        public async Task UpdateAsync(int id, PessoaUpdateDTO updateDTO)
        {
            var pessoa = await _repository.GetByIdAsync(id);

            if (pessoa == null) throw new Exception("Não encontrado");

            if (!string.IsNullOrEmpty(updateDTO.Nome))
                pessoa.Nome = updateDTO.Nome;

            if (updateDTO.Idade.HasValue)
                pessoa.Idade = updateDTO.Idade.Value;

            await _repository.UpdateAsync(pessoa);
        }
    }
}
