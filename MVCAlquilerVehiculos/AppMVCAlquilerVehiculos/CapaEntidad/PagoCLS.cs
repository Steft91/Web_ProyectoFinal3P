using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PagoCLS
    {
        public int idPago { get; set; }
        public int idReserva { get; set; }
        public double monto { get; set; }
        public string metodoPago { get; set; }
        public DateTime fechaPago { get; set; }
    }
}
