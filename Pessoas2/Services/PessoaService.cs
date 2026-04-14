using Pessoas2.DTOs;
using Pessoas2.Models;
using Pessoas2.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Pessoas2.Services
{
    
    public class PessoaService : IPessoaService  
    {
        private readonly IPessoasRepository _repository;

        public PessoaService(IPessoasRepository repository)
        {
            _repository = repository;
        }

        // ============================================
        // ADD
        // ============================================
        public async Task<PessoaResponseDTO> AddAsync(PessoaCreateDTO createDTO)
        {
            // Validações
            if (string.IsNullOrEmpty(createDTO.nome))
            {
                throw new ArgumentException("Nome é obrigatório");
            }

            // CORRIGIDO: antes estava com mensagem errada "Idade é obrigatório"
            if (createDTO.idade < 0 || createDTO.idade > 150)
            {
                throw new ArgumentException("Idade deve estar entre 0 e 150");  // ← mensagem correta
            }

            var pessoa = new Pessoa
            {
                nome = createDTO.nome,
                idade = createDTO.idade
            };

            var novaPessoa = await _repository.AddAsync(pessoa);
            return MapToResponseDto(novaPessoa);
        }

        // ============================================
        // DELETE
        // ============================================
        public async Task DeleteAsync(int id)
        {
            var existe = await _repository.ExistsAsync(id);
            if (!existe)
                throw new ArgumentException("Pessoa não encontrada");

            await _repository.DeleteAsync(id);
        }

        // ============================================
        // EXISTS (se precisar, mas não está na interface)
        // ============================================
        // Se IPessoaService não tem ExistsAsync, pode remover ou manter como private
        private async Task<bool> ExistsAsync(int id)  // ← mudei para private
        {
            return await _repository.ExistsAsync(id);
        }

        // ============================================
        // GET ALL
        // ============================================
        public async Task<IEnumerable<PessoaResponseDTO>> GetAllAsync()
        {
            var pessoas = await _repository.GetAllAsync();
            return pessoas.Select(p => MapToResponseDto(p));
        }

        // ============================================
        // GET BY ID
        // ============================================
        public async Task<PessoaResponseDTO?> GetByIdAsync(int id)  // ← parâmetro adicionado
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id deve ser maior que zero");
            }

            var pessoa = await _repository.GetByIdAsync(id);
            if (pessoa == null)
                throw new ArgumentException("Pessoa não encontrada");

            return MapToResponseDto(pessoa);
        }

        // ============================================
        // UPDATE
        // ============================================
        public async Task UpdateAsync(int id, PessoaUpdateDTO updateDTO)
        {
            var pessoa = await _repository.GetByIdAsync(id);

            if (pessoa == null)
                throw new ArgumentException("Pessoa não encontrada");

            // Atualizar nome
            if (!string.IsNullOrWhiteSpace(updateDTO.nome))
                pessoa.nome = updateDTO.nome;

            // Atualizar idade
            if (updateDTO.idade.HasValue)
            {
                if (updateDTO.idade.Value < 0 || updateDTO.idade.Value > 150)
                    throw new ValidationException("Idade deve estar entre 0 e 150");

                pessoa.idade = updateDTO.idade.Value;
            }

            // ⚠️ FALTANDO SALVAR AS ALTERAÇÕES!
            await _repository.UpdateAsync(pessoa);  // ← ADICIONAR ESTA LINHA!
        }

        // ============================================
        // MÉTODO AUXILIAR
        // ============================================
        private PessoaResponseDTO MapToResponseDto(Pessoa pessoa)
        {
            return new PessoaResponseDTO
            {
                id = pessoa.id,
                nome = pessoa.nome,
                idade = pessoa.idade
            };
        }
    }
}