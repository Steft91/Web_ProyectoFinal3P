using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAppMVC.Controllers
{
    public class TipoMedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inicio() {
            return View();
        }
        public IActionResult SinMenu() {
            return View();
        }

        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.listarTipoMedicamento();
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.filtrarTipoMedicamento(nombre);
        }

        public int GuardarTipoMedicamento(TipoMedicamentoCLS otipoMedicamentoCLS)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            var formValues = Request.Form;


            foreach (var key in formValues.Keys)
            {
                var value = formValues[key];
                Console.WriteLine($"{key}: {value}");
            }
            return obj.GuardarTipoMedicamento(otipoMedicamentoCLS);

        }

        public TipoMedicamentoCLS recuperarTipoMedicamento(int idTipoMedicamento)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.recuperarTipoMedicamento(idTipoMedicamento);

        }

    }
}
