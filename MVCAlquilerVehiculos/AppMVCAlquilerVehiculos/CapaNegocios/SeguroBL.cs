using CapaDatos;
using CapaEntidad;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaNegocios
{
    public class SeguroBL
    {
        public List<SeguroCLS> listarSeguro()
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.listarSeguro();
        }

        public List<SeguroCLS> filtrarSeguro(string nombre)
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.filtrarSeguro(nombre);  
        }

        public int GuardarSeguro(SeguroCLS oSeguroCLS)
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.GuardarSeguro(oSeguroCLS);
        }
        public SeguroCLS recuperarSeguro(int idSeguro)
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.recuperarSeguro(idSeguro);

        }
        public int EliminarSeguro(int idSeguro)
        {
            SeguroDAL obj = new SeguroDAL();
            return obj.EliminarSeguro(idSeguro);
        }

    }
}

