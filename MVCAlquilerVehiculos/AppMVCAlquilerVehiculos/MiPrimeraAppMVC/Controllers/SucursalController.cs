using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAppMVC.Controllers
{
    public class SucursalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public List<Sucursal> listarSucursales()
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.listarSucursales();
        }

        public List<Sucursal> filtrarSucursales(Sucursal objSucursal)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursales(objSucursal);
        }

        public int GuardarSucursal(Sucursal oSucursal)
        {
            SucursalBL obj = new SucursalBL();
            return obj.GuardarSucursal(oSucursal);
        }

        // public string cadena()
        //{
        // IConfigurationBuilder builder = new ConfigurationBuilder();
        // builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
        //var root = builder.Build();
        //var cadenaDato = root.GetConnectionString("cn");
        //return cadenaDato;
        // }

    }
}
