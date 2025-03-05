using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAppMVC.Controllers
{
    public class VehiculoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<VehiculoCLS> listarVehiculo()
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.listarVehiculo();
        }

        public List<VehiculoCLS> filtrarVehiculo(string nombre)
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.filtrarVehiculo(nombre);
        }

        public int GuardarVehiculo(VehiculoCLS oVehiculoCLS)
        {
            VehiculoBL obj = new VehiculoBL();
            return obj.GuardarVehiculo(oVehiculoCLS);

        }

        public VehiculoCLS recuperarVehiculo(int idVehiculo)
        {
            VehiculoBL obj = new VehiculoBL();
            return obj.recuperarVehiculo(idVehiculo);

        }
        public int EliminarVehiculo(int idVehiculo)
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.EliminarVehiculo(idVehiculo);
        }

    }
}
