using System.ComponentModel.DataAnnotations;

namespace Pessoas2.DTOs
{
    public class PessoaCreateDTO
    {
       
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string nome { get; set; } = string.Empty;
        [Range(0,100,ErrorMessage ="A idade deve ser entre 0 e 100")]
        public int idade { get; set; }
    }
}
