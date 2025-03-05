using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAppMVC.Controllers
{
    public class ReservaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public List<ReservaCLS> listarReserva()
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.listarReserva();
        }

        public List<ReservaCLS> filtrarReserva(string nombre)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.filtrarReserva(nombre);
        }

        public int GuardarReserva(ReservaCLS oReservaCLS)
        {
            ReservaBL obj = new ReservaBL();
            return obj.GuardarReserva(oReservaCLS);

        }

        public ReservaCLS recuperarReserva(int idReserva)
        {
            ReservaBL obj = new ReservaBL();
            return obj.recuperarReserva(idReserva);

        }

        public int EliminarReserva(int idReserva)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.EliminarReserva(idReserva);
        }

    }
}
