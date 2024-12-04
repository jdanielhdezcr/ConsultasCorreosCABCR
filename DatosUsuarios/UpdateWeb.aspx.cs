using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatosUsuarios
{
    
    public partial class Updateweb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Haga clic en vaciar tabla para eliminar los datos";
            cmd_upload.Visible = false;
            Label1.Visible = false;
            FileUpload1.Visible = false;
        }

        protected void cmd_check_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["bdweb"].ConnectionString; //creamos un objeto tipo string, que obtiene la cadena de conexion definida en el archivo web.config
                using (MySqlConnection con = new MySqlConnection(cs)) //definimos una variable tipo conexion sql, que obtiene por parámetro la cadena de conexion
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM agremiados";
                    con.Open();
                    int respuesta = cmd.ExecuteNonQuery();
                    if (respuesta > 1)
                    {
                        Label1.Visible = true;
                        Label1.Text = respuesta + " filas borradas";
                        cmd_upload.Visible = true;
                        FileUpload1.Visible = true;
                        cmd_check.Visible = false;
                        Label2.Text = "Busque el archivo CSV para cargar la nueva base de datos";
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "no se borraron filas";
                        cmd_upload.Visible = true;
                        FileUpload1.Visible = true;
                        cmd_check.Visible = false;
                        Label2.Text = "Busque el archivo CSV para cargar la nueva base de datos";

                    }

                    con.Close();


                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void cmd_return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


        public void BulkInsert(string csvfile, string table, string fieldterminator, string lineterminator, int linestoskip)
        {
            string cs = ConfigurationManager.ConnectionStrings["bdweb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                var bl = new MySqlBulkLoader(con)
                {
                    TableName = table,
                    FieldTerminator = fieldterminator,
                    LineTerminator = lineterminator,
                    FileName = csvfile,
                    //Columns = { "codigo", "nombre", "apellido1", "apellido2", "tipo1", "tipo10", "tipo65", "direccion", "provincia", "canton", "distrito", "tel1", "tel2", "fax", "apartado", "cedula", "tipo_ced", "zona", "nacionalid", "nacimiento", "incorporad", "fallecido", "suspendido", "susp_hasta", "susp_tipo", "direcciofi", "provincofi", "cantonofi", "distritofi", "telofi1", "telofi2", "faxofi", "apartadofi", "celular1", "celular2", "email1", "email2", "email3", "sexo", "universida", "especialid", "especiali2", "especiali3", "observacio", "notas", "fec_reci", "pago_anu", "marcar", "cedula2", "monto", "suspenvolu", "suspenmoro" },
                };
                bl.Local = true;
                int respuesta = bl.Load();
                //MySqlCommand cmd = new MySqlCommand();
                //cmd.Connection = con;
                //cmd.CommandText = "LOAD DATA LOCAL INFILE '" + csvfile + "' INTO TABLE "+  table +" FIELDS TERMINATED BY "+'"'+fieldterminator+'"'+" LINES TERMINATED BY "+'"'+lineterminator+'"'+" (codigo,nombre,apellido1,apellido2,tipo1,tipo10,tipo65,direccion,provincia,canton,distrito,tel1,tel2,fax,apartado,cedula,tipo_ced,zona,nacionalid,nacimiento,incorporad,fallecido,suspendido,susp_hasta,susp_tipo,direcciofi,provincofi,cantonofi,distritofi,telofi1,telofi2,faxofi,apartadofi,celular1,celular2,email1,email2,email3,sexo,universida,especialid,especiali2,especiali3,observacio,notas,fec_reci,pago_anu,marcar,cedula2,monto,suspenvolu,suspenmoro)";
                //con.Open();
                //int respuesta=cmd.ExecuteNonQuery();
                if (respuesta > 1)
                {
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "Archivo cargado exitosamente. " + respuesta + " filas insertadas";
                    Label1.Font.Underline = true;
                    Label1.Font.Bold = true;
                    //ingresa un nuevo registro en el log de actualizaciones
                    string comm = "INSERT INTO UpdateLog VALUES('" + this.User.Identity.Name + "','SITIO WEB',SWITCHOFFSET(GETDATE(), '-06:00'))";
                    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(comm))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "no se insertaron filas";
                }
                con.Close();
            }
            catch (Exception e)
            {
                Label1.Text = "Error en la carga del archivo. Comunique este error al departamento técnico: " + e;
            }
        }


        //protected void cmd_find_Click(object sender, EventArgs e)
        //{




        //}

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Get the physical file system path for the currently
            // executing application.
            string appPath = Request.PhysicalApplicationPath;
            if (FileUpload1.HasFile)
            {



                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                string[] validFileTypes = { "csv" };
                string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                // Allow only files with .csv or .xls extensions
                // to be uploaded.

                bool isValidFile = false;

                for (int i = 0; i < validFileTypes.Length; i++)
                {

                    if (extension == "." + validFileTypes[i])

                    {

                        isValidFile = true;
                        string savePath = appPath +
                    Server.HtmlEncode(FileUpload1.FileName);
                        FileUpload1.SaveAs(savePath);
                        Label1.Text = "File Uploaded: " + savePath;
                        BulkInsert(savePath, "nuevo2_aboga.agremiados", ";", "\r\n", 0);

                        break;

                    }

                }

                if (!isValidFile)

                {

                    Label1.ForeColor = System.Drawing.Color.Red;

                    Label1.Text = "Archivo no válido. seleccione un archivo con extensión " +

                                   string.Join(",", validFileTypes);

                }

                //else

                //{

                //    Label1.ForeColor = System.Drawing.Color.Green;

                //    Label1.Text = ""++"";

                //}

            }
            else
            {
                Label1.Text = "No se seleccionó ningún archivo";
            }

        }
    }
}