using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ws_portafolio.DataAccess
{
    public class MysqlPortafolio
    {
        public static string CadenaConexion 
        {
            get { return  ConfigurationManager.ConnectionStrings["Portafolio"].ConnectionString; }
        }

    }
}