using Aquitectura.Negocio.Interfaces;
using Arquitectura.Negocio.Expertos;
using Arquitectura.Repositorio.Interfaces;
using Arquitectura.Repositorio.Modelo;
using Arquitectura.Repositorio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Arquitectura.IoC
{
    public static class ServicesExtencion
    {
        public static IServiceCollection registrarServicioRepositorio(this IServiceCollection servicio)
        {
            //Repositorio
            servicio.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return servicio;
        }

        public static IServiceCollection registrarServicioNegocio(this IServiceCollection servicio)
        {
            //Negocio
            servicio.AddTransient<IExpertoClientes, ExpertoClientes>();
            return servicio;
        }

        public static IServiceCollection configurarConnectionString(this IServiceCollection servicio, string connectionString)
        {
            //ConnectionString
            servicio.AddDbContext<ContextoBD>(x => x.UseSqlServer(connectionString));
            return servicio;
        }
    }
}
