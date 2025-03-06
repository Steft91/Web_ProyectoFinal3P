using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        [Authorize(Roles = "Empleado")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Empleado")]
        public List<EmpleadoCLS> listarEmpleado()
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.listarEmpleado();
        }

        [Authorize(Roles = "Empleado")]
        public List<EmpleadoCLS> filtrarEmpleado(string nombre)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.filtrarEmpleado(nombre);
        }

        [Authorize(Roles = "Empleado")]
        public int GuardarEmpleado(EmpleadoCLS oEmpleadoCLS)
        {
            EmpleadoBL obj = new EmpleadoBL();
            return obj.GuardarEmpleado(oEmpleadoCLS);

        }

        [Authorize(Roles = "Empleado")]
        public EmpleadoCLS recuperarEmpleado(int idEmpleado)
        {
            EmpleadoBL obj = new EmpleadoBL();
            return obj.recuperarEmpleado(idEmpleado);

        }

        [Authorize(Roles = "Empleado")]
        public int EliminarEmpleado(int idEmpleado)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.EliminarEmpleado(idEmpleado);
        }

    }
}
