using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ws_portafolio.Controller;
using ws_portafolio.DataBase;
using ws_portafolio.Model;

namespace ws_portafolio
{
    /// <summary>
    /// Descripción breve de ws_portafolio_data
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_portafolio_data : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola Mundo";
        }

        [WebMethod]
        public RespuestaLenguajes getLenguajes()
        {
            string Response = string.Empty;
            
            if (!ConexionMysql.loadDBRegistry())
            {
                return new RespuestaLenguajes { nCodigoError = 0 , sCodigoError = "Servicio no disponible"};
            }
           
            return portafolioController.BuscarLenguajes();
        }

        [WebMethod]
        public RespuestaFrameworks getFramework()
        {
            if (!ConexionMysql.loadDBRegistry())
            {
                return new RespuestaFrameworks { nCodigoError = 0, sCodigoError = "Servcio no disponible" };
            }
            return portafolioController.BuscarFrameworks();
        }
    }
}
