using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class TipoMedicamentoDAL : CadenaDAL
    {
        public TipoMedicamentoCLS recuperarTipoMedicamento(int idTipoMedicamento)
        {
            TipoMedicamentoCLS oTipoMedicamentoCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("select IDTIPOMEDICAMENTO, NOMBRE, DESCRPCION\"\r\n+ \"from TipoMedicamento where BHABILITADO = 1 and IDTIPOMEDICAMENTO = @idTipoMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@idTipoMedicamento", idTipoMedicamento);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                            if (dr != null) {
                                while (dr.Read())
                                {
                                    oTipoMedicamentoCLS = new TipoMedicamentoCLS();
                                    oTipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                    oTipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                    oTipoMedicamentoCLS.descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                }
                                    cn.Close();
                                }
                            }                           
                        }
                catch (Exception)
                {
                    cn.Close();
                    oTipoMedicamentoCLS = null;
                    throw;
                }
            }
            return oTipoMedicamentoCLS;
        }


        public int GuardarTipoMedicamento(TipoMedicamentoCLS otipoMedicamentoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("insert into TipoMedicamento(NOMBRE,DESCRIPCION, BHABILITADO)" +
                        "values(@nombre, @descripcion, 1)", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", otipoMedicamentoCLS.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", otipoMedicamentoCLS.descripcion);

                        rpta = cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("ex ocurrida en dal" + ex);
                    cn.Close();
                }
                return rpta;
        }
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS> lista = new List<TipoMedicamentoCLS>();

            using (SqlConnection cn = new SqlConnection(cadena)) 
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                TipoMedicamentoCLS oTipoMedicamentoCLS = new TipoMedicamentoCLS
                                {
                                    idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2)
                                };

                                lista.Add(oTipoMedicamentoCLS);
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

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            List<TipoMedicamentoCLS> lista = new List<TipoMedicamentoCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombretipomedicamento", nombre ?? "");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                TipoMedicamentoCLS oTipoMedicamentoCLS = new TipoMedicamentoCLS
                                {
                                    idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2)
                                };

                                lista.Add(oTipoMedicamentoCLS);
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