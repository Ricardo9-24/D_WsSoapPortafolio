//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ws_portafolio.Model;
using ws_portafolio.DataBase;
using System.Web.Services;
using ws_portafolio.Controller;
using ws_portafolio.DataAccess;

namespace ws_portafolio.Controller
{
    public class portafolioController
    {

        public static RespuestaLenguajes BuscarLenguajes()
        {
            RespuestaLenguajes oRespLenguajes = new RespuestaLenguajes();
            ConexionMysql buscarLenguajes = new ConexionMysql();

            Dictionary<string, object> listParametros = new Dictionary<string, object>();
            return buscarLenguajes.ExecuteQuerySPSin();

        }

        public static RespuestaFrameworks BuscarFrameworks()
        {
            DAC_CAT_Framework buscarFramework = new DAC_CAT_Framework();
            return buscarFramework.getLenguajes();
        }

    }
}