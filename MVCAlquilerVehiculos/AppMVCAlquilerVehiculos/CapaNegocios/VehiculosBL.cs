﻿using CapaDatos;
using CapaEntidad;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaNegocios
{
    public class VehiculosBL
    {
        public List<VehiculosCLS> listarVehiculos()
        {
            VehiculosDAL obj = new VehiculosDAL();
            return obj.listarVehiculos();
        }

        public List<VehiculosCLS> filtrarVehiculos(string nombre)
        {
            VehiculosDAL obj = new VehiculosDAL();
            return obj.filtrarVehiculos(nombre);  
        }

        public int GuardarVehiculos(VehiculosCLS oVehiculosCLS)
        {
            VehiculosDAL obj = new VehiculosDAL();
            return obj.GuardarVehiculos(oVehiculosCLS);
        }
        public VehiculosCLS recuperarVehiculos(int idVehiculos)
        {
            VehiculosDAL obj = new VehiculosDAL();
            return obj.recuperarVehiculos(idVehiculos);

        }
        public int EliminarVehiculos(int idVehiculos)
        {
            VehiculosDAL obj = new VehiculosDAL();
            return obj.EliminarVehiculos(idVehiculos);
        }

    }
}

