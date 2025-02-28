using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class ClienteBL
    {
        public List<ClienteCLS> listarCliente()
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.listarCliente();
        }

        public List<ClienteCLS> filtrarCliente(string nombre)
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.filtrarCliente(nombre);
        }

        public int GuardarCliente(ClienteCLS otipoMedicamentoCLS)
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.GuardarCliente(otipoMedicamentoCLS);
        }

        public ClienteCLS recuperarCliente(int idTipoMedicamento)
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.recuperarCliente(idTipoMedicamento);

        }
        public int EliminarCliente(int idTipoMedicamento)
        {
            ClienteDAL obj = new ClienteDAL();
            return obj.EliminarCliente(idTipoMedicamento);
        }

    }
}
