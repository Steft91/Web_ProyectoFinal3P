using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class PagoBL
    {
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
            PagoDAL obj = new PagoDAL();
            return obj.GuardarPago(oPagoCLS);
        }

        public PagoCLS recuperarPago(int idPago)
        {
            PagoDAL obj = new PagoDAL();
            return obj.recuperarPago(idPago);

        }
        public int EliminarPago(int idPago)
        {
            PagoDAL obj = new PagoDAL();
            return obj.EliminarPago(idPago);
        }

    }
}
