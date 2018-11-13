using System.Linq;
using API.Data.Repositorio.Base;
using API.Data.Repositorio.Context;
using API.Data.Repositorio.Interface;
using API.Domain;

namespace API.Data.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DataContexto contexto) : base(contexto)
        {
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            return Contexto.Set<Usuario>().FirstOrDefault(w => w.Email == email);
        }

        public object ObtenhaUsuarioPorCodigo(string codigo)
        {
            return Contexto.Set<Usuario>().FirstOrDefault(w => w.CodigoRecuperacao == codigo );
        }
    }
}
