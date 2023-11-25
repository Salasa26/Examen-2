using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TALLERUH.Clases
{
    public class EQUIPOS
    {
        public int EquipoID { get; set; }
        public int UsuarioID { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }

        public EQUIPOS(int usuarioID, string tipoEquipo, string modelo)
        {
            
            UsuarioID = usuarioID;
            TipoEquipo = tipoEquipo;
            Modelo = modelo;
        }
        public EQUIPOS() { }

        public static int Agregar(int UsuarioID, string TipoEquipo, string Modelo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAREQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAREQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));



                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }


        public static int modificar(int EquipoID, int UsuarioID, string TipoEquipo, string Modelo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAREQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@CODIGO", EquipoID));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }


    }
}