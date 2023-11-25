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
    public partial class Equipos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Edatagrid.DataSource = dt;
                            Edatagrid.DataBind();  // actualizar el grid view
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
                using (SqlCommand cmd = new SqlCommand("Select TipoEquipo from TiposLista"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownListETipo.DataSource = dt;

                            DropDownListETipo.DataTextField = dt.Columns["TipoEquipo"].ToString();
                            DropDownListETipo.DataValueField = dt.Columns["TipoEquipo"].ToString();
                            DropDownListETipo.DataBind();
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
            if (Clases.EQUIPOS.Agregar(int.Parse(EUsuarioID.Text), DropDownListETipo.SelectedValue, EModelo.Text) > 0)
            {
                LlenarGrid();
                alertas("Equipo agregado con exito.");
                EEquipoID.Text = ""; EUsuarioID.Text = "";EModelo.Text = "";


            }
            else
            {
                alertas("Error al agregar el Equipo. Es posible que el Usuario ID no este dentro de los disponibles.");
            }

        }

        protected void TButton2_Click(object sender, EventArgs e)
        {

            if (Clases.EQUIPOS.Borrar(int.Parse(EEquipoID.Text)) > 0)
            {
                LlenarGrid();
                alertas("Equipo borrado con exito.");
                EEquipoID.Text = ""; EUsuarioID.Text = ""; EModelo.Text = "";


            }
            else
            {
                alertas("Error al borrar el Equipo, es posible que el EquipoID digitado no este dentro de los disponibles.");
            }


        }

        protected void TButton3_Click(object sender, EventArgs e)
        {

            if (Clases.EQUIPOS.modificar(int.Parse(EEquipoID.Text), int.Parse(EUsuarioID.Text), DropDownListETipo.SelectedValue, EModelo.Text) > 0)
            {
                LlenarGrid();
                alertas("Equipo modificado con exito.");
                EEquipoID.Text = ""; EUsuarioID.Text = "";  EModelo.Text = "";


            }
            else
            {
                alertas("Error al modificar el Equipo.");
            }





        }

        protected void TBconsulta_Click(object sender, EventArgs e)
        {
            {
                int codigo = int.Parse(EEquipoID.Text);
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos WHERE EquipoID ='" + codigo + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                Edatagrid.DataSource = dt;
                                Edatagrid.DataBind();  // actualizar el grid view
                            }
                        }



                    }


                }
            }

            EEquipoID.Text = ""; EUsuarioID.Text = ""; EModelo.Text = "";
        }
    }
}