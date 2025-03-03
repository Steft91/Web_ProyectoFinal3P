using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class SeguroDAL : CadenaDAL
    {
        public int EliminarSeguro(int idSeguro)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarSeguro", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idSeguro", idSeguro);
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

        public SeguroCLS recuperarSeguro(int idSeguro)
        {
            SeguroCLS oSeguroCLS = new SeguroCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarSeguro", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idSeguro", idSeguro);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                oSeguroCLS.idSeguro = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oSeguroCLS.idReserva = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                oSeguroCLS.tipoSeguro = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oSeguroCLS.costo = dr.IsDBNull(3) ? 0 : (double)dr.GetDecimal(3);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oSeguroCLS;
        }

        public int GuardarSeguro(SeguroCLS oSeguroCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspGuardarSeguro", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idSeguro", oSeguroCLS.idSeguro);
                        cmd.Parameters.AddWithValue("@idReserva", oSeguroCLS.idReserva);
                        cmd.Parameters.AddWithValue("@tipoSeguro", oSeguroCLS.tipoSeguro);
                        cmd.Parameters.AddWithValue("@costo", oSeguroCLS.costo);

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

        public List<SeguroCLS> listarSeguro()
        {
            List<SeguroCLS> lista = new List<SeguroCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarSeguros", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                SeguroCLS oSeguroCLS = new SeguroCLS
                                {
                                    idSeguro = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    idReserva = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
                                    tipoSeguro = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    costo = dr.IsDBNull(3) ? 0 : (double)dr.GetDecimal(3)
                                };

                                lista.Add(oSeguroCLS);
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

        public List<SeguroCLS> filtrarSeguro(string nombre)
        {
            List<SeguroCLS> lista = new List<SeguroCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSeguros", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipoSeguro", nombre ?? "");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                SeguroCLS oSeguroCLS = new SeguroCLS
                                {
                                    idSeguro = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    idReserva = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
                                    tipoSeguro = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    costo = dr.IsDBNull(3) ? 0 : (double)dr.GetDecimal(3)
                                };

                                lista.Add(oSeguroCLS);
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