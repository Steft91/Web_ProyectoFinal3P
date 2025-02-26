using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class VehiculosDAL : CadenaDAL
    {
        public VehiculosCLS recuperarVehiculos(int idVehiculos)
        {
            VehiculosCLS oVehiculosCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarVehiculos", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@iidVehiculos", idVehiculos);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                            if (dr != null) {
                                while (dr.Read())
                                {
                                    oVehiculosCLS = new VehiculosCLS();
                                    oVehiculosCLS.idVehiculo = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                    oVehiculosCLS.marca = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                    oVehiculosCLS.modelo = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                    oVehiculosCLS.anio = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                                    oVehiculosCLS.precio = dr.IsDBNull(4) ? 0 : (double)dr.GetDecimal(4);
                                    oVehiculosCLS.estado = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                }
                                cn.Close();
                                }
                            }                           
                        }
                catch (Exception)
                {
                    cn.Close();
                    oVehiculosCLS = null;
                    throw;
                }
            }
            return oVehiculosCLS;
        }

        public int GuardarVehiculos(VehiculosCLS oVehiculosCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspGuardarVehiculos", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@marca", oVehiculosCLS.marca);
                        cmd.Parameters.AddWithValue("@modelo", oVehiculosCLS.modelo);
                        cmd.Parameters.AddWithValue("@año", oVehiculosCLS.anio);
                        cmd.Parameters.AddWithValue("@precio", oVehiculosCLS.precio);
                        cmd.Parameters.AddWithValue("@estado", oVehiculosCLS.estado);

                        rpta = cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("ex ocurrida en dal" + ex);
                    cn.Close();
                }
                return rpta;
        }
        public List<VehiculosCLS> listarVehiculos()
        {
            List<VehiculosCLS> lista = new List<VehiculosCLS>();

            using (SqlConnection cn = new SqlConnection(cadena)) 
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarVehiculos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                VehiculosCLS oVehiculosCLS = new VehiculosCLS
                                {
                                    idVehiculo = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    marca = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    modelo = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    anio = dr.IsDBNull(2) ? 0 : dr.GetInt32(3),
                                    precio = dr.IsDBNull(2) ? 0 : (double)dr.GetDecimal(4),
                                    estado = dr.IsDBNull(2) ? "" : dr.GetString(5)
                                };

                                lista.Add(oVehiculosCLS);
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

        public List<VehiculosCLS> filtrarVehiculos(string nombre)
        {
            List<VehiculosCLS> lista = new List<VehiculosCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarVehiculos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@marca", nombre ?? "");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                VehiculosCLS oVehiculosCLS = new VehiculosCLS
                                {
                                    idVehiculo = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    marca = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    modelo = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    anio = dr.IsDBNull(2) ? 0 : dr.GetInt32(3),
                                    precio = dr.IsDBNull(2) ? 0 : (double)dr.GetDecimal(4),
                                    estado = dr.IsDBNull(2) ? "" : dr.GetString(5)
                                };

                                lista.Add(oVehiculosCLS);
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


//select IDTIPOMEDICAMENTO, NOMBRE, DESCRPCION"
//+ "from TipoMedicamento where BHABILITADO = 1 and IDTIPOMEDICAMENTO = @idtipomedicamento", cn)