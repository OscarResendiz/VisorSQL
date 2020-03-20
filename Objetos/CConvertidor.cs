using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    /// <summary>
    /// Summary description for CConvertidor.
    /// </summary>
    public class CConvertidor
    {
        System.Collections.ArrayList lista;
        public CConvertidor()
        {
            //
            // TODO: Add constructor logic here
            //

            lista = new System.Collections.ArrayList();
            lista.Add(new CDato("bigint", "int", "System.Data.SqlDbType.BigInt"));
            lista.Add(new CDato("binary", "int", "System.Data.SqlDbType.Binary"));
            lista.Add(new CDato("bit", "bool", "System.Data.SqlDbType.Bit"));
            lista.Add(new CDato("char", "string", "System.Data.SqlDbType.Char"));
            lista.Add(new CDato("datetime", "System.DateTime", "System.Data.SqlDbType.DateTime"));
            lista.Add(new CDato("decimal", "float", "System.Data.SqlDbType.Decimal"));
            lista.Add(new CDato("float", "float", "System.Data.SqlDbType.Float"));
            lista.Add(new CDato("int", "int", "System.Data.SqlDbType.Int"));
            lista.Add(new CDato("money", "float", "System.Data.SqlDbType.Money"));
            lista.Add(new CDato("nchar", "string", "System.Data.SqlDbType.NChar"));
            lista.Add(new CDato("ntext", "string", "System.Data.SqlDbType.NText"));
            lista.Add(new CDato("numeric", "int", "System.Data.SqlDbType.Int"));
            lista.Add(new CDato("nvarchar", "string", "System.Data.SqlDbType.NVarChar"));
            lista.Add(new CDato("real", "float", "System.Data.SqlDbType.Real"));
            lista.Add(new CDato("smalldatetime", "System.DateTime", "System.Data.SqlDbType.SmallDateTime"));
            lista.Add(new CDato("smallint", "int", "System.Data.SqlDbType.SmallInt"));
            lista.Add(new CDato("smallmoney", "float", "System.Data.SqlDbType.SmallMoney"));
            lista.Add(new CDato("sysname", "string", "System.Data.SqlDbType.VarChar"));
            lista.Add(new CDato("text", "string", "System.Data.SqlDbType.Text"));
            lista.Add(new CDato("timestamp", "System.DateTime", "System.Data.SqlDbType.Timestamp"));
            lista.Add(new CDato("tinyint", "int", "System.Data.SqlDbType.TinyInt"));
            lista.Add(new CDato("varbinary", "int", "System.Data.SqlDbType.VarBinary"));
            lista.Add(new CDato("varchar", "string", "System.Data.SqlDbType.VarChar"));
            lista.Add(new CDato("System.Boolean", "bool", "System.Boolean"));

            lista.Add(new CDato("System.Int32", "int", "System.Data.SqlDbType.Int"));
            lista.Add(new CDato("System.String", "string", "System.Data.SqlDbType.VarChar"));
            lista.Add(new CDato("System.Decimal", "float", "System.Data.SqlDbType.Real"));
            lista.Add(new CDato("System.Double", "float", "System.Data.SqlDbType.Real"));
            lista.Add(new CDato("System.DateTime", "System.DateTime", "System.Data.SqlDbType.SmallDateTime"));

        }
        public string DameCadena(string tipo, string nombre)
        {
            int i, n;
            n = lista.Count;
            for (i = 0; i < n; i++)
            {
                CDato d = (CDato)lista[i];
                if (d.DatosSQL == tipo)
                {
                    return "\t\tpublic " + d.DatoC + " " + nombre + ";\r\n";
                }
            }
            return "//\t\tTipoDesconosido " + nombre + ";\r\n"; ;
        }
        public string DameTipo(string tipo)
        {
            int i, n;
            n = lista.Count;
            for (i = 0; i < n; i++)
            {
                CDato d = (CDato)lista[i];
                if (d.DatosSQL.ToUpper().Trim() == tipo.ToUpper().Trim())
                {
                    return d.DatoC;//+" "+nombre+";\r\n";
                }
            }
            return "TipoDesconosido ";//+nombre+";\r\n";;
        }
        public string DameTipoNet(string tipo)
        {
            int i, n;
            n = lista.Count;
            for (i = 0; i < n; i++)
            {
                CDato d = (CDato)lista[i];
                if (d.DatosSQL.ToUpper().Trim() == tipo.ToUpper().Trim())
                {
                    return d.DatoNET;//+" "+nombre+";\r\n";
                }
            }
            return "TipoDesconosido ";//+nombre+";\r\n";;
        }
    }
}
