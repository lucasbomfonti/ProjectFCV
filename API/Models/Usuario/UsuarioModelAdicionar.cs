using System;
using System.ComponentModel.DataAnnotations;
using API.AnotacaoCustomizada;
using API.Data.Serviço;

namespace API.Models.Usuario
{
    public class UsuarioModelAdicionar
    {
        [ValidacaoCpf("Id", typeof(UsuarioServico))]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }

        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email Inválido")]
        public string Email { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "A senha deve ser maior que 5 caracteres.")]
        [MaxLength (15, ErrorMessage = "A senha não pode ser maior que 15 caractere.")]
        [RegularExpression(@"([a-zA-Z]+[0-9]+|[0-9]+[a-zA-Z]+)+([a-zA-Z]*[0-9]*)", ErrorMessage = "The password must contain letters and numbers")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "A senha e a confirmação de senha devem ser iguais.")]
        public string ConfirmacaoSenha { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }

    }
}
