using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace Visor_sql_2015.Controladores_DB
{
    public class MySqlServer : IDataBase 
    {
        private MySqlException MensajeErrorSQL;
        private MySql.Data.MySqlClient.MySqlConnectionStringBuilder ConnectionStringBuilder;
        private CNodoTabla Tablas=null;
        private bool _isExecuting;
        private DateTime Inicio, Fin;
        private MySqlCommand Command;
        private MySqlConnection Conexion = null;
        private Editor.CErrorQuery FMensajeError;
        private int _TimeOut;
        private DataSet FResults;
        #region Eventos
        public event ProcessingQuery EndingQuery;
        public event ProcessingQuery BeginningQuery;
        #endregion
        public MySqlServer()
        {
            ConnectionStringBuilder = new MySqlConnectionStringBuilder();
        }
        public bool EnEjecucion
        {
            get
            {
                return _isExecuting;
            }
        }
        public DataSet Results
        {
            get
            {
                return FResults;
            }
            set
            {
                FResults = value;
            }
        }
        public string TiempoEjecucion
        {
            get
            {
                string second, minute, hour, miliseg;
                TimeSpan X;
                try
                {
                    X = Fin.Subtract(Inicio);

                    hour = X.Hours > 9 ? X.Hours.ToString() : "0" + X.Hours.ToString();
                    minute = X.Minutes > 9 ? X.Minutes.ToString() : "0" + X.Minutes.ToString();
                    second = X.Seconds > 9 ? X.Seconds.ToString() : "0" + X.Seconds.ToString();

                    if (X.Milliseconds > 9)
                    {
                        if (X.Milliseconds > 99)
                        {
                            miliseg = X.Milliseconds.ToString();
                        }
                        else
                        {
                            miliseg = "0" + X.Milliseconds.ToString();
                        }
                    }
                    else
                    {
                        miliseg = "00" + X.Milliseconds.ToString();
                    }

                }
                catch (Exception)
                {
                    hour = "00";
                    minute = "00";
                    second = "00";
                    miliseg = "000";
                }
                return hour + ":" + minute + ":" + second + "." + miliseg;
            }
        }
        public int TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }
        public Editor.CErrorQuery MensajeError
        {
            get
            {
                return FMensajeError;
            }
        }
        public string Error
        {
            get
            {
                return MensajeError + " -- " + TiempoEjecucion;
            }
            set
            {
                if (FMensajeError == null)
                    FMensajeError = new Editor.CErrorQuery();
                FMensajeError.msg = value;
            }
        }
        public string ConnectionString
        {
            get
            {
                return ConnectionStringBuilder.ConnectionString;
            }
            set
            {
                ConnectionStringBuilder.ConnectionString = value;
            }
        }
        public string BDName
        {
            get
            {
                return ConnectionStringBuilder.Database;
            }
            set
            {
                //no hace nada por ahorita
                ConnectionStringBuilder.Database = value;
            }
        }
        public string Servidor
        {
            get
            {
                return ConnectionStringBuilder.Server;
            }
            set
            {
                //hay que implementarlo
                ConnectionStringBuilder.Server = value;
            }
        }
        public string User
        {
            get
            {
                return ConnectionStringBuilder.UserID;
            }
            set
            {
                ConnectionStringBuilder.UserID = value;
            }
        }
        public string Password
        {
            get
            {
                return ConnectionStringBuilder.Password;
            }
            set
            {
                ConnectionStringBuilder.Password = value;
            }
        }
        public bool PruebaConexion()
        {
            try
            {
                if (Conexion == null)
                {
                    this.Conexion = new MySqlConnection();
                }
                AbreConexion();

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Conexion.Close();
            return true;
        }
        public CNodoTabla BuscaEnTabla(string nombre)
        {
            CNodoTabla nt = Tablas.BuscaTabla(nombre);
            if (nt == null)
            {
                //no se encontro, por lo que busco en la base de datos
                List<Objetos.CParametro> l2;
                List<Objetos.CSysObject> l;
                l = this.BuscaObjetos(nombre, TIPOOBJETO.TABLAX);
                if (l.Count == 0)
                {
                    //no era tabla 
                    //Quisas sea una vista
                    l = BuscaObjetos(nombre, TIPOOBJETO.VISTA);
                    if (l.Count == 0)
                        return null;
                    if (l[0].Nombre.ToLower().Trim() == nombre.ToLower().Trim())
                    {
                        l2 = this.DameCamposTabla(nombre);
                        Tablas.AddTabla(nombre, l2);
                        return Tablas.BuscaTabla(nombre);
                    }
                }
                if (l[0].Nombre.ToLower().Trim() == nombre.ToLower().Trim())
                {
                    l2 = this.DameCamposTabla(nombre);
                    Tablas.AddTabla(nombre, l2);
                    return Tablas.BuscaTabla(nombre);
                }
            }
            return nt;
        }
        public System.Collections.Generic.List<Objetos.CSysObject> BuscaObjetos(string nombre, TIPOOBJETO tipo)
        {
            if (isExecuting)
                return new List<Objetos.CSysObject>();
            string comando = "";
            System.Collections.Generic.List<Objetos.CSysObject> lista = new System.Collections.Generic.List<Objetos.CSysObject>();
            switch (tipo)
            {
                case TIPOOBJETO.NINGUNO: //Todos
                    //comando = "select table_name as NAME,table_type as XTYPE from information_schema.tables where table_name like \'" + nombre.Trim() + "%\' and table_schema=\'" + Conexion.Database + "\'";
                    comando = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + Conexion.Database + "' and ROUTINE_NAME like '" + nombre.Trim() + "%'\n";
                    comando = comando + "union all\n";
                    comando = comando + "select table_NAME as NAME,TABLE_TYPE as XTYPE from information_schema.tables where table_SCHEMA='" + Conexion.Database + "' and table_NAME like '" + nombre.Trim() + "%'\n";
                    comando = comando + "order by name";
                    break;
                case TIPOOBJETO.TABLAX://tablas
                    comando = "select table_name as NAME,table_type as XTYPE from information_schema.tables where table_type=\'BASE TABLE\' and table_name like \'" + nombre.Trim() + "%\' and table_schema=\'" + Conexion.Database + "\';";
                    break;
                case TIPOOBJETO.VISTAS_TABLAS://tablas
                    comando = "select table_name as NAME,table_type as XTYPE from information_schema.tables where (table_type=\'BASE TABLE\' or table_type=\'VIEW\' )and table_name like \'" + nombre.Trim() + "%\' and table_schema=\'" + Conexion.Database + "\';";
                    break;
                case TIPOOBJETO.VISTA:
                    comando = "select table_name as NAME,\'V\' as XTYPE from information_schema.tables where table_type=\'VIEW\' and table_schema=\'" + Conexion.Database + "\' and table_name like \'" + nombre.Trim() + "%\'";
                    break;
                case TIPOOBJETO.STOREPROCERURE:
                    comando = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + Conexion.Database + "' and ROUTINE_NAME like '" + nombre + "%' and ROUTINE_TYPE='PROCEDURE'";
                    break;
                case TIPOOBJETO.FUNCTION:
                    comando = "select ROUTINE_NAME as NAME,ROUTINE_TYPE as XTYPE from information_schema.routines where ROUTINE_SCHEMA='" + Conexion.Database + "' and ROUTINE_NAME like '" + nombre + "%' and ROUTINE_TYPE='FUNCTION'";
                    break;
                case TIPOOBJETO.FOREINGKEY:
                    comando = "select NAME,XTYPE from sysobjects WHERE XTYPE=\'F\' and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.PRIMARYKEY:
                    comando = "select NAME,XTYPE from sysobjects WHERE XTYPE=\'PK\' and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.TABLASYSTEMA:
                    comando = "select NAME,XTYPE from sysobjects WHERE XTYPE=\'S\' and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.TRIGER:
                    comando = "select NAME,XTYPE from sysobjects WHERE XTYPE=\'TR\' and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.EN_CODIGO:
                    if (nombre.Trim() == "")
                        return lista;
                    return BuscaEnCodigo(nombre);
                    //comando = "select distinct NAME,XTYPE from sysobjects where id in(select id from syscomments where text like \'%" + nombre.Trim() + "%\')";
                    break;
                case TIPOOBJETO.CAMPOS_TABLA:
                    //se trae todas las tablas que tienen el campo que busco
                    //comando = "SELECT s2.* FROM syscolumns s,sysobjects s2 WHERE s2.id=s.id AND s.[name]=\'"+nombre.Trim()+"\'";
                    comando = "select distinct\n";
                    comando = comando + "		b.TABLE_NAME as NAME,\n";
                    comando = comando + "		b.TABLE_TYPE as XTYPE\n";
                    comando = comando + "from \n";
                    comando = comando + "	information_schema.columns a,\n";
                    comando = comando + "	information_schema.tables b\n";
                    comando = comando + "where \n";
                    comando = comando + "	a.TABLE_SCHEMA='" + Conexion.Database + "' \n";
                    comando = comando + "	and a.COLUMN_NAME like '" + nombre.Trim() + "%'\n";
                    comando = comando + "	and b.TABLE_SCHEMA=a.TABLE_SCHEMA\n";
                    comando = comando + "	and b.TABLE_NAME=a.TABLE_NAME\n";
                    break;
            }
            try
            {
                //RECUPERANDO DATOS
                MySqlDataReader dr;
                dr = ExecuteReader(comando);
                while (dr.Read())
                {
                    Objetos.CSysObject objeto = new Objetos.CSysObject();
                    string XTYPE = "";//dr["XTYPE"].ToString().ToUpper().Trim();
                    objeto.Nombre = dr["NAME"].ToString();
                    XTYPE = DameTypo(dr["XTYPE"].ToString().ToUpper().Trim());
                    objeto.TipoObjeto = TIPOOBJETO.NINGUNO;
                    //string XTYPE = dr["XTYPE"].ToString().ToUpper().Trim();
                    if (XTYPE == "U")
                        objeto.TipoObjeto = TIPOOBJETO.TABLAX;
                    else if (XTYPE == "V")
                        objeto.TipoObjeto = TIPOOBJETO.VISTA;
                    else if (XTYPE == "P" )
                        objeto.TipoObjeto = TIPOOBJETO.STOREPROCERURE;
                    else if (XTYPE == "TR")
                        objeto.TipoObjeto = TIPOOBJETO.TRIGER;
                    else if (XTYPE == "F")
                        objeto.TipoObjeto = TIPOOBJETO.FOREINGKEY;
                    else if (XTYPE == "PK")
                        objeto.TipoObjeto = TIPOOBJETO.PRIMARYKEY;
                    else if (XTYPE == "S")
                        objeto.TipoObjeto = TIPOOBJETO.TABLASYSTEMA;
                    else if (XTYPE == "FN")
                        objeto.TipoObjeto = TIPOOBJETO.FUNCTION;

                    lista.Add(objeto);
                }
            }
            catch (System.Exception ex)
            {

                CierraConexion();
                throw new Exception(ex.Message);
            }
            CierraConexion();
            return lista;
        }
        private void CierraConexion()
        {
            Conexion.Close();
        }
        public Objetos.CSysObject DameTablaVista(string nombre)
        {
            if (isExecuting)
                return null;
            string comando = "";
            comando = "select table_name as NAME,table_type as XTYPE from information_schema.tables where (table_type=\'BASE TABLE\' or table_type=\'VIEW\' )and table_name = \'" + nombre.Trim() + "\' and table_schema=\'" + Conexion.Database + "\';";
            try
            {
                //RECUPERANDO DATOS
                MySqlDataReader dr;
                dr = ExecuteReader(comando);
                if (dr.Read())
                {
                    Objetos.CSysObject objeto = new Objetos.CSysObject();
                    objeto.Nombre = dr["NAME"].ToString();
                    objeto.TipoObjeto = TIPOOBJETO.NINGUNO;
                    string XTYPE = DameTypo(dr["XTYPE"].ToString().ToUpper().Trim());
                    if (XTYPE == "U")
                        objeto.TipoObjeto = TIPOOBJETO.TABLAX;
                    else if (XTYPE == "V")
                        objeto.TipoObjeto = TIPOOBJETO.VISTA;
                    else if (XTYPE == "P" || XTYPE == "FN")
                        objeto.TipoObjeto = TIPOOBJETO.STOREPROCERURE;
                    else if (XTYPE == "TR")
                        objeto.TipoObjeto = TIPOOBJETO.TRIGER;
                    else if (XTYPE == "F")
                        objeto.TipoObjeto = TIPOOBJETO.FOREINGKEY;
                    else if (XTYPE == "PK")
                        objeto.TipoObjeto = TIPOOBJETO.PRIMARYKEY;
                    else if (XTYPE == "S")
                        objeto.TipoObjeto = TIPOOBJETO.TABLASYSTEMA;
                    return objeto;
                }
            }
            catch (System.Exception ex)
            {
                CierraConexion();
                throw new Exception(ex.Message);
            }
            CierraConexion();
            return null;
        }
        public System.Collections.Generic.List<Objetos.CParametro> DameCamposTabla(string nombre)
        {
            if (nombre == "")
            {
                return new List<Objetos.CParametro>();
            }
            System.Collections.Generic.List<Objetos.CParametro> CamposTabla = new List<Objetos.CParametro>();
            string s = "describe " + nombre + ";";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            Objetos.CParametro Parametro;
            Objetos.CConvertidor cv = new Objetos.CConvertidor();
            while (dr.Read())
            {
                Parametro = new Objetos.CParametro();
                Parametro.nombre = dr["Field"].ToString();
                Parametro.NULOS = dr["Null"].ToString();
                Parametro.tipo = dr["Type"].ToString();
                Parametro.Logitud = DameLongitud(dr["Type"].ToString());
                Parametro.iscomputed = 0;
                Parametro.collation = "";
                Parametro.TipoNet = cv.DameTipo(Parametro.tipo);
                CamposTabla.Add(Parametro);
            }
            CierraConexion();
            //ahora veo cuales son llaves primarias
            List<Objetos.CParametro> l = DameLLavesPrimarias(nombre);
            foreach (Objetos.CParametro obj in CamposTabla)
            {
                foreach (Objetos.CParametro obj2 in l)
                {
                    if (obj.nombre == obj2.nombre)
                    {
                        //si es clave primaria
                        obj.LLavePrimaria = true;
                        break;
                    }
                }
            }
            return CamposTabla;
        }
        public System.Collections.Generic.List<Objetos.CParametro> DameCamposTabla(string nombre, string campo)
        {
            System.Collections.Generic.List<Objetos.CParametro> CamposTabla = new List<Objetos.CParametro>();
            string s = "select \n";
            s = s + "	COLUMN_NAME as COLUMNA,\n";
            s = s + "	DATA_TYPE as TIPO,\n";
            s = s + "	CHARACTER_MAXIMUM_LENGTH as LONGUTUD,\n";
            s = s + "	0 as iscomputed,\n";
            s = s + "	case IS_NULLABLE when 'YES' then 'si' else 'no' end as NULOS,\n";
            s = s + "	COLLATION_NAME as collation\n";
            s = s + "from \n";
            s = s + "    information_schema.columns\n";
            s = s + "where \n";
            s = s + "    table_schema='" + Conexion.Database + "' \n";
            s = s + "    and table_name='" + nombre + "'\n";
            s = s + "and COLUMN_NAME like '" + campo + "%'\n";
            s = s + "order by \n";
            s = s + "	ORDINAL_POSITION\n";
            s = s + "\n";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            Objetos.CParametro Parametro;
            Objetos.CConvertidor cv = new Objetos.CConvertidor();
            while (dr.Read())
            {
                Parametro = new Objetos.CParametro();
                Parametro.nombre = dr["COLUMNA"].ToString();
                Parametro.NULOS = dr["NULOS"].ToString();
                Parametro.tipo = dr["TIPO"].ToString();
                if (dr["LONGUTUD"].ToString() != "")
                {
                    Parametro.Logitud = int.Parse(dr["LONGUTUD"].ToString());
                }
                else
                {
                    Parametro.Logitud = 0;
                }
                Parametro.iscomputed = int.Parse(dr["iscomputed"].ToString());
                Parametro.collation = dr["collation"].ToString();
                Parametro.TipoNet = cv.DameTipo(Parametro.tipo);
                CamposTabla.Add(Parametro);
            }
            CierraConexion();
            //ahora veo cuales son llaves primarias
            List<Objetos.CParametro> l = DameLLavesPrimarias(nombre);
            foreach (Objetos.CParametro obj in CamposTabla)
            {
                foreach (Objetos.CParametro obj2 in l)
                {
                    if (obj.nombre == obj2.nombre)
                    {
                        //si es clave primaria
                        obj.LLavePrimaria = true;
                        break;
                    }
                }
            }
            return CamposTabla;
        }
        public string DameCodigo(string nombre)
        {
            string campo = "";
            if (nombre == "")
                return "";
            string s = "";
            //aqui hay que modificar para que vea si es un SP o una vista ya que se requieren consultas diferentes en cada caso
            if (EsVista(nombre) == true)
            {
                //es una vista
                s= "show create view " + nombre + "";
                campo = "Create View";
            }
            else if (EsFuncion(nombre) == true)
            {
                s= "show create function " + nombre + "";
                campo = "Create function";
            }
            else
            {
                //es un procedimiento almacenado
                s= "show create procedure " + nombre + "";
                campo = "Create Procedure";
            }
            MySqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
            }
            catch (MySqlException ex)
            {
                CierraConexion();
                return "";
            }
            s = "";
            while (dr.Read())
            {
                s = s + dr[campo].ToString().Replace('�', 'ñ'); ;
            }
            CierraConexion();
            return s;
        }
        public string CreaCodigoTabla(string nombre)
        {
            string s = "select\n";
            s = s + "	column_name as COLUMNA,\n";
            s = s + "	data_type as TIPO,\n";
            s = s + "	case isnull(character_maximum_length) when 1 then 0 else character_maximum_length end as longitud,\n";
            s = s + "	case is_nullable when 'YES' then 'SI' else 'NO' end as NULOS \n";
            s = s + "from \n";
            s = s + "	information_schema.columns \n";
            s = s + "where \n";
            s = s + "	table_schema='" + Conexion.Database + "' \n";
            s = s + "	and table_name='" + nombre + "';\n";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            s = "using System;\r\n";
            s = s + "namespace //namespace\r\n";
            s = s + "{\r\n";
            s = s + "\t/// <summary>\r\n";
            s = s + "\t/// Summary description for " + nombre + ".\r\n";
            s = s + "\t/// </summary>\r\n";
            s = s + "\tpublic class " + nombre + "\r\n";
            s = s + "\t{\r\n";
            s = s + "\t\tpublic " + nombre + "()\r\n";
            s = s + "\t\t{\r\n";
            s = s + "\t\t//\r\n";
            s = s + "\t\t// TODO: Add constructor logic here\r\n";
            s = s + "\t\t//\r\n";
            s = s + "\t\t}\r\n";
            Objetos.CConvertidor conv = new Objetos.CConvertidor();
            while (dr.Read())
            {
                s = s + conv.DameCadena(dr["TIPO"].ToString(), dr["COLUMNA"].ToString());
            }
            s = s + "\t}\r\n";
            s = s + "}\r\n";
            CierraConexion();
            return s;
        }
        public System.Collections.Generic.List<Objetos.CParametro> DameLLavesPrimarias(string nombre)
        {
            //regresa los campos que forman la yave primaria
            System.Collections.Generic.List<Objetos.CParametro> CamposTabla;
            string s = "describe " + nombre;
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            CamposTabla = new System.Collections.Generic.List<Objetos.CParametro>();
            Objetos.CParametro Parametro;
            Objetos.CConvertidor cv = new Objetos.CConvertidor();
            while (dr.Read())
            {
                if (dr["KEY"].ToString().ToUpper() == "PRI")
                {
                    Parametro = new Objetos.CParametro();
                    Parametro.nombre = dr["Field"].ToString();
                    Parametro.tipo = dr["Type"].ToString();
                    Parametro.Logitud = DameLongitud(Parametro.tipo);
                    Parametro.TipoNet = cv.DameTipo(Parametro.tipo);
                    CamposTabla.Add(Parametro);
                }
            }
            CierraConexion();
            return CamposTabla;
        }
        public System.Collections.Generic.List<Objetos.CLLaveForanea> DameLLavesForaneas(string tabla)
        {
            System.Collections.Generic.List<Objetos.CLLaveForanea> lista = new System.Collections.Generic.List<Objetos.CLLaveForanea>();
            string s = "select distinct constraint_name as name,0 as id from information_schema.KEY_COLUMN_USAGE where table_schema='" + Conexion.Database + "' and constraint_name<>'PRIMARY'and table_name='" + tabla + "'";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            lista = new System.Collections.Generic.List<Objetos.CLLaveForanea>();
            Objetos.CLLaveForanea LLaveForanea;
            while (dr.Read())
            {
                LLaveForanea = new Objetos.CLLaveForanea();
                LLaveForanea.name = dr["name"].ToString();
                LLaveForanea.id = int.Parse(dr["id"].ToString());
                lista.Add(LLaveForanea);
            }
            CierraConexion();
            return lista;
        }
        public System.Collections.Generic.List<Objetos.CLLaveForanea> DameLLavesForaneasHijas(string tabla)
        {
            System.Collections.Generic.List<Objetos.CLLaveForanea> lista = new System.Collections.Generic.List<Objetos.CLLaveForanea>();
            string s = "select distinct CONSTRAINT_NAME as name,0 as id from information_schema.KEY_COLUMN_USAGE where CONSTRAINT_SCHEMA='" + Conexion.Database + "' and REFERENCED_TABLE_NAME='" + tabla + "'";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            lista = new System.Collections.Generic.List<Objetos.CLLaveForanea>();
            Objetos.CLLaveForanea LLaveForanea;
            while (dr.Read())
            {
                LLaveForanea = new Objetos.CLLaveForanea();
                LLaveForanea.name = dr["name"].ToString();
                LLaveForanea.id = int.Parse(dr["id"].ToString());
                lista.Add(LLaveForanea);
            }
            CierraConexion();
            return lista;
        }
        public System.Collections.Generic.List<Objetos.CCampoFK> DameCamposFK(string nombre)
        {
            System.Collections.Generic.List<Objetos.CCampoFK> lista = new System.Collections.Generic.List<Objetos.CCampoFK>();
            string s = "select table_name as hija ,column_name as columnahija,referenced_table_name as maestra,referenced_column_name as columnaMaestra from information_schema.KEY_COLUMN_USAGE where table_schema='" + Conexion.Database + "' and constraint_name='" + nombre + "'";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            lista = new System.Collections.Generic.List<Objetos.CCampoFK>();
            Objetos.CCampoFK CampoFK;
            while (dr.Read())
            {
                CampoFK = new Objetos.CCampoFK();
                CampoFK.columnahija = dr["columnahija"].ToString();
                CampoFK.columnaMaestra = dr["columnaMaestra"].ToString();
                CampoFK.maestra = dr["maestra"].ToString();
                CampoFK.hija = dr["hija"].ToString();
                lista.Add(CampoFK);
            }
            CierraConexion();
            return lista;
        }
        public System.Collections.Generic.List<Objetos.CParametro> DameParametrosDeProcedimiento(string nombre)
        {
            string s = "select \n";
            s = s + "	PARAMETER_NAME as COLUMNA,\n";
            s = s + "	DATA_TYPE as TIPO, \n";
            s = s + "	CHARACTER_MAXIMUM_LENGTH as LONGITUD,\n";
            s = s + "	'NO' as NULOS \n";
            s = s + "from \n";
            s = s + "	information_schema.parameters \n";
            s = s + "where \n";
            s = s + "	SPECIFIC_SCHEMA='" + Conexion.Database + "' \n";
            s = s + "	and SPECIFIC_NAME='" + nombre + "'\n";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            Objetos.CConvertidor conv = new Objetos.CConvertidor();
            System.Collections.Generic.List<Objetos.CParametro> lista = new System.Collections.Generic.List<Objetos.CParametro>();
            while (dr.Read())
            {
                Objetos.CParametro pa = new Objetos.CParametro();
                pa.tipo = conv.DameTipo(dr["TIPO"].ToString());
                pa.TipoNet = conv.DameTipoNet(dr["TIPO"].ToString());
                pa.nombre = dr["COLUMNA"].ToString();
                if (dr["LONGITUD"].ToString() != "")
                {
                    pa.Logitud = int.Parse(dr["LONGITUD"].ToString());
                }
                else
                {
                    pa.Logitud = 0;
                }
                lista.Add(pa);
            }
            CierraConexion();
            return lista;
        }
        public System.Collections.Generic.List<Objetos.CSysObject> DameDependencias(string Nombre)
        {
            return DameHijosDe(Nombre);
        }
        public System.Collections.Generic.List<Objetos.CSysObject> DameDependientesDe(string Nombre)
        {
            System.Collections.Generic.List<Objetos.CSysObject> lista = new System.Collections.Generic.List<Objetos.CSysObject>();
            string s = "declare @tabla sysname\r\n";
            s = s + "select @tabla=\'" + Nombre + "\'\r\n";
            s = s + "declare @idtabla int\r\n";
            s = s + "declare @tipo char(1)\r\n";
            s = s + "select @idtabla=id,@tipo=xtype from sysobjects where name=@tabla\r\n";
            s = s + "if(@tipo='P')\r\n";
            s = s + "\tselect * from sysobjects  where id in(select id from sysdepends where depid=@idtabla) order by name\r\n";
            s = s + "else\r\n";
            s = s + "select * from sysobjects  where id in(select depid from sysdepends where id=@idtabla)\r\n";
            s = s + "union\r\n";
            s = s + "select * from sysobjects where id in( select rkeyid from sysforeignkeys where  fkeyid=@idtabla)\r\n";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            while (dr.Read())
            {
                Objetos.CSysObject objeto = new Objetos.CSysObject();
                objeto.Nombre = dr["NAME"].ToString();
                objeto.TipoObjeto = TIPOOBJETO.NINGUNO;
                string XTYPE = dr["XTYPE"].ToString().ToUpper().Trim();
                if (XTYPE == "U")
                    objeto.TipoObjeto = TIPOOBJETO.TABLAX;
                else if (XTYPE == "V")
                    objeto.TipoObjeto = TIPOOBJETO.VISTA;
                else if (XTYPE == "P" || XTYPE == "FN")
                    objeto.TipoObjeto = TIPOOBJETO.STOREPROCERURE;
                else if (XTYPE == "TR")
                    objeto.TipoObjeto = TIPOOBJETO.TRIGER;
                else if (XTYPE == "F")
                    objeto.TipoObjeto = TIPOOBJETO.FOREINGKEY;
                else if (XTYPE == "PK")
                    objeto.TipoObjeto = TIPOOBJETO.PRIMARYKEY;
                else if (XTYPE == "S")
                    objeto.TipoObjeto = TIPOOBJETO.TABLASYSTEMA;
                lista.Add(objeto);
            }
            CierraConexion();
            return lista;
        }
        public System.Collections.Generic.List<Objetos.CSysObject> DameHijosDe(string Nombre)
        {
            System.Collections.Generic.List<Objetos.CSysObject> lista = new System.Collections.Generic.List<Objetos.CSysObject>();
            string s = "select distinct  table_name  as NAME,'U' as XTYPE from information_schema.KEY_COLUMN_USAGE  where table_schema='" + Conexion.Database + "' and referenced_table_name='" + Nombre + "' and constraint_name<>'primary' order by table_name ";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            while (dr.Read())
            {
                Objetos.CSysObject objeto = new Objetos.CSysObject();
                objeto.Nombre = dr["NAME"].ToString();
                objeto.TipoObjeto = TIPOOBJETO.NINGUNO;
                string XTYPE = dr["XTYPE"].ToString().ToUpper().Trim();
                if (XTYPE == "U")
                    objeto.TipoObjeto = TIPOOBJETO.TABLAX;
                else if (XTYPE == "V")
                    objeto.TipoObjeto = TIPOOBJETO.VISTA;
                else if (XTYPE == "P" || XTYPE == "FN")
                    objeto.TipoObjeto = TIPOOBJETO.STOREPROCERURE;
                else if (XTYPE == "TR")
                    objeto.TipoObjeto = TIPOOBJETO.TRIGER;
                else if (XTYPE == "F")
                    objeto.TipoObjeto = TIPOOBJETO.FOREINGKEY;
                else if (XTYPE == "PK")
                    objeto.TipoObjeto = TIPOOBJETO.PRIMARYKEY;
                else if (XTYPE == "S")
                    objeto.TipoObjeto = TIPOOBJETO.TABLASYSTEMA;
                lista.Add(objeto);
            }
            CierraConexion();
            return lista;
        }
        public System.Collections.Generic.List<Objetos.CSysObject> DamePadresDe(string Nombre)
        {
            System.Collections.Generic.List<Objetos.CSysObject> lista = new System.Collections.Generic.List<Objetos.CSysObject>();
            string s = "select distinct referenced_table_name as NAME,'U' as XTYPE from information_schema.KEY_COLUMN_USAGE  where table_schema='" + Conexion.Database + "' and table_name ='" + Nombre + "' and constraint_name<>'primary' order by referenced_table_name";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            while (dr.Read())
            {
                Objetos.CSysObject objeto = new Objetos.CSysObject();
                objeto.Nombre = dr["NAME"].ToString();
                objeto.TipoObjeto = TIPOOBJETO.NINGUNO;
                string XTYPE = dr["XTYPE"].ToString().ToUpper().Trim();
                if (XTYPE == "U")
                    objeto.TipoObjeto = TIPOOBJETO.TABLAX;
                else if (XTYPE == "V")
                    objeto.TipoObjeto = TIPOOBJETO.VISTA;
                else if (XTYPE == "P" || XTYPE == "FN")
                    objeto.TipoObjeto = TIPOOBJETO.STOREPROCERURE;
                else if (XTYPE == "TR")
                    objeto.TipoObjeto = TIPOOBJETO.TRIGER;
                else if (XTYPE == "F")
                    objeto.TipoObjeto = TIPOOBJETO.FOREINGKEY;
                else if (XTYPE == "PK")
                    objeto.TipoObjeto = TIPOOBJETO.PRIMARYKEY;
                else if (XTYPE == "S")
                    objeto.TipoObjeto = TIPOOBJETO.TABLASYSTEMA;
                lista.Add(objeto);
            }
            CierraConexion();
            return lista;
        }
        public DataSet Ejecuta(string comando)
        {
            if (isExecuting)
                return new DataSet();
            if (Tablas != null)
                Tablas.Clear();
            MySqlCommand SqlCommand1;
            SqlCommand1 = new MySqlCommand();
            SqlCommand1.CommandText = comando;
            SqlCommand1.CommandType = System.Data.CommandType.Text;
            SqlCommand1.Connection = Conexion;
            SqlCommand1.CommandTimeout = TimeOut;
            SqlCommand1.UpdatedRowSource = UpdateRowSource.Both;
            SqlCommand1.Connection.Open();
            MySqlDataAdapter sqlDataAdapter1;
            sqlDataAdapter1 = new MySqlDataAdapter();
            sqlDataAdapter1.SelectCommand = SqlCommand1;
            DataSet ds = new DataSet("Resultado de la consulta");
            try
            {
                sqlDataAdapter1.GetFillParameters();
                sqlDataAdapter1.Fill(ds);
                int k = ds.Tables.Count;
            }
            catch (MySqlException ex)
            {

                SqlCommand1.Connection.Close();
                throw ex;
            }
            SqlCommand1.Connection.Close();
            return ds;
        }
        public string DaMeDescripcionTabla(string tabla)
        {
            string s = "select TABLE_COMMENT from information_schema.tables where TABLE_SCHEMA='" + Conexion.Database + "' and TABLE_NAME='" + tabla + "'\n";
            MySqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
            }
            catch (System.Exception)
            {
                Conexion.Close();
                return "";
            }
            s = "";
            if (dr.Read())
            {
                s = dr["TABLE_COMMENT"].ToString();
            }
            CierraConexion();
            return s;
        }
        public string DameDescripcionCampo(string tabla, string campo)
        {
            string s = "select\n";
            s = s + "column_comment as Descripcion\n";
            s = s + "from information_schema.columns\n";
            s = s + "where table_schema='" + Conexion.Database + "'\n";
            s = s + "and table_name =\'" + tabla + "\'\n";
            s = s + "and column_name =\'" + campo + "\';\n";
            MySqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
                if (dr.Read())
                {
                    s = dr["Descripcion"].ToString();
                }
            }
            catch (System.Exception)
            {
                CierraConexion();
                return "";
            }
            CierraConexion();
            return s;

        }
        public void GusrdaDescripcionTabla(string tabla, string descripcion)
        {
            //creo la consulta
            string s = "ALTER TABLE `" + Conexion.Database + "`.`" + tabla + "`\n";
            s = s + "COMMENT = '" + descripcion.Replace("\\", "\\\\") + "' ;\n";
            try
            {
                Ejecuta(s);
            }
            catch (System.Exception)
            {
                return;
            }
        }
        public void GuardaDescripcionCampo(string tabla, string campo, string descripcion)
        {
            // primero me traigo la descripcion de la tabla
            string s = this.GeneraCodigoTabla(tabla, null);
            // separo las lineas
            string[] lineas = s.Split('\n');
            // ahora recorro el arreglo para buscar el campo
            bool primero = true;
            foreach (string s2 in lineas)
            {
                if (primero == false)
                {
                    //ya me salte el primer texto
                    //separo los datos por palabras
                    string[] items = s2.Split(' ');
                    string scampo = "";
                    // en teoria la primer palabra tiene que ser el nombre del campo
                    foreach (string stmp in items)
                    {
                        if (stmp.Trim() != "")
                        {
                            //ya filtre los espacios en blanco
                            // ahora reviso si es el campo que ando buscando
                            scampo = this.QuitaComillas(stmp);
                            break;
                        }
                    }
                    if (scampo.ToUpper().Trim() == campo.ToUpper().Trim())
                    {
                        // ya tengo el campo que estoy buscando
                        // creo el query 
                        s = "ALTER TABLE " + tabla + " CHANGE COLUMN " + campo + " ";
                        foreach (string stmp in items)
                        {
                            if (stmp.Contains("COMMENT") == true)
                            {
                                break;
                            }
                            s = s + " " + stmp;
                        }
                        // quito la coma que viene al final
                        s = s.Replace(',', ' ');
                        // agrego el comentario
                        s = s + " COMMENT '" + descripcion.Replace("\\", "\\\\") + "\'";
                        // ejecuto el query
                        try
                        {
                            Ejecuta(s);
                        }
                        catch (System.Exception ex)
                        {
                            return;
                        }
                        return;
                    }

                }
                primero = false;
            }
        }
        public bool EsLLavePrimaria(string Tabla, string Campo)
        {
            string s = "select \n";
            s = s + "	case column_key when 'PRI' then 1 else 0 end  as ERROR \n";
            s = s + "from\n";
            s = s + "	information_schema.columns\n";
            s = s + "where\n";
            s = s + "	table_schema='" + Conexion.Database + "' \n";
            s = s + "	and table_name='" + Tabla + "'\n";
            s = s + "	and column_name='" + Campo + "';\n";

            MySqlDataReader dr;
            dr = ExecuteReader(s);
            s = "";
            if (dr.Read())
            {
                s = dr["ERROR"].ToString();
            }
            CierraConexion();
            if (s == "1")
                return true;
            return false;
        }
        public bool EsLLaveForanea(string tabla, string campo)
        {
            string s = "select * from information_schema.KEY_COLUMN_USAGE where table_schema='" + Conexion.Database + "' and table_name='" + tabla + "' and column_name='" + campo + "' and constraint_name<>'primary'";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            s = "";
            if (dr.Read())
            {
                s = dr["constraint_name"].ToString();
            }
            CierraConexion();
            if (s != "")
                return true;
            return false;
        }
        public string DameTablaForanea(string tabla, string campo)
        {
            string s = "select referenced_table_name from information_schema.KEY_COLUMN_USAGE where table_schema='" + Conexion.Database + "' and table_name='" + tabla + "' and column_name='" + campo + "' and constraint_name<>'primary'";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            s = "";
            if (dr.Read())
            {
                s = dr["referenced_table_name"].ToString();
            }
            CierraConexion();
            return s;
        }
        public System.DateTime DameFechaModificacion(string nombre)
        {
            return System.DateTime.Now;
        }
        public System.Collections.Generic.List<Objetos.CCampoFK> DameLLaveForanea(string nombre)
        {
            string s = "";
            s = s + "select distinct \n";
            s = s + "	table_name as TablaHija ,\n";
            s = s + "	column_name as ColumnaHija,\n";
            s = s + "	referenced_table_name as TablaPadre,\n";
            s = s + "	referenced_column_name as ColumnaPadre\n";
            s = s + "from \n";
            s = s + "	information_schema.KEY_COLUMN_USAGE \n";
            s = s + "where \n";
            s = s + "	table_schema='" + Conexion.Database + "' \n";
            s = s + "	and constraint_name='" + nombre + "'\n";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            System.Collections.Generic.List<Objetos.CCampoFK> lista = new System.Collections.Generic.List<Objetos.CCampoFK>();
            Objetos.CCampoFK CampoFK;
            while (dr.Read())
            {
                CampoFK = new Objetos.CCampoFK();
                CampoFK.columnahija = dr["ColumnaHija"].ToString();
                CampoFK.columnaMaestra = dr["ColumnaPadre"].ToString();
                CampoFK.maestra = dr["TablaPadre"].ToString();
                CampoFK.hija = dr["TablaHija"].ToString();
                lista.Add(CampoFK);
            }
            CierraConexion();
            return lista;
        }
        public string DameCodigoCampoCalculado(string tabla, string campo)
        {
            string s = "";
            s = s + "declare @Tabla varchar(50)\n";
            s = s + "declare @Campo varchar(50)\n";
            s = s + "select @Tabla= \'" + tabla + "\'\n";
            s = s + "select @Campo= \'" + campo + "\'\n";
            s = s + "declare @id int\n";
            s = s + "declare @idCampo int\n";
            s = s + "--me traigo la clave de la tabla\n";
            s = s + "select @id=id from sysobjects where name=@Tabla\n";
            s = s + "--ahora me traigo la clave del campo\n";
            s = s + "select @idCampo=colid from syscolumns where id=@id and name=@Campo\n";
            s = s + "--regreso el codigo del campo calculad\n";
            s = s + "select text from syscomments where id=@id and number=@idCampo\n";
            MySqlDataReader dr;
            dr = ExecuteReader(s);
            if (dr.Read())
            {
                s = dr["text"].ToString();
            }
            CierraConexion();
            return s;
        }
        public string EsIdentity(string Tabla, string Campo)
        {
            string s = "declare @tabla varchar(100)\n";
            s = s + "declare @campo varchar(100)\n";
            s = s + "select @tabla=\'" + Tabla + "\'\n";
            s = s + "select @campo=\'" + Campo + "\'\n";
            s = s + "declare @id int\n";
            s = s + "--obtengo el id de la tabla\n";
            s = s + "select @id=OBJECT_ID(@tabla)\n";
            s = s + "declare @seed_value int\n";
            s = s + "declare @increment_value int\n";
            s = s + "--veo si el campo es identidad\n";
            s = s + "declare @ok int\n";
            s = s + "SELECT @ok=COLUMNPROPERTY(@id,@campo,'IsIdentity')\n";
            s = s + "if (@ok is null or @ok=0)\n";
            s = s + "begin\n";
            s = s + "\tRAISERROR('No es identidad', 16, 1)\n";
            s = s + "\treturn\n";
            s = s + "end\n";
            s = s + "--como si es identidad, me traigo sus propiedades\n";
            s = s + "select @seed_value=IDENT_SEED ( @tabla) \n";
            s = s + "select @increment_value=IDENT_INCR ( @tabla)\n";
            s = s + "--regreso los valores\n";
            s = s + "select @seed_value as  seed_value,@increment_value as increment_value\n";
            s = s + "\n";
            MySqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
                s = "";
                if (dr.Read())
                {
                    s = " identity(" + dr["seed_value"].ToString() + "," + dr["increment_value"].ToString() + ")";
                }
            }
            catch (System.Exception)
            {
                CierraConexion();
                return "";
            }
            CierraConexion();
            return s;
        }
        public Objetos.CIdentity DameIdentity(string Tabla, string Campo)
        {
            Objetos.CIdentity identidad = new Objetos.CIdentity();
            string s = "declare @tabla varchar(100)\n";
            s = s + "declare @campo varchar(100)\n";
            s = s + "select @tabla=\'" + Tabla + "\'\n";
            s = s + "select @campo=\'" + Campo + "\'\n";
            s = s + "declare @id int\n";
            s = s + "--obtengo el id de la tabla\n";
            s = s + "select @id=OBJECT_ID(@tabla)\n";
            s = s + "declare @seed_value int\n";
            s = s + "declare @increment_value int\n";
            s = s + "--veo si el campo es identidad\n";
            s = s + "declare @ok int\n";
            s = s + "SELECT @ok=COLUMNPROPERTY(@id,@campo,'IsIdentity')\n";
            s = s + "if (@ok is null or @ok=0)\n";
            s = s + "begin\n";
            s = s + "\tRAISERROR('No es identidad', 16, 1)\n";
            s = s + "\treturn\n";
            s = s + "end\n";
            s = s + "--como si es identidad, me traigo sus propiedades\n";
            s = s + "select @seed_value=IDENT_SEED ( @tabla) \n";
            s = s + "select @increment_value=IDENT_INCR ( @tabla)\n";
            s = s + "--regreso los valores\n";
            s = s + "select @seed_value as  seed_value,@increment_value as increment_value\n";
            s = s + "\n";
            MySqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
                if (dr.Read())
                {
                    identidad.inicio = int.Parse(dr["seed_value"].ToString());
                    identidad.incremento = int.Parse(dr["increment_value"].ToString());
                    identidad.EsIdentidad = true;
                }
            }
            catch (System.Exception)
            {
                CierraConexion();
                return identidad;
            }
            CierraConexion();
            return identidad;
        }
        public Objetos.CDefault DameDefault(string Tabla, string Campo)
        {
            Objetos.CDefault obj = new Objetos.CDefault();
            string s = "declare @tabla varchar(100)\n";
            s = s + "declare @campo varchar(100)\n";
            s = s + "select @tabla=\'" + Tabla + "\'\n";
            s = s + "select @campo=\'" + Campo + "\'\n";
            s = s + "--vero si es un valor default\n";
            s = s + "declare @cdefault int\n";
            s = s + "declare @id_tabla int\n";
            s = s + "select @id_tabla=id from sysobjects where name=@tabla\n";
            s = s + "select @cdefault=cdefault from syscolumns where id=@id_tabla and name=@campo\n";
            s = s + "if(@cdefault is null or @cdefault=0)\n";
            s = s + "begin\n";
            s = s + "\tRAISERROR('no es campo default', 16, 1)\n";
            s = s + "\treturn\n";
            s = s + "end\n";
            s = s + "declare @defaulvalue varchar(100)\n";
            s = s + "--me traigo el texto\n";
            s = s + "select @defaulvalue=text from syscomments where id=@cdefault\n";
            s = s + "select @defaulvalue as defaulvalue\n";
            MySqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
                if (dr.Read())
                {
                    obj.EsDeafult = true;
                    obj.Valor = dr["defaulvalue"].ToString();
                }
            }
            catch (System.Exception)
            {
                CierraConexion();
                return obj;
            }
            CierraConexion();
            return obj;
        }
        public string GeneraCodigoTabla(string Nombre, List<Objetos.CParametro> Campos)
        {
            string s = "show create table " + Nombre + "";
            MySqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
                if (dr.Read())
                {
                    s = dr["create table"].ToString();
                }
            }
            catch (System.Exception)
            {
                CierraConexion();
                return "";
            }
            CierraConexion();
            return s;
        }
        public void Async_ObtenTablaQuery(string Query)
        {
            if (isExecuting)
                return;
            if (Command == null)
                Command = new MySqlCommand();
            if (Conexion == null)
            {
                if (FMensajeError == null)
                    FMensajeError = new Editor.CErrorQuery();
                FMensajeError.msg = "No hay Conexion a la Base de Datos";
                return;
            }
            if (Query.Trim() == "")
            {
                if (FMensajeError == null)
                    FMensajeError = new Editor.CErrorQuery();
                FMensajeError.msg = "Query Vacio...";
                return;
            }

            Command.CommandText = Query;
            Command.CommandType = CommandType.Text;
            Command.Connection = Conexion;
            Command.CommandTimeout = TimeOut;

            try
            {
                if (Command.Connection.State != ConnectionState.Closed)
                    Command.Connection.Close();
                if (!isExecuting && BeginningQuery != null)
                    BeginningQuery();
                isExecuting = true;
                if (FMensajeError == null)
                    FMensajeError = new Editor.CErrorQuery();
                FMensajeError.msg = "OK";
                HandleCallback(null);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Command.Connection.Close();
                if (isExecuting && EndingQuery != null)
                    EndingQuery();
                isExecuting = false;
                throw ex;
            }

        }
        public void StopAsync()
        {
            bool EstabaEnEjecucion = isExecuting;
            if (isExecuting)
            {
                try
                {
                    Command.Cancel();
                    if (FMensajeError == null)
                        FMensajeError = new Editor.CErrorQuery();
                    FMensajeError.msg = "Termino Forzado de la Ejecucion de Query";
                }
                catch (Exception ex)
                {
                    if (FMensajeError == null)
                        FMensajeError = new Editor.CErrorQuery();
                    FMensajeError.msg = "Error: " + ex.Message;
                }
                finally
                {
                    Command.Connection.Close();
                    isExecuting = false;
                    if (EstabaEnEjecucion && EndingQuery != null)
                        EndingQuery();
                }
            }
        }
        public bool ExisteCampoTabla(string tabla, string campo)
        {
            string s = "select COLUMN_NAME from information_schema.columns where TABLE_SCHEMA='" + Conexion.Database + "' and TABLE_NAME='" + tabla + "' and COLUMN_NAME='" + campo + "'";
            MySqlDataReader dr;
            int x = 0;
            try
            {
                dr = ExecuteReader(s);
                if (dr.Read())
                {
                    if (dr["COLUMN_NAME"].ToString() != "")
                        x = 1;
                    else
                        x = 0;
                }
            }
            catch (System.Exception)
            {
                CierraConexion();
                return false;
            }
            CierraConexion();
            if (x == 1)
                return true;
            return false;
        }
        public void Close()
        {
            //hay que investigar que poner aqui
        }
        public List<string> GetDataBases()
        {
            //por ahorita no hace nada, pero hay que ver la forma de implementarlo
            List<string> l = new List<string>();
            //regresa la lista de bases de datos que hay en el servidor
            try
            {
                AbreConexion();
                MySqlDataReader data = null;
                MySqlCommand query = new MySqlCommand("show databases", Conexion);
                data = query.ExecuteReader();
                while (data.Read() != false)
                {
                    l.Add(data["Database"].ToString());
                }
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return l;
            }
            Conexion.Close();
            return l;
        }
        public void CargaConexion(AdministrarConexiones.FileConecction fc)
        {
            //tambien hay que implementarla
            ConnectionStringBuilder.Server = fc.Servidor;
            ConnectionStringBuilder.UserID = fc.Usuario;
            ConnectionStringBuilder.Password = fc.Password;
            ConnectionStringBuilder.Database = fc.Base;
        }
        private string QuitaComillas(string s)
        {
            string s2 = "";
            int i, n;
            n = s.Length;
            for (i = 0; i < n; i++)
            {
                if (s[i] == '\'' || s[i] == '`')
                    s2 = s2 + "";
                else
                    s2 = s2 + s[i];
            }
            return s2;
        }

        private void AbreConexion()
        {
            if (isExecuting)
                return;
            if (Conexion != null)
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
            else
            {
                Conexion = new MySqlConnection();
            }
            Conexion.ConnectionString = ConnectionStringBuilder.ConnectionString;
            Conexion.Open();
        }
        private int DameLongitud(string dato)
        {
            string s = "";
            int n, i = 0;
            n = dato.Length;
            //busco el parentesis que se habre
            while (i < n && dato[i] != '(')
            {
                i++;
            }
            i++;
            if (i < n)
            {
                //si esta, ahora me traigo los datos
                while (dato[i] != ')' && i < n)
                {
                    s = s + dato[i];
                    i++;
                }
            }
            try
            {
                n = int.Parse(s);
            }
            catch (System.Exception)
            {
                return 0;
            }
            return n;
        }
        private string DameTypo(string tipo)
        {
            string s = "";
            switch (tipo)
            {
                case "BASE TABLE":
                    s = "U";
                    break;
                case "SYSTEM VIEW":
                    s = "V";
                    break;
                case "VIEW":
                    s = "V";
                    break;
                case "V":
                    s = "V";
                    break;
                case "PROCEDURE":
                    s = "P";
                    break;
                case "FUNCTION":
                    s = "FN";
                    break;

            }
            return s;
        }
        private System.Collections.Generic.List<Objetos.CSysObject> BuscaEnCodigo(string cadena)
        {
            // se tare todos los procedimiento almacendaos y empieza abucar la cadena en su codigo de uno por uno
            System.Collections.Generic.List<Objetos.CSysObject> lista = new List<Objetos.CSysObject>();
            System.Collections.Generic.List<Objetos.CSysObject> procedimientos;
            // me traigo todos los procedimientos almacenados
            procedimientos = BuscaObjetos("", TIPOOBJETO.STOREPROCERURE);
            // recorro todos y cada uno de losprocedimientos almacenados para buscar la cadena
            foreach (Objetos.CSysObject pro in procedimientos)
            {
                string codigo = this.DameCodigo(pro.Nombre);
                if (codigo.Contains(cadena) == true)
                {
                    lista.Add(pro);
                }
            }
            return lista;
        }
        private bool EsFuncion(string nombre)
        {
            //verifica si es una vista y regresa true si lo es
            string comando = "";
            comando = "select ROUTINE_NAME as NAME,ROUTINE_type as XTYPE from information_schema.routines where ROUTINE_TYPE=\'FUNCTION\' and ROUTINE_NAME = \'" + nombre.Trim() + "\' and ROUTINE_schema=\'" + Conexion.Database + "\';";
            try
            {
                //RECUPERANDO DATOS
                MySqlDataReader dr;
                dr = ExecuteReader(comando);
                if (dr.Read())
                {
                    CierraConexion();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                CierraConexion();
                throw new Exception(ex.Message);
            }
            CierraConexion();
            return false;
        }
        private bool EsVista(string nombre)
        {
            //verifica si es una vista y regresa true si lo es
            string comando = "";
            comando = "select table_name as NAME,table_type as XTYPE from information_schema.tables where table_type=\'VIEW\' and table_name = \'" + nombre.Trim() + "\' and table_schema=\'" + Conexion.Database + "\';";
            try
            {
                //RECUPERANDO DATOS
                MySqlDataReader dr;
                dr = ExecuteReader(comando);
                if (dr.Read())
                {
                    CierraConexion();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                CierraConexion();
                throw new Exception(ex.Message);
            }
            CierraConexion();
            return false;
        }
        private void HandleCallback(IAsyncResult result)
        {
            try
            {
                Results = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(Command);
                {
                    da.Fill(Results);
                }
            }
            catch (MySqlException ex)
            {
                MensajeErrorSQL = ex;
                if (FMensajeError == null)
                    FMensajeError = new Editor.CErrorQuery();
                FMensajeError.msg = "Error: " + ex.Message;
                FMensajeError.LineNumber = ObtenLineaError(ex.Message);
            }
            catch (System.Exception ex)
            {
                ;
            }
            finally
            {
                EndingQuery();
                isExecuting = false;
            }
        }
        private int ObtenLineaError(string msg)
        {
            int pos;
            pos=msg.ToLower().IndexOf("at line");
            if (pos == -1)
                return 0;
            string s = msg.Substring(pos);
            string[] ops;
            ops=s.Split();
            pos = 0;
            foreach(string s2 in ops)
            {
                try
                {
                    pos=int.Parse(s2);
                    return pos;
                }
                catch(System.Exception)
                {
                    pos=0;
                }
            }
            return pos;
        }
        private bool isExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                if (value)
                {
                    Inicio = DateTime.Now;
                    _isExecuting = true;
                }
                else
                {
                    Fin = DateTime.Now;
                    _isExecuting = false;
                }
            }
        }
        public List<string> GetServers()
        {
            //hay que buscar a todos los servidores que esten al alcanse 
            List<string> servidores = new List<string>();
            return servidores;
        }
        public IDataBase Clona()
        {

            MySqlServer DB = new MySqlServer();
            DB.ConnectionString = this.ConnectionString;
            DB.PruebaConexion();
            return DB;
        }
        private MySqlDataReader ExecuteReader(string s)
        {
            string comando = "";
            MySqlCommand SqlCommand1;
            AbreConexion();
            SqlCommand1 = new MySqlCommand();
            SqlCommand1.CommandType = System.Data.CommandType.Text;
            SqlCommand1.Connection = this.Conexion;//remplzar por el componente de conexion adecuado
            comando = s;
            SqlCommand1.CommandText = comando;
            SqlCommand1.CommandTimeout = 5000000;
            //RECUPERANDO DATOS
            MySqlDataReader dr;
            dr = (MySqlDataReader)SqlCommand1.ExecuteReader();
            return dr;
        }
        public List<string> DameTiposDatos()
        {
            List<string> lista = new List<string>();
            lista.Add("Char");
            lista.Add("Varchar");
            lista.Add("Text");
            lista.Add("TinyText");
            lista.Add("MediumText");
            lista.Add("LongText");
            lista.Add("Blob");
            lista.Add("TinyBlob");
            lista.Add("MediumBlob");
            lista.Add("LongBlob");
            lista.Add("Int");
            lista.Add("int unsigned");
            lista.Add("TinyiInt");
            lista.Add("SmallInt");
            lista.Add("MediumInt");
            lista.Add("BigInt");
            lista.Add("Float");
            lista.Add("Double");
            lista.Add("Decimal");
            lista.Add("Date");
            lista.Add("DateTime");
            lista.Add("TimeStamp");
            lista.Add("Time");
            lista.Add("Year");
            return lista;
        }
        private bool AceptaLongitud(string tipo)
        {
            if (tipo.Trim().ToUpper() == "INT")
                return false;
            if (tipo.Trim().ToUpper() == "DATE")
                return false;
            return true;
        }
        public string CreaTabla(Objetos.CDefinicionTabla tabla, bool ejecutar = true)
        {
            bool primero = true;
            string s = "";
            //creo la consulta de creacion de tablas
            s = "create table " + tabla.Nombre + "(\n";
            //agrego los campos que pertenecen a la tabla
            foreach (Objetos.CDefinicionCampo campo in tabla.Campos)
            {
                //creco si es el primer campo
                if (primero)
                {
                    //lo cambio
                    primero = false;
                }
                else
                {
                    //solo agrego la coma
                    s = s + ",";
                }
                //ahora agrego el campo
                s = s + campo.Nombre;
                //agrego el tipo
                s = s + " " + campo.Tipo;
                //checo si tiene definido tamanio
                if (campo.Longitud > 0 && AceptaLongitud(campo.Tipo))
                {
                    //si tiene un tamanio definido
                    s = s + "(" + campo.Longitud.ToString() + ")";
                }
                //checo si acepta nulos
                if (campo.AceptaNulos == false)
                {
                    //no acepta nulos
                    s = s + " not null";
                }
                //checo si es identidad
                if (campo.AutoIncremental)
                {
                    s = s + " AUTO_INCREMENT";
                }
                if (campo.Unico)
                {
                    s = s + " unique";
                }
                //checo si tiene valores por default
                if (campo.ValorDefault != null && campo.ValorDefault.Trim() != "")
                {
                    //si tiene valores por default
                    s = s + " default " + campo.ValorDefault;
                }
                //checo si tiene valores calculados
                if (campo.ValorCalculado != null && campo.ValorCalculado.Trim() != "")
                {
                    //si tiene valores calculados
                    s = s + " as " + campo.ValorCalculado;
                }
                s = s + "\n";
            }
            //creo la llave primaria si es que la tiene
            if (tabla.PrimaryKey.Count > 0)
            {
                //si contiene llave primaria
                s = s + ",constraint PK_" + tabla.Nombre + " primary key(";
                primero = true;
                //recorro todos los campos para agregarlos
                foreach (Objetos.CDefinicionCampo campo in tabla.PrimaryKey)
                {
                    if (primero)
                    {
                        primero = false;
                    }
                    else
                    {
                        //como no es el primero le agrego una coma
                        s = s + ",";
                    }
                    //agrego el nombre del campo
                    s = s + campo.Nombre;
                    //s = s + "\n";
                }
                s = s + ")\n";
            }
            //agrego los campos unicos
            foreach (string unico in tabla.Unicos)
            {
                s = s + ",unique (" + unico + ")\n";
            }
            //agrego las llaves foraneas
            foreach (Objetos.CDefinicionFK fk in tabla.LLavesForaneas)
            {
                s = s + ",constraint " + fk.Nombre + " foreign key(";
                //recorro los campos de la tabla
                primero = true;
                foreach (Objetos.CDefinicionDetalleFK detalle in fk.Campos)
                {
                    if (primero)
                    {
                        primero = false;
                    }
                    else
                    {
                        s = s + ",";
                    }
                    //agrego el nombre
                    s = s + detalle.CampoHijo;
                }
                s = s + ") references " + fk.TablaPadre + "(";
                primero = true;
                foreach (Objetos.CDefinicionDetalleFK detalle in fk.Campos)
                {
                    if (primero)
                    {
                        primero = false;
                    }
                    else
                    {
                        s = s + ",";
                    }
                    //agrego el nombre
                    s = s + detalle.CampoPadre;
                }
                s = s + ")\n";
            }
            //termino de crear la tabla
            s = s + ")\n";
            //checo si hay que ejecutar el comando
            if (ejecutar)
            {
                this.Ejecuta(s);
            }
            //regreso el comendo construido
            return s;
        }
        public List<Objetos.CUnico> DameUnicos(string tabla)
        {
            return new List<Objetos.CUnico>();
        }
    }
}
