using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ws_portafolio.DataBase.ConexionMysql;

namespace ws_portafolio.DataBase
{
    public class ConnectionTools
    {

        internal static SqlCommand conetarMysql(string text, CommandType type, string StringConexion)
        {
            SqlCommand Command;
            SqlConnection Connection = new SqlConnection(StringConexion);
            Command = new SqlCommand(text, Connection);
            Command.CommandType = type;
            return Command;
        }

        internal static DataTable _getDataTable(SqlCommand Command)
        {
            DataTable dt = new DataTable();
            try
            {
                Command.Connection.Open();
                SqlDataAdapter Adapter = new SqlDataAdapter();
                Adapter.SelectCommand = Command;
                Adapter.Fill(dt);
            }
            catch (Exception ex){ throw new Exception(ex.Message); }
            finally
            {
                Command.Connection.Dispose();
                Command.Dispose();
            }
            return dt;
        }
    }
}