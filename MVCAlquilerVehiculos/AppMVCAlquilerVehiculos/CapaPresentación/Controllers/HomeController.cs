using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CapaPresentacion.Models;
using Microsoft.Extensions.Logging;
using CapaNegocios;
using CapaEntidad;
using CapaDatos;
using Microsoft.AspNet.Identity;

namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Si el usuario está autenticado, buscar el Cliente relacionado usando el userId
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                ClienteDAL clienteDal = new ClienteDAL();
                ClienteCLS? cliente = clienteDal.recuperarClienteFromUser(userId);
                ViewData["cliente"] = cliente;
                if (cliente != null)
                {
                    ViewData["clienteNombre"] = cliente.nombre;
                    ViewData["clienteApellido"] = cliente.apellido;
                    ViewData["clienteTelefono"] = cliente.telefono;
                }

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
