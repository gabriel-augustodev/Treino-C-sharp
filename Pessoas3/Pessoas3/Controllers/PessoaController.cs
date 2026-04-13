using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pessoas3.DTOs;
using Pessoas3.Services;

namespace Pessoas3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController (IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pessoa = await _service.GetByIdAsync(id);
            if(pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {

            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PessoaCreateDTO createDTO)
        {
            var pessoa = await _service.AddAsync(createDTO);

            return CreatedAtAction(nameof(GetById), new { Id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(PessoaUpdateDTO updateDTO, int id) {
            await _service.UpdateAsync(id, updateDTO);
            return NoContent();
        }

        


    }
}
