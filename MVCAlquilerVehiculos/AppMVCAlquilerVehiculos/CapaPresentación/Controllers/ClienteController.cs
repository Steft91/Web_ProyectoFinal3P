using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public List<ClienteCLS> listarCliente()
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.listarCliente();
        }

        public List<ClienteCLS> filtrarCliente(string nombre)
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.filtrarCliente(nombre);
        }

        public int GuardarCliente(ClienteCLS oClienteCLS)
        {
            ClienteBL obj = new ClienteBL();
            return obj.GuardarCliente(oClienteCLS);

        }

        public ClienteCLS recuperarCliente(int idCliente)
        {
            ClienteBL obj = new ClienteBL();
            return obj.recuperarCliente(idCliente);

        }

        public int EliminarCliente(int idCliente)
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.EliminarCliente(idCliente);
        }

    }
}
