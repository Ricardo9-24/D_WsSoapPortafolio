using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_portafolio.Model
{
    public class RespuestaLenguajes
    {

        public int nCodigoError = 0;
        public string sCodigoError = string.Empty;
        public List<Lenguajes> ListLenguajes;
        
    }
    public class Lenguajes
    {
        public int nIdLenguaje = 0;
        public string sDescripcion = string.Empty;
        public string sAbreviatura = string.Empty;
        public string sTipoDesarrollo = string.Empty;
        public string sTipoLenguaje = string.Empty;
    }
}