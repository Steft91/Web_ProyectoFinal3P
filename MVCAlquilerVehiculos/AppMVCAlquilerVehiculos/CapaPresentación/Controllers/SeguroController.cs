using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class SeguroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<SeguroCLS> listarSeguro()
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.listarSeguro();
        }

        public List<SeguroCLS> filtrarSeguro(string nombre)
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.filtrarSeguro(nombre);
        }

        public int GuardarSeguro(SeguroCLS oSeguroCLS)
        {
            SeguroBL obj = new SeguroBL();
            return obj.GuardarSeguro(oSeguroCLS);

        }

        public SeguroCLS recuperarSeguro(int idSeguro)
        {
            SeguroBL obj = new SeguroBL();
            return obj.recuperarSeguro(idSeguro);

        }
        public int EliminarSeguro(int idSeguro)
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.EliminarSeguro(idSeguro);
        }

    }
}
