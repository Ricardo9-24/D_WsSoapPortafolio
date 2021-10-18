using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_portafolio.Model
{
    public class RespuestaFrameworks
    {
        public string sCodigoError = string.Empty;
        public int nCodigoError = 0;
        public List<Framework> nListFrameworks;

        public class Framework
        {
            public int nIdFramework = 0;
            public string sNombre = string.Empty;
            public string sTipoFramework = string.Empty;
            public string sArquitectura = string.Empty;
        }
    }
}