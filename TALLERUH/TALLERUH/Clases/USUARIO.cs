using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace TALLERUH.Clases
{
    public class USUARIO
    {

        public int UsuarioID {  get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }

        public USUARIO(string nombre, string correoElectronico, string telefono) // no se ocupa ID ya que es automatico del SQL
        {
            
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
        }

        public USUARIO() { }

        public static int Agregar(string nombre, string CorreoElectronico, string Telefono )
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGARUSUARIO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Correo", CorreoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));


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
                    SqlCommand cmd = new SqlCommand("BORRARUSUARIO", Conn)
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

        public static int Modificar(int codigo, string nombre, string CorreoElectronico, string Telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZARUSUARIO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Correo", CorreoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));


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