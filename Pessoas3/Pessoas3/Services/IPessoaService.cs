using Pessoas3.DTOs;


namespace Pessoas3.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaResponseDTO>> GetAllAsync();
        Task<PessoaResponseDTO> GetByIdAsync(int id);
        Task<PessoaResponseDTO> AddAsync(PessoaCreateDTO createDTO);
        Task UpdateAsync(int id, PessoaUpdateDTO updateDTO);
        Task DeleteAsync(int id);
    }
}
