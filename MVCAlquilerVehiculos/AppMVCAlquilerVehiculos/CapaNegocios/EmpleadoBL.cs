using CapaDatos;
using CapaEntidad;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaNegocios
{
    public class EmpleadoBL
    {
        public List<EmpleadoCLS> listarEmpleado()
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.listarEmpleado();
        }

        public List<EmpleadoCLS> filtrarEmpleado(string nombre)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.filtrarEmpleado(nombre);
        }

        public int GuardarEmpleado(EmpleadoCLS oEmpleadoCLS)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.GuardarEmpleado(oEmpleadoCLS);
        }

        public EmpleadoCLS recuperarEmpleado(int idEmpleado)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.recuperarEmpleado(idEmpleado);

        }
        public int EliminarEmpleado(int idEmpleado)
        {
            EmpleadoDAL obj = new EmpleadoDAL();
            return obj.EliminarEmpleado(idEmpleado);
        }

    }
}

