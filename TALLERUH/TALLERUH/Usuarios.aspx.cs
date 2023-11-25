using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TALLERUH
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Clases.USUARIO.Agregar(tNombre.Text, tCElectronico.Text, tTelefono.Text) >0)
            {
                LlenarGrid();
                alertas("Usuario agregado con exito.");
                tNombre.Text = ""; tCElectronico.Text = ""; tTelefono.Text = ""; tCodigo.Text = "";


            }
            else
            {
                alertas("Error al agregar el Usuario.");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Clases.USUARIO.Borrar(int.Parse(tCodigo.Text)) > 0)
            {
                LlenarGrid();
                alertas("Usuario borrado con exito.");
                tNombre.Text = ""; tCElectronico.Text = ""; tTelefono.Text = ""; tCodigo.Text = "";


            }
            else
            {
                alertas("Error al borrar el Usuario.");
            }



        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Clases.USUARIO.Modificar(int.Parse(tCodigo.Text), tNombre.Text, tCElectronico.Text, tTelefono.Text) > 0)
            {
                LlenarGrid();
                alertas("Usuario modificado con exito.");
                tNombre.Text = ""; tCElectronico.Text = ""; tTelefono.Text = ""; tCodigo.Text = "";


            }
            else
            {
                alertas("Error al modificar el Usuario.");
            }



        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {

            {
                int codigo = int.Parse(tCodigo.Text);
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE UsuarioID ='" + codigo + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                datagrid.DataSource = dt;
                                datagrid.DataBind();  // actualizar el grid view
                            }
                        }



                    }

                    
                }
            }

            tNombre.Text = ""; tCElectronico.Text = ""; tTelefono.Text = ""; tCodigo.Text = "";


        }
    }   

}