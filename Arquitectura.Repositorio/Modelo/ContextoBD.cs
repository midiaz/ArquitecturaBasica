using Arquitectura.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Arquitectura.Repositorio.Modelo
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Cliente> Cliente { get; set; }

    }
}
