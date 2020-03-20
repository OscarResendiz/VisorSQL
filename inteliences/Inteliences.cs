using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
///clase que va a administradr el inteliences para liberar al edicot de todo el proceso
namespace Visor_sql_2015
{
    public delegate void OnEventoInteliencesEvent();
    public delegate System.Windows.Forms.Form OnParentFormEvent();
    public delegate void OnKeyEventx(Keys dato);
    public partial class Inteliences : Component, ICompletionDataProvider
    {
        private List<Objetos.CTablaVariable> TablasVariable;
        private List<CObjetoInteliences> listaElementos = new List<CObjetoInteliences>();            
        List<CObjetoInteliences> CurChilds;
        private ICSharpCode.TextEditor.TextEditorControl TCodigo;
        private Controladores_DB.IDataBase FDB;
        public event OnEventoInteliencesEvent Ejecutar;
        public event OnEventoInteliencesEvent Comentar;
        public event OnEventoInteliencesEvent Descomentar;
        public event OnEventoInteliencesEvent Buscar;
        public event OnEventoInteliencesEvent Guardar;
        public event OnEventoInteliencesEvent Abrir;
        public event OnParentFormEvent OnParentForm;
        public event OnKeyEventx OnKey;
        List<string> ReservedWords = new List<string>{"@@IDENTITY","ADD","ALL","ALTER","AND","ANY ","AS","ASC","AUTHORIZATION","AVG ","BACKUP",
                                                      "BEGIN","BETWEEN","BREAK","BROWSE","BULK","BY","CASCADE","CASE","CHECK","CHECKPOINT","CLOSE",
                                                      "CLUSTERED","COALESCE","COLLATE","COLUMN","COMMIT","COMPUTE","CONSTRAINT","CONTAINS","CONTAINSTABLE",
                                                      "CONTINUE","CONVERT","COUNT","CREATE","CROSS","CURRENT","CURRENT_DATE","CURRENT_TIME","CURRENT_TIMESTAMP",
                                                      "CURRENT_USER","CURSOR","DATABASE","DATABASEPASSWORD","DATEADD","DATEDIFF","DATENAME","DATEPART",
                                                      "DBCC","DEALLOCATE","DECLARE","DEFAULT","DELAY","DELETE","DENY","DESC","DISK","DISTINCT","DISTRIBUTED",
                                                      "DOUBLE","DROP","DUMP","ELSE","ENCRYPTION","END","ERRLVL","ESCAPE","EXCEPT","EXEC","EXECUTE",
                                                      "EXISTS","EXIT","EXPRESSION","FETCH","FILE","FILLFACTOR","FOR","FOREIGN","FREETEXT","FREETEXTTABLE",
                                                      "FROM","FULL","FUNCTION","GOTO","GRANT","GROUP","HAVING","HOLDLOCK","IDENTITY","IDENTITY_INSERT",
                                                      "IDENTITYCOL","IF","IN","INDEX","INNER","INSERT","INTERSECT","INTO","IS","JOIN","KEY",
                                                      "KILL","LEFT","LIKE","LINENO","LOAD","MAX","MIN","NATIONAL","NOCHECK","NONCLUSTERED",
                                                      "NOT","NULL","NULLIF","OF","OFF","OFFSETS","ON","OPEN","OPENDATASOURCE","OPENQUERY",
                                                      "OPENROWSET","OPENXML","OPTION","OR","ORDER","OUTER","OVER","PERCENT","PLAN","PRECISION",
                                                      "PRIMARY","PRINT","PROC","PROCEDURE","PUBLIC","RAISERROR","READ","READTEXT","RECONFIGURE","REFERENCES",
                                                      "REPLICATION","RESTORE","RESTRICT","RETURN","REVOKE","RIGHT","ROLLBACK","ROWCOUNT","ROWGUIDCOL",
                                                      "RULE","SAVE","SCHEMA","SELECT","SESSION_USER","SET","SETUSER","SHUTDOWN","SOME","STATISTICS",
                                                      "SUM","SYSTEM_USER","TABLE","TEXTSIZE","THEN","TO","TOP","TRAN","TRANSACTION","TRIGGER","TRUNCATE",
                                                      "TSEQUAL","UNION","UNIQUE","UPDATE","UPDATETEXT","USE","USER","VALUES","VARYING","VIEW","WAITFOR",
                                                      "WHEN","WHERE","WHILE","WITH","WRITETEXT","OSCAR"};
        public Controladores_DB.IDataBase DB
        {
            get
            {
                return FDB;
            }
            set
            {
                FDB = value;
            }
        }
        public Inteliences()
        {
            InitializeComponent();
        }

        public Inteliences(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #region Interfaces para el inteliences
        public int DefaultIndex
        {
            get
            {
                return -1;
            }
        }
        public string PreSelection
        {
            get
            {
                return null;
            }
        }
        public System.Windows.Forms.ImageList ImageList
        {
            get
            {
                return PopIList;
            }
        }
        public string Filtro;
        public FilteringTypeValues tipo;
        public string NombreTabla;
        public ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped)
        {
            List<CObjetoInteliences> lista = new List<CObjetoInteliences>();         
            //recorro la lista de elementos a mostrar para agregar solo aquellas que coincidan con el filtro
            foreach (CObjetoInteliences obj in listaElementos)
            {
                if (obj.Compara(fileName) == true)
                    lista.Add(obj);
            }
            //List<Objetos.CSysObject> objetos=null;
            //switch (tipo)
            //{
            //    case FilteringTypeValues.Fields:
            //        objetos = DB.BuscaObjetos(Filtro, Controladores_DB.TIPOOBJETO.NINGUNO);
            //        foreach (Objetos.CSysObject obj in objetos)
            //        {
            //            CObjetoInteliences dato = new CObjetoInteliences();
            //            dato.TipoObjeto = obj.TipoObjeto;
            //            dato.Nombre = obj.Nombre;
            //            lista.Add(dato);
            //        }
            //        break;
            //    case FilteringTypeValues.Tables:
            //        objetos = DB.BuscaObjetos(Filtro, Controladores_DB.TIPOOBJETO.TABLAX);
            //        foreach (Objetos.CSysObject obj in objetos)
            //        {
            //            CObjetoInteliences dato = new CObjetoInteliences();
            //            dato.TipoObjeto = obj.TipoObjeto;
            //            dato.Nombre = obj.Nombre;
            //            lista.Add(dato);
            //        }
            //        break;
            //    case FilteringTypeValues.Childs:
            //        List<Objetos.CParametro> campos;
            //        campos = DB.DameCamposTabla(NombreTabla, Filtro);
            //        foreach (Objetos.CParametro p in campos)
            //        {
            //            CObjetoInteliences obj = new CObjetoInteliences();
            //            obj.TipoObjeto = Controladores_DB.TIPOOBJETO.CAMPOS_TABLA;
            //            obj.Nombre = p.nombre;
            //            lista.Add(obj);
            //        }
            //        break;
            //    case FilteringTypeValues.Variables:
            //        return Vars.ToArray();
            //}
            lista.Sort(ICompletionDataCompare);
            return lista.ToArray();
        }
        public bool InsertAction(ICompletionData data, TextArea textArea, int insertionOffset, char key)
        {
            textArea.Caret.Position = textArea.Document.OffsetToPosition(
                Math.Min(insertionOffset, textArea.Document.TextLength)
                );
            return data.InsertAction(textArea, key);
        }
        public CompletionDataProviderKeyResult ProcessKey(char key)
        {
            if (char.IsLetterOrDigit(key) || key == '_')
            {
                return CompletionDataProviderKeyResult.NormalKey;
            }
            return CompletionDataProviderKeyResult.InsertionKey;
        }
        public static int ICompletionDataCompare(ICompletionData x, ICompletionData y)
        {
            return String.Compare(x.Text, y.Text, true);
        }
        public CObjetoInteliences GetByName(string nombre)
        {
            Objetos.CSysObject obj;
            List<Objetos.CSysObject> list;
            list = DB.BuscaObjetos(nombre, Controladores_DB.TIPOOBJETO.NINGUNO);
            if (list.Count == 0)
                return null;
            obj=list[0];
            if (nombre.ToUpper() != obj.Nombre.ToUpper())
                return null;//nombre coincide exactamente con else nombre
            CObjetoInteliences obj2 = new CObjetoInteliences();
            obj2.TipoObjeto = obj.TipoObjeto;
            obj2.Nombre = obj.Nombre;
            return obj2;
        }
        #endregion
        public ICSharpCode.TextEditor.TextEditorControl TextEditorControl
        {
            get
            {
                return TCodigo;
            }
            set
            {
                TCodigo = value;
                if (TCodigo == null)
                    return;
                TCodigo.ActiveTextAreaControl.TextArea.DoProcessDialogKey += Query_DoProcessDialogKey;
            }
        }
        public System.Windows.Forms.Form ParentForm
        {
            get
            {
                if (OnParentForm != null)
                    return OnParentForm();
                return null;
            }
        }
        #region Codigo para el inteliences
        AutoCompleteWindow ISense;
        public bool ShowingIntellisense
        {
           
            get
            {
                return ((ISense != null) && (!ISense.IsDisposed));
            }
        }
        List<Variables> Vars;
        //private SQLServer DataProvider;
        string FilterString;
        FilteringTypeValues CurrentFilter;
        int _FireAt;
        public int FireAt
        {
            get
            {
                return _FireAt;
            }
            set
            {
                _FireAt = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowIntellisense();

        }
        void CodeCompletionWindowClosed(object sender, EventArgs e)
        {
            if (ISense != null)
            {
                ISense.Closed -= CodeCompletionWindowClosed;
                ISense.Closing -= ISense_Closing;
                ISense.Dispose();
                ISense = null;
            }
        }
        bool CancelClose;
        void ISense_Closing(object sender, CancelEventArgs e)
        {
            if (CancelClose)
            {
                CancelClose = false;
                e.Cancel = true;
            }
        }
        private string CurQuery, CurWord, InspectedObjectName;
        private string GetWordAtOffsetMinusOne()
        {
            return "hola oscar";
        }
        //int CurOffset;
        private Hashtable Aliases;

        bool Query_DoProcessDialogKey(Keys keyData)// Echo == true, then NoEcho == false
        {
            if (OnKey != null)
                OnKey(keyData);
            #region Procesado de Atajos, automaticamente deshabilitan el intellisense
            switch (keyData)
            {
                case Keys.F5:
                    //ejecutar query
                    if (Ejecutar!=null )//ejecutar query
                        Ejecutar();
                    return true;
                //case Keys.Shift | Keys.F5:
                //    //detener ejecucion de query
                //    if (BtnStop.Enabled)
                //        BtnStop_Click(null, null);
                //    return true;
                //case Keys.Control | Keys.F5:
                //    //forzar detencion de query
                //    if (BtnExtremeStop.Enabled)
                //        BtnExtremeStop_Click(null, null);
                //    return true;
                case Keys.Control | Keys.K:
                    //comentar seleccion
                    if (Comentar!=null)
                        Comentar();
                    return true;
                case Keys.Control | Keys.U:
                    //decomentar seleccion
                    if (Descomentar!=null)
                        Descomentar();
                    return true;
                //case Keys.Control | Keys.F:
                //    //abrir ventana de busqueda
                //    BtnSearch_Click(null, null);
                //    return true;
                case Keys.F3:
                case Keys.Control|Keys.F:
                    //buscar siguiente, silenciosamente
                    if(Buscar!=null)
                        Buscar();
                    //FindNext(true, false, String.Format("Cadena de Texto: {0}, no encontrada.", _findForm.LookFor));
                    return true;
                //case Keys.Shift | Keys.F3:
                //    //buscar anterior silenciosamente
                //    FindNext(true, true, String.Format("Cadena de Texto: {0}, no encontrada.", _findForm.LookFor));
                //    return true;
                //case Keys.F2:
                //    //poner bookmark
                //    BtnBookmark_Click(null, null);
                //    return true;
                //case Keys.Shift | Keys.F2:
                //    //ir al bookmark anterior
                //    BtnPrevious_Click(null, null);
                //    return true;
                //case Keys.Control | Keys.F2:
                //    //ir al siguiente bookmark
                //    BtnNext_Click(null, null);
                //    return true;
                //case Keys.Control | Keys.Shift | Keys.F2:
                //    //limpiar los bookmarks
                //    BtnClearBookmarks_Click(null, null);
                //    return true;
                case Keys.Control | Keys.G:
                    if (Guardar != null)
                        Guardar();
                    //                    BtnSave_Click(null, null);
                    return true;
                case Keys.Control | Keys.L:
                    if(Abrir!=null)
                        Abrir();
                    //BtnLoad_Click(null, null);
                    return true;
                //case Keys.Control | Keys.W:
                //    //mostrar/ocultar ventana de resultados
                //    BtnShowHideResults_Click(null, null);
                //    return true;
            }
            #endregion

            #region Codigo Anterior para Intellisense, codigo propio no de ICSharp.TextEditor
            if (ShowingIntellisense)
            {
                #region Codigo para el Manejo de Teclas si el "IntelliSense" esta Activado
                switch (keyData)
                {
                    case Keys.Back:
                        ISense.Close();
                        if (FilterString != null && FilterString.Length > 0)
                        {
                            FilterString = FilterString.Remove(FilterString.Length - 1);
                            //TCodigo.ActiveTextAreaControl.Caret.Position = TCodigo.Document.OffsetToPosition(TCodigo.ActiveTextAreaControl.Caret.Offset - 1);
                            //TCodigo.Document.Insert(TCodigo.ActiveTextAreaControl.Caret.Offset, "$");//(TCodigo.ActiveTextAreaControl.Caret.Offset, 1);
                            //TCodigo.ActiveTextAreaControl.Caret.Position = TCodigo.Document.OffsetToPosition(TCodigo.ActiveTextAreaControl.Caret.Offset + 1);
                            CancelClose = true;
                            ShowIntellisense();
                        }
                        return true;
                    case Keys.Escape:
                        ISense.Close();
                        break;
                    case Keys.OemMinus:
                        FilterString += "-";
                        ShowIntellisense();
                        //CancelClose = true;
                        return false;
                    case Keys.OemMinus | Keys.Shift:
                        FilterString += "_";
                        ShowIntellisense();
                        //CancelClose = true;
                        return false;
                    case (Keys)65601:
                    case Keys.A:
                    case (Keys)65602:
                    case Keys.B:
                    case (Keys)65603:
                    case Keys.C:
                    case (Keys)65604:
                    case Keys.D:
                    case (Keys)65605:
                    case Keys.E:
                    case (Keys)65606:
                    case Keys.F:
                    case (Keys)65607:
                    case Keys.G:
                    case (Keys)65608:
                    case Keys.H:
                    case (Keys)65609:
                    case Keys.I:
                    case (Keys)65610:
                    case Keys.J:
                    case (Keys)65611:
                    case Keys.K:
                    case (Keys)65612:
                    case Keys.L:
                    case (Keys)65613:
                    case Keys.M:
                    case (Keys)65614:
                    case Keys.N:
                    case (Keys)65615:
                    case Keys.O:
                    case (Keys)65616:
                    case Keys.P:
                    case (Keys)65617:
                    case Keys.Q:
                    case (Keys)65618:
                    case Keys.R:
                    case (Keys)65619:
                    case Keys.S:
                    case (Keys)65620:
                    case Keys.T:
                    case (Keys)65621:
                    case Keys.U:
                    case (Keys)65622:
                    case Keys.V:
                    case (Keys)65623:
                    case Keys.W:
                    case (Keys)65624:
                    case Keys.X:
                    case (Keys)65625:
                    case Keys.Y:
                    case (Keys)65626:
                    case Keys.Z:
                    case Keys.NumPad0:
                    case Keys.NumPad1:
                    case Keys.NumPad2:
                    case Keys.NumPad3:
                    case Keys.NumPad4:
                    case Keys.NumPad5:
                    case Keys.NumPad6:
                    case Keys.NumPad7:
                    case Keys.NumPad8:
                    case Keys.NumPad9:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                    case System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space:
                        FilterString += ((char)keyData).ToString();
                        ShowIntellisense();
                        return false;
                    case Keys.Delete:
                    case Keys.Left:
                    case Keys.Right:
                        return true;
                    default:
                        if (ShowingIntellisense)
                            return true;
                        else
                            return false;
                }
                #endregion
            }
            else
            {
                #region Switch para saber que se va a mostrar cuando se quiera hacer intellisense
                switch (keyData)
                {
                    case Keys.Control | Keys.OemPeriod://ctrl + . , forzar muestra de intellisense
                    case Keys.Space | Keys.Control://ctrl + space, forzar muestra de intellisense
                        CurrentFilter = FilteringTypeValues.All;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        //   FireAt = CurOffset;
                        ShowIntellisense();
                        return true;
                    case Keys.Space:
                        string WordBehind = GetWordAtOffset();
                        int auxoffset2 = TCodigo.Document.PositionToOffset(TCodigo.ActiveTextAreaControl.Caret.Position);
                        if (WordBehind.Equals("FROM", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("JOIN", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("UPDATE", StringComparison.CurrentCultureIgnoreCase))
                        {//si es un FROM o un ON sacar la lista de tablas y vistas
                            TCodigo.Document.Insert(auxoffset2, " ");
                            TCodigo.ActiveTextAreaControl.Caret.Column += 1;
                            auxoffset2++;
                            CurOffset = auxoffset2;

                            CurrentFilter = FilteringTypeValues.Fields;
                            FilterString = "";
                            FireAt = CurOffset;
                            CargaTablasVistas();
                            ShowIntellisense();
                            return true;
                        }
                        else if (WordBehind.Equals("DELETE", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("UPDATE", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("INTO", StringComparison.CurrentCultureIgnoreCase))
                        {//si es un DELETE, un UPDATE o un INTO sacar la lista de tablas
                            TCodigo.Document.Insert(auxoffset2, " ");
                            TCodigo.ActiveTextAreaControl.Caret.Column += 1;
                            auxoffset2++;
                            CurOffset = auxoffset2;

                            CurrentFilter = FilteringTypeValues.Fields;
                            FilterString = "";
                            FireAt = CurOffset;
                            CargaTablas();
                            ShowIntellisense();
                            return true;
                        }
                        else if (WordBehind.Equals("INSERT", StringComparison.CurrentCultureIgnoreCase))
                        {//si es un DELETE, un UPDATE o un INTO sacar la lista de tablas
                            Formularios.FormBuscarTabla dlg = new Formularios.FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
                            if (dlg.ShowDialog() == DialogResult.Cancel)
                                return false;
                            //obtengo la poicion del insert
                            //ahora me regreso hasta encontrar un enter o el inicio de liena
                            int pos = TCodigo.Document.PositionToOffset(TCodigo.ActiveTextAreaControl.Caret.Position);
                            int linea = TCodigo.Document.GetLineNumberForOffset(pos); 
                            string s2 = TCodigo.Document.GetText(TCodigo.Document.GetLineSegment(linea));//TCodigo.Lines[linea];
                            string Tabuladores = "";
                            //cuento el numero de tabuladores
                            int i, n;
                            n = s2.Length;
                            for (i = 0; i < n; i++)
                            {
                                if (s2[i] != '\t' && s2[i] != ' ')
                                {
                                    break;
                                }
                                Tabuladores = Tabuladores + s2[i];
                            }
                            //--------------------------------------------------------------------
                            TCodigo.Document.Insert(pos," "+dlg.DameInsert(Tabuladores, ""));
                            return true;
                        }
                        //else if (WordBehind.Equals("EXEC", StringComparison.CurrentCultureIgnoreCase) || WordBehind.Equals("EXECUTE", StringComparison.CurrentCultureIgnoreCase))
                        //{//si es un EXEC o un EXECUTE la lista de sps
                        //    TCodigo.Document.Insert(auxoffset2, " ");
                        //    TCodigo.ActiveTextAreaControl.Caret.Column += 1;
                        //    auxoffset2++;
                        //    CurOffset = auxoffset2;

                        //    CurrentFilter = FilteringTypeValues.Sps;
                        //    FilterString = "";
                        //    FireAt = CurOffset;
                        //    ShowIntellisense();
                        //    return true;
                        //}
                        return false;
                    case Keys.OemPeriod:
                    case Keys.Decimal:
                        return ValidaPunto();
                    case Keys.T | Keys.Control://ctrl + t , mostrar tablas + vistas
                        CurrentFilter = FilteringTypeValues.Fields;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        FireAt = CurOffset;
                        ShowIntellisense();
                        break;
                    case Keys.P | Keys.Control://ctrl + p , mostrar procedimientos almacenados
                        CurrentFilter = FilteringTypeValues.Sps;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        FireAt = CurOffset;
                        ShowIntellisense();
                        break;
                    case Keys.D | Keys.Control://ctrl + d , mostrar variables 
                        CurrentFilter = FilteringTypeValues.Variables;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        FireAt = CurOffset;
                        AddVariables();
                        ShowIntellisense();
                        return true;
                    case Keys.Control | Keys.Q | Keys.Alt ://aroba, @
                        //case Keys.RButton | Keys.ShiftKey | Keys.Space | Keys.Control | Keys.Alt:
//                        TCodigo.Document.Insert(CurOffset, "@");
                        CurrentFilter = FilteringTypeValues.Variables;
                        CurWord = GetWordAtOffsetMinusOne();
                        FilterString = CurWord;
                        FireAt = CurOffset;
                        WordBehind = GetWordAtOffset();
                        auxoffset2 = TCodigo.Document.PositionToOffset(TCodigo.ActiveTextAreaControl.Caret.Position);
                        if (AddVariables() == false)
                            return false;
                        //ShowIntellisense();

                        ///------------
                        ///                            TCodigo.Document.Insert(auxoffset2, " ");
                       // TCodigo.ActiveTextAreaControl.Caret.Column += 1;
                       // auxoffset2++;
                        CurOffset = auxoffset2;
                        FilterString = "";
                        FireAt = auxoffset2;
                        ShowIntellisense();

                        return true ;
                    case Keys.S | Keys.Control://ctrl + s , mostrar snippets
                        MessageBox.Show("Ctr + S");
                        break;
                }
                #endregion
            }
            #endregion
           // MessageBox.Show(keyData.ToString ());
            return false;
        }
        ICSharpCode.TextEditor.TextLocation CurPos;
        int CurOffset;
        private string GetWordAtOffset()
        {
            ICSharpCode.TextEditor.Document.TextWord CW;

            CW = TCodigo.Document.GetLineSegment(TCodigo.ActiveTextAreaControl.Caret.Line).GetWord(TCodigo.ActiveTextAreaControl.Caret.Column);
            if (CW != null && CW.Word.Trim().Length > 0)
            {
                CurPos = new ICSharpCode.TextEditor.TextLocation(CW.Offset, TCodigo.ActiveTextAreaControl.Caret.Line);
                CurOffset = TCodigo.Document.PositionToOffset(CurPos);
            }
            else
            {
                if (TCodigo.ActiveTextAreaControl.Caret.Column > 0)
                    CW = TCodigo.Document.GetLineSegment(TCodigo.ActiveTextAreaControl.Caret.Line).GetWord(TCodigo.ActiveTextAreaControl.Caret.Column - 1);
                if (CW != null && CW.Word.Trim().Length > 0)
                {
                    CurPos = new ICSharpCode.TextEditor.TextLocation(CW.Offset, TCodigo.ActiveTextAreaControl.Caret.Line);
                    CurOffset = TCodigo.Document.PositionToOffset(CurPos);
                }
                else
                {
                    CurPos.X = TCodigo.ActiveTextAreaControl.Caret.Column;
                    CurPos.Y = TCodigo.ActiveTextAreaControl.Caret.Line;
                    CurOffset = TCodigo.Document.PositionToOffset(CurPos);
                }
            }
            return CW == null ? "" : CW.Word;
        }
        private string GetWordAtOffsetMinus(int BackSpaces)
        {
            ICSharpCode.TextEditor.Document.TextWord CW;

            if (TCodigo.ActiveTextAreaControl.Caret.Column - BackSpaces >= 0)
                CW = TCodigo.Document.GetLineSegment(TCodigo.ActiveTextAreaControl.Caret.Line).GetWord(TCodigo.ActiveTextAreaControl.Caret.Column - BackSpaces);
            else
                return "";

            if (CW != null && CW.Word.Trim().Length > 0)
            {
                ;
            }
            else
            {
                if (TCodigo.ActiveTextAreaControl.Caret.Column > 0)
                    CW = TCodigo.Document.GetLineSegment(TCodigo.ActiveTextAreaControl.Caret.Line).GetWord(TCodigo.ActiveTextAreaControl.Caret.Column - BackSpaces);
            }
            return CW == null ? "" : CW.Word;
        }
        public void ShowIntellisense()
        {
            if (ShowingIntellisense)
            {
                ISense.Close();
            }
            ///-----------------
            ///-----------
            Filtro = FilterString;
            tipo = CurrentFilter;           
            ISense = AutoCompleteWindow.ShowCompletionWindow(this.ParentForm, TCodigo, FilterString, this, ' ', FireAt, FireAt + FilterString.Length);

            if (ISense != null)
            {
                CancelClose = true;
                ISense.Closing += ISense_Closing;
                ISense.Closed += CodeCompletionWindowClosed;
            }
        }
        public bool AddVariables()
        {
            if (Vars == null)
                Vars = new List<Variables>();
            else
                Vars.Clear();
            //   List<string> Cadenas = new List<string>();
            Filtro = "@";
            //  Cadenas.Clear();
            // PosIni = SelectionStart - 1;
            //  contextMenuStrip1.Items.Clear();
            List<AnalizadorLexico.CLexema> Lexemas;
            //cargo todos los lexemas del codigo en la lista
            Lexemas = new List<AnalizadorLexico.CLexema>();
            cAnaLex1.Texto = TCodigo.Text;
            AnalizadorLexico.CLexema lex = null;
            AnalizadorLexico.CLexema UltimoLex = null;
            do
            {
                lex = cAnaLex1.DameItem();
                if (lex != null)
                {
                    //checo si es una variable
                    if (lex.Tipo == AnalizadorLexico.TIPO_LEX.VARIABLE)
                    {
                        ToolStripItem nodo;
                        //checo si no se repite
                        int i, n;
                        n = Vars.Count;
                        bool encontrado = false;
                        for (i = 0; i < n; i++)
                        {
                            if (Vars[i].Text.ToUpper() == lex.cadena.ToUpper())
                            {
                                encontrado = true;
                                break;
                            }
                        }
                        if (encontrado == false)
                        {
                            //Aux.Add(ToAdd.ToLower());
                            Variables tmp = new Variables(lex.cadena);//.Substring(1));
                            Vars.Add(tmp);
                            //                            nodo = contextMenuStrip1.Items.Add(lex.cadena);
                            //                          nodo.Click += new EventHandler(OnMenu_Click3);
                        }
                    }
                    else
                    {
                        //me traigo el ultimo item que esta antes del
                        if (lex.Pos < CurOffset)
                            UltimoLex = lex;
                    }
                }
            }
            while (lex != null);
            if (Vars.Count == 0)
                return false; //no hay variables que mostrar y hay que dejar que escriba el @
            if (UltimoLex != null)
            {
                if (UltimoLex.cadena.ToUpper() == "DECLARE")
                    return false;
            }
            //reviso si en la linea actual se esta creando un procedimiento almacenado
            int lienaActual = TCodigo.Document.GetLineNumberForOffset(CurOffset);
            cAnaLex1.Texto = TCodigo.Document.GetText(TCodigo.Document.GetLineSegment(lienaActual));
            //busco si existe las palabra procedure ya que puede ser que se este actualizando o creando
            do
            {
                lex = cAnaLex1.DameItem();
                if (lex != null)
                {
                    if (lex.cadena.ToUpper() == "PROCEDURE")
                        return false;
                    if (lex.cadena.ToUpper() == "DECLARE") //es muy probable que se esten declarando varias variables
                        return false;
                }
            }
            while (lex != null);
            //asigno la lista de elementos a mostrar
            listaElementos.Clear();
            foreach (Variables v in Vars)
            {
                CObjetoInteliences obj = new CObjetoInteliences();
                obj.TipoObjeto = Controladores_DB.TIPOOBJETO.NINGUNO;
                obj.Nombre =v.Text;
                listaElementos.Add(obj);
            }
            return true;
        }
        #endregion
        private bool EstaEnCometario(int pos)
        {
            //revisa si la pocicion dada esta dentro de un comentario
            cAnaLex1.Texto = TCodigo.Text;
            AnalizadorLexico.CLexema lex = null;
            do
            {
                lex = cAnaLex1.DameItem();
                if (lex == null)
                    return false;
                if (lex.Tipo == AnalizadorLexico.TIPO_LEX.COMENTARIO)
                {
                    if (pos >= lex.Pos && pos <= (lex.Pos + lex.cadena.Length))
                    {
                        //esta dentro de un comentario
                        return true;
                    }
                }
            }
            while (lex != null);
            return false;
        }
        private bool ValidaPunto()
        {
            FilterString = "";
            Filtro = "";
            bool Encontrado = false; //se usa en caso de que ya me pase despues del puno y no he encontrado la tabala o alias al que hace referencia
            int statusalias = 0;
            if (Aliases == null)
                Aliases = new Hashtable();
            else
                Aliases.Clear();

            string NobreTablaAlias="";
            string NombreAlias="";
            Objetos.CSysObject tabla = null;
            CargaTablasVariables();
            //Aqui se apreto el punto y hay que revisar si hay que poner la lista de campos de alguna tabla, vista o nada
            //me traigo la pocicion donde esta el punto
            int pos = TCodigo.Document.PositionToOffset(TCodigo.ActiveTextAreaControl.Caret.Position);
            TCodigo.Document.Insert(pos, ".");
            TCodigo.ActiveTextAreaControl.Caret.Column += 1;
            //analizo la cadena hasta el punto
            cAnaLex1.Texto = TCodigo.Text;
            AnalizadorLexico.CLexema lex = null;
            AnalizadorLexico.CLexema lexAnterior = null; //este va almacenar el item que esta anterior al punto
            do
            {
                //me traigo el item 
                lex = cAnaLex1.DameItem();
                if (lex == null)
                    return true; //regreso porque no encontre nada util
                //veo si es un comentario o una cadena
                if (lex.Tipo == AnalizadorLexico.TIPO_LEX.COMENTARIO || lex.Tipo == AnalizadorLexico.TIPO_LEX.CADENA)
                {
                    //veo si mi punto esta dentro del comentario o cadena
                    if (pos >= lex.Pos && pos <= (lex.Pos + lex.cadena.Length))
                    {
                        //esta dentro de un comentario o una cadena,  por lo que no hago nada
                        return true;
                    }
                }
                //no esta dentro de un comentario ni cadena,
                //ahora reviso si ya me pase del punto
                if (pos - 1 < lex.Pos)
                {
                    //ya me pase, por lo que el lexema anterior es el que tiene el punto asociado
                    if (lexAnterior == null)
                    {
                        //al parecer solo fue un punto solitario y no hay nada que hacer
                        return true;
                    }
                    //reviso si el lexema anterior es un identificador
                    if (lexAnterior.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                    {
                        //si es unchecked identificador
                        //ahora hay que ver si es una vista o una tabla dicho identificador
                        tabla = DB.DameTablaVista(lexAnterior.cadena);
                        //lo busco entre la lista que me traje
                        if (tabla != null && tabla.Nombre.ToUpper().Trim() == lexAnterior.cadena.ToUpper().Trim())
                        {
                            //es una tabla o vista
                            //mando a llamar al inteliences para que muestre los campos de la tabla
                            CurrentFilter = FilteringTypeValues.Childs;
                            FilterString = "";
                            NombreTabla = tabla.Nombre;
                            FireAt = CurOffset;
                            CargaCamposTabla(NombreTabla);
                            ShowIntellisense();
                            return true;
                        }
                        //no es una tabla, por lo que lo mas probable es que sea un alias de alguna tabla
                        //reviso la tabla de alias encontrados
                        if (Aliases.Count != 0)
                        {
                            if (Aliases.ContainsKey(lexAnterior.cadena) == true)
                            {
                                NombreTabla = Aliases[lexAnterior.cadena].ToString();
                                if (NombreTabla == null || NombreTabla == "")
                                {
                                    //no es un alias, por lo que no hago nada
                                    return true;
                                }
                                //mando a llamar al inteliences para que muestre los campos de la tabla
                                CurrentFilter = FilteringTypeValues.Childs;
                                FilterString = "";
                                FireAt = CurOffset;
                                CargaCamposTabla(NombreTabla);
                                ShowIntellisense();
                                return true;
                            }
                        }
                    }
                   // return true; //ya me pase y no encontre nada
                    if (lexAnterior != null)
                        Encontrado = true;
                }
                if(Encontrado==false)
                    lexAnterior = lex;
                //mo me he pasado del punto,
                //veo si el lexema es un identificador o una variable
                if (lex.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR|| lex.Tipo== AnalizadorLexico.TIPO_LEX.VARIABLE)
                {
                    //es un identificador
                    //checo si esuna tabla o vista
                    switch (statusalias)
                    {
                        case 0:
                            if (lex.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                            {
                                tabla = DB.DameTablaVista(lex.cadena);
                                if (tabla != null)
                                {
                                    //es una tabla y posiblemente un alias
                                    //creo el alias
                                    NobreTablaAlias = tabla.Nombre;
                                    //cambio el status al estado 1:
                                    statusalias = 1;
                                }
                            }
                            if (lex.Tipo == AnalizadorLexico.TIPO_LEX.VARIABLE)
                            {
                                //posiblemnete sea una tabla variable
                                foreach (Objetos.CTablaVariable tb in TablasVariable)
                                {
                                    if (lex.cadena == tb.Nombre)
                                    {
                                        //es una tabla variable
                                        NobreTablaAlias = lex.cadena;
                                        //cambio el status al estado 1:
                                        statusalias = 1;
                                    }
                                }
                            }
                            break;
                        case 1:
                            //detecte un alias
                            NombreAlias = lex.cadena;
                            bool encontrado = false;

                            if (Aliases.ContainsKey(NombreAlias) == true)
                            {
                                //ya existe, porlo que hay que actualizarlo
                                Aliases.Remove(NombreAlias);
                            }
                            Aliases.Add(NombreAlias, NobreTablaAlias);
                            //reinicio el proceso
                            NobreTablaAlias = "";
                            NombreAlias = "";
                            statusalias = 0;
                            break;
                        case 2:
                            //ok es posible que sea un alias, pero tengo que revisar si es una palabra reservada
                            //no es palabra reservada, porlo que acompleto el alias y lo agrego a la lista de alias
                            NombreAlias = lex.cadena;
                            encontrado = false;
                            if (Aliases.ContainsKey(NombreAlias) == true)
                            {
                                //ya existe, porlo que hay que actualizarlo
                                Aliases.Remove(NombreAlias);
                            }
                            Aliases.Add(NombreAlias, NobreTablaAlias);
                            //reinicio el proceso
                            NobreTablaAlias = "";
                            NombreAlias = "";
                            statusalias = 0;
                            break;
                    }
                }
                else if (lex.Tipo == AnalizadorLexico.TIPO_LEX.PALABRA_RESERVADA)
                {
                    //aqui se espera la palabra as o el alias en si
                    if (statusalias == 1 && lex.cadena.ToUpper().Trim() == "AS")
                    {
                        //solamente paso al punto2
                        statusalias = 2;
                    }
                    else
                    {
                        //reinicio el proceso
                        NobreTablaAlias = "";
                        NombreAlias = "";
                        statusalias = 0;
                    }

                }
                else
                {
                    //es otra cosa
                    statusalias = 0;
                }
            }
            while (lex != null);
            return true;
        }
        private bool EsPalabraReservada(string palabra)
        {
            //recorre la lista de palabras reservadas y si coincide con alguna de ellas, regresa true
            foreach (string s in ReservedWords)
            {
                if (s.ToUpper().Trim() == palabra.ToUpper().Trim())
                    return true;
            }
            return false;
        }
        private void CargaTablas()
        {
            listaElementos.Clear();
            List<Objetos.CSysObject> objetos = null;
            objetos = DB.BuscaObjetos("", Controladores_DB.TIPOOBJETO.TABLAX);
            foreach (Objetos.CSysObject obj in objetos)
            {
                CObjetoInteliences dato = new CObjetoInteliences();
                dato.TipoObjeto = obj.TipoObjeto;
                dato.Nombre = obj.Nombre;
                listaElementos.Add(dato);
            }
            //ahora agrego las tablas variables
            CargaTablasVariables();
            foreach (Objetos.CTablaVariable tabla in TablasVariable)
            {
                CObjetoInteliences dato = new CObjetoInteliences();
                dato.TipoObjeto = Controladores_DB.TIPOOBJETO.TABLAX;
                dato.Nombre = tabla.Nombre;
                listaElementos.Add(dato);
            }
        }
        private void CargaTablasVistas()
        {
            listaElementos.Clear();
            List<Objetos.CSysObject> objetos=null;
            objetos = DB.BuscaObjetos("", Controladores_DB.TIPOOBJETO.VISTAS_TABLAS);
            foreach (Objetos.CSysObject obj in objetos)
            {
                CObjetoInteliences dato = new CObjetoInteliences();
                dato.TipoObjeto = obj.TipoObjeto;
                dato.Nombre = obj.Nombre;
                listaElementos.Add(dato);
            }
            //ahora agrego las tablas variables
            CargaTablasVariables();
            foreach (Objetos.CTablaVariable tabla in TablasVariable)
            {
                CObjetoInteliences dato = new CObjetoInteliences();
                dato.TipoObjeto = Controladores_DB.TIPOOBJETO.TABLAX;
                dato.Nombre = tabla.Nombre;
                listaElementos.Add(dato);
            }
        }
        private void CargaCamposTabla(string tabla)
        {
            listaElementos.Clear();
            List<Objetos.CParametro> campos;
            campos = DB.DameCamposTabla(tabla, Filtro);
            foreach (Objetos.CParametro p in campos)
            {
                CObjetoInteliences obj = new CObjetoInteliences();
                obj.TipoObjeto = Controladores_DB.TIPOOBJETO.CAMPOS_TABLA;
                obj.Nombre = p.nombre;
                listaElementos.Add(obj);
            }
            //es pisible que sea una tabla variable
            if (tabla[0] == '@')
            {
                //es una tabla variable
                //pido analizar todas las tablas variables
                CargaTablasVariables();
                //ahora busco la tabla
                foreach (Objetos.CTablaVariable objt in TablasVariable)
                {
                    if (objt.Nombre == tabla)
                    {
                        //ya la encontre, ahora agrego sus campos
                        foreach (string s in objt.Campos)
                        {
                            CObjetoInteliences obj = new CObjetoInteliences();
                            obj.TipoObjeto = Controladores_DB.TIPOOBJETO.CAMPOS_TABLA;
                            obj.Nombre = s;
                            listaElementos.Add(obj);
                        }
                    }
                }
            }
        }
        private void CargaTablasVariables()
        {
            //analiza el codigo y busca las declaraciones de tablas variables
            Objetos.CTablaVariable Tabla=null;
            cAnaLex1.Texto = TCodigo.Text;
            if (TablasVariable == null)
            {
                TablasVariable = new List<Objetos.CTablaVariable>();
            }
            else
            {
                TablasVariable.Clear();
            }
            AnalizadorLexico.CLexema lex = null;
            int estado = 0;
            do
            {
                lex = cAnaLex1.DameItem();
                if (lex == null)
                    return;
                switch (estado)
                {
                    case 0:
                        //en este estado espero la palabra reservada declare
                        if (lex.Tipo == AnalizadorLexico.TIPO_LEX.PALABRA_RESERVADA)
                        {
                            if (lex.cadena.ToUpper() == "DECLARE")
                            {
                                //es la palabra declare
                                //es la palabra declare y me paso al estatus 1
                                estado = 1;
                            }
                        }
                        break;
                    case 1:
                        //aqui espero una variable
                        if (lex.Tipo == AnalizadorLexico.TIPO_LEX.VARIABLE)
                        {
                            //asigno el nombre dela tabla, eso presumiendo que si es una taba
                            Tabla = new Objetos.CTablaVariable();
                            Tabla.Nombre = lex.cadena;
                            estado = 2;
                        }
                        else
                        {
                            //no es una variable asi que reinicio la busqueda
                            estado = 0;
                        }
                        break;
                    case 2:
                        //en este estado espero la palabra clave table o la palabra clave as
                        if (lex.Tipo == AnalizadorLexico.TIPO_LEX.PALABRA_RESERVADA)
                        {
                            if (lex.cadena.ToUpper() == "TABLE")
                            {
                                //es uan tabla
                                estado = 4;
                            }
                            else if (lex.cadena.ToUpper() == "AS")
                            {
                                estado = 3;
                            }
                            else
                            {
                                //no es por lo que reinicio el analisis
                                estado = 0;
                            }
                        }
                        else
                        {
                            estado = 0;
                        }
                        break;
                    case 3:
                        //aqui espero lapalabra reservada table
                        if (lex.Tipo == AnalizadorLexico.TIPO_LEX.PALABRA_RESERVADA)
                        {
                            if (lex.cadena.ToUpper() == "TABLE")
                            {
                                estado = 4;
                            }
                            else
                            {
                                estado = 0;
                            }
                        }
                        else
                        {
                            estado = 0;
                        }
                        break;
                    case 4:
                        //aqui espero un parentesis que abre
                        if (lex.cadena == "(")
                        {
                            estado = 5;
                        }
                        else
                        {
                            estado = 0;
                        }
                        break;
                    case 5:
                        //aqui espero el nombre de un campo
                        if (lex.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                        {
                            //como no analizo el tipo, solo lo agrego
                            Tabla.Add(lex.cadena);
                            estado = 6;
                        }
                        else
                        {
                            estado = 0;
                        }
                        break;
                    case 6:
                        //aqui no me interesa que hay
                        estado = 7;
                        break;
                    case 7:
                        //aqui espero los siguientes itms
                        //puede ser ) para terminar la tabla
                        //puede ser , para agregar otro campo
                        //puede ser ( para asignar un tamaño
                        if (lex.cadena == ")")
                        {
                            //aqui se termino de encontrar la tabla variable
                            //agrego la tabla a la lista de tablas
                            TablasVariable.Add(Tabla);
                            // y reinicio el analisis
                            estado = 0;
                        }
                        else if (lex.cadena == ",")
                        {
                            //aqui se puso una coma y hay que agregar un nuevo campo
                            estado = 5;
                        }
                        else if (lex.cadena == "(")
                        {
                            //aqui se espera el tamaño
                            estado = 8;
                        }
                        else if (lex.Tipo == AnalizadorLexico.TIPO_LEX.PALABRA_RESERVADA)
                        {
                            estado = 7; //se queda en el mismo lugar 
                        }
                        else
                        {
                            //como puede aver varias cosas mejor que se quede aqui
                            estado = 7;
                        }
                        break;
                    case 8:
                        //aqui se espera un numero que significa el tamaño del campo, pero no me interesa
                        estado = 9;
                        break;
                    case 9:
                        //aqui espero el )
                        if (lex.cadena == ")")
                        {
                            estado = 10;
                        }
                        else
                        {
                            //regreso al analisis de campos
                            estado = 5;
                        }
                        break;
                    case 10:
                        //aqui espero los siguientes items
                        //un ) que me indica que ya termino de declararce la tabla
                        // una , significa que hay que agregar otro campo a la tabla
                        if (lex.cadena == ")")
                        {
                            //aqui se termino de encontrar la tabla variable
                            //agrego la tabla a la lista de tablas
                            TablasVariable.Add(Tabla);
                            // y reinicio el analisis
                            estado = 0;
                        }
                        else if (lex.cadena == ",")
                        {
                            estado = 5;
                        }
                        else
                        {
                            //aqui puede aver un error, asi que reinicio el analisis
                            estado = 0;
                        }
                        break;
                }
            }
            while (lex != null);
        }
    }
}
