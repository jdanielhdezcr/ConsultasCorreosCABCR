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
    
    public partial class Adduser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Visible = false;
            Label3.Text = "";
        }

        protected void cmd_reload_Click(object sender, EventArgs e)
        {
            Label3.Visible = false;
            Label3.Text = "";

        }



        protected void cmd_return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void cmd_add_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                MySqlConnection con = new MySqlConnection(cs);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO users (carnet,user_name) VALUES('" + Txt_carnet.Text + "','" + Txt_username.Text + "') ";
                cmd.Connection = con;
                con.Open();
                int respuesta = cmd.ExecuteNonQuery();
                con.Close();
                if (respuesta == 1)
                {
                    Label3.Visible = true;
                    Label3.Text = "El usuario " + Txt_username.Text + " fue creado";
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "El usuario " + Txt_username.Text + " ya existe en la base de datos";
                }

            }
            catch
            {
                Label3.Visible = true;
                Label3.Text = "ha habido un error con la transacción. por favor consulte la base de datos y comuniquese con TI";


            }
        }
    }
}