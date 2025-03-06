using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class PagoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public List<PagoCLS> listarPago()
        {
            PagoDAL obj = new PagoDAL();
            return obj.listarPago();
        }

        public List<PagoCLS> filtrarPago(string nombre)
        {
            PagoDAL obj = new PagoDAL();
            return obj.filtrarPago(nombre);
        }

        public int GuardarPago(PagoCLS oPagoCLS)
        {
            PagoBL obj = new PagoBL();
            return obj.GuardarPago(oPagoCLS);

        }

        public PagoCLS recuperarPago(int idPago)
        {
            PagoBL obj = new PagoBL();
            return obj.recuperarPago(idPago);

        }

        public int EliminarPago(int idPago)
        {
            PagoDAL obj = new PagoDAL();
            return obj.EliminarPago(idPago);
        }

    }
}
