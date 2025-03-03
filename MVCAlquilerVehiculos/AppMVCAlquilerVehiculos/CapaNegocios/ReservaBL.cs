using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class ReservaBL
    {
        public List<ReservaCLS> listarReserva()
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.listarReserva();
        }

        public List<ReservaCLS> filtrarReserva(string nombre)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.filtrarReserva(nombre);
        }

        public int GuardarReserva(ReservaCLS oReservaCLS)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.GuardarReserva(oReservaCLS);
        }

        public ReservaCLS recuperarReserva(int idReserva)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.recuperarReserva(idReserva);

        }
        public int EliminarReserva(int idReserva)
        {
            ReservaDAL obj = new ReservaDAL();
            return obj.EliminarReserva(idReserva);
        }

    }
}
