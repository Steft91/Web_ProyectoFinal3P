using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAppMVC.Controllers
{
    public class VehiculosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<VehiculosCLS> listarVehiculos()
        {
            VehiculosDAL obj = new VehiculosDAL();
            return obj.listarVehiculos();
        }

        public List<VehiculosCLS> filtrarVehiculos(string nombre)
        {
            VehiculosDAL obj = new VehiculosDAL();
            return obj.filtrarVehiculos(nombre);
        }

        public int GuardarVehiculos(VehiculosCLS oVehiculosCLS)
        {
            VehiculosBL obj = new VehiculosBL();
            //var formValues = Request.Form;


            //foreach (var key in formValues.Keys)
            //{
            //    var value = formValues[key];
            //    Console.WriteLine($"{key}: {value}");
            //}
            return obj.GuardarVehiculos(oVehiculosCLS);

        }

        public VehiculosCLS recuperarVehiculos(int idVehiculos)
        {
            VehiculosBL obj = new VehiculosBL();
            return obj.recuperarVehiculos(idVehiculos);

        }
        public int EliminarVehiculos(int idVehiculos)
        {
            VehiculosDAL obj = new VehiculosDAL();
            return obj.EliminarVehiculos(idVehiculos);
        }

    }
}
