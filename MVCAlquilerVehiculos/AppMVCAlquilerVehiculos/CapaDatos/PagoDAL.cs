using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class PagoDAL : CadenaDAL
    {
        public int EliminarPago(int idPago)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarPago", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPago", idPago);
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

        public PagoCLS recuperarPago(int idPago)
        {
            PagoCLS oPagoCLS = new PagoCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarPago", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPago", idPago);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                oPagoCLS.idPago = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oPagoCLS.idReserva = dr.IsDBNull(1) ? 0: dr.GetInt32(1);
                                oPagoCLS.monto = dr.IsDBNull(2) ? 0 : (double)dr.GetDecimal(2);
                                oPagoCLS.metodoPago = dr.IsDBNull(3) ? string.Empty : dr.GetString(3);
                                oPagoCLS.fechaPago = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oPagoCLS;
        }

        public int GuardarPago(PagoCLS oPagoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspGuardarPago", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPago", oPagoCLS.idPago);
                        cmd.Parameters.AddWithValue("@idCliente", oPagoCLS.idReserva);
                        cmd.Parameters.AddWithValue("@idVehiculo", oPagoCLS.monto);
                        cmd.Parameters.AddWithValue("@fechaInicio", oPagoCLS.metodoPago);
                        cmd.Parameters.AddWithValue("@fechaFin", oPagoCLS.fechaPago);
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

        public List<PagoCLS> listarPago()
        {
            List<PagoCLS> lista = new List<PagoCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarPagos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PagoCLS oPagoCLS = new PagoCLS
                                {
                                    idPago = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    idReserva = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
                                    monto = dr.IsDBNull(2) ? 0 : (double)dr.GetDecimal(2),
                                    metodoPago = dr.IsDBNull(3) ? string.Empty : dr.GetString(3),
                                    fechaPago = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4)
                                };

                                lista.Add(oPagoCLS);
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

        public List<PagoCLS> filtrarPago(string nombre)
        {
            List<PagoCLS> lista = new List<PagoCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarPagos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MetodoPago", nombre ?? "");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PagoCLS oPagoCLS = new PagoCLS
                                {
                                    idPago = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    idReserva = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
                                    monto = dr.IsDBNull(2) ? 0 : dr.GetInt32(2),
                                    metodoPago = dr.IsDBNull(3) ? string.Empty : dr.GetString(3),
                                    fechaPago = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4)
                                };

                                lista.Add(oPagoCLS);
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
