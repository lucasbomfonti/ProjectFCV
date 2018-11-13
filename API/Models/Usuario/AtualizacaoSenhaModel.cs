using System.ComponentModel.DataAnnotations;

namespace API.Models.Usuario
{
    public class AtualizacaoSenhaModel
    {
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [MaxLength(25, ErrorMessage = "Password must contain a maximum of 25 characters")]
        [RegularExpression(@"([a-zA-Z]+[0-9]+|[0-9]+[a-zA-Z]+)+([a-zA-Z]*[0-9]*)", ErrorMessage = "The password must contain letters and numbers")]
        public string  Senha { get; set; }
        [Compare("Senha", ErrorMessage = "Password and password confirmation must be the same")]
        public string ConfirmacaoSenha { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "the code can not be less than 6 characters ")]
        [MaxLength(10, ErrorMessage = "the code can not be longer than 6 characters")]
        public string Codigo { get; set; }
    }
}
