using Microsoft.AspNetCore.Mvc;
using Pessoas.Models;
using Pessoas.Services;

namespace Pessoas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pessoa = _service.GetById(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }
        [HttpGet("situacao")]
        public IActionResult Situacao()
        {
            return Ok("Então como fui?");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Pessoa pessoa)
        {
            _service.Add(pessoa);
            return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pessoa pessoa)
        {
            pessoa.Id = id;
            _service.Update(pessoa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

    }
}
