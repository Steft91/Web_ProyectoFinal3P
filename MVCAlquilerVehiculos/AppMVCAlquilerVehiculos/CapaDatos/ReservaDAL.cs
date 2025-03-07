using System.Data.SqlClient;
using System.Data;
using CapaEntidad;
using CapaEntidad.Interfaces;

namespace CapaDatos
{
    public class ReservaDAL : CadenaDAL
    {
        public int EliminarReserva(int idReserva)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarReservas", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idReserva", idReserva);
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

        public ReservaCLS recuperarReserva(int idReserva)
        {
            ReservaCLS oReservaCLS = new ReservaCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarReservas", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idReserva", idReserva);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                oReservaCLS.idReserva = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oReservaCLS.idCliente = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                oReservaCLS.idVehiculo = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);
                                oReservaCLS.fechaInicio = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                oReservaCLS.fechaFin = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4);
                                oReservaCLS.estado = dr.IsDBNull(5) ? "" : dr.GetString(5);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oReservaCLS;
        }

        public int GuardarReserva(ReservaCLS oReservaCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspGuardarReservas", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idReserva", oReservaCLS.idReserva);
                        cmd.Parameters.AddWithValue("@idCliente", oReservaCLS.idCliente);
                        cmd.Parameters.AddWithValue("@idVehiculo", oReservaCLS.idVehiculo);
                        cmd.Parameters.AddWithValue("@fechaInicio", oReservaCLS.fechaInicio);
                        cmd.Parameters.AddWithValue("@fechaFin", oReservaCLS.fechaFin);
                        cmd.Parameters.AddWithValue("@estado", oReservaCLS.estado);

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

        public List<ReservaCLS> listarReserva()
        {
            List<ReservaCLS> lista = new List<ReservaCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarReservas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ReservaCLS oReservaCLS = new ReservaCLS
                                {
                                    idReserva = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    idCliente = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
                                    idVehiculo = dr.IsDBNull(2) ? 0 : dr.GetInt32(2),
                                    fechaInicio = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3),
                                    fechaFin = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4),
                                    estado = dr.IsDBNull(5) ? "" : dr.GetString(5)
                                };

                                lista.Add(oReservaCLS);
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

        public List<ReservaCLS> filtrarReserva(string nombre)
        {
            List<ReservaCLS> lista = new List<ReservaCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarReservas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@estado", nombre ?? "");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ReservaCLS oReservaCLS = new ReservaCLS
                                {
                                    idReserva = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    idCliente = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
                                    idVehiculo = dr.IsDBNull(2) ? 0 : dr.GetInt32(2),
                                    fechaInicio = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3),
                                    fechaFin = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4),
                                    estado = dr.IsDBNull(5) ? "" : dr.GetString(5)
                                };

                                lista.Add(oReservaCLS);
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
    //{
    //    public int EliminarReserva(int idReserva)
    //    {
    //        int rpta = 0;
    //        using (SqlConnection cn = new SqlConnection(cadena))
    //        {
    //            try
    //            {
    //                cn.Open();
    //                using (SqlCommand cmd = new SqlCommand("uspEliminarReservas", cn))
    //                {
    //                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    //                    cmd.Parameters.AddWithValue("@idReserva", idReserva);
    //                    rpta = cmd.ExecuteNonQuery();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                cn.Close();
    //            }
    //        }
    //        return rpta;
    //    }

    //    public ReservaCLS recuperarReserva(int idReserva)
    //    {
    //        ReservaCLS oReservaCLS = new ReservaCLS();

    //        using (SqlConnection cn = new SqlConnection(cadena))
    //        {
    //            try
    //            {
    //                cn.Open();
    //                using (SqlCommand cmd = new SqlCommand("uspRecuperarReservas", cn))
    //                {
    //                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    //                    cmd.Parameters.AddWithValue("@idReserva", idReserva);

    //                    SqlDataReader dr = cmd.ExecuteReader();
    //                    if (dr != null)
    //                    {
    //                        while (dr.Read())
    //                        {
    //                            oReservaCLS.idReserva = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
    //                            oReservaCLS.idCliente = dr.IsDBNull(1) ? 0: dr.GetInt32(1);
    //                            oReservaCLS.idVehiculo = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);
    //                            oReservaCLS.fechaInicio = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
    //                            oReservaCLS.fechaFin = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4);
    //                            oReservaCLS.estado = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                cn.Close();
    //            }
    //        }
    //        return oReservaCLS;
    //    }

    //    public int GuardarReserva(ReservaCLS oReservaCLS)
    //    {
    //        int rpta = 0;
    //        using (SqlConnection cn = new SqlConnection(cadena))
    //            try
    //            {
    //                cn.Open();

    //                using (SqlCommand cmd = new SqlCommand("uspGuardarReservas", cn))
    //                {
    //                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    //                    cmd.Parameters.AddWithValue("@idReserva", oReservaCLS.idReserva);
    //                    cmd.Parameters.AddWithValue("@idCliente", oReservaCLS.idCliente);
    //                    cmd.Parameters.AddWithValue("@idVehiculo", oReservaCLS.idVehiculo);
    //                    cmd.Parameters.AddWithValue("@fechaInicio", oReservaCLS.fechaInicio);
    //                    cmd.Parameters.AddWithValue("@fechaFin", oReservaCLS.fechaFin);
    //                    cmd.Parameters.AddWithValue("@estado", oReservaCLS.estado);

    //                    rpta = cmd.ExecuteNonQuery();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine("ex ocurrida en dal" + ex);
    //                cn.Close();
    //            }
    //        return rpta;
    //    }

    //    public List<ReservaCLS> listarReserva()
    //    {
    //        List<ReservaCLS> lista = new List<ReservaCLS>();

    //        using (SqlConnection cn = new SqlConnection(cadena))
    //        {
    //            try
    //            {
    //                cn.Open();
    //                using (SqlCommand cmd = new SqlCommand("uspListarReservas", cn))
    //                {
    //                    cmd.CommandType = CommandType.StoredProcedure;

    //                    using (SqlDataReader dr = cmd.ExecuteReader())
    //                    {
    //                        while (dr.Read())
    //                        {
    //                            ReservaCLS oReservaCLS = new ReservaCLS
    //                            {
    //                                idReserva = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
    //                                idCliente = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
    //                                idVehiculo = dr.IsDBNull(2) ? 0 : dr.GetInt32(2),
    //                                fechaInicio = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3),
    //                                fechaFin = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4),
    //                                estado = dr.IsDBNull(5) ? string.Empty : dr.GetString(5)
    //                            };

    //                            lista.Add(oReservaCLS);
    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception)
    //            {
    //                lista = null;
    //                throw;
    //            }
    //        }
    //        return lista;
    //    }

    //    public List<ReservaCLS> filtrarReserva(string nombre)
    //    {
    //        List<ReservaCLS> lista = new List<ReservaCLS>();

    //        using (SqlConnection cn = new SqlConnection(cadena))
    //        {
    //            try
    //            {
    //                cn.Open();
    //                using (SqlCommand cmd = new SqlCommand("uspFiltrarReservas", cn))
    //                {
    //                    cmd.CommandType = CommandType.StoredProcedure;
    //                    cmd.Parameters.AddWithValue("@estado", nombre ?? "");

    //                    using (SqlDataReader dr = cmd.ExecuteReader())
    //                    {
    //                        while (dr.Read())
    //                        {
    //                            ReservaCLS oReservaCLS = new ReservaCLS
    //                            {
    //                                idReserva = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
    //                                idCliente = dr.IsDBNull(1) ? 0 : dr.GetInt32(1),
    //                                idVehiculo = dr.IsDBNull(2) ? 0 : dr.GetInt32(2),
    //                                fechaInicio = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3),
    //                                fechaFin = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4),
    //                                estado = dr.IsDBNull(5) ? string.Empty : dr.GetString(5)
    //                            };

    //                            lista.Add(oReservaCLS);
    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception)
    //            {
    //                lista = null;
    //                throw;
    //            }
    //        }
    //        return lista;
    //    }
    //}
}
