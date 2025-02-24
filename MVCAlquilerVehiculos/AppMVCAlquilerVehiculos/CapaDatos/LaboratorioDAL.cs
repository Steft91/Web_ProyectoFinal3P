using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class LaboratorioDAL : CadenaDAL
    {
        public List<Laboratorio> listarLaboratorios()
        {
            List<Laboratorio> lista = new List<Laboratorio>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarLaboratorio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Laboratorio
                                {
                                    iidLaboratorio = dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? null : dr.GetString(1),
                                    direccion = dr.IsDBNull(2) ? null : dr.GetString(2),
                                    personaContacto = dr.IsDBNull(3) ? null : dr.GetString(3)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en listarLaboratorios: {ex.Message}");
                    lista = new List<Laboratorio>(); // Devolver lista vacía en vez de null
                }
            }
            return lista;
        }

        public List<Laboratorio> filtrarLaboratorios(Laboratorio obj)
        {
            List<Laboratorio> lista = new List<Laboratorio>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarLaboratorio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", (object)obj.nombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@direccion", (object)obj.direccion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@personacontacto", (object)obj.personaContacto ?? DBNull.Value);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Laboratorio
                                {
                                    iidLaboratorio = dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? null : dr.GetString(1),
                                    direccion = dr.IsDBNull(2) ? null : dr.GetString(2),
                                    personaContacto = dr.IsDBNull(3) ? null : dr.GetString(3)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en filtrarLaboratorios: {ex.Message}");
                    lista = new List<Laboratorio>(); // Devolver lista vacía en vez de null
                }
            }
            return lista;
        }
    }
}
