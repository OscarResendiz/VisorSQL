using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using System.Data.SqlClient;

namespace Visor_sql_2008
{
    public class SQLServer_Object : ICompletionData, IDataBaseChild
    {
        #region Miembros de ICompletionData
        private string _Description;
        public string Description
        {
            get { return Name; }
        }
        int _ImageIndex;
        public int ImageIndex
        {
            get { return _ImageIndex; }
        }
        public bool InsertAction(TextArea textArea, char ch)
        {
            string ToWrite;

            switch (Kind)
            {
                case DataType.StoredProcedure:
                    ToWrite = "EXEC " + Text;
                    foreach (SQLServer_Object Ch in Childs)
                        ToWrite += String.Format("\n\t {0}= '', ", Ch.Text);
                    if (ToWrite.EndsWith(", "))
                        ToWrite = ToWrite.Substring(0, ToWrite.Length - 2);
                    break;
                case DataType.Snippet:
                    ToWrite = "";
                    break;
                case DataType.Table:
                case DataType.DataBase:
                case DataType.View:
                case DataType.Variable:
                case DataType.Field:
                case DataType.KeyField:
                case DataType.ForeignKeyField:
                default:
                    ToWrite = Text;
                    break;
            }

            textArea.InsertString(ToWrite);
            return false;
        }
        public double Priority
        {
            get { return 1.0; }
        }
        public string Text
        {
            get
            {
                return Name;
            }
            set
            {
                _Name = value;
            }
        }
        #endregion

        #region Miembros de IDataBaseChild
        private int _Id;
        public int DBId
        {
            get { return _Id; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
        }
        private DataType _Kind;
        public DataType Kind
        {
            get { return _Kind; }
        }
        private string _script;
        public string Script
        {
            get
            {
                SqlCommand cmd = null;
                SqlDataReader rdr = null;
                if (_script == "_")
                {//codigo para obtener el script de tablas, vistas o Sps
                    switch (_Kind)
                    {
                        case DataType.Table:
                            #region Ejecutar codigo sql para obtener el script de la tabla, pero parece que solo funciona con SQL 2005 o mas reciente
                            //crea un scrip para crear la tabla de la base de datos
                            StringBuilder sc = new StringBuilder();
                            sc.AppendLine(String.Format("CREATE TABLE {0}", Name));
                            sc.AppendLine("(");
                            //defino los campos que lleva
                            int i, n;
                            n = Childs.Count;
                            for (i = 0; i < n; i++)
                            {
                                //le asigno el nombre del campo
                                if (i > 0)
                                    sc.Append(String.Format("\t{0}{1}", ",", Childs[i].Name));
                                else
                                    sc.Append(String.Format("\t{0}", Childs[i].Name));

                                //veo si es un campo calculado
                                if (Childs[i].Calculado)
                                {
                                    //es un campo calculado, por lo que me traigo el codigo del campo

                                    sc.AppendLine(" as " + Childs[i].Default);
                                }
                                else
                                {
                                    //le asigno el tipo
                                    sc.Append(String.Format(" {0}", Childs[i].Tipo));
                                    if (Childs[i].Tipo.ToLower().Trim() == "varchar" || Childs[i].Tipo.ToLower().Trim() == "char" || Childs[i].Tipo.ToLower().Trim() == "nvarchar")
                                    {
                                        sc.Append(String.Format("({0})", Childs[i].Precision));
                                    }
                                    //verifico si es nulo o no es nulo
                                    if (Childs[i].Nullable)
                                        sc.Append(" NOT NULL ");
                                    if (Childs[i].IsIdentity)
                                        sc.Append(String.Format(" identity( {0}, {1} )", Childs[i].Seed.ToString(), Childs[i].Increment.ToString()));
                                }
                                if (!Childs[i].Calculado && !String.IsNullOrEmpty(Childs[i].Default))
                                {
                                    sc.Append(" DEFAULT " + Childs[i].Default);
                                }
                                sc.AppendLine();
                            }
                            string campos = "";
                            //ahora checo los constrains      
                            foreach (IDataBaseChild child in Childs)
                                if (child.LlavePrimaria)
                                    campos += child.Name + ", ";

                            if (!String.IsNullOrEmpty(campos))
                                sc.AppendLine(String.Format("\t,constraint PK_{0} primary key({1})", Name, campos.Substring(0, campos.Length - 2)));

                            //ahora checo las llaves foraneas
                            foreach (IDataBaseChild child in Childs)
                            {
                                if (child.LlaveForanea)
                                {
                                    sc.AppendLine(String.Format("\t,constraint FK_{0}_{1} foreign key({2}) references {3}({4})",
                                                                                Name,
                                                                                child.ReferenceTable,
                                                                                child.Name,
                                                                                child.ReferenceTable,
                                                                                child.ReferenceField));
                                }
                            }
                            sc.AppendLine(")");
                            _script = sc.ToString();
                            #endregion
                            break;
                        case DataType.View:
                            #region Codigo para obtener el codigo de la vista
                            string sql_view = "select text from syscomments where id = @DBId order by colid";
                            sql_view = sql_view.Replace("@DBId", DBId.ToString());
                            try
                            {
                                cmd = new SqlCommand(sql_view, Parent.Conexion);
                                cmd.Connection.Open();
                                rdr = cmd.ExecuteReader();
                                StringBuilder sc1 = new StringBuilder();
                                while (rdr.Read())
                                    sc1.AppendLine(rdr[0].ToString());
                                _script = sc1.ToString();
                            }
                            catch (Exception)
                            {
                                if (rdr != null && !rdr.IsClosed)
                                    rdr.Close();
                                rdr.Dispose();
                                if (cmd != null && cmd.Connection != null && cmd.Connection.State == System.Data.ConnectionState.Open)
                                    cmd.Connection.Close();
                                cmd.Dispose();
                                _script = "";
                                return _script;
                            }
                            finally
                            {
                                rdr.Close();
                                rdr.Dispose();
                                cmd.Connection.Close();
                                cmd.Dispose();
                            }
                            #endregion
                            break;
                        case DataType.StoredProcedure:
                            #region Codigo para obtener el codigo de la vista
                            string sql_sp = "select text from syscomments where id = @DBId order by colid";
                            sql_sp = sql_sp.Replace("@DBId", DBId.ToString());
                            try
                            {
                                cmd = new SqlCommand(sql_sp, Parent.Conexion);
                                cmd.Connection.Open();
                                rdr = cmd.ExecuteReader();
                                StringBuilder sc2 = new StringBuilder();
                                while (rdr.Read())
                                    sc2.AppendLine(rdr[0].ToString());
                                _script = sc2.ToString();
                            }
                            catch (Exception)
                            {
                                if (rdr != null && !rdr.IsClosed)
                                    rdr.Close();
                                rdr.Dispose();
                                if (cmd != null && cmd.Connection != null && cmd.Connection.State == System.Data.ConnectionState.Open)
                                    cmd.Connection.Close();
                                cmd.Dispose();
                                _script = "";
                                return _script;
                            }
                            finally
                            {
                                rdr.Close();
                                rdr.Dispose();
                                cmd.Connection.Close();
                                cmd.Dispose();
                            }
                            #endregion
                            break;
                        //case DataType.DataBase:
                        //case DataType.Variable:
                        //case DataType.Snippet:
                        //case DataType.Field:
                        //case DataType.KeyField:
                        //case DataType.ForeignKeyField:
                        default:
                            _script = "";
                            break;
                    }
                }
                return _script;
            }
        }
        private List<SQLServer_Object> _Childs;
        public List<SQLServer_Object> Childs
        {
            get
            {
                return _Childs;
            }
        }
        SQLServer _Daddy;
        public IDataBase Parent
        {
            get
            {
                return _Daddy;
            }
        }
        public string Tipo { get; set; }
        public int Precision { get; set; }
        public bool Nullable { get; set; }
        public bool LlavePrimaria
        {
            get;
            set;
        }
        public bool Calculado
        {
            get;
            set;
        }
        public bool LlaveForanea
        {
            get;
            set;
        }
        public string Default
        {
            get;
            set;
        }
        public int ReferenceID
        {
            get;
            set;
        }
        public string ReferenceTable
        {
            get;
            set;
        }
        public string ReferenceField
        {
            get;
            set;
        }
        public int Seed { get; set; }
        public int Increment { get; set; }
        public bool IsIdentity
        {
            get;
            set;
        }
        public string IdentityScript
        {
            get;
            set;
        }
        public bool ChildWithName(string ChildName, bool NameStartWith)
        {
            if (Childs != null && Childs.Count > 0)
            {
                foreach (SQLServer_Object child in Childs)
                {
                    if (NameStartWith)
                    {
                        if (child.Name.StartsWith(ChildName, StringComparison.CurrentCultureIgnoreCase))
                            return true;
                    }
                    else
                    {
                        if (child.Name.ToLower().Contains(ChildName.ToLower()))
                            return true;
                    }
                }
            }
            return false;
        }
        #endregion
        public SQLServer_Object(SQLServer Dad, int ID, string Name, string Descrption, DataType Kind)
        {
            _Daddy = Dad;
            _Id = ID;
            _Name = Name;
            _Kind = Kind;
            _Description = Descrption;
            _script = "_";
            _Childs = new List<SQLServer_Object>();
            switch (Kind)
            {
                case DataType.Table:
                    _ImageIndex = 0;
                    break;
                case DataType.View:
                    _ImageIndex = 1;
                    break;
                case DataType.StoredProcedure:
                    _ImageIndex = 2;
                    break;
                case DataType.Field:
                    _ImageIndex = 3;
                    break;
                case DataType.ForeignKeyField:
                    _ImageIndex = 4;
                    break;
                case DataType.KeyField:
                    _ImageIndex = 5;
                    break;
                case DataType.Variable:
                    _ImageIndex = 6;
                    break;
                case DataType.Snippet:
                    _ImageIndex = 7;
                    break;
                case DataType.DataBase:
                    _ImageIndex = 8;
                    break;
            }
        }
        public static int Compare(SQLServer_Object x, SQLServer_Object y)
        {
            return String.Compare(x.Name, y.Name, true);
        }
    }
}
