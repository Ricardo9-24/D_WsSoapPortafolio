using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_portafolio.DataBase
{
    public class PoolConnectionParameters
    {
        /// <summary>
        /// Gets or sets the name of the parameter
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        public object ParameterValue { get; set; }

        /// <summary>
        /// Gets or sets the DbType of the parameter.
        /// </summary>
        public int? ParemeterDbType { get; set; }

        /// <summary>
        /// Gets or sets the direccion of the parameter
        /// </summary>
        public int? ParameterDirection { get; set; }
    }
}