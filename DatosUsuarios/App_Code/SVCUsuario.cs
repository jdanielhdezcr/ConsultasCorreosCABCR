using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Script.Services;
using System.ServiceModel.Activation;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.

namespace SVCCertificaciones {

    public class SVCUsuario : IService3 //el servicio se conecta con la interface. las funciones declaradas en el contrato se programan acá
    {
        public agremiado ConsultarAgremiadoXUsuario(string pUser) //la funcion que revisa la certificacion, y recibe un solo parámetro que es el codigo de certificacion
        {
            agremiado agr = new agremiado(); //definimos un objeto certificacion
            string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString; //creamos un objeto tipo string, que obtiene la cadena de conexion definida en el archivo web.config
            using (MySqlConnection con = new MySqlConnection(cs)) //definimos una variable tipo conexion sql, que obtiene por parámetro la cadena de conexion
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT carnet,user_name FROM users where user_name = '" + pUser + "'";
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    agr.Carnet = Convert.ToInt32(rdr["carnet"]);
                    agr.user_name = rdr["user_name"].ToString();
                    //certf.CodigoCert = rdr["CodigoCert"].ToString();

                }
                con.Close();
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = "select codigo,nombre,apellido1,apellido2,cedula,incorporad,tipo1 from LAWYERS where codigo= " + agr.Carnet;
                con.Open();
                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {

                    agr.nombre = rdr2["nombre"].ToString() + " " + rdr2["apellido1"].ToString() + " " + rdr2["apellido2"].ToString();
                    agr.cedula = rdr2["cedula"].ToString();
                    agr.fechainc = rdr2["incorporad"].ToString();
                    agr.condicionprof = Convert.ToInt32(rdr2["tipo1"]);
                    agr.codigo = rdr2["codigo"].ToString();
                    //certf.CodigoCert = rdr["CodigoCert"].ToString();

                }
                con.Close();
               

                return agr;
            }


        }
    }

}
