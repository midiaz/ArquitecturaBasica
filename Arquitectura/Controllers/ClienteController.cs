using Aquitectura.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arquitectura.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IExpertoClientes _expertoClientes;
        public ClienteController(IExpertoClientes expertoClientes)
        {
            _expertoClientes = expertoClientes;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var clientes = _expertoClientes.Listar();
            return View(clientes);
        }
    }
}
