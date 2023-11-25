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
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDropdownListEquipos();
            }

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Tdatagrid.DataSource = dt;
                            Tdatagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }



        }

        protected void LlenarDropdownListEquipos()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select TipoEspecialidad from TiposListaEspecialidad"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownListEspecialidad.DataSource = dt;

                            DropDownListEspecialidad.DataTextField = dt.Columns["TipoEspecialidad"].ToString();
                            DropDownListEspecialidad.DataValueField = dt.Columns["TipoEspecialidad"].ToString();
                            DropDownListEspecialidad.DataBind();
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

        protected void TButton1_Click(object sender, EventArgs e)
        {
            if (Clases.TECNICOS.Agregar(tNombre.Text, DropDownListEspecialidad.SelectedValue) > 0)
            {
                LlenarGrid();
                alertas("Tecnico agregado con exito.");
                tNombre.Text = ""; tCodigoTec.Text = ""; tNombre.Text = "";


            }
            else
            {
                alertas("Error al agregar el Tecnico.");
            }




        }

        protected void TButton2_Click(object sender, EventArgs e)
        {
            if (Clases.TECNICOS.Borrar(int.Parse(tCodigoTec.Text)) > 0)
            {
                LlenarGrid();
                alertas("Tecnico borrado con exito.");
                tNombre.Text = ""; tCodigoTec.Text = ""; tNombre.Text = ""; 


            }
            else
            {
                alertas("Error al borrar el Tecnico.");
            }



        }

        protected void TButton3_Click(object sender, EventArgs e)
        {
            if (Clases.TECNICOS.Modificar(int.Parse(tCodigoTec.Text), tNombre.Text, DropDownListEspecialidad.SelectedValue) > 0)
            {
                LlenarGrid();
                alertas("Tecnico modificado con exito.");
                tNombre.Text = ""; tCodigoTec.Text = ""; tNombre.Text = "";


            }
            else
            {
                alertas("Error al modificar el Tecnico.");
            }



        }

        protected void TBconsulta_Click(object sender, EventArgs e)
        {

            {
                int codigo = int.Parse(tCodigoTec.Text);
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos WHERE TecnicoID ='" + codigo + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                Tdatagrid.DataSource = dt;
                                Tdatagrid.DataBind();  // actualizar el grid view
                            }
                        }



                    }


                }
            }

            tNombre.Text = ""; tCodigoTec.Text = ""; tNombre.Text = ""; 

        }
    }
}