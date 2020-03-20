using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using System.Windows.Forms;

namespace Visor_sql_2015.Controladores_DB
{
    public class MSSQLServer : IDataBase
    {
        //datos privados
        #region DATOS PRIVADOS
        System.Data.SqlClient.SqlConnectionStringBuilder ConnectionStringBuilder;
        private DataSet FResults;
        private Editor.CErrorQuery FMensajeError;
        AsyncCallback callback;
        private IAsyncResult IAsyncStop;
        private bool _isExecuting;
        private DateTime Inicio, Fin;
        private int _TimeOut;
        private System.Data.SqlClient.SqlException MensajeErrorSQL;
        private System.Data.SqlClient.SqlConnection Conexion = null;
        private CNodoTabla Tablas;
        private System.Data.SqlClient.SqlCommand Command;
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
        #endregion
        #region PROPIEDADES PUBLICAS
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
        public bool AutenticacionWindows
        {
            get
            {
                return ConnectionStringBuilder.IntegratedSecurity;
            }
            set
            {
                ConnectionStringBuilder.IntegratedSecurity = value;
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
                return ConnectionStringBuilder.InitialCatalog;
            }
            set
            {
                ConnectionStringBuilder.InitialCatalog = value;
            }
        }
        public string Servidor
        {
            get
            {
                return ConnectionStringBuilder.DataSource;
            }
            set
            {
                ConnectionStringBuilder.DataSource = value;
            }
        }

        #endregion
        #region METODOS PUBLICOS
        public MSSQLServer()
        {
            //creo la memoria interna
            ConnectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            Tablas = new CNodoTabla();
            Tablas.Tabla = "";// es un campo vacio el primero

            //Variable para controlar cuando se esta ejecutando una consulta
            isExecuting = false;
            //Variable para asignar el tiempo maximo de procesamiento de un query, por default no tiene limite
            TimeOut = 0;
            //Funcion para manejar el "regreso" de la ejecucion
            callback = new AsyncCallback(HandleCallback);
        }
        public bool PruebaConexion()
        {
            try
            {
                if (Conexion == null)
                {

                    this.Conexion = new System.Data.SqlClient.SqlConnection(ConnectionStringBuilder.ConnectionString);
                }
                AbreConexion();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Conexion.Close();
            //cargo la lista de objetos
            CargaObjetos();
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
        private string ConvierteCadena(string cadena)
        {
            System.Collections.ArrayList cadenas = new System.Collections.ArrayList();
            int i, n, k, j;
            string s = "";
            string s2 = "";
            string cadenafinal = "";
            n = cadena.Length;
            //separo la cadena de conexion en lineas
            for (i = 0; i < n; i++)
            {
                if (cadena[i] == ';')
                {
                    s = s + cadena[i];
                    cadenas.Add(s);
                    s = "";
                }
                else
                    s = s + cadena[i];
            }
            // elimino las lineas que no son soportadas
            n = cadenas.Count;
            for (i = 0; i < n; i++)
            {
                s = (string)cadenas[i];
                k = s.Length;
                for (j = 0; j < k; j++)
                {
                    if (s[j] == '=')
                    {

                        if (s2.ToLower() == "data source".ToLower())
                        {
                            cadenafinal = cadenafinal + s;
                            s2 = "";
                            break;
                        }
                        if (s2.ToLower() == "workstation id".ToLower())
                        {
                            cadenafinal = cadenafinal + s;
                            s2 = "";
                            break;
                        }
                        if (s2.ToLower() == "packet size".ToLower())
                        {
                            cadenafinal = cadenafinal + s;
                            s2 = "";
                            break;
                        }
                        if (s2.ToLower() == "integrated security".ToLower())
                        {
                            cadenafinal = cadenafinal + s;
                            s2 = "";
                            break;
                        }
                        if (s2.ToLower() == "persist security info".ToLower())
                        {
                            cadenafinal = cadenafinal + s;
                            s2 = "";
                            break;
                        }

                        if (s2.ToLower() == "Password".ToLower())
                        {
                            cadenafinal = cadenafinal + s;
                            s2 = "";
                            break;
                        }
                        if (s2.ToLower() == "User ID".ToLower())
                        {
                            cadenafinal = cadenafinal + s;
                            s2 = "";
                            break;
                        }
                        if (s2.ToLower() == "initial catalog".ToLower())
                        {
                            cadenafinal = cadenafinal + s;
                            s2 = "";
                            break;
                        }
                        s2 = "";
                        break;
                    }
                    else
                        s2 = s2 + s[j];
                }
            }
            return cadenafinal;
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
            comando = "select NAME,XTYPE from sysobjects WHERE (XTYPE=\'U\' or XTYPE=\'V\' ) and name =\'" + nombre.Trim() + "\'";
            try
            {
                //RECUPERANDO DATOS
                System.Data.SqlClient.SqlDataReader dr;
                dr = ExecuteReader(comando);
                if (dr.Read())
                {
                    Objetos.CSysObject objeto = new Visor_sql_2015.Objetos.CSysObject();
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
            System.Collections.Generic.List<Objetos.CParametro> CamposTabla = new List<Visor_sql_2015.Objetos.CParametro>();
            string s = "declare @nombre varchar(50)\n";
            s = s + "select @nombre=\'" + nombre + "\'\n";
            s = s + "declare @numtypes nvarchar(80)\n";
            s = s + "declare @no varchar(2)\n";
            s = s + "declare @objid int\n";
            s = s + "declare @yes varchar(2)\n";
            s = s + "select @yes=\'Si\'\n";
            s = s + "select @no=\'no\'\n";
            s = s + "select @objid=id from sysobjects where name=@nombre\n";
            s = s + "select @numtypes = N'tinyint,smallint,decimal,int,real,money,float,numeric,smallmoney'\n";
            s = s + "select\n";
            s = s + "name AS COLUMNA,\n";
            s = s + "type_name(xusertype) AS TIPO,\n";
            s = s + "convert(int, length)AS LONGITUD,\n";
            s = s + "xprec,\n";
            s = s + "xscale,\n";
            s = s + "iscomputed,\n";
            s = s + "case when isnullable = 0 then @no else @yes end AS NULOS,\n";
            s = s + "collation\n";
            s = s + "from syscolumns where id = @objid and number = 0 order by colid\n";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            Objetos.CParametro Parametro;
            Objetos.CConvertidor cv = new Objetos.CConvertidor();
            while (dr.Read())
            {
                Parametro = new Objetos.CParametro();
                Parametro.nombre = dr["COLUMNA"].ToString();
                Parametro.NULOS = dr["NULOS"].ToString();
                Parametro.tipo = dr["TIPO"].ToString();
                Parametro.Logitud = int.Parse(dr["LONGITUD"].ToString());
                Parametro.xprec = int.Parse(dr["xprec"].ToString());
                Parametro.xscale = int.Parse(dr["xscale"].ToString());
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
        public System.Collections.Generic.List<Objetos.CParametro> DameCamposTabla(string nombre, string campo)
        {
            System.Collections.Generic.List<Objetos.CParametro> CamposTabla = new List<Visor_sql_2015.Objetos.CParametro>();
            string s = "declare @nombre varchar(50)\n";
            s = s + "select @nombre=\'" + nombre + "\'\n";
            s = s + "declare @numtypes nvarchar(80)\n";
            s = s + "declare @no varchar(2)\n";
            s = s + "declare @objid int\n";
            s = s + "declare @yes varchar(2)\n";
            s = s + "select @yes=\'Si\'\n";
            s = s + "select @no=\'no\'\n";
            s = s + "select @objid=id from sysobjects where name=@nombre\n";
            s = s + "select @numtypes = N'tinyint,smallint,decimal,int,real,money,float,numeric,smallmoney'\n";
            s = s + "select\n";
            s = s + "name AS COLUMNA,\n";
            s = s + "type_name(xusertype) AS TIPO,\n";
            s = s + "convert(int, length)AS LONGITUD,\n";
            s = s + "xprec,\n";
            s = s + "xscale,\n";
            s = s + "iscomputed,\n";
            s = s + "case when isnullable = 0 then @no else @yes end AS NULOS,\n";
            s = s + "collation\n";
            s = s + "from syscolumns where id = @objid and number = 0 and name like '" + campo + "%' order by colid\n";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            Objetos.CParametro Parametro;
            Objetos.CConvertidor cv = new Objetos.CConvertidor();
            while (dr.Read())
            {
                Parametro = new Objetos.CParametro();
                Parametro.nombre = dr["COLUMNA"].ToString();
                Parametro.NULOS = dr["NULOS"].ToString();
                Parametro.tipo = dr["TIPO"].ToString();
                Parametro.Logitud = int.Parse(dr["LONGITUD"].ToString());
                Parametro.xprec = int.Parse(dr["xprec"].ToString());
                Parametro.xscale = int.Parse(dr["xscale"].ToString());
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
            if (nombre == "")
            {
                return "";
            }
            string s = "";
            s = "select c.text from syscomments c,sysobjects o where c.id=o.id and o.name = \'" + nombre.Trim() + "\' order by c.colid";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            s = "";
            while (dr.Read())
            {
                s = s + dr["text"].ToString();
            }
            CierraConexion();
            return s;
        }
        public string CreaCodigoTabla(string nombre)
        {
            string s = "declare @nombre varchar(50)\n";
            s = s + "select @nombre=\'" + nombre + "\'\n";
            s = s + "declare @numtypes nvarchar(80)\n";
            s = s + "declare @no varchar(2)\n";
            s = s + "declare @objid int\n";
            s = s + "declare @yes varchar(2)\n";
            s = s + "select @yes=\'Si\'\n";
            s = s + "select @no=\'no\'\n";
            s = s + "select @objid=id from sysobjects where name=@nombre\n";
            s = s + "select @numtypes = N'tinyint,smallint,decimal,int,real,money,float,numeric,smallmoney'\n";
            s = s + "select\n";
            s = s + "name AS COLUMNA,\n";
            s = s + "type_name(xusertype) AS TIPO,\n";
            s = s + "convert(int, length)AS LONGITUD,\n";
            s = s + "case when isnullable = 0 then @no else @yes end AS NULOS\n";
            s = s + "from syscolumns where id = @objid order by colid\n";
            System.Data.SqlClient.SqlDataReader dr;
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
            string s = "";
            s = s + "declare @indid int\n";
            s = s + "declare @nombre varchar(50)\n";
            s = s + "declare @pknombre varchar(256)\n";
            s = s + "select @nombre=\'" + nombre.Trim() + "\'\n";
            s = s + "declare @numtypes nvarchar(80)\n";
            s = s + "declare @no varchar(2)\n";
            s = s + "declare @objid int\n";
            s = s + "declare @yes varchar(2)\n";
            s = s + "select @yes=\'Si\'\n";
            s = s + "select @no=\'no\'\n";
            s = s + "select @objid=id from sysobjects where name=@nombre\n";
            s = s + "select @pknombre=name from sysobjects where xtype=\'PK\' and parent_obj=@objid\n";
            s = s + "select @numtypes = N\'tinyint,smallint,decimal,int,real,money,float,numeric,smallmoney\'\n";
            s = s + "select  @indid=indid from sysindexes where name =@pknombre\n";
            s = s + "select\n";
            s = s + "	c.name AS COLUMNA,\n";
            s = s + "	type_name(c.xusertype) AS TIPO,\n";
            s = s + "	convert(int, c.length)AS LONGITUD,\n";
            s = s + "	c.xprec,\n";
            s = s + "	c.xscale,\n";
            s = s + "	case when c.isnullable = 0 then @no else @yes end AS NULOS\n";
            s = s + "from \n";
            s = s + "	syscolumns c,\n";
            s = s + "	sysindexkeys pk \n";
            s = s + "where\n";
            s = s + "	c.id = @objid \n";
            s = s + "	and c.number = 0 \n";
            s = s + "	and c.id=pk.id \n";
            s = s + "	and c.colid=pk.colid \n";
            s = s + "	and pk.indid=@indid \n";
            s = s + "order by c.colid\n";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            CamposTabla = new System.Collections.Generic.List<Objetos.CParametro>();
            Objetos.CParametro Parametro;
            Objetos.CConvertidor cv = new Objetos.CConvertidor();
            while (dr.Read())
            {
                Parametro = new Objetos.CParametro();
                Parametro.nombre = dr["COLUMNA"].ToString();
                Parametro.tipo = dr["TIPO"].ToString();
                Parametro.Logitud = int.Parse(dr["LONGITUD"].ToString());
                Parametro.xprec = int.Parse(dr["xprec"].ToString());
                Parametro.xscale = int.Parse(dr["xscale"].ToString());
                Parametro.TipoNet = cv.DameTipo(Parametro.tipo);
                CamposTabla.Add(Parametro);
            }
            CierraConexion();
            return CamposTabla;
        }
        public System.Collections.Generic.List<Objetos.CLLaveForanea> DameLLavesForaneas(string tabla)
        {
            System.Collections.Generic.List<Objetos.CLLaveForanea> lista = new System.Collections.Generic.List<Objetos.CLLaveForanea>();
            string s = "select name,id from sysobjects where id in(select constid from sysforeignkeys where fkeyid in( select id from sysobjects where name=\'" + tabla + "\'))";
            System.Data.SqlClient.SqlDataReader dr;
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
            string s = "select name,id from sysobjects where id in(select  constid from sysforeignkeys where rkeyid in( select id from sysobjects where name=\'" + tabla + "\'))";
            System.Data.SqlClient.SqlDataReader dr;
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
        public System.Collections.Generic.List<Objetos.CCampoFK> DameCamposFK(string FKName)
        {
            System.Collections.Generic.List<Objetos.CCampoFK> lista = new System.Collections.Generic.List<Objetos.CCampoFK>();
            string s = "select tm.name as maestra,ti.name as hija,cm.name as columnaMaestra,ci.name as columnahija from sysobjects o,sysforeignkeys fk,sysobjects  tm,sysobjects  ti,syscolumns cm,syscolumns ci where o.xtype='f' and fk.constid=o.id and tm.id=fk.rkeyid and ti.id=fk.fkeyid and cm.id=tm.id and cm.colid=rkey and ci.id=ti.id and ci.colid=fkey and o.name='" + FKName + "'";
            System.Data.SqlClient.SqlDataReader dr;
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
            string s = "declare @nombre varchar(50)\n";
            s = s + "select @nombre=\'" + nombre + "\'\n";
            s = s + "declare @numtypes nvarchar(80)\n";
            s = s + "declare @no varchar(2)\n";
            s = s + "declare @objid int\n";
            s = s + "declare @yes varchar(2)\n";
            s = s + "select @yes=\'Si\'\n";
            s = s + "select @no=\'no\'\n";
            s = s + "select @objid=id from sysobjects where name=@nombre\n";
            s = s + "select @numtypes = N'tinyint,smallint,decimal,int,real,money,float,numeric,smallmoney'\n";
            s = s + "select\n";
            s = s + "name AS COLUMNA,\n";
            s = s + "type_name(xusertype) AS TIPO,\n";
            s = s + "convert(int, length)AS LONGITUD,\n";
            s = s + "xprec,\n";
            s = s + "xscale,\n";
            s = s + "case when isnullable = 0 then @no else @yes end AS NULOS\n";
            s = s + "from syscolumns where id = @objid order by colid\n";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            Objetos.CConvertidor conv = new Objetos.CConvertidor();
            System.Collections.Generic.List<Objetos.CParametro> lista = new System.Collections.Generic.List<Objetos.CParametro>();
            while (dr.Read())
            {
                Objetos.CParametro pa = new Objetos.CParametro();
                pa.tipo = conv.DameTipo(dr["TIPO"].ToString());
                pa.TipoNet = conv.DameTipoNet(dr["TIPO"].ToString());
                pa.nombre = dr["COLUMNA"].ToString();
                pa.Logitud = int.Parse(dr["LONGITUD"].ToString());
                pa.xprec = int.Parse(dr["xprec"].ToString());
                pa.xscale = int.Parse(dr["xscale"].ToString());
                lista.Add(pa);
            }
            CierraConexion();
            return lista;
        }
        public System.Collections.Generic.List<Objetos.CSysObject> DameDependencias(string Nombre)
        {
            System.Collections.Generic.List<Objetos.CSysObject> lista = new System.Collections.Generic.List<Objetos.CSysObject>();
            string s = "declare @tabla sysname\r\n";
            s = s + "select @tabla=\'" + Nombre + "\'\r\n";
            s = s + "declare @idtabla int\r\n";
            s = s + "declare @tipo char(1)\r\n";
            s = s + "select @idtabla=id,@tipo=xtype from sysobjects where name=@tabla\r\n";
            s = s + "if(@tipo='P')\r\n";
            s = s + "\tselect * from sysobjects  where id in(select depid from sysdepends where id=@idtabla) order by name\r\n";
            s = s + "else\r\n";
            s = s + "begin\r\n";
            s = s + "select * from sysobjects where id in( select fkeyid from sysforeignkeys where rkeyid =@idtabla)\r\n";
            s = s + "union\r\n";
            s = s + "select * from sysobjects  where id in(select id from sysdepends where depid=@idtabla)\r\n";
            s = s + "end\r\n";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            while (dr.Read())
            {
                Objetos.CSysObject objeto = new Visor_sql_2015.Objetos.CSysObject();
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
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            while (dr.Read())
            {
                Objetos.CSysObject objeto = new Visor_sql_2015.Objetos.CSysObject();
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
            string s = "select name,xtype from sysobjects where id in( select fkeyid from sysforeignkeys where rkeyid in ( select id from sysobjects where name=\'" + Nombre + "\'))";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            while (dr.Read())
            {
                Objetos.CSysObject objeto = new Visor_sql_2015.Objetos.CSysObject();
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
            string s = "select name,xtype from sysobjects where id in( select rkeyid from sysforeignkeys where  fkeyid in ( select id from sysobjects where name=\'" + Nombre + "\'))";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            while (dr.Read())
            {
                Objetos.CSysObject objeto = new Visor_sql_2015.Objetos.CSysObject();
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
            System.Data.SqlClient.SqlCommand SqlCommand1;
            SqlCommand1 = new System.Data.SqlClient.SqlCommand();
            SqlCommand1.CommandText = comando;
            SqlCommand1.CommandType = System.Data.CommandType.Text;
            SqlCommand1.Connection = Conexion;
            SqlCommand1.CommandTimeout = TimeOut;
            SqlCommand1.Connection.Open();
            System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
            sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            sqlDataAdapter1.SelectCommand = SqlCommand1;
            DataSet ds = new DataSet("Resultado de la consulta");
            try
            {
                sqlDataAdapter1.GetFillParameters();
                sqlDataAdapter1.Fill(ds);
                int k = ds.Tables.Count;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                SqlCommand1.Connection.Close();
                throw ex;
            }
            SqlCommand1.Connection.Close();
            return ds;
        }
        public string DaMeDescripcionTabla(string tabla)
        {
            string s = "declare @tabla varchar(100)\n";
            s = s + "declare @id int\n";
            s = s + "select @tabla=\'" + tabla + "\'\n";
            s = s + "SELECT   value  from   ::fn_listextendedproperty  ('MS_Description','user', 'dbo', 'table', @tabla, null,null)\n";
            System.Data.SqlClient.SqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
            }
            catch (System.Exception)
            {
                CierraConexion();
                return "";
            }
            s = "";
            if (dr.Read())
            {
                s = dr["value"].ToString();
            }
            CierraConexion();
            return s;
        }
        public string DameDescripcionCampo(string tabla, string campo)
        {
            string s = "declare @nombreTabla varchar(100)\n";
            s = s + "declare @nombreCampo varchar(100)\n";
            s = s + "declare @comentario varchar(100)\n";
            s = s + "declare @id int\n";
            s = s + "declare @idc int\n";
            s = s + "select @nombreTabla =\'" + tabla + "\'\n";
            s = s + "select @nombreCampo =\'" + campo + "\'\n";
            s = s + "SELECT   value as  Descripcion from   ::fn_listextendedproperty  ('caption','user', 'dbo', 'table', @nombreTabla, 'column',@nombreCampo)";
            System.Data.SqlClient.SqlDataReader dr;
            string s2 = "";
            try
            {
                dr = ExecuteReader(s);
                if (dr.Read())
                {
                    s2 = dr["Descripcion"].ToString();
                }
            }
            catch (System.Exception)
            {
                CierraConexion();
                return "";
            }
            CierraConexion();
            return s2;

        }
        public void GusrdaDescripcionTabla(string tabla, string descripcion)
        {
            //creo la consulta
            string s = "declare @descripcion varchar(500)\n";
            s = s + "declare @tabla varchar(100)\n";
            s = s + "select @tabla =\'" + tabla + "\'\n";
            s = s + "select @descripcion =\'" + FiltraComillas(descripcion) + "\'\n";
            s = s + "if exists(SELECT * FROM ::fn_listextendedproperty(\'MS_Description\', \'user\' , \'dbo\', \'TABLE\', @tabla, null, null))\n";
            s = s + "begin\n";
            s = s + "\t--trato de actualisar\n";
            s = s + "\tEXEC   sp_updateextendedproperty \'MS_Description\', @descripcion, \'user\', dbo, \'table\', @tabla, null, null\n";
            s = s + "end\n";
            s = s + "else\n";
            s = s + "begin\n";
            s = s + "\tEXEC   sp_addextendedproperty \'MS_Description\', @descripcion, \'user\', dbo, \'table\', @tabla, null, null\n";
            s = s + "end\n";
            try
            {
                Ejecuta(s);
            }
            catch (System.Exception)
            {
                return;
            }
        }
        private string FiltraComillas(string s)
        {
            string s2 = "";
            int i, n;
            n = s.Length;
            for (i = 0; i < n; i++)
            {
                if (s[i] == '\'')
                    s2 = s2 + "''";
                else
                    s2 = s2 + s[i];
            }
            return s2;
        }
        public void GuardaDescripcionCampo(string tabla, string campo, string descripcion)
        {
            string s = "declare @descripcion sql_variant\n";
            s = s + "declare @tabla varchar(100)\n";
            s = s + "declare @campo varchar(100)\n";
            s = s + "select @tabla =\'" + tabla + "\'\n";
            s = s + "select @campo =\'" + campo + "\'\n";
            s = s + "select @descripcion =\'" + FiltraComillas(descripcion) + "\'\n";
            s = s + "if exists(SELECT * FROM ::fn_listextendedproperty (\'caption\', \'user\' , \'dbo\', \'TABLE\', @tabla, \'column\',@campo))\n";
            s = s + "begin\n";
            s = s + "\t--trato de actualisar\n";
            s = s + "\tEXEC   sp_updateextendedproperty \'caption\', @descripcion, \'user\', dbo, \'table\', @tabla, \'column\',@campo\n";
            s = s + "end\n";
            s = s + "else\n";
            s = s + "begin\n";
            s = s + "\tEXEC   sp_addextendedproperty \'caption\', @descripcion, \'user\', dbo, \'table\', @tabla, \'column\',@campo\n";
            s = s + "end\n";
            try
            {
                Ejecuta(s);
            }
            catch (System.Exception)
            {
                return;
            }
        }
        public bool EsLLavePrimaria(string Tabla, string Campo)
        {
            string s = "declare @tabla varchar(100)\n";
            s = s + "declare @campo varchar(100)\n";
            s = s + "select @tabla=\'" + Tabla + "\'\n";
            s = s + "select @campo=\'" + Campo + "\'\n";
            s = s + "declare @indid int\n";
            s = s + "declare @nombre varchar(50)\n";
            s = s + "declare @pknombre varchar(256)\n";
            s = s + "select @nombre=@tabla\n";
            s = s + "declare @numtypes nvarchar(80)\n";
            s = s + "declare @no varchar(2)\n";
            s = s + "declare @objid int\n";
            s = s + "declare @yes varchar(2)\n";
            s = s + "select @yes=\'Si\'\n";
            s = s + "select @no=\'no\'\n";
            s = s + "select @objid=id from sysobjects where name=@nombre\n";
            s = s + "select @pknombre=name from sysobjects where xtype='PK' and parent_obj=@objid\n";
            s = s + "select @numtypes = N'tinyint,smallint,decimal,int,real,money,float,numeric,smallmoney'\n";
            s = s + "select  @indid=indid from sysindexes where name =@pknombre\n";
            s = s + "if exists(\n";
            s = s + "select\n";
            s = s + "c.name AS COLUMNA,\n";
            s = s + "type_name(c.xusertype) AS TIPO,\n";
            s = s + "convert(int, c.length)AS LONGITUD,\n";
            s = s + "case when c.isnullable = 0 then @no else @yes end AS NULOS\n";
            s = s + "from \n";
            s = s + "syscolumns c,\n";
            s = s + "sysindexkeys pk \n";
            s = s + "where\n";
            s = s + "c.id = @objid \n";
            s = s + "and c.number = 0 \n";
            s = s + "and c.id=pk.id \n";
            s = s + "and c.colid=pk.colid \n";
            s = s + "and pk.indid=@indid \n";
            s = s + "and c.name=@campo\n";
            s = s + ")\n";
            s = s + "select \'1\' as ERROR\n";
            s = s + "else\n";
            s = s + "select \'0\' as ERROR\n";
            System.Data.SqlClient.SqlDataReader dr;
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
            string s = "";
            s = s + "declare @tabla varchar(100)\n";
            s = s + "declare @campo varchar(100)\n";
            s = s + "select @tabla=\'" + tabla + "\'\n";
            s = s + "select @campo=\'" + campo + "\'\n";
            s = s + "if exists(\n";
            s = s + "select\n";
            s = s + "o.name,\n";
            s = s + "fk.rkey,\n";
            s = s + "c.name\n";
            s = s + "from\n";
            s = s + "sysobjects o,\n";
            s = s + "sysforeignkeys fk,\n";
            s = s + "syscolumns c\n";
            s = s + "where\n";
            s = s + "o.name=@tabla\n";
            s = s + "and c.name=@campo\n";
            s = s + "and fk.fkeyid=o.id\n";
            s = s + "and c.id=fk.fkeyid\n";
            s = s + "and c.colid=fk.fkey)\n";
            s = s + "select 1 as ERROR\n";
            s = s + "else\n";
            s = s + "select 0 as ERROR\n";
            System.Data.SqlClient.SqlDataReader dr;
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
        public string DameTablaForanea(string tabla, string campo)
        {
            string s = "";
            s = s + "declare @tabla varchar(100)\n";
            s = s + "declare @campo varchar(100)\n";
            s = s + "select @tabla=\'" + tabla + "\'\n";
            s = s + "select @campo=\'" + campo + "\'\n";
            s = s + "select\n";
            s = s + "	o2.name\n";
            s = s + "from\n";
            s = s + "	sysobjects o,\n";
            s = s + "	sysforeignkeys fk,\n";
            s = s + "	syscolumns c,\n";
            s = s + "	sysobjects o2\n";
            s = s + "where\n";
            s = s + "	o.name=@tabla\n";
            s = s + "	and c.name=@campo\n";
            s = s + "	and fk.fkeyid=o.id\n";
            s = s + "	and c.id=fk.fkeyid\n";
            s = s + "	and c.colid=fk.fkey\n";
            s = s + "	and o2.id=fk.rkeyid\n";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            s = "";
            if (dr.Read())
            {
                s = dr["name"].ToString();
            }
            CierraConexion();
            return s;
        }
        public System.DateTime DameFechaModificacion(string nombre)
        {
            System.DateTime fecha = System.DateTime.Now;
            string s = "select crdate from sysobjects where name=\'" + nombre + "\'";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            s = "";
            if (dr.Read())
            {
                fecha = System.DateTime.Parse(dr["crdate"].ToString());
            }
            CierraConexion();
            return fecha;
        }
        public System.Collections.Generic.List<Objetos.CCampoFK> DameLLaveForanea(string nombre)
        {
            string s = "";
            s = s + "select \n";
            s = s + "	fo.name as TablaHija,\n";
            s = s + "	fc.name as ColumnaHija,\n";
            s = s + "	ro.name as TablaPadre,\n";
            s = s + "	rc.name as ColumnaPadre\n";
            s = s + "from \n";
            s = s + "	sysforeignkeys r,\n";
            s = s + "	sysobjects o,\n";
            s = s + "	sysobjects fo,\n";
            s = s + "	syscolumns fc,\n";
            s = s + "	sysobjects ro,\n";
            s = s + "	syscolumns rc\n";
            s = s + "where \n";
            s = s + "	constid =o.id\n";
            s = s + "	and o.name=\'" + nombre + "\'\n";
            s = s + "	and fo.id=r.fkeyid\n";
            s = s + "	and fc.id=fo.id\n";
            s = s + "	and fc.colid=r.fkey\n";
            s = s + "	and ro.id=r.rkeyid\n";
            s = s + "	and rc.id=ro.id\n";
            s = s + "	and rc.colid=r.rkey\n";
            System.Data.SqlClient.SqlDataReader dr;
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
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(s);
            if (dr.Read())
            {
                s = dr["text"].ToString();
            }
            CierraConexion();
            return s;
        }
        private void AbreConexion()
        {
            if (isExecuting)
                return;
            if (Conexion == null)
            {
                Conexion = new System.Data.SqlClient.SqlConnection(ConnectionStringBuilder.ConnectionString);
            }
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            Conexion.ConnectionString = ConnectionStringBuilder.ConnectionString;
            Conexion.Open();
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
            System.Data.SqlClient.SqlDataReader dr;
            try
            {
                dr = ExecuteReader(s);
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
            Objetos.CIdentity identidad = new Visor_sql_2015.Objetos.CIdentity();
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
            System.Data.SqlClient.SqlDataReader dr;
            s = "";
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
            Objetos.CDefault obj = new Visor_sql_2015.Objetos.CDefault();
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
            System.Data.SqlClient.SqlDataReader dr;
            s = "";
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
            //crea un scrip para crear la tabla de la base de datos
            string s;
            s = "create table " + Nombre + "\r\n";
            s = s + "(\r\n";
            //defino los campos que lleva
            int i, n;
            n = Campos.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro obj = Campos[i];
                //le asigno el nombre del campo
                s = s + "\t";
                if (i > 0)
                    s = s + ",";
                s = s + obj.nombre;
                //veo si es un campo calculado
                if (obj.iscomputed == 1)
                {
                    //es un campo calculado, por lo que me traigo el codigo del campo
                    s = s + " as " + DameCodigoCampoCalculado(Nombre, obj.nombre);
                }
                else
                {
                    //le asigno el tipo
                    s = s + " " + obj.tipo;
                    if (obj.tipo.ToLower().Trim() == "varchar" || obj.tipo.ToLower().Trim() == "char" || obj.tipo.ToLower().Trim() == "nvarchar")
                        s = s + "(" + obj.Logitud.ToString() + ")";
                    if (obj.tipo.ToLower().Trim() == "decimal")
                    {
                        s = s + "(" + obj.xprec.ToString() + "," + obj.xscale.ToString() + ")";
                    }
                    //verifico si es nulo o no es nulo
                    if (obj.NULOS.ToLower().Trim() == "no")
                        s = s + " not null";
                    s = s + EsIdentity(Nombre, obj.nombre);
                }
                //veo si es un valor default
                Objetos.CDefault df;
                df = DameDefault(Nombre, obj.nombre);
                if (df.EsDeafult == true)
                {
                    s = s + " default " + df.Valor;
                }
                //doy un salto de linea para el siguiente campo
                s = s + "\r\n";
            }
            //ahora checo los constrains            
            System.Collections.Generic.List<Objetos.CParametro> PrimaryKeys;
            PrimaryKeys = DameLLavesPrimarias(Nombre);
            n = PrimaryKeys.Count;
            if (n > 0)
            {
                s = s + "\t,constraint PK_" + Nombre + " primary key(";
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro objpk = PrimaryKeys[i];
                    if (i > 0)
                        s = s + ",";
                    s = s + objpk.nombre;
                }
                s = s + ")\r\n";
            }
            //ahora checo las llaves foraneas
            System.Collections.Generic.List<Objetos.CLLaveForanea> FKS;
            FKS = DameLLavesForaneas(Nombre);
            string s2 = "";
            foreach (Objetos.CLLaveForanea fk in FKS)
            {
                s = s + "\t,constraint " + fk.name + " foreign key(";
                System.Collections.Generic.List<Objetos.CCampoFK> lfk;
                lfk = DameLLaveForanea(fk.name);
                n = lfk.Count;
                Objetos.CCampoFK CampoFK = lfk[0];
                s2 = " references " + CampoFK.maestra + "(";
                for (i = 0; i < n; i++)
                {
                    CampoFK = lfk[i];
                    if (i > 0)
                    {
                        s = s + ",";
                        s2 = s2 + ",";
                    }
                    s = s + CampoFK.columnahija;
                    s2 = s2 + CampoFK.columnaMaestra;

                }
                s = s + ")";
                s2 = s2 + ")";
                s = s + s2 + "\r\n";
            }
            s = s + "\r\n)";
            return s;
        }
        //funcion para ejecutar consulta asincronamento
        public void Async_ObtenTablaQuery(string Query)
        {
            if (isExecuting)
                return;
            if (Command == null)
                Command = new System.Data.SqlClient.SqlCommand();
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
            ConnectionStringBuilder.AsynchronousProcessing = true;
            AbreConexion();
            Command.CommandText = Query;
            Command.CommandType = CommandType.Text;
            Command.Connection = Conexion;
            Command.CommandTimeout = TimeOut;

            try
            {
                if (!isExecuting && BeginningQuery != null)
                    BeginningQuery();
                isExecuting = true;
                IAsyncStop = Command.BeginExecuteReader(callback, Command, CommandBehavior.CloseConnection);
                if (FMensajeError == null)
                    FMensajeError = new Editor.CErrorQuery();
                FMensajeError.msg = "OK";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                CierraConexion();
                if (isExecuting && EndingQuery != null)
                    EndingQuery();
                isExecuting = false;
                throw ex;
            }

        }
        private void HandleCallback(IAsyncResult result)
        {
            try
            {
                // Retrieve the original command object, passed
                // to this procedure in the AsyncState property
                // of the IAsyncResult parameter.
                System.Data.SqlClient.SqlCommand command = (System.Data.SqlClient.SqlCommand)result.AsyncState;
                System.Data.SqlClient.SqlDataReader reader = command.EndExecuteReader(result);
                // You may not interact with the form and its contents
                // from a different thread, and this callback procedure
                // is all but guaranteed to be running from a different thread
                // than the form. Therefore you cannot simply call code that 
                // fills the grid, like this:
                // FillGrid(reader);
                // Instead, you must call the procedure from the form's thread.
                // One simple way to accomplish this is to call the Invoke
                // method of the form, which calls the delegate you supply
                // from the form's thread. 
                Results = new DataSet();
                Results.Load(reader, LoadOption.OverwriteChanges, new string[] { "Tabla 1", "Tabla 2", "Tabla 3", "Tabla 4", "Tabla 5", "Tabla 6", "Tabla 7" });
                //FillGridDelegate del = new FillGridDelegate(FillGrid);
                //this.Invoke(del, reader);
                // Do not close the reader here, because it is being used in 
                // a separate thread. Instead, have the procedure you have
                // called close the reader once it is done with it.
                //reviso si se obtuvieron datos 
                int i = 0;
                foreach (DataTable dt in Results.Tables)
                {
                    if (dt.Columns.Count > 0)
                    {
                        i++;
                    }
                }
                if (i == 0)
                {
                    //hay que mandar una excepcion indicando el numero de registros afectados
                    string s = reader.RecordsAffected.ToString();
                    if (reader.RecordsAffected == 1)
                        s = s + " Registro afectado ";
                    else
                        s = s + " Registros afectados ";
                    if (FMensajeError == null)
                        FMensajeError = new Editor.CErrorQuery();
                    FMensajeError.msg = s;
                    FMensajeError.LineNumber = 0;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Because you are now running code in a separate thread, 
                // if you do not handle the exception here, none of your other
                // code catches the exception. Because there is none of 
                // your code on the call stack in this thread, there is nothing
                // higher up the stack to catch the exception if you do not 
                // handle it here. You can either log the exception or 
                // invoke a delegate (as in the non-error case in this 
                // example) to display the error on the form. In no case
                // can you simply display the error without executing a delegate
                // as in the try block here. 
                // You can create the delegate instance as you 
                // invoke it, like this:
                MensajeErrorSQL = ex;
                if (FMensajeError == null)
                    FMensajeError = new Editor.CErrorQuery();
                FMensajeError.msg = "Error: " + ex.Message;
                FMensajeError.LineNumber = ex.LineNumber;
            }
            finally
            {
                if (isExecuting && EndingQuery != null)
                    EndingQuery();
                isExecuting = false;
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
            string s = "declare @tabla varchar(100) \n";
            s = s + "declare @campo varchar(100) \n";
            s = s + "declare @id_tabla int \n";
            s = s + "select @tabla=\'" + tabla + "\' \n";
            s = s + "select @campo=\'" + campo + "\' \n";
            s = s + "select @id_tabla= id from sysobjects where name=@tabla \n";
            s = s + "if exists( select * from syscolumns where id=@id_tabla and name=@campo) \n";
            s = s + "begin \n";
            s = s + "	select 1 as existe \n";
            s = s + "end \n";
            s = s + "else \n";
            s = s + "begin \n";
            s = s + "	select 0 as existe \n";
            s = s + "end \n";
            System.Data.SqlClient.SqlDataReader dr;
            int x = 0;
            try
            {
                dr = ExecuteReader(s);
                if (dr.Read())
                {
                    x = int.Parse(dr["existe"].ToString());
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
            Conexion.Close();
        }
        #endregion
        #region Eventos
        public event ProcessingQuery EndingQuery;
        public event ProcessingQuery BeginningQuery;
        #endregion
        public List<string> GetServers()
        {
            //hay que buscar a todos los servidores que esten al alcanse 
            List<string> servidores = new List<string>();
            System.Data.Sql.SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
            System.Data.DataTable dataTable = instance.GetDataSources();
            foreach (DataRow dr in dataTable.Rows)
            {
                servidores.Add(dr["ServerName"].ToString());
            }
            return servidores;
        }
        public List<string> GetDataBases()
        {
            List<string> bases = new List<string>();
            //creo la consulta
            ConnectionStringBuilder.InitialCatalog = "master";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader("SELECT name FROM sysdatabases");
            while (dr.Read())
            {
                bases.Add(dr["name"].ToString());
            }
            CierraConexion();
            return bases;
        }
        public void CargaConexion(AdministrarConexiones.FileConecction fc)
        {
            //cargo los datos de la conexion
            Servidor = fc.Servidor;
            User = fc.Usuario;
            Password = fc.Password;
            AutenticacionWindows = fc.WindowsAutentication;
            ConnectionStringBuilder.InitialCatalog = fc.Base;
        }
        private System.Data.SqlClient.SqlDataReader ExecuteReader(string comando)
        {
            AbreConexion();
            System.Data.SqlClient.SqlDataReader dr = null;
            System.Data.SqlClient.SqlCommand SqlCommand1;
            SqlCommand1 = new System.Data.SqlClient.SqlCommand();
            SqlCommand1.CommandType = System.Data.CommandType.Text;
            SqlCommand1.Connection = this.Conexion;//remplzar por el componente de conexion adecuado
            SqlCommand1.CommandText = comando;
            if (SqlCommand1.Connection.State == ConnectionState.Open)
                SqlCommand1.Connection.Close();
            SqlCommand1.Connection.Open();
            //RECUPERANDO DATOS
            dr = SqlCommand1.ExecuteReader();
            VerifcaCadena(comando);
            return dr;
        }
        private void VerifcaCadena(string s)
        {
            //si dentro de la consulta hay una modificacion, creacion o eliminacion de algun objetos recargo la estructura
            //de la base de datos
            bool recargar = false;
            if (s.ToUpper().Contains("CREATE"))
                recargar = true;
            if (s.ToUpper().Contains("ALTER"))
                recargar = true;
            if (s.ToUpper().Contains("DROP"))
                recargar = true;
            if (recargar)
                CargaObjetos();
        }
        public IDataBase Clona()
        {
            MSSQLServer DB = new MSSQLServer();
            DB.ConnectionString = this.ConnectionString;
            return DB;
        }
        public List<string> DameTiposDatos()
        {
            //regresa la lista de tipos de datos que maneja el motor
            List<string> lista = new List<string>();
            //creo la consulta
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader("select name from systypes");
            while (dr.Read())
            {
                lista.Add(dr["name"].ToString());
            }
            CierraConexion();
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
                    s = s + " identity";
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
                    s = s + " compute " + campo.ValorCalculado;
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
                    s = s + "\n";
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

        private void CargaObjetos()
        {
        }
        public System.Collections.Generic.List<Objetos.CSysObject> BuscaObjetos(string nombre, TIPOOBJETO tipo)
        {
            if (isExecuting)
                return new List<Visor_sql_2015.Objetos.CSysObject>();
            string comando = "";
            System.Collections.Generic.List<Objetos.CSysObject> lista = new System.Collections.Generic.List<Objetos.CSysObject>();
            switch (tipo)
            {
                case TIPOOBJETO.NINGUNO: //Todos
                    comando = "select NAME,XTYPE from sysobjects where name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.TABLAX://tablas
                    comando = "select NAME,XTYPE from sysobjects WHERE XTYPE=\'U\' and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.VISTAS_TABLAS://tablas
                    comando = "select NAME,XTYPE from sysobjects WHERE (XTYPE=\'U\' or XTYPE=\'V\' ) and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.VISTA:
                    comando = "select NAME,XTYPE from sysobjects WHERE XTYPE=\'V\' and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.STOREPROCERURE:
                    comando = "select NAME,XTYPE from sysobjects WHERE (XTYPE=\'P\' ) and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
                    break;
                case TIPOOBJETO.FUNCTION:
                    comando = "select NAME,XTYPE from sysobjects WHERE (xtype=\'FN\') and name like \'" + nombre.Trim() + "%\' ORDER BY NAME";
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
                    comando = "select distinct NAME,XTYPE from sysobjects where id in(select id from syscomments where text like \'%" + nombre.Trim() + "%\')";
                    break;
                case TIPOOBJETO.CAMPOS_TABLA:
                    //se trae todas las tablas que tienen el campo que busco
                    comando = "SELECT s2.* FROM syscolumns s,sysobjects s2 WHERE s2.id=s.id AND s.[name]=\'" + nombre.Trim() + "\'";
                    break;
            }
            try
            {
                //RECUPERANDO DATOS
                System.Data.SqlClient.SqlDataReader dr;
                dr = ExecuteReader(comando);
                while (dr.Read())
                {
                    Objetos.CSysObject objeto = new Visor_sql_2015.Objetos.CSysObject();
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
                    else if (XTYPE == "FN")
                        objeto.TipoObjeto = TIPOOBJETO.FUNCTION;
                    lista.Add(objeto);
                }
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
            CierraConexion();
            return lista;
        }
        public List<Objetos.CUnico> DameUnicos(string tabla)
        {
            Objetos.CUnico obj = null;
            List<Objetos.CUnico> l = new List<Objetos.CUnico>();
            string cadena = "";
            cadena = cadena + " select ";
            cadena = cadena + "     i.name as nombre ";
            cadena = cadena + "     ,c.name as campo ";
            cadena = cadena + " from ";
            cadena = cadena + "     sysobjects o ";
            cadena = cadena + "     ,sysindexes i ";
            cadena = cadena + "     ,sys.index_columns ic ";
            cadena = cadena + "     ,syscolumns c ";
            cadena = cadena + " where ";
            cadena = cadena + "     o.name='" + tabla + "' ";
            cadena = cadena + "     and i.id=o.id ";
            cadena = cadena + "     and ic.object_id=o.id ";
            cadena = cadena + "     and ic.index_id=i.indid ";
            cadena = cadena + "     and c.id=o.id ";
            cadena = cadena + "     and c.colid=ic.column_id ";
            cadena = cadena + " order by ";
            cadena = cadena + "     i.name ";
            cadena = cadena + "     ,ic.index_column_id ";
            string nombre = "";
            System.Data.SqlClient.SqlDataReader dr;
            dr = ExecuteReader(cadena);
            while (dr.Read())
            {
                if (dr["nombre"].ToString() != nombre)
                {
                    if (obj != null)
                    {
                        l.Add(obj);
                    }
                    nombre = dr["nombre"].ToString();
                    obj = new Objetos.CUnico();
                    obj.Nombre = nombre;
                    obj.tabla = tabla;
                }
                obj.Campos.Add(dr["campo"].ToString());
            }
            if (obj != null)
                l.Add(obj);
            return l;
        }
    }
}
