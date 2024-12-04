using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de agremiado
/// </summary>
namespace SVCCertificaciones
{
    //definimos en esta clase el objeto certificacion, las propiedades y los metodos de construccion
    public class agremiado
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

    }
}
