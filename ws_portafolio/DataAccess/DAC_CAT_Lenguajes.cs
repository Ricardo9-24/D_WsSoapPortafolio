using MySql.Data.MySqlClient;
using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using ws_portafolio.Model;

namespace ws_portafolio.DataAccess
{
    public class DAC_CAT_Lenguajes
    {

        public RespuestaLenguajes ExecuteQuerySP()
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

        //MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Portafolio"].ConnectionString);
//        List<Lenguajes> ListLenguajes = new List<Lenguajes>();
//        RespuestaLenguajes oDatosLenguajes = new RespuestaLenguajes();
//        MySqlCommand dbCmd;
//        MySqlDataReader reader;

//        string sqlQuery = "CALL portafolio.sp_seleccionar_lenguajes();";

//        conn.Open();
//        dbCmd = new MySqlCommand(sqlQuery, conn);

//        IAsyncResult DBResult = dbCmd.BeginExecuteReader();
//        WaitHandle[] HandleResult = { DBResult.AsyncWaitHandle };
//        WaitHandle.WaitAny(HandleResult);
//        reader = dbCmd.EndExecuteReader(DBResult);

//        if (reader.HasRows)
//        {
//            while (reader.Read())
//            {
//                Lenguajes datosLenguajes = new Lenguajes();
//        datosLenguajes.nIdLenguaje = reader.GetInt32("nIdLenguaje");
//                datosLenguajes.sAbreviatura = reader.GetString("sAbreviatura");
//                datosLenguajes.sDescripcion = reader.GetString("sDescripcion");
//                datosLenguajes.sTipoDesarrollo = reader.GetString("sTipoDesarrollo");
//                datosLenguajes.sTipoLenguaje = reader.GetString("sTipoLenguaje");
//                ListLenguajes.Add(datosLenguajes);
//            }

//    oDatosLenguajes.ListLenguajes = ListLenguajes;
//            oDatosLenguajes.nCodigoError = 0;
//            oDatosLenguajes.sCodigoError = "Respuesta exitosa";
//        }
//conn.Close();
//    }
    }
}