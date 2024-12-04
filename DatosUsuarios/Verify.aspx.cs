using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatosUsuarios
{
     
    public class Root
    {
        public int carnet { get; set; }
        public int cedula { get; set; }
        public int condicionprof { get; set; }
        public string fechainc { get; set; }
        public string nombre { get; set; }
        public string suspmoro { get; set; }
        public string suspvol { get; set; }
        public string user_name { get; set; }
    }
    public partial class Verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
        }

        private void getlawyersdata(agremiado agr)
        {
            try
            {
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
               
                
                    if (agr.user_name == null)
                    {
                        Label1.Visible = true;
                        Label1.Text = "El carnet " + txt_codigocer.Text + " no devuelve dato de correo electronico";
                        Label2.Visible = false;
                        Label3.Visible = false;
                        Label4.Visible = false;
                        Label5.Visible = true;
                        Label6.Visible = true;
                        Label7.Visible = true;
                        Label8.Visible = true;
                        Label9.Visible = true;
                        Label10.Visible = true;
                        Label11.Visible = true;
                        Label12.Visible = true;
                        Label9.Text = agr.nombre;
                        Label10.Text = agr.cedula;
                        Label11.Text = agr.fechainc;
                        switch (agr.condicionprof)
                        {
                            case 10:
                                Label12.Font.Bold = false;
                                Label12.Font.Underline = false;
                                Label12.Text = "Activo";
                                break;
                            case 70:
                                Label12.Font.Bold = false;
                                Label12.Font.Underline = false;
                                Label12.Text = "Fallecido";
                                break;
                            case 80:
                                Label12.Font.Bold = true;
                                Label12.Font.Underline = true;
                                Label12.Text = "Suspendido";
                                break;
                        }






                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "Carné:";
                        Label2.Visible = true;
                        Label3.Visible = true;
                        Label4.Visible = true;
                        Label5.Visible = true;
                        Label6.Visible = true;
                        Label7.Visible = true;
                        Label8.Visible = true;
                        Label9.Visible = true;
                        Label10.Visible = true;
                        Label11.Visible = true;
                        Label12.Visible = true;
                        Label2.Text = agr.Carnet.ToString();
                        Label4.Text = agr.user_name + "@abogados.or.cr";
                        Label9.Text = agr.nombre;
                        Label10.Text = agr.cedula;
                        Label11.Text = agr.fechainc;
                        switch (agr.condicionprof)
                        {
                            case 10:
                                Label12.Font.Bold = false;
                                Label12.Font.Underline = false;
                                Label12.Text = "Activo";
                                break;
                            case 70:
                                Label12.Font.Bold = false;
                                Label12.Font.Underline = false;
                                Label12.Text = "Fallecido";
                                break;
                            case 80:
                                Label12.Font.Bold = true;
                                Label12.Font.Underline = true;
                                Label12.Text = "Suspendido";

                                break;
                        }

                        ;
                    }

                


            }

            catch
            {
                Label1.Visible = true;
                Label1.Text = "La busqueda no encontro ningun dato que coincida. Verifique el dato y reintente";
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;

            }
}
        

        protected void cmd_check_Click(object sender, EventArgs e)
        {
            //getlawyersdata("https://consultacorreoscabcr.azurewebsites.net/service.svc/ConsultarAgremiado/" + txt_codigocer.Text);
            agremiado agr = new agremiado();
            agr=agr.ConsultarAgremiado(txt_codigocer.Text);
            getlawyersdata(agr);

        }

        protected void cmd_reload_Click(object sender, EventArgs e)
        {
            txt_codigocer.Text = "";
            Txtusername.Text = "";
            Txt_cedula.Text = "";

        }

        protected void cmd_return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }



        protected void cmd_cedula_Click(object sender, EventArgs e)
        {
            //getlawyersdata("https://consultacorreoscabcr.azurewebsites.net/SVCCedula.svc/ConsultarAgremiadoXCedula/" + Txt_cedula.Text);
            agremiado agr = new agremiado();
            agr = agr.ConsultarAgremiadoXCedula(Txt_cedula.Text);
            getlawyersdata(agr);
        }

        protected void cmd_username_Click(object sender, EventArgs e)
        {
            //getlawyersdata("https://consultacorreoscabcr.azurewebsites.net/SVCUsuario.svc/ConsultarAgremiadoXUsuario/" + Txtusername.Text);
            agremiado agr = new agremiado();
            agr = agr.ConsultarAgremiadoXUsuario(Txtusername.Text);
            getlawyersdata(agr);
        }
    }
}