using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ClienteDAL : CadenaDAL
    {
        public int EliminarCliente(int idCliente)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarClientes", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);
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

        public ClienteCLS recuperarCliente(int idCliente)
        {
            ClienteCLS oClienteCLS = new ClienteCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarClientes", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                oClienteCLS.idCliente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oClienteCLS.nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                oClienteCLS.apellido = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                oClienteCLS.telefono = dr.IsDBNull(1) ? string.Empty : dr.GetString(3);
                                oClienteCLS.email = dr.IsDBNull(2) ? string.Empty : dr.GetString(4);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return oClienteCLS;
        }

        public int GuardarCliente(ClienteCLS oClienteCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspGuardarClientes", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCliente", oClienteCLS.idCliente);
                        cmd.Parameters.AddWithValue("@nombre", oClienteCLS.nombre);
                        cmd.Parameters.AddWithValue("@apellido", oClienteCLS.apellido);
                        cmd.Parameters.AddWithValue("@telefono", oClienteCLS.telefono);
                        cmd.Parameters.AddWithValue("@email", oClienteCLS.email);

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

        public List<ClienteCLS> listarCliente()
        {
            List<ClienteCLS> lista = new List<ClienteCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarClientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ClienteCLS oClienteCLS = new ClienteCLS
                                {
                                    idCliente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    apellido = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    telefono = dr.IsDBNull(1) ? "" : dr.GetString(3),
                                    email = dr.IsDBNull(2) ? "" : dr.GetString(4)
                                };

                                lista.Add(oClienteCLS);
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

        public List<ClienteCLS> filtrarCliente(string nombre)
        {
            List<ClienteCLS> lista = new List<ClienteCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarClientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombre ?? "");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ClienteCLS oClienteCLS = new ClienteCLS
                                {
                                    idCliente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    apellido = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    telefono = dr.IsDBNull(1) ? "" : dr.GetString(3),
                                    email = dr.IsDBNull(2) ? "" : dr.GetString(4)
                                };

                                lista.Add(oClienteCLS);
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
