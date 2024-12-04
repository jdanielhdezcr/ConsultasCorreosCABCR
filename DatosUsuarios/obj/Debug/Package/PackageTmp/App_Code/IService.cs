using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
namespace SVCCertificaciones {
    [ServiceContract] //el contrato de servicio define los procedimientos o funciones que llamará el servicio. si en el servicio se programan 3 funciones, 
    //en el contrato deben declararse las 3 funciones para que sean consumidas por el sitio web
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/ConsultarAgremiado/{pCarne}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        agremiado ConsultarAgremiado(string pCarne);
        
    }


}