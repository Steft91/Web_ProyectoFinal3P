using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ReservaController : Controller
    {
        [Authorize(Roles = "Empleado")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Empleado")]
        public List<ReservaCLS> listarReserva()
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.listarReserva();
        }

        [Authorize(Roles = "Empleado")]
        public List<ReservaCLS> filtrarReserva(string nombre)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.filtrarReserva(nombre);
        }

        [Authorize(Roles = "Empleado")]
        public int GuardarReserva(ReservaCLS oReservaCLS)
        {
            ReservaBL obj = new ReservaBL();
            return obj.GuardarReserva(oReservaCLS);

        }

        [Authorize(Roles = "Empleado")]
        public ReservaCLS recuperarReserva(int idReserva)
        {
            ReservaBL obj = new ReservaBL();
            return obj.recuperarReserva(idReserva);

        }

        [Authorize(Roles = "Empleado")]
        public int EliminarReserva(int idReserva)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.EliminarReserva(idReserva);
        }

    }
}
