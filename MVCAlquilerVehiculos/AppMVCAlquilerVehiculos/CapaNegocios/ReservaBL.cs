using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using CapaEntidad.Interfaces;

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

        public int crearReservaUsuario(string userId, ReservaUsuarioRequest reservaUsuarioRequest)
        {
            ReservaDAL reservaDal = new ReservaDAL();
            ClienteDAL clienteDal = new ClienteDAL();
            VehiculoDAL vehiculoDal = new VehiculoDAL();

            // Recuperar y validar el vehículo
            VehiculoCLS? vehiculo = vehiculoDal.recuperarVehiculo(reservaUsuarioRequest.reserva.idVehiculo);
            if (vehiculo == null)
            {
                System.Console.WriteLine("Vehículo con id " + reservaUsuarioRequest.reserva.idVehiculo + " no encontrado");
                return -1;
            }

            // Chequear si existe algún objeto Cliente asociado al userId, si no existe, crearlo
            ClienteCLS? cliente = clienteDal.recuperarClienteFromUser(userId);
            if (cliente == null)
            {
                System.Console.WriteLine("Cliente con userId " + userId + " no encontrado, creando nuevo cliente");
                ClienteCLS nuevoCliente = new ClienteCLS
                {
                    nombre = reservaUsuarioRequest.datosCliente.nombre,
                    apellido = reservaUsuarioRequest.datosCliente.apellido,
                    telefono = reservaUsuarioRequest.datosCliente.telefono,
                    email = reservaUsuarioRequest.datosCliente.email,
                    userId = userId
                };
                clienteDal.GuardarCliente(nuevoCliente);
                cliente = clienteDal.recuperarClienteFromUser(userId)!;
                System.Console.WriteLine("Cliente creado con id " + cliente.idCliente);
            } else
            {
                System.Console.WriteLine("Cliente encontrado con id " + cliente.idCliente);
            }

                // Crear la reserva
                ReservaCLS reserva = new ReservaCLS
                {
                    idVehiculo = reservaUsuarioRequest.reserva.idVehiculo,
                    idCliente = cliente.idCliente,
                    fechaInicio = DateTime.Parse(reservaUsuarioRequest.reserva.fechaInicio),
                    fechaFin = DateTime.Parse(reservaUsuarioRequest.reserva.fechaFin),
                    estado = "Pendiente"
                };

            return reservaDal.GuardarReserva(reserva);
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
