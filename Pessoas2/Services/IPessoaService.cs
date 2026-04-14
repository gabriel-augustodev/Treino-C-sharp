using Pessoas2.DTOs;

namespace Pessoas2.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaResponseDTO>> GetAllAsync();

        // ⚠️ FALTANDO O PARÂMETRO id!
        Task<PessoaResponseDTO?> GetByIdAsync(int id);  // ← adicionei "int id"

        Task<PessoaResponseDTO> AddAsync(PessoaCreateDTO createDto);

        Task UpdateAsync(int id, PessoaUpdateDTO updateDto);

        Task DeleteAsync(int id);
    }
}