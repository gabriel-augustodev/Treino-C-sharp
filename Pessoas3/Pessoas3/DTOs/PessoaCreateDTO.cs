using System.ComponentModel.DataAnnotations;

namespace Pessoas3.DTOs
{
    public class PessoaCreateDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;
        [Range(0, 150, ErrorMessage = "A idade deve estar entre 0 e 150")]
        public int Idade { get; set; }
    }
}
