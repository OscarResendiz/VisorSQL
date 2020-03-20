using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections ;
using System.Linq;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using System.Diagnostics;

namespace Visor_sql_2015.Editor
{
    public delegate void OnMuestraGridsEvent(DataSet ds, string Msg);
    public delegate void OnCodigoSPEvent(string Nombre, string Codigo);
    public delegate void OnMuestraErrorEvent(CErrorQuery obj, TextEditX ed);
    public delegate void OnLimpiaResultadosEvent();
    public delegate void OnBuscarTextoEvent(string texto);
    public partial class TextEditX : EditorGenerico
    {
        #region Codigo Agregado /*Gonzalo*/
        delegate void LLenarGrid();
        LLenarGrid GetResults;
        #endregion
        private bool FGuardado;
        private int checkPrint;
        //int PosIni;
        private List<string> Cadenas;
        string Filtro;
        private bool ControlV;
        private int ControlVI;
        private string Tabuladores;
        int RataX, RataY;
        public event Formularios.OnVerObjetoEvent OnVerObjeto;
        public event OnMuestraErrorEvent OnMuestraError;
        public event OnLimpiaResultadosEvent OnLimpiaResultados;
        public event OnMuestraGridsEvent OnMuestraGrids;
        public event OnCodigoSPEvent OnCodigoSP;
        public event OnCodigoSPEvent OnDependencias;
        public event OnCodigoSPEvent OnDependientes;
        public event OnBuscarTextoEvent OnBuscarTexto;
        public event SelectTabByNameEvent SelectEdicion;
        Controladores_DB.IDataBase DB;
        public TextEditX(string Nombre, Controladores_DB.IDataBase db)
        {
            Cadenas = new List<string>();
            Filtro = "";
            #region Cambio de asignacion de 1 solo objeto de conexion, a un obtejo de conexion para cada texto
            DB = db;
            DB = db.Clona();
	        #endregion
            InitializeComponent();
            _search = new TextEditorSearcher();
            _search.Document = TCodigo.Document;
            inteliences1.DB = DB;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            ICSharpCode.TextEditor.Document.FileSyntaxModeProvider provider = new ICSharpCode.TextEditor.Document.FileSyntaxModeProvider(appPath);
            ICSharpCode.TextEditor.Document.HighlightingManager.Manager.AddSyntaxModeFileProvider(provider);
            TCodigo.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter("SQL");
            TCodigo.Document.FoldingManager.FoldingStrategy = new Ez_SQL.Clases.TxtEditor.SQLFoldingStrategy();
            TCodigo.Document.FoldingManager.UpdateFoldings(null, null);
            TNombre.Text = Nombre;
            Text = Nombre;
            CargaColor();
            Lfecha.Text = "Fecha de modificacion: " + DB.DameFechaModificacion(TNombre.Text);
            TCodigo.Text = DB.DameCodigo(TNombre.Text);
            //Codigo agregado para manejar querys asincronos
            DB.BeginningQuery += new Visor_sql_2015.Controladores_DB.ProcessingQuery(DB_BeginningQuery);
            DB.EndingQuery += new Visor_sql_2015.Controladores_DB.ProcessingQuery(DB_EndingQuery);
            GetResults = new LLenarGrid(ObtenResultados);
            FGuardado = true;
            //agrego eventos
            TCodigo.ActiveTextAreaControl.TextArea.KeyDown+=new System.Windows.Forms.KeyEventHandler(TCodigo_KeyDown);
            TCodigo.ActiveTextAreaControl.TextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(TCodigo_KeyUp);
            

            
            
        }
        private void FormSP_Load(object sender, EventArgs e)
        {
            Lfecha.Text = "Fecha de modificacion: " + DB.DameFechaModificacion(TNombre.Text);
            TCodigo.Text = DB.DameCodigo(TNombre.Text);
        }
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void BToCSharp_Click(object sender, EventArgs e)
        {
            if (TNombre.Text.Trim() != "")
            {
                CreaCodigoProcedimiento();
            }
            else
            {

                string s = Cid_Utilities.CidString.SQLSent_To_CSharpStr(TCodigo.Text);
                if (OnCodigoSP != null)
                    OnCodigoSP("", s);
            }
        }
        private bool TipoBasico(string s)
        {
            if (s == "int")
                return true;
            if (s == "float")
                return true;
            if (s == "string")
                return true;
            if (s == "bool")
                return true;
            return false;
        }
        private void CreaCodigoProcedimiento()
        {
            string NombreProcedimiento;
            System.Collections.Generic.List<Objetos.CParametro> CamposARegresar;
            Formularios.FormProcedimiento dlg = new Formularios.FormProcedimiento(DB, TNombre.Text);
            dlg.Nombre = TNombre.Text;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            NombreProcedimiento = TNombre.Text;
            if (dlg.Nombre == TNombre.Text)
                NombreProcedimiento = "SqlCommand1";
            //obtengo la lista de parametros de la funcion
            System.Collections.Generic.List<Objetos.CParametro> Parametros = DB.DameParametrosDeProcedimiento(TNombre.Text);
            string s;
            //creo la cabecera de la funcion
            s = "#region ";
            string s2 = "";
            if (dlg.Estatica == true)
                s2 = s2 + "public static " + dlg.Retorno + " " + dlg.Nombre + "(";
            else
                s2 = s2 + "public " + dlg.Retorno + " " + dlg.Nombre + "(";
            Objetos.CConvertidor conv = new Objetos.CConvertidor();
            int i, n;
            n = Parametros.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro pa = Parametros[i];
                if (i > 0)
                    s2 = s2 + ",";
                s2 = s2 + pa.DameCadena();
            }
            s2 = s2 + ")\r\n";
            s += s2 + s2;
            s += "{\r\n";
            if (dlg.TipoRetornoX == ENUMTipoRetorno.LISTA_GENERICA)
                s += "\t\tSystem.Collections.Generic.List<" + dlg.Clase + "> lista=new System.Collections.Generic.List<" + dlg.Clase + ">();\r\n";
            if (dlg.TipoRetornoX == ENUMTipoRetorno.LISTA)
                s += "\t\tSystem.Collections.ArrayList lista=new System.Collections.ArrayList();\r\n";
            if (dlg.TipoRetornoX == ENUMTipoRetorno.DATO)
                s += "\t\t" + dlg.Clase + " dato=null;\r\n";
            n = Parametros.Count;
            if (dlg.CrearSqlConnection)
            {
                s += "\t//Creando el componente de conexión\r\n";
                s += "\tSystem.Data.SqlClient.SqlConnection Conexion;";
                s += "\tConexion = new System.Data.SqlClient.SqlConnection();\r\n";
                if (dlg.LeerConfiguracionASP)
                {
                    s += "\tSystem.Configuration.ConnectionStringSettings cs = System.Configuration.ConfigurationManager.ConnectionStrings[\"" + dlg.SConnectionStrings + "\"];\r\n";
                    s += "\tConexion.ConnectionString = ConvierteCadena(cs.ConnectionString);\r\n";
                }
                else
                {
                    s += "\t//Conexion.ConnectionString =Colocar la cadena de conexion aqui\r\n";
                }
            }

            if (dlg.CrearComponente)
            {
                s += "\t//CREANDO EL PROCEDIMIENTO ALMACENADO " + TNombre.Text + "\r\n";
                s += "\r\n";
                s += "\tSystem.Data.SqlClient.SqlCommand " + NombreProcedimiento + ";\r\n";
                s += "\t" + NombreProcedimiento + "= new System.Data.SqlClient.SqlCommand();\r\n";
                s += "\t" + NombreProcedimiento + ".CommandText = \"[" + TNombre.Text + "]\";\r\n";
                s += "\t" + NombreProcedimiento + ".CommandType = System.Data.CommandType.StoredProcedure;\r\n";
                if (dlg.Estatica == true)
                    s += "\t" + NombreProcedimiento + ".Connection = Conexion;//remplzar por el componente de conexion adecuado\r\n";
                else
                    s += "\t" + NombreProcedimiento + ".Connection = this.Conexion;//remplzar por el componente de conexion adecuado\r\n";
                s += "\r\n";
                s += "\t//CREANDO PARAMETROS\r\n";
                s += "\r\n";
                s += "\t" + NombreProcedimiento + ".Parameters.Add(new System.Data.SqlClient.SqlParameter(\"@RETURN_VALUE\", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), \"\", System.Data.DataRowVersion.Current, null));\r\n";
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro pa = Parametros[i];
                    s += "\t" + NombreProcedimiento + ".Parameters.Add(new System.Data.SqlClient.SqlParameter(\"" + pa.nombre + "\"," + pa.TipoNet + "," + pa.Logitud + "));\r\n";
                }
            }
            //asigno parametros
            s += "\r\n";
            s += "\t//ASIGNANDO PARAMETROS\r\n";
            s += "\r\n";
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro pa = Parametros[i];
                s += "\t" + NombreProcedimiento + ".Parameters[\"" + pa.nombre + "\"].Value=" + pa.nombreC + ";\r\n";
            }
            s += "\t" + NombreProcedimiento + ".Connection.Open();\r\n";
            s += "\ttry\r\n";
            s += "\t{\r\n";
            if (dlg.RegresaDatos == false)
            {
                s += "\t\t" + NombreProcedimiento + ".ExecuteNonQuery();\r\n";
                s += "\t}\r\n";
                s += "\tcatch(System.Data.SqlClient.SqlException ex)\r\n";
                s += "\t{\r\n";
                s += "\t\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                if (ThrowEx.Checked)
                    s += "\t\tthrow new Exception(ex.Errors[0].Message);\r\n";
                else
                    s += "\t\tSystem.Windows.Forms.MessageBox.Show(ex.Errors[0].Message, \"" + TNombre.Text + "\", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);\r\n";
                s += "\t}\r\n";
                s += "\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "}\r\n";
                s += "#endregion\r\n";

                Clipboard.Clear();
                Clipboard.SetText(s);
                MessageBox.Show("Codigo C# Pegado al Portapapeles");

                if (OnCodigoSP != null)
                    OnCodigoSP(TNombre.Text + " C#", s);
                return;
            }
            //regresa datos
            if (dlg.TipoRetornoX == ENUMTipoRetorno.DATO)
            {
                //hay que regresar un dato
                s += "\t\t//RECUPERANDO DATOS\r\n";
                s += "\t\tSystem.Data.SqlClient.SqlDataReader dr;\r\n";
                s += "\t\tdr=" + NombreProcedimiento + ".ExecuteReader();\r\n";
                s += "\t\tif(dr.Read())\r\n";
                s += "\t\t{\r\n";
                if (TipoBasico(dlg.Clase) == false)
                    s += "\t\t\tdato=new " + dlg.Clase + "();\r\n";
                CamposARegresar = dlg.CamposRegresar;
                n = CamposARegresar.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro par = CamposARegresar[i];
                    if (par.TipoNet == "int")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\t\tdato." + par.nombre + "=int.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        else
                            s += "\t\t\t\tdato=int.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\t\tdato." + par.nombre + "=0;\r\n";
                        else
                            s += "\t\t\t\tdato=0;\r\n";
                    }
                    else if (par.TipoNet == "System.DateTime")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\t\tdato." + par.nombre + "=System.DateTime.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        else
                            s += "\t\t\t\tdato=System.DateTime.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\t\tdato." + par.nombre + "=System.DateTime.Now.Date;\r\n";
                        else
                            s += "\t\t\t\tdato=System.DateTime.Now.Date;\r\n";
                    }
                    if (par.TipoNet == "float")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\t\tdato." + par.nombre + "=float.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        else
                            s += "\t\t\t\tdato=float.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=0;\r\n";
                    }
                    if (par.TipoNet == "bool")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                        {
                            s += "\t\t\t{\r\n";
                            s += "\t\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim().ToUpper()==\"TRUE\")\r\n";
                            s += "\t\t\t\t\t\tdato." + par.nombre + "=true;\r\n";
                            s += "\t\t\t\telse\r\n";
                            s += "\t\t\t\t\t\tdato." + par.nombre + "=false;\r\n";
                            s += "\t\t\t}\r\n";

                        }
                        else
                        {
                            s += "\t\t\t{\r\n";
                            s += "\t\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim().ToUpper()==\"TRUE\")\r\n";
                            s += "\t\t\t\t\t\tdato=true;\r\n";
                            s += "\t\t\t\telse\r\n";
                            s += "\t\t\t\t\t\tdato=false;\r\n";
                            s += "\t\t\t}\r\n";
                        }
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=false;\r\n";
                    }
                    if (par.TipoNet == "string")
                    {
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\tdato." + par.nombre + "=dr[\"" + par.nombre + "\"].ToString();\r\n";
                        else
                            s += "\t\t\tdato=dr[\"" + par.nombre + "\"].ToString();\r\n";
                    }
                }
                s += "\t\t}\r\n";
                s += "\t}\r\n";
                s += "\tcatch(System.Data.SqlClient.SqlException ex)\r\n";
                s += "\t{\r\n";
                s += "\t\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                if (ThrowEx.Checked)
                    s += "\t\tthrow new Exception(ex.Errors[0].Message);\r\n";
                else
                    s += "\t\tSystem.Windows.Forms.MessageBox.Show(ex.Errors[0].Message, \"" + TNombre.Text + "\", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);\r\n";
                s += "\t}\r\n";
                s += "\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "\treturn dato;\r\n";
                s += "}\r\n";
                s += "#endregion\r\n";
                
                Clipboard.Clear();
                Clipboard.SetText(s);
                MessageBox.Show("Codigo C# Pegado al Portapapeles");

                if (OnCodigoSP != null)
                    OnCodigoSP(TNombre.Text + " C#", s);
                return;
            }
            if (dlg.TipoRetornoX == ENUMTipoRetorno.LISTA || dlg.TipoRetornoX == ENUMTipoRetorno.LISTA_GENERICA)
            {
                //hay que regresar un dato
                s += "\t\t//RECUPERANDO DATOS\r\n";
                s += "\t\tSystem.Data.SqlClient.SqlDataReader dr;\r\n";
                s += "\t\tdr=" + NombreProcedimiento + ".ExecuteReader();\r\n";
                s += "\t\twhile(dr.Read())\r\n";
                s += "\t\t{\r\n";
                s += "\t\t\t" + dlg.Clase + " dato=new " + dlg.Clase + "();\r\n";
                CamposARegresar = dlg.CamposRegresar;
                n = CamposARegresar.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro par = CamposARegresar[i];
                    if (par.TipoNet == "int")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=int.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=0;\r\n";
                    }
                    else if (par.TipoNet == "System.DateTime")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=System.DateTime.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=System.DateTime.Now.Date;\r\n";
                    }
                    if (par.TipoNet == "float")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=float.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=0;\r\n";
                    }
                    if (par.TipoNet == "bool")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                        {
                            s += "\t\t\t{\r\n";
                            s += "\t\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim().ToUpper()==\"TRUE\")\r\n";
                            s += "\t\t\t\t\t\tdato." + par.nombre + "=true;\r\n";
                            s += "\t\t\t\telse\r\n";
                            s += "\t\t\t\t\t\tdato." + par.nombre + "=false;\r\n";
                            s += "\t\t\t}\r\n";

                        }
                        else
                        {
                            s += "\t\t\t{\r\n";
                            s += "\t\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim().ToUpper()==\"TRUE\")\r\n";
                            s += "\t\t\t\t\t\tdato=true;\r\n";
                            s += "\t\t\t\telse\r\n";
                            s += "\t\t\t\t\t\tdato=false;\r\n";
                            s += "\t\t\t}\r\n";
                        }
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=0;\r\n";
                    }
                    if (par.TipoNet == "string")
                    {
                        s += "\t\t\tdato." + par.nombre + "=dr[\"" + par.nombre + "\"].ToString();\r\n";
                    }
                }
                s += "\t\t\tlista.Add(dato);\r\n";
                s += "\t\t}\r\n";
                s += "\t}\r\n";
                s += "\tcatch(System.Data.SqlClient.SqlException ex)\r\n";
                s += "\t{\r\n";
                s += "\t\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                if (ThrowEx.Checked)
                    s += "\t\tthrow new Exception(ex.Errors[0].Message);\r\n";
                else
                    s += "\t\tSystem.Windows.Forms.MessageBox.Show(ex.Errors[0].Message, \"" + TNombre.Text + "\", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);\r\n";
                s += "\t}\r\n";
                s += "\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "\treturn lista;\r\n";
                s += "}\r\n";
                s += "#endregion\r\n";
                
                Clipboard.Clear();
                Clipboard.SetText(s);
                MessageBox.Show("Codigo C# Pegado al Portapapeles");

                if (OnCodigoSP != null)
                    OnCodigoSP(TNombre.Text + " C#", s);
                return;
            }
            s += "\t\tSystem.Data.SqlClient.SqlDataReader dr;\r\n";
            s += "\t\tdr=" + NombreProcedimiento + ".ExecuteReader();\r\n";
            s += "\t\twhile(dr.Read())\r\n";
            s += "\t\t{\r\n";
            s += "\t\t\t//agregar el codigo para leer los datos aqui\r\n";
            s += "\t\t\t//=dr[\"\"].ToString();\r\n";
            s += "\t\t}\r\n";
            s += "\t}\r\n";
            s += "\tcatch(System.Data.SqlClient.SqlException ex)\r\n";
            s += "\t{\r\n";
            s += "\t\t" + NombreProcedimiento + ".Connection.Close();\r\n";
            if(ThrowEx.Checked)
                s += "\t\tthrow new Exception(ex.Errors[0].Message);\r\n";
            else
                s += "\t\tSystem.Windows.Forms.MessageBox.Show(ex.Errors[0].Message, \"" + TNombre.Text + "\", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);\r\n";
            s += "\t}\r\n";
            s += "\t" + NombreProcedimiento + ".Connection.Close();\r\n";
            s += "}\r\n";
            s += "#endregion\r\n";

            Clipboard.Clear();
            Clipboard.SetText(s);
            MessageBox.Show("Codigo C# Pegado al Portapapeles");
            if (OnCodigoSP != null)
                OnCodigoSP(TNombre.Text + " C#", s);
        }
        private void BDependency_Click(object sender, EventArgs e)
        {
            if (OnDependencias != null)
                OnDependencias("Dependencia de " + TNombre.Text, TNombre.Text);
        }
        private void verDependientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnDependientes != null)
                OnDependientes("Dependientes de " + TNombre.Text, TNombre.Text);
        }
        private void BSearch_Click(object sender, EventArgs e)
        {
            SearchAndReplace _findForm = new SearchAndReplace();
            _findForm.ShowFor(this, TCodigo, false);
            TCodigo.Refresh();
        }
        private void OnMenu_Click(object sender, EventArgs e)
        {
            int x = SelectionStart;
            TCodigo.Document.Replace(SelectionStart, SelectionLength , "");
            TCodigo.Refresh();
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            TCodigo.Document.Replace(SelectionStart, SelectionLength, m.Text);
            TCodigo.Refresh();
        }
        private void OnMenu_Click2(object sender, EventArgs e)
        {
            int x = SelectionStart;
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            TCodigo.Document.Replace(SelectionStart, SelectionLength, m.Text);
            TCodigo.Refresh();
        }
        public string Codigo
        {
            get
            {
                return TCodigo.Text;
            }
            set
            {
                TCodigo.Text = value;
            }
        }
        public override void Guardar()
        {
            if (SFilename.Text == "")
            {
                saveFileDialog1.FileName = TNombre.Text;
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            else
            {
                saveFileDialog1.FileName = SFilename.Text;
            }
            TCodigo.SaveFile(saveFileDialog1.FileName);
            FGuardado = true;
            SFilename.Text = saveFileDialog1.FileName;
        }
        private void OnMenu_Click3(object sender, EventArgs e)
        {
            int x = SelectionStart;
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            SelectedText = m.Text.Substring(1);
        }
        private void OnMenuRAISERROR_Click(object sender, EventArgs e)
        {
            int x = SelectionStart;
            SelectedText = "RAISERROR(\'mensage de error\', 16, 1)\r\n" + Tabuladores + "return";
        }
        private void CargaColor()
        {

            string archivo = DirColor + "\\Color";
            if (!System.IO.File.Exists(archivo))
            {
                return;
            }
            System.IO.StreamReader rt;
            rt = System.IO.File.OpenText(archivo);
            //cTextColor1.BackColor = DameColor(rt).Color;
            //cTextColor1.ColorCadena = DameColor(rt).Color;
            //cTextColor1.ColorComentario = DameColor(rt).Color;
            //cTextColor1.ColorIdentificador = DameColor(rt).Color;
            //cTextColor1.ColorNumero = DameColor(rt).Color;
            //cTextColor1.ColorOtro = DameColor(rt).Color;
            //cTextColor1.ColorPalabraRserevada = DameColor(rt).Color;
            //cTextColor1.ColorSimbolo = DameColor(rt).Color;
            //cTextColor1.ColorVariable = DameColor(rt).Color;
            rt.Close();

        }
        public string DirColor
        {
            get
            {
                string s, dir = Application.ExecutablePath;
                int i, n;
                n = dir.Length;
                for (i = n - 1; i > 0; i--)
                {
                    if (dir[i] == '\\')
                        break;
                }
                s = dir.Substring(0, i);
                return s + "\\Color";
            }
        }
        private System.Drawing.Pen DameColor(System.IO.StreamReader rt)
        {
            int r, g, b;
            string s;
            s = rt.ReadLine();
            r = int.Parse(s);
            s = rt.ReadLine();
            g = int.Parse(s);
            s = rt.ReadLine();
            b = int.Parse(s);
            System.Drawing.Pen p;
            p = new System.Drawing.Pen(System.Drawing.Color.FromArgb(r, g, b));
            return p;
        }
        public void ActualizaColores()
        {
            //este codigo hay que sobre escribirlo
            CargaColor();
//            cTextColor1.AnalizaTexto();
        }
        private void cTextColor1_OnCambiaFoco()
        {
            TNombre.Focus();
            TNombre.SelectionLength = 0;
        }
        private void TCodigo_MouseDown(object sender, MouseEventArgs e)
        {
            TCodigo.ContextMenuStrip = contextMenuStrip2;
            RataX = e.X;
            RataY = e.Y;

        }
        public void Ejecuta(string s)
        {
            TCodigo.Text = s;
            BExecute_Click(null, null);
        }
        public void Abrir()
        {
            if (SFilename.Text == "")
            {
                openFileDialog1.FileName = TNombre.Text;
            }
            else
            {
                openFileDialog1.FileName = SFilename.Text;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            SFilename.Text = openFileDialog1.FileName;
            TCodigo.LoadFile(SFilename.Text);
            FGuardado = true;
        }
        private void TCodigo_KeyDown(object sender, KeyEventArgs e)
        {
//            LIstaIntelience_KeyDown(sender, e);
            if (e.KeyCode == Keys.F6)
            {
                BComment_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.F7)
            {
                BDecomment_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.Right && e.Shift == true && e.Control == true)
            {
                e.Handled = true;
                int maxtam = TCodigo.Text.Length;
                int posf = SelectionStart + SelectionLength;
                //filtro LostFocus espacios enum blanco
                int blacos = 0;
                while ((posf<maxtam-1)&&(TCodigo.Text[posf] == ' ' || TCodigo.Text[posf] == '\r' || TCodigo.Text[posf] == '\n' || TCodigo.Text[posf] == '\t'))
                {
                    blacos++;
                    posf++;
                }
                //me traigo el siguiente item del texto
                cAnaLex1.Texto = TCodigo.Text.Substring(posf);
                AnalizadorLexico.CLexema lex;
                lex = cAnaLex1.DameItem();
                if (lex == null)
                    return;
                SelectionLength = SelectionLength + lex.cadena.Length + blacos;
            }
            ControlV = (e.KeyCode == Keys.V && e.Modifiers == Keys.Control);
            if (ControlV == true)
            {
//                ControlVI = TCodigo.GetLineFromCharIndex(SelectionStart);
            }
            #region Tratamiento del enter
            if (e.KeyCode == Keys.Enter)
            {
                if (TCodigo.Text == "")
                    return;
                e.Handled = true;
                //me traigo la posicion de la linea en la que estoy
                int si = SelectionStart;
                //ahora me regreso hasta encontrar un enter o el inicio de liena
                int pos = 0;// TCodigo.GetLineFromCharIndex(SelectionStart);
                string s = "";// TCodigo.Lines[pos];
                Tabuladores = "\r";
                //cuento el numero de tabuladores
                int i, n;
                n = s.Length;
                for (i = 0; i < n; i++)
                {
                    if (s[i] != '\t' && s[i] != ' ')
                    {
                        break;
                    }
                    Tabuladores = Tabuladores + s[i];
                }
                string s2 = "";
                for (; i < n; i++)
                {
                    //me traigo la primer palabra wue encuentre
                    if (s[i] == '\t' || s[i] == ' ')
                    {
                        break;
                    }
                    else
                        s2 = s2 + s[i];
                }
                if (s2.ToLower().Trim() == "begin")
                {
                    if (ValidaBgeins() == true)
                    {
                        Tabuladores = Tabuladores.Substring(1);
                        string s3 = "\n"+Tabuladores + "\t";
                        si = si + s3.Length;
                        Tabuladores = s3 + "\n" + Tabuladores + "end";
                        SelectedText = Tabuladores;
                        SelectionStart = si;
                        return;
                    }
                    else
                    {
                        Tabuladores = Tabuladores.Substring(1);
                        string s3 = Tabuladores + "\n\t";
                        si = si + s3.Length;
                        SelectedText = s3;
                        SelectionStart = si;
                    }
                }
                if (s2.ToLower().Trim() == "try")
                {
                    Tabuladores = Tabuladores.Substring(1);
                    string s3 = "begin try\n" + Tabuladores + "\t--Colocar aquí el código que puede fallar\n"+Tabuladores+"\t";
                    si = si + s3.Length-1;
                    s3 = s3 + "\t\n" + Tabuladores + "end try\n";
                    s3 = s3 + Tabuladores + "begin catch\n" + Tabuladores + "\t--Colocar el código para manejar la excepción\n\n\t--Para recuperar el mensaje de error utilice ERROR_MESSAGE()\n\n";
                    s3 = s3 + Tabuladores + "end catch\t\n\n\r";
                    SelectionStart = SelectionStart - 3;
                    SelectionLength = 3;
                    SelectedText = s3;
                    SelectionStart = si-1;
                    TCodigo.Focus();
                    return;
                }
                SelectedText = Tabuladores;
                return;
            }
            #endregion

            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                e.Handled = true;
            }
        }
        private void VerificaEspacio(KeyPressEventArgs e)
        {
            int si = SelectionStart;
            Tabuladores = DameTabuladores(si);
            string s = DameItemAnterior(si);
            VerificaClaves2(s, e);

        }
        private bool VerificaClaves2(string s, KeyPressEventArgs e)
        {
            if (s.ToLower().Trim() == "insert")
            {
                //es autocompletar un insert
                Formularios.FormBuscarTabla dlg = new Formularios.FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                //obtengo la poicion del insert
                //ahora me regreso hasta encontrar un enter o el inicio de liena
//                int pos = TCodigo.GetLineFromCharIndex(SelectionStart);
//                string s2 = TCodigo.Lines[pos];
                Tabuladores = "";
                //cuento el numero de tabuladores
                int i, n;
//                n = s2.Length;
//                for (i = 0; i < n; i++)
                {
//                    if (s2[i] != '\t' && s2[i] != ' ')
                    {
//                        break;
                    }
//                    Tabuladores = Tabuladores + s2[i];
                }
                //--------------------------------------------------------------------
                SelectedText = " " + dlg.DameInsert(Tabuladores, "");
//                cTextColor1.AnalizaLinea(pos);
//                cTextColor1.AnalizaLinea(pos + 1);
                return true;
            }
            if (s.ToLower().Trim() == "exec")
            {
                //es autocompletar un insert
                Formularios.FormBuscarTabla dlg = new Formularios.FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE);
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                SelectedText = " " + dlg.DameSP("");
//                cTextColor1.AnalizaLinea(TCodigo.GetLineFromCharIndex(SelectionStart));
                return true;
            }
            if (s.ToLower().Trim() == "like")
            {
                e.Handled = true;
                //es autocompletar un insert
                int ss = SelectionStart;
                SelectedText = " \'%%\'";
                SelectionStart = ss + 3;
                return true;
            }
            if (s.ToLower().Trim() == "from" || s.ToLower().Trim() == "update" || s.ToLower().Trim() == "delete")
            {
                List<Objetos.CSysObject> l=null;
                if (s.ToLower().Trim() == "from")
                {
                    //CancelClose = true;
                    //ShowIntellisense();
                    //l=DB.BuscaObjetos("", Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTAS_TABLAS);
                }
                if (s.ToLower().Trim() == "update" || s.ToLower().Trim() == "delete")
                {
                    inteliences1.ShowIntellisense();
//                    l = DB.BuscaObjetos("", Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
                }
                    //Filtro = "";
                    //PosIni = SelectionStart;
                    //Cadenas.Clear();
                    //foreach(Objetos.CSysObject obj in l)
                    //{
                    //    Cadenas.Add(obj.Nombre);
                    //}
                    //MuestraOpciones();
                    return true;
            }
            return false;
        }
        private string DameTabuladores(int linea)
        {
            //ahora me regreso hasta encontrar un enter o el inicio de liena
//            int pos = TCodigo.GetLineFromCharIndex(linea);
            string s;
//            if (pos > 0)
//                s = TCodigo.Lines[pos];
//            else
                s = TCodigo.Text;

            string Tabuladores1 = "\r";
            //cuento el numero de tabuladores
            int i, n;
            n = s.Length;
            for (i = 0; i < n; i++)
            {
                if (s[i] != '\t' && s[i] != ' ')
                {
                    break;
                }
                Tabuladores1 = Tabuladores1 + s[i];
            }
            return Tabuladores1;
        }
        private string DameItemAnterior(int posicion)
        {
            List<Objetos.CAlias> Alias = new List<Visor_sql_2015.Objetos.CAlias>(); ;
            List<AnalizadorLexico.CLexema> Lexemas;
            //cargo todos los lexemas del codigo en la lista
            Lexemas = new List<AnalizadorLexico.CLexema>();

            int linea = TCodigo.Document.GetLineNumberForOffset(SelectionStart);

            cAnaLex1.Texto = TCodigo.Document.GetText(TCodigo.Document.GetLineSegment(linea));//TCodigo.Lines[linea];
            AnalizadorLexico.CLexema lex = null;
            AnalizadorLexico.CLexema lex2 = null;
            do
            {
                lex = cAnaLex1.DameItem();
                if (lex != null)
                {
                    Lexemas.Add(lex);
                    //checo si es un alias
                    if (lex.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                    {
                        if (lex2 != null)
                        {
                            if (lex2.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                            {
                                //veo si es una tabla
                                Controladores_DB.CNodoTabla nt1;
                                nt1 = DB.BuscaEnTabla(lex2.cadena);
                                if (nt1 != null)
                                {
                                    //encontre un alias
                                    Objetos.CAlias al = new Visor_sql_2015.Objetos.CAlias();
                                    al.Item = lex;
                                    al.tabla = nt1;
                                    Alias.Add(al);
                                }
                            }
                        }
                        lex2 = lex;
                    }
                }
            }
            while (lex != null);
            //ta tego todos los lexemas en memosria;
            //ahora busco el que esta justo antes del punto
            int aa=TCodigo.Document.GetLineSegment(linea).Offset;
            int posPunto = posicion - aa;
            int i, n, px = -1;
            n = Lexemas.Count;
            for (i = 0; i < n; i++)
            {
                lex = Lexemas[i];
                if (posPunto >= lex.Pos && posPunto <= lex.Pos + lex.cadena.Length)
                {
                    //ya tengo la posicion del punto que escribieron
                    px = i;
                    break;
                }
            }
            //ahora me traigo el lexema que esta atras del punto
            if (px == -1)
                return "";
            lex = Lexemas[px];
            return lex.cadena;
        }
        private void convertirAMayúsculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int li, lf;
            //le hago la convercion
            SelectedText = SelectedText.ToUpper();
        }
        private void convertirAMinúsculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int li, lf;
            //obtengo la linea donde inicia la seleccion
            //le hago la convercion
            SelectedText = SelectedText.ToLower();
            //analizo las lineas
        }
        private void TCodigo_KeyUp(object sender, KeyEventArgs e)
        {
//            LIstaIntelience_KeyUp(sender, e);
            if (e.Control == true)
            {
                //es control
                if (e.KeyCode == Keys.S)
                {
                    AgregaPatron();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                BExecute_Click(null, null);
            }
            if (ControlV == true)
            {
//                int controlf = TCodigo.GetLineFromCharIndex(SelectionStart);
                e.Handled = true;
//                for (int i = ControlVI; i <= controlf; i++)
                {
//                    cTextColor1.AnalizaLinea(i);

                }
            }
        }
        private void BComment_Click(object sender, EventArgs e)
        {
            Comentar();
        }
        private void BExecute_Click(object sender, EventArgs e)
        {
            Ejecutar();
        }
        public int DameLinea(int pos)
        {
//            return TCodigo.GetFirstCharIndexFromLine(pos);
            return 0;
        }
        public ICSharpCode.TextEditor.TextEditorControl DameTexto()
        {
            return TCodigo;
        }
        private void TCodigo_MouseClick(object sender, MouseEventArgs e)
        {
//            LIstaIntelience.Visible = false;
        }
        private void BConfigurePage_Click(object sender, EventArgs e)
        {
        }
        private void BPreview_Click(object sender, EventArgs e)
        {
        }
        private void BPrint_Click(object sender, EventArgs e)
        {
        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             RichTextBoxPrintCtrl.RichTextBoxPrintCtrl tmp=new RichTextBoxPrintCtrl.RichTextBoxPrintCtrl();
             tmp.Text = TCodigo.Text;

            // Print the content of RichTextBox. Store the last character printed.
             checkPrint = tmp.Print(checkPrint, tmp.TextLength, e);

            // Check for more pages
             if (checkPrint < tmp.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

        }
        private bool ValidaBgeins()
        {
            //analiza el texto en busca de los begin y ends y regresa true si no estan valaceados
            cAnaLex1.Texto = TCodigo.Text;
            int balanceo=0;
            while (true)
            {
                AnalizadorLexico.CLexema l;
                l=cAnaLex1.DameItem();
                if (l == null)
                    break;
                if (l.cadena.Trim().ToLower() == "begin")
                    balanceo++;
                if (l.cadena.Trim().ToLower() == "end")
                    balanceo--;
            }
            if (balanceo == 0)
                return false;
            return true;
        }

        #region Codigo Agregado /*Gonzalo*/
        void DB_BeginningQuery()
        {
//            TCodigo.ReadOnly = true;
            //BExecute.Image = Properties.Resources.CheckX;
        }
        void DB_EndingQuery()
        {
            try
            {
                BeginInvoke(GetResults);
            }
            catch (Exception ex)
            {
                CErrorQuery err = new CErrorQuery();
                err.msg = ex.Message;
                if (OnMuestraError != null)
                    OnMuestraError(err, this);
            }
        }
        void ObtenResultados()
        {
            DataSet ds = new DataSet();
            int NumeroTablas = 0;
            if (DB.Error.StartsWith("OK") || FormPrincipal.ResultadosIncompletos)
            {
                //Primero Averiguar el Numero de tablas que regresa el resultado, con un maximo de 10 tablas
                NumeroTablas = DB.Results.Tables.Count;
                //while (DB.Results.Tables[NumeroTablas].Columns.Count > 0 && NumeroTablas < 11)
                  //  NumeroTablas++;

                while (DB.Results.Tables.Count > NumeroTablas)
                    DB.Results.Tables.RemoveAt(DB.Results.Tables.Count - 1);

                if (DB.Results.Tables.Count == 0)
                {
                    CErrorQuery err = new CErrorQuery();
                    err.msg = DB.Error;
                    if (OnMuestraError != null)
                        OnMuestraError(err, this);
//                    TCodigo.ReadOnly = false;
                    TCodigo.Focus();
                    //BExecute.Image = Properties.Resources.BExecute_Image;
                    return;
                }
                if (OnMuestraGrids != null)
                    OnMuestraGrids(DB.Results, DB.TiempoEjecucion);
            }
            else
            {
                if (OnMuestraError != null)
                {
                    OnMuestraError(DB.MensajeError, this);                    
                }
            }
//            TCodigo.ReadOnly = false;
            TCodigo.Focus();
            //BExecute.Image = Properties.Resources.BExecute_Image;
        }
        #endregion
        public bool Guardado
        {
            get
            {
                if (SFilename.Text != "")
                {
                    if (FGuardado == false)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public string FileName
        {
            get
            {
                return SFilename.Text;
            }
        }
        private void AgregaPatron()
        {
            patrones.FormSelPatron dlg = new Visor_sql_2015.patrones.FormSelPatron();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            string s = dlg.PatronText;
            int li, lf;
            int i1, i2;
            i1 = SelectionStart;
            SelectedText = s;
            i2 = i1 + s.Length;
            
        }
        private string SelectedText
        {
            get
            {
                if (TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection.Count > 0)
                {
                    ICSharpCode.TextEditor.Document.ISelection s = TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection[0];
                    return s.SelectedText;
                }
                return "";
            }
            set
            {
                if (TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection.Count > 0)
                {
                    ICSharpCode.TextEditor.Document.ISelection s = TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection[0];
                    TCodigo.Document.Replace(s.Offset, s.Length, value);
                    TCodigo.Refresh();
                    return;
                }

                TCodigo.Document.Insert(TCodigo.ActiveTextAreaControl.Caret.Offset, value);
            }
        }
        private int SelectionStart
        {
            get
            {
                if (TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection.Count > 0)
                {
                    ICSharpCode.TextEditor.Document.ISelection sel = null;
                    sel = TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection[0];
                    return sel.Offset;
                }
                return TCodigo.ActiveTextAreaControl.Caret.Offset;
            }
            set
            {
            }
        }
        private int SelectionLength
        {
            get
            {
                if (TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection.Count > 0)
                {
                    ICSharpCode.TextEditor.Document.ISelection sel = null;
                    sel = TCodigo.ActiveTextAreaControl.SelectionManager.SelectionCollection[0];
                    return sel.Length;
                }
                return 0;
            }
            set
            {
            }
        }
        private void BDecomment_Click(object sender, EventArgs e)
        {
            DesComentar();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TCodigo.Document.FoldingManager.UpdateFoldings(null, null);
            //            Lfecha.Text = TCodigo.SelectionIndent.ToString() + "." + TCodigo.Bounds.Bottom.ToString();
            bool ok = true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            BDependency.Enabled = ok;
            //calculo la posicion del cursor
            LX.Text = "X=" + TCodigo.ActiveTextAreaControl.Caret.Column.ToString(); ;
            LY.Text = "Y=" + TCodigo.ActiveTextAreaControl.Caret.Line.ToString();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AnalizadorLexico.CLexema lex=null;

            cAnaLex1.Texto=TCodigo.Text;
            do
            {
                
                lex=cAnaLex1.DameItem();
                if(lex==null )
                {
                    return;
                }
                //me traigo la pocicion del lexema
                if(SelectionStart>=lex.Pos &&SelectionStart<=( lex.cadena.Length+ lex.Pos))
                {
                    //encontre el item al que hace referencia
                    System.Collections.Generic.List<Objetos.CSysObject> l;
                    l = DB.BuscaObjetos(lex.cadena, Visor_sql_2015.Controladores_DB.TIPOOBJETO.NINGUNO);
                    if (l.Count == 0)
                        return;
                    Objetos.CSysObject obj = l[0];
                    if (obj.Nombre.ToLower().Trim() != lex.cadena.ToLower().Trim())
                        return;
                    if (OnVerObjeto != null)
                        OnVerObjeto(obj);
                    return;
                }
            }
            while(lex!=null );
        }

        private void CHNumeroLinea_CheckedChanged(object sender, EventArgs e)
        {
            TCodigo.ShowLineNumbers =CHNumeroLinea.Checked;
        }

        private Form inteliences1_OnParentForm()
        {
            return ParentForm;
        }

        private void inteliences1_OnKey(Keys dato)
        {
            label2.Text = dato.ToString();
        }


        private void inteliences1_Guardar()
        {
            Guardar();
        }

        private void inteliences1_Abrir()
        {
            Abrir();
        }
        #region Opciones de Edicion
        public override void EdicionCopiar()
        {
            Clipboard.SetText(TCodigo.ActiveTextAreaControl.SelectionManager.SelectedText);
        }
        public override void EdicionPegar()
        {
            string s = Clipboard.GetText();
            if (s == null || s == "")
                return;
            SelectedText=s;
            TCodigo.Refresh();
        }
        public override void EdicionCortar()
        {
            Clipboard.SetText(TCodigo.ActiveTextAreaControl.SelectionManager.SelectedText);
            SelectedText = "";
            TCodigo.ActiveTextAreaControl.SelectionManager.ClearSelection();
        }
        #endregion
        #region Deshacer y rehacer
        public override void EdicionDeshacer()
        {
            TCodigo.Undo();
        }
        public override void EdicionReHacer()
        {
            TCodigo.Redo();
        }
        #endregion
        public virtual void Ejecutar()
        {
            if (!DB.EnEjecucion)
            {
                try
                {
                    if (OnLimpiaResultados != null)
                        OnLimpiaResultados();
                    if (TCodigo.ActiveTextAreaControl.SelectionManager.SelectedText.Trim() == "")
                        DB.Async_ObtenTablaQuery(TCodigo.Text);
                    else
                        DB.Async_ObtenTablaQuery(TCodigo.ActiveTextAreaControl.SelectionManager.SelectedText);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    int i, n;
                    n = ex.Errors.Count;
                    for (i = 0; i < n; i++)
                    {
                        CErrorQuery err = new CErrorQuery();
                        err.msg = ex.Errors[i].Message;
                        err.LineNumber = ex.Errors[i].LineNumber;
                        if (OnMuestraError != null)
                            OnMuestraError(err, this);
                    }
                    return;
                }
            }
            else
            {
                DB.StopAsync();
            }
        }
        public override void Comentar()
        {
            //comenta el dodigo seleccionado
            string s;
            string s2 = "--";
            s = SelectedText;
            int i, n;
            n = s.Length;
            for (i = 0; i < n; i++)
            {
                s2 = s2 + s[i];
                if (s[i] == '\n')
                {
                    s2 = s2 + "--";
                }
            }
            SelectedText = s2;
        }
        public override void DesComentar()
        {
            //comenta el dodigo seleccionado
            string s;
            string s2 = "";
            s = SelectedText;
            s2 = s.Replace("--", "");
            SelectedText = s2;
        }
        #region Busquedas
        public bool _lastSearchWasBackward = false;
        public bool _lastSearchLoopedAround;
        TextEditorSearcher _search;
        public override TextRange FindNext(bool viaF3, bool searchBackward, string messageIfNotFound, string TextoBuscar, bool CaseSensitive, bool WholeWords)
        {
            if (string.IsNullOrEmpty(TextoBuscar))
            {
                return null;
            }
            if(_search ==null)
                _search = new TextEditorSearcher();
            _search.Document = TCodigo.Document;
            _lastSearchWasBackward = searchBackward;
            _search.LookFor = TextoBuscar;
            _search.MatchCase = CaseSensitive;
            _search.MatchWholeWordOnly = WholeWords;

            var caret = TCodigo.ActiveTextAreaControl.Caret;
            if (viaF3 && _search.HasScanRegion && !caret.Offset.IsInRange(_search.BeginOffset, _search.EndOffset))
            {
                // user moved outside of the originally selected region
                _search.ClearScanRegion();
                //UpdateTitleBar();
            }

            int startFrom = caret.Offset - (searchBackward ? 1 : 0);
            TextRange range = _search.FindNext(startFrom, searchBackward, out _lastSearchLoopedAround);
            if (range != null)
                SelectResult(range);
            else if (messageIfNotFound != null)
                MessageBox.Show(messageIfNotFound);
            return range;
        }
        private void SelectResult(TextRange range)
        {
            TextLocation p1 = TCodigo.Document.OffsetToPosition(range.Offset);
            TextLocation p2 = TCodigo.Document.OffsetToPosition(range.Offset + range.Length);
            TCodigo.ActiveTextAreaControl.SelectionManager.SetSelection(p1, p2);
            TCodigo.ActiveTextAreaControl.ScrollTo(p1.Line, p1.Column);
            // Also move the caret to the end of the selection, because when the user 
            // presses F3, the caret is where we start searching next time.
            TCodigo.ActiveTextAreaControl.Caret.Position =
                TCodigo.Document.OffsetToPosition(range.Offset + range.Length);
        }
        public override void ReemplazarSiguiente(string textoBuscar, string TextoRemplazar,bool CaseSensitive, bool WholeWords)
        {
            var sm = TCodigo.ActiveTextAreaControl.SelectionManager;
            if (string.Equals(sm.SelectedText, textoBuscar, StringComparison.OrdinalIgnoreCase))
                InsertText(TextoRemplazar);
            FindNext(false, _lastSearchWasBackward, "No se encontró el elemento", textoBuscar,CaseSensitive,WholeWords);
        }
        private void InsertText(string text)
        {
            var textArea = TCodigo.ActiveTextAreaControl.TextArea;
            textArea.Document.UndoStack.StartUndoGroup();
            try
            {
                if (textArea.SelectionManager.HasSomethingSelected)
                {
                    textArea.Caret.Position = textArea.SelectionManager.SelectionCollection[0].StartPosition;
                    textArea.SelectionManager.RemoveSelectedText();
                }
                textArea.InsertString(text);
            }
            finally
            {
                textArea.Document.UndoStack.EndUndoGroup();
            }
        }
        public override void RemplazarTodo(string textoBuscar, string TextoRemplazar,bool CaseSensitive, bool WholeWords)
        {
            int count = 0;
            // BUG FIX: if the replacement string contains the original search string
            // (e.g. replace "red" with "very red") we must avoid looping around and
            // replacing forever! To fix, start replacing at beginning of region (by 
            // moving the caret) and stop as soon as we loop around.
            TCodigo.ActiveTextAreaControl.Caret.Position =
                TCodigo.Document.OffsetToPosition(_search.BeginOffset);

            TCodigo.Document.UndoStack.StartUndoGroup();
            try
            {
                while (FindNext(false, false, null, textoBuscar, CaseSensitive, WholeWords) != null)
                {
                    if (_lastSearchLoopedAround)
                        break;

                    // Replace
                    count++;
                    InsertText(TextoRemplazar);
                }
            }
            finally
            {
                TCodigo.Document.UndoStack.EndUndoGroup();
            }
            if (count == 0)
                MessageBox.Show("No se encontro ninguna ocurrencia");
            else
            {
                MessageBox.Show(string.Format("Se reemplazaron {0} cadenas.", count));
            }
        }
        Dictionary<TextEditorControl, HighlightGroup> _highlightGroups = new Dictionary<TextEditorControl, HighlightGroup>();
        public override void MarcarCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar)
        {
            if (!_highlightGroups.ContainsKey(TCodigo))
                _highlightGroups[TCodigo] = new HighlightGroup(TCodigo);
            HighlightGroup group = _highlightGroups[TCodigo];

            if (string.IsNullOrEmpty(textoBuscar))
            {
                // Clear highlights
                group.ClearMarkers();
            }
            else
            {
                _search.LookFor = textoBuscar;
                _search.MatchCase = CaseSensitive;
                _search.MatchWholeWordOnly = WholeWords;

                bool looped = false;
                int offset = 0, count = 0;
                for (; ; )
                {
                    TextRange range = _search.FindNext(offset, false, out looped);
                    if (range == null || looped)
                        break;
                    offset = range.Offset + range.Length;
                    count++;

                    var m = new TextMarker(range.Offset, range.Length,
                            TextMarkerType.SolidBlock, ColorAplicar, Color.Black);
                    group.AddMarker(m);
                }
                if (count == 0)
                    MessageBox.Show("Cadena buscada no encontrada.");
                // else
                //   Close();
            }
            TCodigo.Refresh();
        }
        #endregion 
        private void inteliences1_Buscar()
        {
            if (OnBuscarTexto != null)
                OnBuscarTexto(SelectedText);
        }
        public override void VistaPrevia()
        {
            printPreviewDialog1.ShowDialog();
        }
        public override void ConfigurarPagina()
        {
            pageSetupDialog1.ShowDialog();
        }
        public override void Imprimir()
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void TCodigo_Enter(object sender, EventArgs e)
        {
            if (SelectEdicion != null)
                SelectEdicion("TabEdicion");
        }
        public override void SetFocus()
        {
            TCodigo.Focus();
        }
    }
}
