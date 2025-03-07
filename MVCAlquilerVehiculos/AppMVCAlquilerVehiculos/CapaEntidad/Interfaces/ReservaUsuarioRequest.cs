using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * const datosCliente = {
			nombre: formReserva.nombre,
			apellido: formReserva.apellido,
			telefono: formReserva.telefono,
			email: formReserva.email,
		}
		const reserva = {
			idVehiculo: idVehiculo,
			fechaInicio: formReserva.fechaInicio.value,
			fechaFin: formReserva.fechaFin.value,
		};
		const reqBody = {
			datosCliente,
			reserva
		}
 */

namespace CapaEntidad.Interfaces
{
	public class ClienteFrontend
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }

    public class ReservaFrontend
    {
        public int idVehiculo { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
    }

    public class ReservaUsuarioRequest
    {
        public ClienteFrontend datosCliente { get; set; }
        public ReservaFrontend reserva { get; set; }
    }
}
