using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ClienteController : Controller
    {
        [Authorize(Roles = "Empleado")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Empleado")]
        public List<ClienteCLS> listarCliente()
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.listarCliente();
        }

        [Authorize(Roles = "Empleado")]
        public List<ClienteCLS> filtrarCliente(string nombre)
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.filtrarCliente(nombre);
        }

        [Authorize(Roles = "Empleado")]
        public int GuardarCliente(ClienteCLS oClienteCLS)
        {
            ClienteBL obj = new ClienteBL();
            return obj.GuardarCliente(oClienteCLS);

        }

        [Authorize(Roles = "Empleado")]
        public ClienteCLS recuperarCliente(int idCliente)
        {
            ClienteBL obj = new ClienteBL();
            return obj.recuperarCliente(idCliente);

        }

        [Authorize(Roles = "Empleado")]
        public int EliminarCliente(int idCliente)
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.EliminarCliente(idCliente);
        }

    }
}
