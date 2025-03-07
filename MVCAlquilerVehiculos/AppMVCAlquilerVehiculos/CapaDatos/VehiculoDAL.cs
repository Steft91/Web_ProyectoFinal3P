using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class VehiculoDAL : CadenaDAL
    {
        public int EliminarVehiculo(int idVehiculo)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarVehiculos", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idVehiculo", idVehiculo);
                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return rpta;
        }

        public VehiculoCLS? recuperarVehiculo(int idVehiculo)
        {
            VehiculoCLS? oVehiculoCLS = new VehiculoCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarVehiculos", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idVehiculo", idVehiculo);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oVehiculoCLS.idVehiculo = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oVehiculoCLS.marca = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                oVehiculoCLS.modelo = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oVehiculoCLS.anio = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                                oVehiculoCLS.precio = dr.IsDBNull(4) ? 0 : (double)dr.GetDecimal(4);
                                oVehiculoCLS.estado = dr.IsDBNull(5) ? "" : dr.GetString(5);
                            }
                        } else
                        {
                            oVehiculoCLS = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oVehiculoCLS;
        }

        public int GuardarVehiculo(VehiculoCLS oVehiculoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspGuardarVehiculos", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idVehiculo", oVehiculoCLS.idVehiculo);
                        cmd.Parameters.AddWithValue("@marca", oVehiculoCLS.marca);
                        cmd.Parameters.AddWithValue("@modelo", oVehiculoCLS.modelo);
                        cmd.Parameters.AddWithValue("@anio", oVehiculoCLS.anio);
                        cmd.Parameters.AddWithValue("@precio", oVehiculoCLS.precio);
                        cmd.Parameters.AddWithValue("@estado", oVehiculoCLS.estado);
                        cmd.Parameters.AddWithValue("@imagen", oVehiculoCLS.imagen);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ex ocurrida en dal" + ex);
                    cn.Close();
                }
            return rpta;
        }

        public List<VehiculoCLS> listarVehiculo()
        {
            List<VehiculoCLS> lista = new List<VehiculoCLS>();

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
                                VehiculoCLS oVehiculoCLS = new VehiculoCLS
                                {
                                    idVehiculo = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    marca = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    modelo = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    anio = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                                    precio = dr.IsDBNull(4) ? 0 : (double)dr.GetDecimal(4),
                                    estado = dr.IsDBNull(5) ? "" : dr.GetString(5),
                                    imagen = dr.IsDBNull(6) ? Array.Empty<byte>() : (byte[])dr["Imagen"]
                                };

                                lista.Add(oVehiculoCLS);
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

        public List<VehiculoCLS> filtrarVehiculo(string nombre)
        {
            List<VehiculoCLS> lista = new List<VehiculoCLS>();

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
                                VehiculoCLS oVehiculoCLS = new VehiculoCLS
                                {
                                    idVehiculo = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    marca = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    modelo = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    anio = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                                    precio = dr.IsDBNull(4) ? 0 : (double)dr.GetDecimal(4),
                                    estado = dr.IsDBNull(5) ? "" : dr.GetString(5)
                                };

                                lista.Add(oVehiculoCLS);
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

