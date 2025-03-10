﻿using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class PagoController : Controller
    {
        [Authorize(Roles = "Empleado")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Empleado")]
        public List<PagoCLS> listarPago()
        {
            PagoDAL obj = new PagoDAL();
            return obj.listarPago();
        }

        [Authorize(Roles = "Empleado")]
        public List<PagoCLS> filtrarPago(string nombre)
        {
            PagoDAL obj = new PagoDAL();
            return obj.filtrarPago(nombre);
        }

        [Authorize(Roles = "Empleado")]
        public int GuardarPago(PagoCLS oPagoCLS)
        {
            PagoBL obj = new PagoBL();
            return obj.GuardarPago(oPagoCLS);

        }

        [Authorize(Roles = "Empleado")]
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
