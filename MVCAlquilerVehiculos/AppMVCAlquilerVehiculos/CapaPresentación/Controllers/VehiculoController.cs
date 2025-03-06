using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class VehiculoController : Controller
    {
        [Authorize(Roles = "Empleado")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Empleado")]
        public List<VehiculoCLS> listarVehiculo()
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.listarVehiculo();
        }

        [Authorize(Roles = "Empleado")]
        public List<VehiculoCLS> filtrarVehiculo(string nombre)
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.filtrarVehiculo(nombre);
        }

        [Authorize(Roles = "Empleado")]
        public int GuardarVehiculo(VehiculoCLS oVehiculoCLS)
        {
            VehiculoBL obj = new VehiculoBL();
            return obj.GuardarVehiculo(oVehiculoCLS);

        }

        [Authorize(Roles = "Empleado")]
        public VehiculoCLS recuperarVehiculo(int idVehiculo)
        {
            VehiculoBL obj = new VehiculoBL();
            return obj.recuperarVehiculo(idVehiculo);

        }
        [Authorize(Roles = "Empleado")]
        public int EliminarVehiculo(int idVehiculo)
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.EliminarVehiculo(idVehiculo);
        }

    }
}
