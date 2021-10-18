using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Z.EntityFramework.Extensions;
using Microsoft.Extensions.DependencyModel;
using Newtonsoft.Json;
using System.Data;
using System.Configuration;
using System.Threading;
using ws_portafolio.Model;
using ws_portafolio.DataAccess;

namespace ws_portafolio.DataBase
{
    public class ConexionMysql
    {

        private RegistryKey registro = Registry.LocalMachine;
        private static string m_registryPath = "SOFTWARE\\Portafolio";


        //private static MySqlDatabase d_dataBase = new MySqlDataBase();

        public class MysqlConnex
        {
            public string server;
            public string user;
            public string password;
            public string database;
            //public int port;

            public string Host { get => server; set => server = value; }
            public string UserName { get => user; set => user = value; }
            public string Password { get => password; set => password = value; }
            public string DataBase { get => database; set => database = value; }
            //public int Port { get => port; set => port = value; }
        }

        public static bool loadDBRegistry()
        {
            if (string.IsNullOrEmpty(m_registryPath))
            {
                throw new Exception("No se encontro la ruta del registry");
                return false;
            }

            //Abrir el registro
            RegistryKey Registro = Registry.LocalMachine;
            RegistryKey PCRegistry;

            try
            {
                PCRegistry = Registro.OpenSubKey(m_registryPath + "\\Database");
                string[] PCRegistro = Registro.GetSubKeyNames();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los strings de conexion");
                return false;
            }

            if (PCRegistry == null)
            {
                throw new Exception("No se encontraron los acesos a la base de datos");
                return false;
            }

            MysqlConnex DBbases = new MysqlConnex();
            DBbases.server = (string)PCRegistry.GetValue("dbHost"); 
            //DBbases.port = Int32.Parse((string)PCRegistry.GetValue("dbPort"));
            DBbases.user = (string)PCRegistry.GetValue("dbUser");
            DBbases.password = (string)PCRegistry.GetValue("dbPassword");
            DBbases.database = (string)PCRegistry.GetValue("dbBase");

            return true;
        }

        public DataTable ExecuteQuerySP(JsonArrayAttribute parametros)
        {
            MysqlConnex DBbases = new MysqlConnex();
            string AccesosBD = String.Format("server={0};user id={1}; password={2}; database={3}; SslMode={4}", DBbases.server, DBbases.user, DBbases.password, DBbases.database, "none");
            //List<object> ojParama = new List<object>();
            string ojParama = JsonConvert.SerializeObject(parametros);
            MySqlCommand dbCmd;
            MySqlDataReader reader;
            DataTable respLenguajes = new DataTable();

            string sqlQuery = "sp_seleccionar_lenguajes";

            try
            {
                var prm = new List<PoolConnectionParameters>();
                prm.Add(new PoolConnectionParameters { ParameterName = "@" + "sLenguaje", ParameterValue = "DDD" });
                Dictionary<string, object> listParametros = new Dictionary<string, object>();
                //listParametros.Add("sLenguaje", "sdddd");
                respLenguajes = HelperMysql.ExecuteQuerySP(sqlQuery, listParametros, AccesosBD);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return respLenguajes;
        }
        public RespuestaLenguajes ExecuteQuerySPSin()
        {
            MySqlDataReader reader;
            List<Lenguajes> ListLenguajes = new List<Lenguajes>();
            RespuestaLenguajes oDatosLenguajes = new RespuestaLenguajes();
            string sqlQueryGetLenguajes = "sp_seleccionar_lenguajes";
            //string sqlQueryGetLenguajes = "CALL `portafolio`.`sp_seleccionar_lenguajes`();";
            using (MySqlConnection conn = new MySqlConnection(MysqlPortafolio.CadenaConexion))
            {
                using (MySqlCommand cmd = new MySqlCommand(sqlQueryGetLenguajes, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@nIdLenguaje", int, 1);
                    conn.Open();
                    if (cmd.Parameters.Count > 0)
                    {
                        //foreach (var item in cmd.Parameters)
                        //{

                        //}
                    }
                    IAsyncResult DBResult = cmd.BeginExecuteReader();
                    WaitHandle[] HandleResult = { DBResult.AsyncWaitHandle };
                    WaitHandle.WaitAny(HandleResult);
                    reader = cmd.EndExecuteReader(DBResult);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Lenguajes datosLenguajes = new Lenguajes();
                            datosLenguajes.nIdLenguaje = reader.GetInt32("nIdLenguaje");
                            datosLenguajes.sAbreviatura = reader.GetString("sAbreviatura");
                            datosLenguajes.sDescripcion = reader.GetString("sDescripcion");
                            datosLenguajes.sTipoDesarrollo = reader.GetString("sTipoDesarrollo");
                            datosLenguajes.sTipoLenguaje = reader.GetString("sTipoLenguaje");
                            ListLenguajes.Add(datosLenguajes);
                        }
                        oDatosLenguajes.ListLenguajes = ListLenguajes;
                        oDatosLenguajes.nCodigoError = 0;
                        oDatosLenguajes.sCodigoError = "Respuesta exitosa";
                    }
                    conn.Close();
                    
                }
            }



            return oDatosLenguajes;
        }
    }
}