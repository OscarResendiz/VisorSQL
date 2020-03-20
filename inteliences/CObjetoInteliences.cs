using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using System.Windows.Forms;

namespace Visor_sql_2015
{
    public class CObjetoInteliences : ICompletionData, IDataBaseChild
    {
        #region Miembros de ICompletionData
        int _ImageIndex;
        public string Nombre;
        public Controladores_DB.TIPOOBJETO TipoObjeto;
        public string Description
        {
            get
            {
                return Nombre;
            }
        }
        public bool Compara(string s)
        {
            //revisa si el nombre coincide con el testoque le estan mandando
            int i, n;
            int poini = 0;
            if (s.Length > Nombre.Length)
                return false;
            if (Nombre[0] == '@')
                poini = 1;
            n = s.Length;
            for (i = poini; i < n; i++)
            {
                if (s[i - poini].ToString().ToUpper() != Nombre[i].ToString().ToUpper())
                    return false;
            }
            return true;
        }
        public int ImageIndex
        {
            get
            {
                switch (TipoObjeto)
                {
                    case Controladores_DB.TIPOOBJETO.CAMPOS_TABLA:
                        return 3;
                    case Controladores_DB.TIPOOBJETO.PRIMARYKEY:
                        return 5;
                    case Controladores_DB.TIPOOBJETO.TABLASYSTEMA:
                        return 0;
                    case Controladores_DB.TIPOOBJETO.TABLAX:
                        return 0;
                    case Controladores_DB.TIPOOBJETO.VISTA:
                        return 1;
                }
                return _ImageIndex;
            }
        }
        public bool InsertAction(TextArea textArea, char ch)
        {
            string ToWrite;

            switch (Kind)
            {
                case DataType.StoredProcedure:
                    ToWrite = "EXEC " + Text;
                    foreach (CObjetoInteliences Ch in Childs)
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
                return Nombre;
            }
            set
            {
                Nombre = value;
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
                return "hola";
            }
        }
        private List<CObjetoInteliences> _Childs;
        public List<CObjetoInteliences> Childs
        {
            get
            {
                return _Childs;
            }
        }
        CObjetoInteliences _Daddy;
        public IDataBaseChild Parent
        {
            get
            {
                return (IDataBaseChild)_Daddy;
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
                foreach (CObjetoInteliences child in Childs)
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
    }
}
