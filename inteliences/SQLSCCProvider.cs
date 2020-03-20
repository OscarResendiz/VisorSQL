using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using System.Windows.Forms;

namespace Visor_sql_2008
{
    public enum FilteringTypeValues { Tables, Views, Sps, Code, Fields, Variables, Snippets, Childs, All };
    public enum DataType
    {
        DataBase,
        Table,
        View,
        StoredProcedure,
        Variable,
        Snippet,
        Field,
        KeyField,
        ForeignKeyField
    } ;
    public enum ConnectionType { SQLServer, MySQL, Oracle, Other }
    public class SQLSCCProvider : ICompletionDataProvider
    {
        public string ConnectioString;
        private ImageList imageList;
        string FilterCad;
        FilteringTypeValues Info;
        SQLServer SqlServerData;
        int StartOffset;
        List<Variables> Vars;
        List<SQLServer_Object> Childs;
        public SQLSCCProvider(SQLServer SqlServerData, ImageList imageList)
        {
            this.SqlServerData = SqlServerData;
            this.imageList = imageList;
            Vars = new List<Variables>();
        }
        public SQLSCCProvider(List<SQLServer_Object> Childs, List<Variables> Vars, SQLServer SqlServerData, ImageList imageList, string FilterCad, FilteringTypeValues Info, int StartOffset)
        {
            this.SqlServerData = SqlServerData;
            this.imageList = imageList;
            this.FilterCad = FilterCad;
            this.Info = Info;
            this.StartOffset = StartOffset;
            this.Vars = Vars;
            this.Childs = Childs;
        }
        public ImageList ImageList
        {
            get
            {
                return imageList;
            }
        }
        public string PreSelection
        {
            get
            {
                return null;
            }
        }
        public int DefaultIndex
        {
            get
            {
                return -1;
            }
        }
        private bool _IsEmpty;
        public bool IsEmpty
        {
            get
            {
                return _IsEmpty;
            }
        }
        public CompletionDataProviderKeyResult ProcessKey(char key)
        {
            if (char.IsLetterOrDigit(key) || key == '_')
            {
                return CompletionDataProviderKeyResult.NormalKey;
            }
            return CompletionDataProviderKeyResult.InsertionKey;
        }
        /// <summary>
        /// Called when entry should be inserted. Forward to the insertion action of the completion data.
        /// </summary>
        public bool InsertAction(ICompletionData data, TextArea textArea, int insertionOffset, char key)
        {
            textArea.Caret.Position = textArea.Document.OffsetToPosition(
                Math.Min(insertionOffset, textArea.Document.TextLength)
                );
            return data.InsertAction(textArea, key);
        }
        public ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped)
        {
            if (SqlServerData == null)
            {
                SqlServerData = new SQLServer(ConnectioString);
                SqlServerData.Initialize();
            }
            List<SQLServer_Object> Back;
            Back = SqlServerData.FilterByType(Info);
            if (Vars != null && Vars.Count > 0 && Info == FilteringTypeValues.Variables)
            {
                List<Variables> VarsBack = Vars.FindAll(N => N.Text.ToLower().StartsWith(FilterCad.ToLower()));
                if (VarsBack == null || VarsBack.Count == 0)
                    _IsEmpty = true;
                else
                    _IsEmpty = false;
                VarsBack.Sort(ICompletionDataCompare);
                return VarsBack.ToArray();
            }
            if (Childs != null && Childs.Count > 0 && Info == FilteringTypeValues.Childs)
            {
                List<SQLServer_Object> ChildsBack = Childs.FindAll(N => N.Text.ToLower().StartsWith(FilterCad.ToLower()));
                if (ChildsBack == null || ChildsBack.Count == 0)
                    _IsEmpty = true;
                else
                    _IsEmpty = false;
                ChildsBack.Sort(ICompletionDataCompare);
                return ChildsBack.ToArray();
            }
            //switch (Info)
            //{
            //    case FilteringTypeValues.Tables:
            //        Back = SqlServerData.FilterByType(FilteringTypeValues.Tables);
            //        break;
            //    case FilteringTypeValues.Views:
            //        Back = SqlServerData.FilterByType(FilteringTypeValues.Views);
            //        break;
            //    case FilteringTypeValues.Sps:
            //        Back = SqlServerData.FilterByType(FilteringTypeValues.Sps);
            //        break;
            //    case FilteringTypeValues.Code:
            //        Back = SqlServerData.FilterByType(FilteringTypeValues.ViewsAndSPs);
            //        break;
            //    case FilteringTypeValues.Fields:
            //        Back = SqlServerData.FilterByType(FilteringTypeValues.Fields);
            //        break;
            //    case FilteringTypeValues.All:
            //        Back = SqlServerData.FilterByType(FilteringTypeValues.All);
            //        break;
            //    default:
            //        Back = new List<CompletionData>();
            //        break;
            //}
            Back = Back.FindAll(N => N.Text.ToLower().StartsWith(FilterCad.ToLower()));
            if (Back == null || Back.Count == 0)
                _IsEmpty = true;
            else
                _IsEmpty = false;
            Back.Sort(ICompletionDataCompare);
            return Back.ToArray();
        }
        public static int ICompletionDataCompare(ICompletionData x, ICompletionData y)
        {
            return String.Compare(x.Text, y.Text, true);
        }
        //private bool FilterByText(CompletionData X)
        //{
        //    return X.Text.ToLower().StartsWith(FilterCad.ToLower());
        //}
    }
}
