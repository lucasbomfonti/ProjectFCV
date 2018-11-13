using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain
{
   public class Usuario : EntidadeBase
    {
        [Column(TypeName = "VARCHAR(14)")]
        [StringLength(14)]
        public string Cpf { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        [StringLength(30)]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(80)")]
        [StringLength(80)]
        public string Senha { get; set; }
        public string CodigoRecuperacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string  Endereco { get; set; }

    }
}
