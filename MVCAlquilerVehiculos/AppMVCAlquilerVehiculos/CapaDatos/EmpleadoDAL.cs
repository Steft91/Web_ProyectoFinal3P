using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class EmpleadoDAL : CadenaDAL
    {
        public int EliminarEmpleado(int idEmpleado)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarEmpleado", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
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

        public EmpleadoCLS recuperarEmpleado(int idEmpleado)
        {
            EmpleadoCLS oEmpleadoCLS = new EmpleadoCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarEmpleado", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                oEmpleadoCLS.idEmpleado = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oEmpleadoCLS.nombreEmpleado = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                oEmpleadoCLS.apellidoEmpleado = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oEmpleadoCLS.cargo = dr.IsDBNull(3) ? string.Empty : dr.GetString(3);
                                oEmpleadoCLS.telefonoEmpleado = dr.IsDBNull(4) ? "" : dr.GetString(4);
                                oEmpleadoCLS.emailEmpleado = dr.IsDBNull(5) ? "" : dr.GetString(5);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oEmpleadoCLS;
        }

        public int GuardarEmpleado(EmpleadoCLS oEmpleadoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspGuardarEmpleado", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEmpleado", oEmpleadoCLS.idEmpleado);
                        cmd.Parameters.AddWithValue("@nombreEmpleado", oEmpleadoCLS.nombreEmpleado);
                        cmd.Parameters.AddWithValue("@apellidoEmpleado", oEmpleadoCLS.apellidoEmpleado);
                        cmd.Parameters.AddWithValue("@cargo", oEmpleadoCLS.cargo);
                        cmd.Parameters.AddWithValue("@telefonoEmpleado", oEmpleadoCLS.telefonoEmpleado);
                        cmd.Parameters.AddWithValue("@emailEmpleado", oEmpleadoCLS.emailEmpleado);

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

        public List<EmpleadoCLS> listarEmpleado()
        {
            List<EmpleadoCLS> lista = new List<EmpleadoCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarEmpleados", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                EmpleadoCLS oEmpleadoCLS = new EmpleadoCLS
                                {
                                    idEmpleado = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    nombreEmpleado = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    apellidoEmpleado = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    cargo = dr.IsDBNull(3) ? "" : dr.GetString(3),
                                    telefonoEmpleado = dr.IsDBNull(4) ? "" : dr.GetString(4),
                                    emailEmpleado = dr.IsDBNull(5) ? "" : dr.GetString(5)
                                };

                                lista.Add(oEmpleadoCLS);
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

        public List<EmpleadoCLS> filtrarEmpleado(string nombre)
        {
            List<EmpleadoCLS> lista = new List<EmpleadoCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarEmpleados", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreEmpleado", nombre ?? "");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                EmpleadoCLS oEmpleadoCLS = new EmpleadoCLS
                                {
                                    idEmpleado = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    nombreEmpleado = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    apellidoEmpleado = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    cargo = dr.IsDBNull(3) ? "" : dr.GetString(3),
                                    telefonoEmpleado = dr.IsDBNull(4) ? "" : dr.GetString(4),
                                    emailEmpleado = dr.IsDBNull(5) ? "" : dr.GetString(5)
                                };

                                lista.Add(oEmpleadoCLS);
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


