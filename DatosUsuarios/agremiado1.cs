using MySql.Data.MySqlClient;
using System.Configuration;
using System;

namespace DatosUsuarios
{
    internal class agremiado
    {
        public int Carnet { get; set; } //tiene una propiedad carnet, en formato entero, que sera uno de los valores que se obtendrán de la consulta
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string fechainc { get; set; }
        public int condicionprof { get; set; }
        public string suspvol { get; set; }
        public string suspmoro { get; set; }
        public string user_name { get; set; } //segunda propiedad es la cedula del agremiado
        public string codigo { get; set; }
        public agremiado ConsultarAgremiado(string pCarne) //la funcion que revisa la certificacion, y recibe un solo parámetro que es el codigo de certificacion
        {
            agremiado agr = new agremiado(); //definimos un objeto certificacion
            string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString; //creamos un objeto tipo string, que obtiene la cadena de conexion definida en el archivo web.config
            using (MySqlConnection con = new MySqlConnection(cs)) //definimos una variable tipo conexion sql, que obtiene por parámetro la cadena de conexion
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT carnet,user_name FROM users where carnet = '" + pCarne + "'";
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
                cmd2.CommandText = "select codigo,nombre,apellido1,apellido2,cedula,incorporad,tipo1 from LAWYERS where codigo= '" + pCarne + "'";
                con.Open();
                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {

                    agr.nombre = rdr2["nombre"].ToString() + " " + rdr2["apellido1"].ToString() + " " + rdr2["apellido2"].ToString();
                    agr.cedula = rdr2["cedula"].ToString();
                    agr.fechainc = rdr2["incorporad"].ToString();
                    agr.condicionprof = Convert.ToInt32(rdr2["tipo1"]);
                    //certf.CodigoCert = rdr["CodigoCert"].ToString();

                }
                con.Close();

                return agr;
            }


        }
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
 

    public agremiado ConsultarAgremiadoXCedula(string pCedula) //la funcion que revisa la certificacion, y recibe un solo parámetro que es el codigo de certificacion
    {
        agremiado agr = new agremiado(); //definimos un objeto certificacion
        string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString; //creamos un objeto tipo string, que obtiene la cadena de conexion definida en el archivo web.config
        using (MySqlConnection con = new MySqlConnection(cs)) //definimos una variable tipo conexion sql, que obtiene por parámetro la cadena de conexion
        {

            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "select codigo,nombre,apellido1,apellido2,cedula,incorporad,tipo1 from LAWYERS where cedula= " + pCedula;
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
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT carnet,user_name FROM users where carnet = '" + agr.codigo + "'";
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                agr.Carnet = Convert.ToInt32(rdr["carnet"]);
                agr.user_name = rdr["user_name"].ToString();
                //certf.CodigoCert = rdr["CodigoCert"].ToString();

            }
            con.Close();

            return agr;
        }


    }
    }
}

