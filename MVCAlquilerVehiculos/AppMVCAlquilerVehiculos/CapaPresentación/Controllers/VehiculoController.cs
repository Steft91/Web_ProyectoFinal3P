using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<int> GuardarVehiculo(VehiculoCLS oVehiculoCLS, IFormFile imagen)
        {
            VehiculoBL obj = new VehiculoBL();
            if (imagen != null && imagen.Length > 0)
            {
                System.Console.WriteLine("file length: " + imagen.Length);
                byte[] fileBytes;

                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                    oVehiculoCLS.imagen = fileBytes;
                }
            } else
            {
                oVehiculoCLS.imagen = Array.Empty<byte>();
            }
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
