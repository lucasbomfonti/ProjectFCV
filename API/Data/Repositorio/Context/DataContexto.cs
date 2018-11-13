using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositorio.Context
{
    public class DataContexto : DbContext
    {
        public DataContexto(DbContextOptions<DataContexto> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
       
        
    }
}
