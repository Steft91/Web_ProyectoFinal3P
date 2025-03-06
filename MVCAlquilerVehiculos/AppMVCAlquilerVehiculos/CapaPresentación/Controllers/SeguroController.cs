using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class SeguroController : Controller
    {
        [Authorize(Roles = "Empleado")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Empleado")]
        public List<SeguroCLS> listarSeguro()
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.listarSeguro();
        }

        [Authorize(Roles = "Empleado")]
        public List<SeguroCLS> filtrarSeguro(string nombre)
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.filtrarSeguro(nombre);
        }

        [Authorize(Roles = "Empleado")]
        public int GuardarSeguro(SeguroCLS oSeguroCLS)
        {
            SeguroBL obj = new SeguroBL();
            return obj.GuardarSeguro(oSeguroCLS);

        }

        [Authorize(Roles = "Empleado")]
        public SeguroCLS recuperarSeguro(int idSeguro)
        {
            SeguroBL obj = new SeguroBL();
            return obj.recuperarSeguro(idSeguro);

        }

        [Authorize(Roles = "Empleado")]
        public int EliminarSeguro(int idSeguro)
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.EliminarSeguro(idSeguro);
        }

    }
}
