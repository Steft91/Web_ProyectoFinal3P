using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<EmpleadoCLS> listarEmpleado()
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.listarEmpleado();
        }

        public List<EmpleadoCLS> filtrarEmpleado(string nombre)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.filtrarEmpleado(nombre);
        }

        public int GuardarEmpleado(EmpleadoCLS oEmpleadoCLS)
        {
            EmpleadoBL obj = new EmpleadoBL();
            return obj.GuardarEmpleado(oEmpleadoCLS);

        }

        public EmpleadoCLS recuperarEmpleado(int idEmpleado)
        {
            EmpleadoBL obj = new EmpleadoBL();
            return obj.recuperarEmpleado(idEmpleado);

        }

        public int EliminarEmpleado(int idEmpleado)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.EliminarEmpleado(idEmpleado);
        }

    }
}
