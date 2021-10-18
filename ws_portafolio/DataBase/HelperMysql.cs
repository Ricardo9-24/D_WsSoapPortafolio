using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ws_portafolio.DataBase;
using System.Linq;
using System.Web;
using static ws_portafolio.DataBase.ConexionMysql;

namespace ws_portafolio.DataBase
{
    public class HelperMysql
    {
        
        public static DataTable ExecuteQuerySP(string storedProcedure, Dictionary<string, object> Parametros, string connStr)
        {
            MysqlConnex connex = new MysqlConnex();
            //string AccesosBD = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", connex.server, connex.user, connex.password, connex.database, "none");

            var cmd = ConnectionTools.conetarMysql(storedProcedure, CommandType.StoredProcedure, connStr);
            if (Parametros != null) cmd = AddParametros(cmd, Parametros);
            return ConnectionTools._getDataTable(cmd);
        }

        public static DataTable ExecuteQuerySP(string storeProcedure, string connStr)
        {
            return ConnectionTools._getDataTable(ConnectionTools.conetarMysql(storeProcedure, CommandType.StoredProcedure, connStr));
        }

        private static SqlCommand AddParametros(SqlCommand cmd, Dictionary<string, object> parametros)
        {

            foreach (var item in parametros)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            return cmd;
        }
    }
}