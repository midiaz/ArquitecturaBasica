using Aquitectura.Negocio.Interfaces;
using Arquitectura.Negocio.Entidades;
using Arquitectura.Repositorio.Interfaces;
using Arquitectura.Utiles;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arquitectura.Negocio.Expertos
{
    public class ExpertoClientes : IExpertoClientes
    {
        private readonly IRepository<Cliente> repo;
        private readonly IOptions<Keys> opciones;
        public ExpertoClientes(IRepository<Cliente> repo, IOptions<Keys> opciones)
        {
            this.repo = repo;
            this.opciones = opciones;
        }


        public void Guardar(string nombre, string apellido, string nroDocumento, string mail)
        {
            try
            {
                string dbName = opciones.Value.DBName;
                Cliente cliente = new Cliente
                {
                    Nombre = nombre,

                };
                repo.Insert(cliente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> busquedaCompleja(string caca, int sorete)
        {
            repo.Table.Where(x => x.Id == sorete && x.Apellido == caca).ToList();
            return new List<Cliente>();
        }

        public List<Cliente> Listar()
        {
            return repo.Table.ToList();
        }
    }
}
