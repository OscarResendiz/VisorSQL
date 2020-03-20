using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading;


namespace Visor_sql_2008
{
    public delegate void EndingLoad();
    public class SQLServer : IDataBase
    {
        public event EndingLoad OnEndedLoad;
        LoadingInfo LoadDialog;
        BackgroundWorker Loader;
        PopupControl.Popup ISenseRect;
        private SqlConnection Conx;
        private bool _FullyLoaded = false;
        public string BD;
        public int _SqlServerVersion;
        public int SqlServerVersion
        {
            get
            {
                return SqlServerVersion;
            }
        }
        private string RealConStr;

        public SQLServer(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            LoadTime = new DateTime(1900, 1, 1);
        }

        #region Miembros de IDataBase
        public SqlConnection Conexion
        {
            get
            {
                return Conx;
            }
        }
        public string ConnectionString
        {
            get
            {
                if (Conx != null && !String.IsNullOrEmpty(RealConStr))
                {
                    return RealConStr;
                }
                return "";
            }
            set
            {
                RealConStr = value;
                if (Conx != null)
                {
                    Conx.ConnectionString = value;
                }
                else
                {
                    Conx = new SqlConnection();
                    Conx.ConnectionString = value;
                }
            }
        }
        public bool Busy
        {
            get
            {
                if (Loader == null || !Loader.IsBusy)
                    return false;
                return true;
            }
        }
        public DateTime LoadTime
        {
            get;
            set;
        }
        public void Initialize()
        {
            if (LoadTime == new DateTime(1900, 1, 1))
            {
                try
                {
                    Conx.Open();
                    Conx.Close();
                }
                catch (Exception)
                {
                    if (Conx.State == ConnectionState.Open)
                        Conx.Close();
                    MessageBox.Show("Fallo Conexion a la Base de Datos", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BD = Conx.Database;

                Loader = new BackgroundWorker();
                Loader.WorkerReportsProgress = true;
                Loader.WorkerSupportsCancellation = true;
                Loader.ProgressChanged += Loader_ProgressChanged;
                Loader.RunWorkerCompleted += Loader_RunWorkerCompleted;
                Loader.DoWork += Loader_DoWork;

                //Inicio de Carga
                ISenseRect = new PopupControl.Popup(LoadDialog = new LoadingInfo());
                ISenseRect.AutoClose = false;
                ISenseRect.FocusOnOpen = false;
                ISenseRect.Opacity = 0.65;
                ISenseRect.ShowingAnimation = PopupControl.PopupAnimations.TopToBottom | PopupControl.PopupAnimations.Slide;
                ISenseRect.HidingAnimation = PopupControl.PopupAnimations.Blend;
                ISenseRect.AnimationDuration = 100;
                LoadDialog.SetInfo(BD, "Abriendo Conexion a BD");
                ISenseRect.Show(new System.Drawing.Point(200, 200));

                Loader.RunWorkerAsync();
            }
        }
        public void FullInitialize()
        {
            if (!_FullyLoaded)
            {
                try
                {
                    Conx.Open();
                    Conx.Close();
                }
                catch (Exception)
                {
                    if (Conx.State == ConnectionState.Open)
                        Conx.Close();
                    MessageBox.Show("Fallo Conexion a la Base de Datos", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BD = Conx.Database;

                Loader = new BackgroundWorker();
                Loader.WorkerReportsProgress = true;
                Loader.WorkerSupportsCancellation = true;
                Loader.ProgressChanged += Loader_ProgressChanged;
                Loader.RunWorkerCompleted += Loader_RunWorkerCompleted;
                Loader.DoWork += Loader_DoWork2;

                //Inicio de Carga
                ISenseRect = new PopupControl.Popup(LoadDialog = new LoadingInfo());
                ISenseRect.AutoClose = false;
                ISenseRect.FocusOnOpen = false;
                ISenseRect.Opacity = 0.65;
                ISenseRect.ShowingAnimation = PopupControl.PopupAnimations.TopToBottom | PopupControl.PopupAnimations.Slide;
                ISenseRect.HidingAnimation = PopupControl.PopupAnimations.Blend;
                ISenseRect.AnimationDuration = 100;
                LoadDialog.SetInfo(BD, "Abriendo Conexion a BD");
                ISenseRect.Show(new System.Drawing.Point(200, 200));

                Loader.RunWorkerAsync();
            }
        }
        public void Refresh()
        {
            try
            {
                Conx.Open();
                Conx.Close();
            }
            catch (Exception)
            {
                if (Conx.State == ConnectionState.Open)
                    Conx.Close();
                MessageBox.Show("Fallo Conexion a la Base de Datos", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BD = Conx.Database;

            Loader = new BackgroundWorker();
            Loader.WorkerReportsProgress = true;
            Loader.WorkerSupportsCancellation = true;
            Loader.ProgressChanged += Loader_ProgressChanged;
            Loader.RunWorkerCompleted += Loader_RunWorkerCompleted;
            Loader.DoWork += Loader_DoWork;

            //Inicio de Carga
            ISenseRect = new PopupControl.Popup(LoadDialog = new LoadingInfo());
            ISenseRect.AutoClose = false;
            ISenseRect.FocusOnOpen = false;
            ISenseRect.Opacity = 0.65;
            ISenseRect.ShowingAnimation = PopupControl.PopupAnimations.TopToBottom | PopupControl.PopupAnimations.Slide;
            ISenseRect.HidingAnimation = PopupControl.PopupAnimations.Blend;
            ISenseRect.AnimationDuration = 100;
            LoadDialog.SetInfo(BD, "Abriendo Conexion a BD");
            ISenseRect.Show(new System.Drawing.Point(200, 200));

            Loader.RunWorkerAsync();
        }
        public bool FullyLoaded
        {
            get
            {
                return _FullyLoaded;
            }
        }
        public List<SQLServer_Object> FilterByType(FilteringTypeValues Type)
        {
            List<SQLServer_Object> Back = new List<SQLServer_Object>();
            switch (Type)
            {
                case FilteringTypeValues.Tables:
                    if (Tables != null && Tables.Count > 0)
                        Back.AddRange(Tables.ToArray());
                    break;
                case FilteringTypeValues.Views:
                    if (Views != null && Views.Count > 0)
                        Back.AddRange(Views.ToArray());
                    break;
                case FilteringTypeValues.Sps:
                    if (Sps != null && Sps.Count > 0)
                        Back.AddRange(Sps.ToArray());
                    break;
                case FilteringTypeValues.Code:
                    if (Views != null && Views.Count > 0)
                        Back.AddRange(Views.ToArray());
                    if (Sps != null && Sps.Count > 0)
                        Back.AddRange(Sps.ToArray());
                    break;
                case FilteringTypeValues.Fields:
                    if (Tables != null && Tables.Count > 0)
                        Back.AddRange(Tables.ToArray());
                    if (Views != null && Views.Count > 0)
                        Back.AddRange(Views.ToArray());
                    break;
                case FilteringTypeValues.Variables:
                case FilteringTypeValues.Snippets:
                    ;
                    break;
                case FilteringTypeValues.All:
                default:
                    if (Tables != null && Tables.Count > 0)
                        Back.AddRange(Tables.ToArray());
                    if (Views != null && Views.Count > 0)
                        Back.AddRange(Views.ToArray());
                    if (Sps != null && Sps.Count > 0)
                        Back.AddRange(Sps.ToArray());
                    break;
            }
            return Back;
        }
        #endregion

        private List<SQLServer_Object> Tables
        {
            get;
            set;
        }
        private List<SQLServer_Object> Views
        {
            get;
            set;
        }
        private List<SQLServer_Object> Sps
        {
            get;
            set;
        }
        public SQLServer_Object GetByName(string Name)
        {
            SQLServer_Object Back = null;
            try
            {
                Back = Tables.First(Table => Table.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase));
            }
            catch (Exception)
            {
                ;
            }
            if (Back != null)
                return Back;
            try
            {
                Back = Views.First(View => View.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase));
            }
            catch (Exception)
            {
                ;
            }
            if (Back != null)
                return Back;
            try
            {
                Back = Sps.First(View => View.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase));
            }
            catch (Exception)
            {
                ;
            }
            return Back;
        }

        void Loader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;

            //// Extract the argument.
            //int arg = (int)e.Argument;

            // Start the time-consuming operation.
            e.Result = RefreshAllData();

            // If the operation was canceled by the user, 
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        void Loader_DoWork2(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;

            //// Extract the argument.
            //int arg = (int)e.Argument;

            // Start the time-consuming operation.
            e.Result = RefreshAllDataFull();

            // If the operation was canceled by the user, 
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private void RefreshTables()
        {
            string sql_tables;
            sql_tables = "SELECT   \n" +
            "	sobj.id as OwnerId,  \n" +
            "	sobj.name as OwnerName,  \n" +
            "	cols.name as Nombre,     \n" +
            "	type_name(cols.xusertype) as Tipo,     \n" +
            "	isnull(cols.prec, 0) as Longitud,     \n" +
            "	isnull(cols.Scale, 0) as Escala,     \n" +
            "	isnull(cols.isnullable, 1) as Nullable,     \n" +
            "	isnull(cols.iscomputed, 0) as Calculated,  \n" +
            "	isnull(comm.text, '') as DefaultValue,     \n" +
            "	case when pk.xtype is null then '0' else '1' end as PKey,   \n" +
            "	case when fk.fkey is null then '0' else '1' end as FKey,   \n" +
            "	isnull(fk.rkeyid, 0) as ReferenceID,  \n" +
            "	isnull(fk2.name, '') as ReferenceTable, \n" +
            "	isnull(cols2.name, '') as ReferenceField, \n" +
            "	isnull(indx.name, '') as IndexName, \n" +
            "	isnull(COLUMNPROPERTY(sobj.id,cols.name,'IsIdentity'), 0) IsIdentity, \n" +
            "	Seed = IDENT_SEED(sobj.name), \n" +
            "	Increment = IDENT_INCR (sobj.name) \n" +
            "FROM   \n" +
            "	sysobjects sobj INNER JOIN syscolumns cols ON sobj.id = cols.id  \n" +
            "      LEFT JOIN sysforeignkeys fk ON fk.fkeyid = cols.id AND fk.fkey = cols.colid  \n" +
            "      LEFT JOIN syscolumns cols2 ON cols2.id = fk.rkeyid AND cols2.colid = fk.rkey \n" +
            "      LEFT JOIN sysobjects fk2 ON fk.rkeyid = fk2.id  \n" +
            "	LEFT JOIN syscomments comm ON cols.cdefault = comm.id OR (cols.id = comm.id and cols.colid = comm.number)  \n" +
            "      LEFT JOIN sysindexkeys ik ON ik.id = cols.id AND ik.colid = cols.colid  \n" +
            "	LEFT JOIN sysindexes indx ON indx.id = ik.id AND indx.indid = ik.indid  \n" +
            "      LEFT JOIN sysobjects pk ON indx.name = pk.name AND pk.parent_obj = indx.id AND pk.xtype = 'PK'  \n" +
            "WHERE   \n" +
            "	sobj.xtype = 'U'   \n" +
            "	and sobj.name <> 'sysdiagrams'   \n" +
            "order by   \n" +
            "	sobj.name, cols.colid  \n";

            //obtener lista de tablas de la BD actual
            DataTable Info = new DataTable();
            SqlCommand cmd = new SqlCommand(sql_tables, Conx);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.Connection.Open();
                da.Fill(Info);
                da.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                return;
            }
            cmd.Dispose();

            if (Tables != null)
                Tables.Clear();
            else
                Tables = new List<SQLServer_Object>();

            SQLServer_Object CurObj = null;
            string curtable = "";
            int i, rowcount = Info.Rows.Count;
            for (i = 0; i < rowcount; i++)
            {
                if (!curtable.Equals(Info.Rows[i]["OwnerName"].ToString(), StringComparison.CurrentCultureIgnoreCase))
                {//agregar solo el campo
                    CurObj = new SQLServer_Object(this, Convert.ToInt32(Info.Rows[i]["OwnerId"]), Info.Rows[i]["OwnerName"].ToString(), "Tabla", DataType.Table);
                    curtable = CurObj.Name;
                    Tables.Add(CurObj);
                }
                SQLServer_Object Field;
                if (Convert.ToInt32(Info.Rows[i]["PKey"]) == 1)
                {
                    Field = new SQLServer_Object(null, 0, Info.Rows[i]["Nombre"].ToString(), "Llave Primaria", DataType.KeyField);
                }
                else if (Convert.ToInt32(Info.Rows[i]["FKey"]) == 1)
                {
                    Field = new SQLServer_Object(null, 0, Info.Rows[i]["Nombre"].ToString(), "Llave Foranea", DataType.ForeignKeyField);
                }
                else
                {
                    Field = new SQLServer_Object(null, 0, Info.Rows[i]["Nombre"].ToString(), "Campo", DataType.Field);
                }
                Field.LlaveForanea = Convert.ToInt32(Info.Rows[i]["FKey"]) == 1;
                Field.LlavePrimaria = Convert.ToInt32(Info.Rows[i]["PKey"]) == 1;
                Field.Tipo = Info.Rows[i]["Tipo"].ToString();
                Field.Precision = Convert.ToInt32(Info.Rows[i]["Longitud"]);
                Field.Nullable = Convert.ToInt32(Info.Rows[i]["Nullable"]) == 1;
                Field.Calculado = Convert.ToInt32(Info.Rows[i]["Calculated"]) == 1;
                Field.Default = Info.Rows[i]["DefaultValue"].ToString();
                Field.ReferenceID = Convert.ToInt32(Info.Rows[i]["ReferenceID"]);
                Field.ReferenceTable = Info.Rows[i]["ReferenceTable"].ToString();
                Field.ReferenceField = Info.Rows[i]["ReferenceField"].ToString();
                if (Convert.ToInt32(Info.Rows[i]["IsIdentity"]) == 1)
                {
                    Field.IsIdentity = true;
                    Field.Seed = Convert.ToInt32(Info.Rows[i]["Seed"]);
                    Field.Increment = Convert.ToInt32(Info.Rows[i]["Increment"]);
                }
                else
                {
                    Field.IsIdentity = false;
                    Field.Seed = 0;
                    Field.Increment = 0;
                }
                CurObj.Childs.Add(Field);
            }
        }
        private void RefreshTablesFull()
        {
            //obtener lista de tablas de la BD actual
            RefreshTables();
            string cad;
            foreach (SQLServer_Object sql_obj in Tables)
                cad = sql_obj.Script;
        }
        private void RefreshViews()
        {
            //obtener lista de vistas de la BD actual
            string sql_views;
            sql_views = "SELECT  \n" +
            "	sobj.id as OwnerId, \n" +
            "	sobj.name as OwnerName, \n" +
            "	cols.name as Nombre,    \n" +
            "	type_name(cols.xusertype) as Tipo,    \n" +
            "	isnull(cols.prec, 0) as Longitud,    \n" +
            "	isnull(cols.Scale, 0) as Escala,    \n" +
            "	isnull(cols.isnullable, 1) as Nullable,    \n" +
            "	isnull(cols.iscomputed, 0) as Calculated	 \n" +
            "FROM  \n" +
            "	sysobjects sobj INNER JOIN syscolumns cols ON sobj.id=cols.id \n" +
            "WHERE  \n" +
            "	sobj.xtype = 'V'  \n" +
            "	and sobj.name <> 'sysdiagrams'  \n" +
            "order by  \n" +
            "	sobj.name, cols.colid \n";

            //obtener lista de vistas de la BD actual
            DataTable Info = new DataTable();
            SqlCommand cmd = new SqlCommand(sql_views, Conx);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.Connection.Open();
                da.Fill(Info);
                da.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                return;
            }
            cmd.Dispose();

            if (Views != null)
                Views.Clear();
            else
                Views = new List<SQLServer_Object>();

            SQLServer_Object CurObj = null;
            string curview = "";
            int i, rowcount = Info.Rows.Count;
            for (i = 0; i < rowcount; i++)
            {
                if (!curview.Equals(Info.Rows[i]["OwnerName"].ToString(), StringComparison.CurrentCultureIgnoreCase))
                {//agregar solo el campo
                    CurObj = new SQLServer_Object(this, Convert.ToInt32(Info.Rows[i]["OwnerId"]), Info.Rows[i]["OwnerName"].ToString(), "Vista", DataType.View);
                    curview = CurObj.Name;
                    Views.Add(CurObj);
                }
                SQLServer_Object Field;
                Field = new SQLServer_Object(null, 0, Info.Rows[i]["Nombre"].ToString(), "Campo", DataType.Field);
                Field.LlaveForanea = false;
                Field.LlavePrimaria = false;
                Field.Tipo = Info.Rows[i]["Tipo"].ToString();
                Field.Precision = Convert.ToInt32(Info.Rows[i]["Longitud"]);
                Field.Nullable = Convert.ToInt32(Info.Rows[i]["Nullable"]) == 1;
                Field.Calculado = false;
                Field.Default = "";
                Field.ReferenceID = 0;
                Field.ReferenceTable = "";
                Field.ReferenceField = "";
                CurObj.Childs.Add(Field);
            }

        }
        private void RefreshViewsFull()
        {
            RefreshViews();
            string cad;
            foreach (SQLServer_Object sql_obj in Views)
                cad = sql_obj.Script;
        }
        private void RefreshSPs()
        {
            //obtener lista de Sps de la BD actual
            string sql_sp;
            sql_sp = "select  \n" +
            "	objs.id as DBId, \n" +
            "	objs.name as Name, \n" +
            "	isnull(cols.name, '') AS ParamName,  \n" +
            "	type_name(cols.xusertype) AS ParamType,  \n" +
            "	isnull(convert(int, length), 0) AS ParamLenght,  \n" +
            "	isnull(isnullable, 1) as Nullable \n" +
            "from   \n" +
            "	sysobjects objs left outer join syscolumns cols on objs.id = cols.id \n" +
            "where   \n" +
            "	objs.xtype = 'P' and  \n" +
            "	objs.category = 0  \n" +
            "order by  \n" +
            "	objs.name, cols.colid \n";

            DataTable Info = new DataTable();
            SqlCommand cmd = new SqlCommand(sql_sp, Conx);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.Connection.Open();
                da.Fill(Info);
                da.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                return;
            }
            cmd.Dispose();

            if (Sps != null)
                Sps.Clear();
            else
                Sps = new List<SQLServer_Object>();

            SQLServer_Object CurObj = null;
            string cursp = "", pname;
            int i, rowcount = Info.Rows.Count;
            for (i = 0; i < rowcount; i++)
            {
                if (!cursp.Equals(Info.Rows[i]["Name"].ToString(), StringComparison.CurrentCultureIgnoreCase))
                {//agregar solo el campo
                    CurObj = new SQLServer_Object(this, Convert.ToInt32(Info.Rows[i]["DBId"]), Info.Rows[i]["Name"].ToString(), "Procedimiento Almacenado", DataType.StoredProcedure);
                    cursp = CurObj.Name;
                    Sps.Add(CurObj);
                }
                pname = Info.Rows[i]["ParamName"].ToString();
                if (!String.IsNullOrEmpty(pname))
                {
                    SQLServer_Object Param;
                    Param = new SQLServer_Object(null, 0, pname, "Parametro de SP", DataType.Variable);
                    Param.LlaveForanea = false;
                    Param.LlavePrimaria = false;
                    Param.Tipo = Info.Rows[i]["ParamType"].ToString();
                    Param.Precision = Convert.ToInt32(Info.Rows[i]["ParamLenght"]);
                    Param.Nullable = Convert.ToInt32(Info.Rows[i]["Nullable"]) == 1;
                    Param.Calculado = false;
                    Param.Default = "";
                    Param.ReferenceID = 0;
                    Param.ReferenceTable = "";
                    Param.ReferenceField = "";
                    CurObj.Childs.Add(Param);
                }

            }



        }
        private void RefreshSPsFull()
        {
            //obtener lista de Sps de la BD actual
            RefreshSPs();
            string cad;
            foreach (SQLServer_Object sp in Sps)
                cad = sp.Script;
        }
        private object RefreshAllData()
        {
            try
            {
                Loader.ReportProgress(0, String.Format("{0}|Extrayendo Informacion de Tablas", BD));
                Thread.Sleep(200);
                RefreshTables();
                Loader.ReportProgress(0, String.Format("{1}|Leidas {0} Tablas", Tables == null ? 0 : Tables.Count, BD));
                Thread.Sleep(200);
                Loader.ReportProgress(0, String.Format("{0}|Extrayendo Informacion de Vistas", BD));
                Thread.Sleep(200);
                RefreshViews();
                Loader.ReportProgress(0, String.Format("{1}|Leidas {0} Vistas", Views == null ? 0 : Views.Count, BD));
                Thread.Sleep(200);
                Loader.ReportProgress(0, String.Format("{0}|Extrayendo Informacion de Procedimientos Almacenados", BD));
                Thread.Sleep(200);
                RefreshSPs();
                Loader.ReportProgress(0, String.Format("{1}|Leidos {0} Procedimientos Almacenados", Sps == null ? 0 : Sps.Count, BD));
                Thread.Sleep(200);
                Loader.ReportProgress(0, String.Format("{0}|Terminada la Extraccion de Informacion, {1} Objetos Leidos", BD, ((Tables == null ? 0 : Tables.Count) + (Views == null ? 0 : Views.Count) + (Sps == null ? 0 : Sps.Count)).ToString()));
                Thread.Sleep(200);
                #region Obtener la fecha de carga de la informacion
                string auxquery = @"declare @fullversion varchar(30)" + Environment.NewLine +
                @"SELECT  @fullversion = convert(varchar(20), SERVERPROPERTY('productversion'))" + Environment.NewLine +
                @"select left(@fullversion, charindex('.', @fullversion) - 1) as MajorVersion, @fullversion as FullVersion";
                SqlCommand aux = new SqlCommand(auxquery, Conx);
                try
                {
                    aux.Connection.Open();
                    _SqlServerVersion = Convert.ToInt32(aux.ExecuteScalar());
                    aux.CommandText = "select getdate() as LoadTime";
                    LoadTime = Convert.ToDateTime(aux.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    if (aux.Connection.State != ConnectionState.Closed)
                        aux.Connection.Close();
                    _SqlServerVersion = 0;
                    LoadTime = new DateTime(1900, 1, 1);
                }
                if (aux.Connection.State != ConnectionState.Closed)
                    aux.Connection.Close();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Informacion de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return 1;
        }
        private object RefreshAllDataFull()
        {
            try
            {
                Loader.ReportProgress(0, String.Format("{0}|Extrayendo Informacion de Tablas", BD));
                Thread.Sleep(200);
                RefreshTablesFull();
                Loader.ReportProgress(0, String.Format("{1}|Leidas {0} Tablas", Tables == null ? 0 : Tables.Count, BD));
                Thread.Sleep(200);
                Loader.ReportProgress(0, String.Format("{0}|Extrayendo Informacion de Vistas", BD));
                Thread.Sleep(200);
                RefreshViewsFull();
                Loader.ReportProgress(0, String.Format("{1}|Leidas {0} Vistas", Views == null ? 0 : Views.Count, BD));
                Thread.Sleep(200);
                Loader.ReportProgress(0, String.Format("{0}|Extrayendo Informacion de Procedimientos Almacenados", BD));
                Thread.Sleep(200);
                RefreshSPsFull();
                Loader.ReportProgress(0, String.Format("{1}|Leidos {0} Procedimientos Almacenados", Sps == null ? 0 : Sps.Count, BD));
                Thread.Sleep(200);
                Loader.ReportProgress(0, String.Format("{0}|Terminada la Extraccion de Informacion, {1} Objetos Leidos", BD, ((Tables == null ? 0 : Tables.Count) + (Views == null ? 0 : Views.Count) + (Sps == null ? 0 : Sps.Count)).ToString()));
                Thread.Sleep(200);
                _FullyLoaded = true;
                #region Obtener la fecha de carga de la informacion
                string auxquery = @"declare @fullversion varchar(30)" + Environment.NewLine +
                @"SELECT  @fullversion = convert(varchar(20), SERVERPROPERTY('productversion'))" + Environment.NewLine +
                @"select left(@fullversion, charindex('.', @fullversion) - 1) as MajorVersion, @fullversion as FullVersion";
                SqlCommand aux = new SqlCommand(auxquery, Conx);
                try
                {
                    aux.Connection.Open();
                    _SqlServerVersion = Convert.ToInt32(aux.ExecuteScalar());
                    aux.CommandText = "select getdate() as LoadTime";
                    LoadTime = Convert.ToDateTime(aux.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    if (aux.Connection.State != ConnectionState.Closed)
                        aux.Connection.Close();
                    _SqlServerVersion = 0;
                    LoadTime = new DateTime(1900, 1, 1);
                }
                if (aux.Connection.State != ConnectionState.Closed)
                    aux.Connection.Close();
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Informacion de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return 1;
        }
        internal void RefreshNew()
        {
            //int NeedRefresh = 0;
            //List<string> buffer;
            //string sql;
            //if (SqlServerVersion >= 9)//si es sql server 2005 o posterior
            //{
            //    SqlCommand aux = new SqlCommand("select count(*) as NeedRefresh from sys.objects where modify_date > '" + LoadTime.ToString("yyyyMMdd hh:mm:ss") + "'", Conx);
            //    try
            //    {
            //        aux.Connection.Open();
            //        NeedRefresh = Convert.ToInt32(aux.ExecuteScalar());
            //        if (NeedRefresh > 0)
            //        {
            //            buffer = new List<string>();
            //            sql = "select name from sys.objects where modify_date > '@date' and type in (@type)";
            //            sql = sql.Replace("@date", LoadTime.ToString("yyyyMMdd hh:mm:ss"));

            //            #region Refrescar las tablas y vistas
            //            SqlDataReader Reader;
            //            aux.CommandText = sql.Replace("@type", "'U', 'V'");
            //            Reader = aux.ExecuteReader();
            //            while (Reader.Read())
            //                buffer.Add(Reader[0].ToString());
            //            Reader.Close();

            //            if (buffer != null && buffer.Count > 0)
            //            {
            //                string sql_tables;
            //                sql_tables = "SELECT   \n" +
            //                "	sobj.id as OwnerId,  \n" +
            //                "	sobj.name as OwnerName,  \n" +
            //                "	cols.name as Nombre,     \n" +
            //                "	type_name(cols.xusertype) as Tipo,     \n" +
            //                "	isnull(cols.prec, 0) as Longitud,     \n" +
            //                "	isnull(cols.Scale, 0) as Escala,     \n" +
            //                "	isnull(cols.isnullable, 1) as Nullable,     \n" +
            //                "	isnull(cols.iscomputed, 0) as Calculated,  \n" +
            //                "	isnull(comm.text, '') as DefaultValue,     \n" +
            //                "	case when pk.xtype is null then '0' else '1' end as PKey,   \n" +
            //                "	case when fk.fkey is null then '0' else '1' end as FKey,   \n" +
            //                "	isnull(fk.rkeyid, 0) as ReferenceID,  \n" +
            //                "	isnull(fk2.name, '') as ReferenceTable, \n" +
            //                "	isnull(cols2.name, '') as ReferenceField, \n" +
            //                "	isnull(indx.name, '') as IndexName, \n" +
            //                "	isnull(COLUMNPROPERTY(sobj.id,cols.name,'IsIdentity'), 0) IsIdentity, \n" +
            //                "	Seed = IDENT_SEED(sobj.name), \n" +
            //                "	Increment = IDENT_INCR (sobj.name) \n" +
            //                "FROM   \n" +
            //                "	sysobjects sobj INNER JOIN syscolumns cols ON sobj.id = cols.id  \n" +
            //                "      LEFT JOIN sysforeignkeys fk ON fk.fkeyid = cols.id AND fk.fkey = cols.colid  \n" +
            //                "      LEFT JOIN syscolumns cols2 ON cols2.id = fk.rkeyid AND cols2.colid = fk.rkey \n" +
            //                "      LEFT JOIN sysobjects fk2 ON fk.rkeyid = fk2.id  \n" +
            //                "	LEFT JOIN syscomments comm ON cols.cdefault = comm.id OR (cols.id = comm.id and cols.colid = comm.number)  \n" +
            //                "      LEFT JOIN sysindexkeys ik ON ik.id = cols.id AND ik.colid = cols.colid  \n" +
            //                "	LEFT JOIN sysindexes indx ON indx.id = ik.id AND indx.indid = ik.indid  \n" +
            //                "      LEFT JOIN sysobjects pk ON indx.name = pk.name AND pk.parent_obj = indx.id AND pk.xtype = 'PK'  \n" +
            //                "WHERE   \n" +
            //                "	sobj.xtype in ('U', 'V')   \n" +
            //                "	and sobj.name <> 'sysdiagrams'   \n" +
            //                "	and sobj.name in (@ListaRefresco)   \n" +
            //                "order by   \n" +
            //                "	sobj.name, cols.colid  \n";
            //                sql_tables = sql_tables.Replace("@ListaRefresco", HDesarrollo.CidString.SQL_List(buffer));

            //                DataTable Info = new DataTable();
            //                using (SqlDataAdapter da = new SqlDataAdapter())
            //                {
            //                    try
            //                    {
            //                        aux.CommandText = sql_tables;
            //                        da.SelectCommand = aux;
            //                        da.Fill(Info);
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        aux.Connection.Close();
            //                        return;
            //                    }
            //                }
            //                if (Info != null && Info.Rows.Count > 0)
            //                {
            //                    for (int i = 0; i < Info.Rows.Count; i++)
            //                    {
            //                        if (Info.Rows[i][0].ToString() == "U")//si es una tabla
            //                        {
            //                            SQLServer_Object Del, Add;
            //                            Del = Tables.Find(Tab => Tab.Name.Equals(Info.

            //                        }
            //                        else
            //                        {//es una vista

            //                        }

            //                    }
            //                }
            //            }
            //            #endregion
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        if (aux.Connection.State != ConnectionState.Closed)
            //            aux.Connection.Close();
            //    }
            //    if (aux.Connection.State != ConnectionState.Closed)
            //        aux.Connection.Close();


            //}
        }
        void Loader_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (ISenseRect != null)
            {
                ISenseRect.Close();
                ISenseRect.Dispose();
            }
            if (LoadDialog != null)
            {
                LoadDialog.Dispose();
                LoadDialog = null;
            }
            LoadTime = DateTime.Now;
            if (OnEndedLoad != null)
                OnEndedLoad();
        }
        void Loader_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            string[] Data = e.UserState.ToString().Split(new char[] { '|' });
            LoadDialog.SetInfo(Data[0], Data[1]);
            LoadDialog.Refresh();
        }
    }
}
