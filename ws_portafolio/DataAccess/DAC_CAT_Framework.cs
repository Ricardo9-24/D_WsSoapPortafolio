using System;
using System.Web;
using System.Linq;
using System.Threading;
using ws_portafolio.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using static ws_portafolio.Model.RespuestaFrameworks;

namespace ws_portafolio.DataAccess
{
    public class DAC_CAT_Framework
    {

        public RespuestaFrameworks getLenguajes()
        {
            MySqlDataReader reader;
            RespuestaFrameworks oRespFramework = new RespuestaFrameworks();
            List<Framework> nListFramework = new List<Framework>();
            string sQuerGetFramework = "sp_seleccionar_framework";
            try
            {            
                using (MySqlConnection conn = new MySqlConnection(MysqlPortafolio.CadenaConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sQuerGetFramework, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                                Framework frame = new Framework();
                                frame.nIdFramework = reader.GetInt32("nIdFramework");
                                frame.sNombre = reader.GetString("sNombre");
                                frame.sTipoFramework = reader.GetString("sTipoFramework");
                                frame.sArquitectura = reader.GetString("sArquitectura");
                                nListFramework.Add(frame);
                            }
                            conn.Close();
                            oRespFramework.nCodigoError = 0;
                            oRespFramework.sCodigoError = "Operacin exitosa";
                            oRespFramework.nListFrameworks = nListFramework;
                        }
                        else
                        {
                            oRespFramework.nCodigoError = 400;
                            oRespFramework.sCodigoError = "Operacion fallida";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oRespFramework.nCodigoError = 444;
                oRespFramework.sCodigoError = "Error inesperado" + ex.Message;
            }
            return oRespFramework;
        }
    }
}