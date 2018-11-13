using System;

namespace API.Models.Usuario
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string  Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
    
    }
}
