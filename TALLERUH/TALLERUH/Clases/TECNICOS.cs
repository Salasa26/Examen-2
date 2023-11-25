using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TALLERUH.Clases
{
    public class TECNICOS
    {
        public int TecnicoID { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        public TECNICOS(string nombre, string especialidad)
        {
            
            Nombre = nombre;
            Especialidad = especialidad;
        }

        public TECNICOS () { }

        public static int Agregar(string nombre, string Especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGARTECNICO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", Especialidad));
                   


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
                    SqlCommand cmd = new SqlCommand("BORRARTECNICO", Conn)
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

        

        public static int Modificar(int codigo, string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZARTECNICO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", especialidad));
                    


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