using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    /// <summary>
    /// Summary description for CDato.
    /// </summary>
    public class CDato
    {
        public CDato(string sql, string equc, string Datonet)
        {
            //
            // TODO: Add constructor logic here
            //
            DatosSQL = sql;
            DatoC = equc;
            DatoNET = Datonet;
        }
        public string DatosSQL;
        public string DatoC;
        public string DatoNET;
    }
}
