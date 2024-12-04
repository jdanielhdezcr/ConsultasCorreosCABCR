using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatosUsuarios
{
    public partial class Default : System.Web.UI.Page
    {
        protected void cmd_reload_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Verify.aspx");
        }

        protected void cmd_check_Click(object sender, EventArgs e)
        {
            Response.Redirect("reloaddb.aspx");
        }

        protected void cmd_uploadweb_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateWeb.aspx");
        }


        protected void cmd_deleteuser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Deleteuser.aspx");
        }

        protected void cmd_adduser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adduser.aspx");
        }
    }
}