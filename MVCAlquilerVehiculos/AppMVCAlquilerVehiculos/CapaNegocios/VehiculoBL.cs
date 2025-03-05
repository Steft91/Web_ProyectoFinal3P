using CapaDatos;
using CapaEntidad;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaNegocios
{
    public class VehiculoBL
    {
        public List<VehiculoCLS> listarVehiculo()
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.listarVehiculo();
        }

        public List<VehiculoCLS> filtrarVehiculo(string nombre)
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.filtrarVehiculo(nombre);  
        }

        public int GuardarVehiculo(VehiculoCLS oVehiculoCLS)
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.GuardarVehiculo(oVehiculoCLS);
        }
        public VehiculoCLS recuperarVehiculo(int idVehiculo)
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.recuperarVehiculo(idVehiculo);

        }
        public int EliminarVehiculo(int idVehiculo)
        {
            VehiculoDAL obj = new VehiculoDAL();
            return obj.EliminarVehiculo(idVehiculo);
        }

    }
}

