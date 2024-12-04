using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatosUsuarios
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                
                using (SqlCommand cmd = new SqlCommand("SELECT FORMAT(fechaact, 'dddd dd MMMM yyyy hh:mm:ss t', 'es-LA') AS FechaFormateada,usuario FROM UpdateLog where idUpdate=(select max(idUpdate) from UpdateLog where basedatos='SITIO WEB')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) { 
                    reader.Read();
                    Label1.Text = reader["FechaFormateada"].ToString();
                        Label3.Text = reader["usuario"].ToString();
                    }
                    con.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT FORMAT(fechaact, 'dddd dd MMMM yyyy hh:mm:ss t', 'es-LA') AS FechaFormateada,usuario FROM UpdateLog where idUpdate=(select max(idUpdate) from UpdateLog where basedatos='CIJUL')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        Label2.Text = reader["FechaFormateada"].ToString();
                        Label4.Text = reader["usuario"].ToString();
                    }
                    con.Close();
                }
            }
        }
    }
}