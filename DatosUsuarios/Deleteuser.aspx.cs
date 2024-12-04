using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatosUsuarios
{
    
    public partial class deleteuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Visible = false;
        }

        protected void cmd_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                MySqlConnection con = new MySqlConnection(cs);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "DELETE FROM users WHERE user_name='" + txt_codigocer.Text + "'";
                cmd.Connection = con;
                con.Open();
                int respuesta = cmd.ExecuteNonQuery();
                con.Close();
                if (respuesta == 1)
                {
                    Label3.Visible = true;
                    Label3.Text = "El usuario " + txt_codigocer.Text + " fue borrado";
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "El usuario " + txt_codigocer.Text + " no existe en la base de datos";
                }

            }
            catch
            {
                Label3.Visible = true;
                Label3.Text = "ha habido un error con la transacción. por favor consulte la base de datos y comuniquese con TI";


            }


        }


        protected void cmd_reload_Click(object sender, EventArgs e)
        {
            Label3.Visible = true;
            Label3.Text = "";
            txt_codigocer.Text = "";
        }



        protected void cmd_return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}