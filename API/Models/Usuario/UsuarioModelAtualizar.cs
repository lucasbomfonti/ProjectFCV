using API.Models.Base;
using System.ComponentModel.DataAnnotations;
using API.AnotacaoCustomizada;
using API.Data.Serviço;
using API.Helper;

namespace API.Models.Usuario
{
    public class UsuarioModelAtualizar : ModeloBaseAtualizacao
    {
        [ValidacaoCpf("Id", typeof(UsuarioServico))]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email Inválido")]
        public string Email { get; set; }   
        public string Celular { get; set; }
    }
}
