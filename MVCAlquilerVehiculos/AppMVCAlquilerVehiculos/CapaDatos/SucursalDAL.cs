using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class SucursalDAL : CadenaDAL
    {
        public int GuardarSucursal(Sucursal oSucursal)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("insert into Sucursal(NOMBRE,DIRECCION, BHABILITADO)" +
                        "values(@nombre, @direccion, 1)", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", oSucursal.nombre);
                        cmd.Parameters.AddWithValue("@direccion", oSucursal.direccion);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                }
            return rpta;
        }
        public List<Sucursal> listarSucursales()
        {
            List<Sucursal> lista = new List<Sucursal>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarSucursal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Sucursal sucursal = new Sucursal
                                {
                                    iidSucursal = dr.GetInt32(0),
                                    nombre = dr.GetString(1),
                                    direccion = dr.GetString(2)
                                };

                                lista.Add(sucursal);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = null;
                    throw;
                }
            }
            return lista;
        }

        public List<Sucursal> filtrarSucursales(Sucursal obj)
        {
            List<Sucursal> lista = new List<Sucursal>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSucursal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombresucursal", (object)obj.nombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@direccion", (object)obj.direccion ?? DBNull.Value);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Sucursal sucursal = new Sucursal
                                {
                                    iidSucursal = dr.GetInt32(0),
                                    nombre = dr.GetString(1),
                                    direccion = dr.GetString(2)
                                };

                                lista.Add(sucursal);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = null;
                    throw;
                }
            }
            return lista;
        }
    }
}
