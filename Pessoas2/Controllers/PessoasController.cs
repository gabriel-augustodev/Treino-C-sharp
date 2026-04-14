using Microsoft.AspNetCore.Mvc;
using Pessoas2.DTOs;
using Pessoas2.Services;

namespace Pessoas2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaResponseDTO>>> GetAll()
        {
            var pessoas = await _service.GetAllAsync();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaResponseDTO>> GetById(int id)
        {
            var pessoa = await _service.GetByIdAsync(id);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaResponseDTO>> Create(PessoaCreateDTO createDTO)
        {
            var novaPessoa = await _service.AddAsync(createDTO);

            // Retorna 201 Created com Location: /api/pessoas/{id}
            return CreatedAtAction(nameof(GetById), new { id = novaPessoa.id }, novaPessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PessoaUpdateDTO updateDTO)
        {
            await _service.UpdateAsync(id, updateDTO);
            return NoContent();  // 204 - Sucesso sem conteúdo
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();  // 204 - Sucesso sem conteúdo
        }

    }
}
