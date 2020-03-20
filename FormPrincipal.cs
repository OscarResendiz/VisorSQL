using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Crownwood.Magic.Common;
using Crownwood.Magic.Controls;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Menus;

namespace Visor_sql_2015
{
    public delegate void SelectTabByNameEvent(string tabName);
    public partial class FormPrincipal : Form
    {

        private bool CerrarPespaña;
        private Formularios.FormBuscar FormBucarx; 
        private bool Cerrando;
        private Editor.FormResultados VResultados;
        private Editor.FormEditor VEditor;
        protected DockingManager _manager;
        protected DockingManager _manager2;
        Controladores_DB.IDataBase DB = null;
        private static bool _ResultadosIncompletos;
        Formularios.FormTablaX TablaActual;
        public static bool ResultadosIncompletos
        {
            get
            {
                return _ResultadosIncompletos;
            }
        }

        private void zzz(Content c, CancelEventArgs e)
        {
            if (c.Control == FormBucarx)
            {
                FormBucarx.Close();
                FormBucarx = null;
            }
        }
        public FormPrincipal()
        {
            Formularios.FormPortada dlg = new Visor_sql_2015.Formularios.FormPortada();
            dlg.ShowDialog();
            InitializeComponent();
            DB = null;
            _manager = new DockingManager(this, VisualStyle.Plain);
            _manager.ContentHiding += new DockingManager.ContentHidingHandler(zzz);
            _manager2 = new DockingManager(this, VisualStyle.Plain);
            Cerrando = false;
            CerrarPespaña = true;
            _ResultadosIncompletos = false;
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            consultaToolStripMenuItem_Click(sender, e);
        }
        private void OpenFile(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null)
            {
                consultaToolStripMenuItem_Click(sender, e);
            }
            Formularios.FormBase dlg = (Formularios.FormBase)ActiveMdiChild;
            dlg.Abrir(); ;
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
//            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void conexionDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargaGrupos();
            //toolStrip1.Visible = barraDeComandosToolStripMenuItem.Checked;
        }
        private void CargaConexiones()
        {
            ComboConexiones.Items.Clear();
            //conexionesToolStripMenuItem.DropDownItems.Clear();
            int i, n;
            string[] archivos;
            if (System.IO.Directory.Exists(DirConexiones) == false)
            {
                System.IO.Directory.CreateDirectory(DirConexiones);
            }
            archivos = System.IO.Directory.GetFiles(DirConexiones);
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                System.Windows.Forms.ToolStripMenuItem Submenu = new System.Windows.Forms.ToolStripMenuItem();
                Submenu.Text = QuitaDirectorio(archivos[i]);
                //Submenu.Click += new System.EventHandler(this.Conexion_Click);
                //this.conexionesToolStripMenuItem.DropDownItems.Add(Submenu);
                ComboConexiones.Items.Add(Submenu.Text);
            }
        }
        private bool CargaConexion()
        {
            string NombreArchivo;
            if (!System.IO.File.Exists("DBCONFIG.TXT"))
            {
                return false;
            }
            System.IO.StreamReader rt;
            rt = File.OpenText("DBCONFIG.TXT");
            DB.ConnectionString = rt.ReadLine();
            NombreArchivo = rt.ReadLine();
            rt.Close();
            try
            {
                DB.PruebaConexion();
            }
            catch (System.Exception)
            {
                return false;
            }
            OnConexion(DB.ConnectionString, NombreArchivo);
            this.Text = DB.ConnectionString;
            return true;
        }
        private void OnDependencias(string nombre, string codigo)
        {
            Formularios.FormVerTodasLasDependencias dlg = new Visor_sql_2015.Formularios.FormVerTodasLasDependencias(DB, codigo);//, codigo, true);
            dlg.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            dlg.MdiParent = this;
            VentanaAcoplable(dlg, 3, false, State.DockLeft);

        }
        private void OnDependientes(string nombre, string codigo)
        {
            Formularios.FormDependecias dlg = new Visor_sql_2015.Formularios.FormDependecias(DB, nombre, codigo, false);
            dlg.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            dlg.MdiParent = this;
            VentanaAcoplable(dlg, 3, false, State.DockLeft);
        }
        private void MuestraVentana(Objetos.CSysObject obj)
        {
            switch (obj.TipoObjeto)
            {
                case Controladores_DB.TIPOOBJETO.TABLAX:
                    Formularios.FormTablaX ftabla = new Visor_sql_2015.Formularios.FormTablaX(obj.Nombre, DB, Controladores_DB.TIPOOBJETO.TABLAX);
                    ftabla.OnEjecuta += new Visor_sql_2015.Formularios.OnCodigoEvent(OnEjecuta);
                    ftabla.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(OnCodigo);
                    ftabla.OnDependencias += new Visor_sql_2015.Formularios.OnCodigoEvent(OnDependencias);
                    ftabla.OnDependientes += new Visor_sql_2015.Formularios.OnCodigoEvent(OnDependientes);
                    ftabla.OnDocuemntar += new Visor_sql_2015.Formularios.OnDocuemntarEvent(OnDocumentar);
                    ftabla.OnTrasar += new Visor_sql_2015.Formularios.OnCodigoEvent(OnTrasar);
                    ftabla.OnMuestraTablaPadre += new Visor_sql_2015.Formularios.OnMuestraTablaPadreEvent(MuestraTablaPadre);
                    ftabla.OnEditarTabla += new Formularios.OnEditarEvent(EditarTabla);
                    ftabla.SelectTab += new SelectTabByNameEvent(SelectTabByName);
                    ftabla.OnFormTablaActual += new Formularios.OnFormTablaActualEvent(FormTablaActual);
                    TablaActual = ftabla;
                    ftabla.MdiParent = this;
                    VentanaAcoplable(ftabla, 1, false, State.DockRight);
                    break;
                case Controladores_DB.TIPOOBJETO.TABLASYSTEMA:
                    Formularios.FormTablaX ftablas = new Visor_sql_2015.Formularios.FormTablaX(obj.Nombre, DB, Controladores_DB.TIPOOBJETO.TABLASYSTEMA);
                    ftablas.OnEjecuta += new Visor_sql_2015.Formularios.OnCodigoEvent(OnEjecuta);
                    ftablas.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(OnCodigo);
                    ftablas.OnDependencias += new Visor_sql_2015.Formularios.OnCodigoEvent(OnDependencias);
                    ftablas.OnDependientes += new Visor_sql_2015.Formularios.OnCodigoEvent(OnDependientes);
                    ftablas.OnTrasar += new Visor_sql_2015.Formularios.OnCodigoEvent(OnTrasar);
                    ftablas.SelectTab += new SelectTabByNameEvent(SelectTabByName);
                    ftablas.OnFormTablaActual += new Formularios.OnFormTablaActualEvent(FormTablaActual);
                    TablaActual = ftablas;


                    ftablas.MdiParent = this;
                    VentanaAcoplable(ftablas, 1, false, State.DockRight);
                    break;
                case Controladores_DB.TIPOOBJETO.STOREPROCERURE:
                    #region nuevo codigo

                    Editor.TextEditX fSP = new Editor.TextEditX(obj.Nombre, DB);
                    fSP.OnCodigoSP += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnCodigo);
                    fSP.OnDependencias += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnDependencias);
                    fSP.OnDependientes += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnDependientes);
                    fSP.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
                    fSP.OnMuestraError += new Visor_sql_2015.Editor.OnMuestraErrorEvent(MuestraErrorX);
                    fSP.OnLimpiaResultados += new Visor_sql_2015.Editor.OnLimpiaResultadosEvent(LimpiaResultados);
                    fSP.OnMuestraGrids += new Visor_sql_2015.Editor.OnMuestraGridsEvent(MuestraGrids);
                    fSP.SelectEdicion += new SelectTabByNameEvent(SelectTabByName);
                    if (VEditor == null)
                    {
                        VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                        VEditor.MdiParent = this;
                        VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                        VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                        VEditor.Show();
                    }
                    VEditor.AgregaEditor(fSP, obj.Nombre);
                    #endregion
                    break;
                case Controladores_DB.TIPOOBJETO.VISTA:
                    Formularios.FormTablaX fVtabla = new Visor_sql_2015.Formularios.FormTablaX(obj.Nombre, DB, Controladores_DB.TIPOOBJETO.VISTA);
                    fVtabla.OnEjecuta += new Visor_sql_2015.Formularios.OnCodigoEvent(OnEjecuta);
                    fVtabla.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(OnCodigo);
                    fVtabla.OnDependencias += new Visor_sql_2015.Formularios.OnCodigoEvent(OnDependencias);
                    fVtabla.OnDependientes += new Visor_sql_2015.Formularios.OnCodigoEvent(OnDependientes);
                    fVtabla.OnTrasar += new Visor_sql_2015.Formularios.OnCodigoEvent(OnTrasar);
                    fVtabla.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraCodigoVista);
                    fVtabla.SelectTab += new SelectTabByNameEvent(SelectTabByName);
                    fVtabla.OnFormTablaActual += new Formularios.OnFormTablaActualEvent(FormTablaActual);
                    TablaActual = fVtabla;

                    fVtabla.MdiParent = this;
                    VentanaAcoplable(fVtabla, 1, false, State.DockRight);
                    break;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.FOREINGKEY:
                    Formularios.FormFK dlgfk = new Visor_sql_2015.Formularios.FormFK(DB, obj.Nombre);
                    dlgfk.MdiParent = this;
                    dlgfk.Show();
                    break;
            }
        }
        private void crearMenuContextualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FormMenuContextual dlg = new Formularios.FormMenuContextual();
            dlg.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(OnCodigo);
            VentanaAcoplable(dlg, 0, false, State.DockLeft);
        }
        private void crearDataGridToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            #region Nuevo codigo
            Formularios.FormLLenarDataGrid fSP = new Formularios.FormLLenarDataGrid(DB);
            fSP.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(OnCodigo);
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.Show();
            }
            VEditor.AgregaEditor(fSP, "DATA GRID");
            #endregion
        }
        private void OnTrasar(string nombre, string codigo)
        {
            Formularios.FormTrasar dlg = new Visor_sql_2015.Formularios.FormTrasar(DB, nombre);
            dlg.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            dlg.OnListaObjetos += new Formularios.OnListaObjetosEvent(MuestraDependencias);
            dlg.MdiParent = this;
            VentanaAcoplable(dlg, 3, false, State.DockLeft);
        }
        private void administrarConexionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarConexiones.AdministradorDeGrupos dlg = new Visor_sql_2015.AdministrarConexiones.AdministradorDeGrupos();
            dlg.MdiParent = this;
            dlg.OnConexionGrupo += new Visor_sql_2015.AdministrarConexiones.OnConexionGrupoEvent(ConexionGrupo);
            dlg.OnAddgrupo += new Visor_sql_2015.AdministrarConexiones.OnGuprosModificadosEvent(Addgrupo);
            dlg.OnDeleteGrupo += new Visor_sql_2015.AdministrarConexiones.OnGuprosModificadosEvent(DeleteGrupo);
            dlg.Show();
        }
        private void OnConexion(string cadena, string nombre)
        {
            CargaConexiones();
            DB.ConnectionString = cadena;
            DB.PruebaConexion();
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText("DBCONFIG.TXT");
            sw.WriteLine(DB.ConnectionString);
            sw.WriteLine(nombre);
            sw.Close();
            this.Text = DB.ConnectionString;
            //sincroniso con el combo
            int i, n;
            n = ComboConexiones.Items.Count;
            for (i = 0; i < n; i++)
            {
                string s = (string)ComboConexiones.Items[i];
                if (s == nombre)
                {
                    if (ComboConexiones.SelectedIndex == i)
                        return;
                    ComboConexiones.SelectedIndex = i;
                    return;
                }
            }
            return;
        }
        public string DirConexiones
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
                return s + "\\CONEXIONES";
            }
        }
        private string QuitaDirectorio(string nombre)
        {
            string s = "";
            int i, n;
            n = nombre.Length;
            for (i = 0; i < n; i++)
            {
                if (nombre[i] == '\\')
                    s = "";
                else
                    s = s + nombre[i];
            }
            return s;
        }
        private void Conexion_Click(string opc)
        {
            //System.Windows.Forms.ToolStripMenuItem Submenu;
            //Submenu = (System.Windows.Forms.ToolStripMenuItem)sender;
            string archivo = DirConexionesGrupo + "\\" + opc;
            if (!System.IO.File.Exists(archivo))
            {
                MessageBox.Show("No se encontro la conexion");
                return;
            }
            AdministrarConexiones.CInstanciadorDB IDB = new AdministrarConexiones.CInstanciadorDB();
            DB = IDB.DameInstancia(DirConexionesGrupo, opc);
            try
            {
                DB.PruebaConexion();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return;
            }
            BConString.Tag = DB.ConnectionString;
            BConString.Text = DB.ConnectionString;
            //sincroniso con el combo
            int i, n;
            n = ComboConexiones.Items.Count;
            for (i = 0; i < n; i++)
            {
                string s = (string)ComboConexiones.Items[i];
                if (s == opc)
                {
                    if (ComboConexiones.SelectedIndex == i)
                        return;
                    ComboConexiones.SelectedIndex = i;
                    return;
                }
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.AboutBox1 dlg = new Visor_sql_2015.Formularios.AboutBox1();
            dlg.ShowDialog();
        }
        private void crearDiccionarioDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FormCrearDiccionario dlg = new Visor_sql_2015.Formularios.FormCrearDiccionario(DB);
            dlg.ShowDialog();
        }
        private void ComboConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboConexiones.SelectedIndex == -1)
                return;
            //System.Windows.Forms.ToolStripItem Submenu = conexionesToolStripMenuItem.DropDownItems[ComboConexiones.SelectedIndex];
            Conexion_Click(ComboConexiones.Text);

        }
        private void MuestraTablaPadre(string tabla, string campo)
        {
            //me traigo la tabla padre
            string tablaPadre = DB.DameTablaForanea(tabla, campo);
            if (tablaPadre == "")
                return;
            //busco el objeto
            System.Collections.Generic.List<Objetos.CSysObject> l;
            l = DB.BuscaObjetos(tablaPadre, Controladores_DB.TIPOOBJETO.TABLAX);
            if (l.Count == 0)
                return;
            MuestraVentana(l[0]);
        }
        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Nuevo codigo
            Inportador.FormImportar fSP = new Inportador.FormImportar(DB);
            fSP.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(OnCodigo);
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.Show();
            }
            VEditor.AgregaEditor(fSP, "IMPORTAR");
            #endregion
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Formularios.FormBase dlg = (Formularios.FormBase)ActiveMdiChild;
            dlg.Guardar();
        }
        private void coloresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FormConfColores dlg = new Visor_sql_2015.Formularios.FormConfColores();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (Formularios.FormBase ch in MdiChildren)
            {
                ch.ActualizaColores();
            }
        }
        private bool dox;
        private void PropChangeHandlerX(Content c, Content.Property p)
        {
            if (c.Docked == dox)
                return;
            dox = c.Docked;
            int o = c.Order;
        }
        private void PropChangeHandler(Content c, Content.Property p)
        {
        }
        private void VentanaAcoplable(Form dlg, int ImajenIndex, bool PositionTop, State state)
        {
            Content c = _manager.Contents.Add(dlg, dlg.Text, imageList1, ImajenIndex);
            c.CaptionBar = true;
            c.CloseButton = true;
            c.PropertyChanged += new Content.PropChangeHandler(PropChangeHandler);
            Size s = new Size(dlg.Width, dlg.Height);
            c.DisplaySize = s;
            _manager.AddContentWithState(c, state);
            c.PropertyChanging += new Content.PropChangeHandler(PropChangeHandlerX);
            WindowContentTabbed wct = c.ParentWindowContent as WindowContentTabbed;
            if (wct != null)
            {
                wct.TabControl.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
                wct.TabControl.PositionTop = PositionTop;
            }

        }
        private void VentanaAcoplable2(Form dlg, int ImajenIndex, bool PositionTop, State state)
        {
            Content c = _manager2.Contents.Add(dlg, dlg.Text, imageList1, ImajenIndex);
            c.CaptionBar = true;
            c.CloseButton = true;
            Size s = new Size(dlg.Width, dlg.Height);
            c.DisplaySize = s;
            _manager2.AddContentWithState(c, state);
            WindowContentTabbed wct = c.ParentWindowContent as WindowContentTabbed;
            if (wct != null)
            {
                wct.TabControl.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
                wct.TabControl.PositionTop = PositionTop;
            }

        }
        private void crearTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearTablas.FormEditorTabla dlg = new CrearTablas.FormEditorTabla(DB);
            dlg.OnCodigo += new CrearTablas.OnCodigoEvent(VerCodigoTabla);
            dlg.Show(this);
/*
            CrearTablas.FormCrearTabla dlg = new Visor_sql_2015.CrearTablas.FormCrearTabla(DB);
            dlg.MdiParent = this;
            VentanaAcoplable(dlg, 0, false, State.DockLeft);
 */
        }
        private void exportarDocumentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Documentador.FormExportarDocuemntacion dlg = new Visor_sql_2015.Documentador.FormExportarDocuemntacion(DB);
            dlg.MdiParent = this;
            VentanaAcoplable(dlg, 0, false, State.DockLeft);
        }
        private void crearSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 2);
            dlg.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ComboConexiones.SelectedIndex == -1)
                ok = false;
            BCompBases.Enabled = ok;
            //crearDataGridToolStripMenuItem1.Enabled = ok;
            BDataGrid.Enabled = ok;
            BDiccionario.Enabled = ok;
            //crearTablaToolStripMenuItem.Enabled = ok;
            BCrearTabla.Enabled = ok;
            //exportarDocumentacionToolStripMenuItem.Enabled = ok;
            BExpDoct.Enabled = ok;
            BImportar.Enabled = ok;
            BVisorDependencias.Enabled = ok;
            newToolStripButton.Enabled = ok;
            openToolStripButton.Enabled = ok;
            saveToolStripButton.Enabled = ok;
            toolStripButton1.Enabled = ok;
            BMenuContex.Enabled = ok;
        }
        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
            }
            VEditor.Show();
        }
        private void OnCodigo(string nombre, string codigo)
        {
            #region Nueva ventana de codigo
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.Show();
            }
            Editor.TextEditX dlg = new Editor.TextEditX(nombre, DB);
            dlg.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            dlg.OnCodigoSP += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnCodigo);
            dlg.OnDependencias += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnDependencias);
            dlg.OnDependientes += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnDependientes);
            dlg.OnMuestraError += new Visor_sql_2015.Editor.OnMuestraErrorEvent(MuestraErrorX);
            dlg.OnLimpiaResultados += new Visor_sql_2015.Editor.OnLimpiaResultadosEvent(LimpiaResultados);
            dlg.OnMuestraGrids += new Visor_sql_2015.Editor.OnMuestraGridsEvent(MuestraGrids);
            dlg.SelectEdicion += new SelectTabByNameEvent(SelectTabByName);
            dlg.Codigo = codigo;
            VEditor.AgregaEditor(dlg, nombre);
            #endregion
        }
        private void MuestraCodigoVista(Objetos.CSysObject obj)
        {
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.Show();
            }
            Editor.TextEditX fVSP = new Editor.TextEditX(obj.Nombre, DB);
            fVSP.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            fVSP.OnDependencias += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnDependencias);
            fVSP.OnDependientes += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnDependientes);
            fVSP.OnMuestraError += new Visor_sql_2015.Editor.OnMuestraErrorEvent(MuestraErrorX);
            fVSP.OnLimpiaResultados += new Visor_sql_2015.Editor.OnLimpiaResultadosEvent(LimpiaResultados);
            fVSP.OnMuestraGrids += new Visor_sql_2015.Editor.OnMuestraGridsEvent(MuestraGrids);
            fVSP.SelectEdicion += new SelectTabByNameEvent(SelectTabByName);
            VEditor.AgregaEditor(fVSP, obj.Nombre);
        }
        private void OnCerrarEditor()
        {
            VEditor = null;
        }
        private void OnEjecuta(string nombre, string codigo)
        {
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
            }
            VEditor.Show();

            Editor.TextEditX dlg = new Editor.TextEditX(nombre, DB);
            dlg.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            dlg.OnMuestraError += new Visor_sql_2015.Editor.OnMuestraErrorEvent(MuestraErrorX);
            dlg.OnLimpiaResultados += new Visor_sql_2015.Editor.OnLimpiaResultadosEvent(LimpiaResultados);
            dlg.OnMuestraGrids += new Visor_sql_2015.Editor.OnMuestraGridsEvent(MuestraGrids);
            dlg.SelectEdicion += new SelectTabByNameEvent(SelectTabByName);
            dlg.Ejecuta(codigo);
            VEditor.AgregaEditor(dlg, nombre);

        }
        private void MuestraErrorX(object obj, Editor.TextEditX ed)
        {
            if (VResultados == null)
            {
                VResultados = new Visor_sql_2015.Editor.FormResultados();
                VResultados.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarResultados);
                VResultados.MdiParent = this;
                VentanaAcoplable(VResultados, 1, false, State.DockBottom);
            }
            VResultados.MuestraErrorX(obj, ed);
        }
        private void LimpiaResultados()
        {
            if (VResultados == null)
            {
                VResultados = new Visor_sql_2015.Editor.FormResultados();
                VResultados.MdiParent = this;
                VResultados.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarResultados);
                VentanaAcoplable(VResultados, 1, false, State.DockBottom);
            }
            VResultados.LimpiaResultados();
        }
        private void MuestraGrids(DataSet ds, string Msg)
        {
            if (VResultados == null)
            {
                VResultados = new Visor_sql_2015.Editor.FormResultados();
                VResultados.MdiParent = this;
                VResultados.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarResultados);
                VentanaAcoplable(VResultados, 1, false, State.DockBottom);
            }
            VResultados.MuestraGrids(ds, Msg);
        }
        private void OnCerrarResultados()
        {
            VResultados = null;
        }
        private void barraDeComandosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip1.Visible = barraDeComandosToolStripMenuItem.Checked;

        }
        private bool PuedoCerrar()
        {
            return Cerrando;
        }
        private bool PuedoCerrarPestaña()
        {
            return CerrarPespaña;
        }
        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cerrando = true;

        }
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarPespaña = false;
            if (Cerrando == false)
            {
                if (MessageBox.Show("Seguro que desea cerrar la aplicacion", "CERRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    if (VEditor != null)
                    {
                        VEditor.CanecaCerrarPestañas();
                        CerrarPespaña = true;
                    }
                    return;
                }
            }
            Cerrando = true;
            if (VEditor != null)
            {
                CerrarPespaña = true;
                if (VEditor.CierraPestañas() == false)
                {
                    //dieron cancelar el cerrado
                    e.Cancel = true;
                    return;
                }
                VEditor.Cierra();
                VEditor = null;
                Close();
                return;
            }
            VEditor = null;
        }
        private void diagramasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void visorDeDependenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Nuevo codigo
            Formularios.FormModelDominio fSP = new Formularios.FormModelDominio(DB);
            fSP.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            fSP.OnListaObjetosX += new Formularios.OnListaObjetosEvent(MuestraDependencias);
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.Show();
            }
            VEditor.AgregaEditor(fSP, "DEPENDENCIAS");
            #endregion
        }
        private bool  nuevo()
        {
            ShowNewForm(null, null);
            return true;
        }
        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.onNuevo += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(nuevo);
            }
            VEditor.Show();

            Editor.TextEditX dlg = new Editor.TextEditX("", DB);
            dlg.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            dlg.OnDependencias += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnDependencias);
            dlg.OnDependientes += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnDependientes);
            dlg.OnMuestraError += new Visor_sql_2015.Editor.OnMuestraErrorEvent(MuestraErrorX);
            dlg.OnLimpiaResultados += new Visor_sql_2015.Editor.OnLimpiaResultadosEvent(LimpiaResultados);
            dlg.OnMuestraGrids += new Visor_sql_2015.Editor.OnMuestraGridsEvent(MuestraGrids);
            dlg.OnCodigoSP += new Visor_sql_2015.Editor.OnCodigoSPEvent(OnCodigo);
            dlg.OnBuscarTexto += new Editor.OnBuscarTextoEvent(BuscarTexto);
            dlg.SelectEdicion += new SelectTabByNameEvent(SelectTabByName);
            VEditor.AgregaEditor(dlg, DB.Servidor + " - " + DB.BDName);
        }
        void BuscarTexto(string s)
        {
            if(s!="")
                TxtBuscar.Text = s;
            BBuscarSiguiente_ButtonClick(null, null);
        }
        private void CargaGrupos()
        {
            ComboGrupos.Items.Clear();
            string[] directorios;
            //se trae la lista de grupos de conexiones
            directorios = System.IO.Directory.GetDirectories(DirConexiones);
            foreach (string s in directorios)
            {
                int i, n, pos = 0;
                n = s.Length;
                for (i = 0; i < n; i++)
                {
                    if (s[i] == '\\')
                        pos = i;
                }
                ComboGrupos.Items.Add(s.Substring(pos + 1));
            }
        }
        private string Grupo
        {
            get
            {
                if (ComboGrupos.SelectedIndex == -1)
                    return "";
                return (string)ComboGrupos.Items[ComboGrupos.SelectedIndex];
            }
            set
            {
                if (ComboGrupos.Items.Count == 0)
                    CargaGrupos();
                int i, n;
                n = ComboGrupos.Items.Count;
                for (i = 0; i < n; i++)
                {
                    string s = (string)ComboGrupos.Items[i];
                    if (s == value)
                    {
                        ComboGrupos.SelectedIndex = i;
                        ComboGrupos_SelectedIndexChanged(null, null);
                        return;
                    }
                }
            }
        }
        private string DirConexionesGrupo
        {
            get
            {
                if (Grupo == "")
                    return DirConexiones;
                return DirConexiones + "\\" + Grupo;
            }
        }
        private void ComboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargo la lista de conexiones
            ComboConexiones.Items.Clear();
            //conexionesToolStripMenuItem.DropDownItems.Clear();
            int i, n;
            string[] archivos;
            if (System.IO.Directory.Exists(DirConexionesGrupo) == false)
            {
                System.IO.Directory.CreateDirectory(DirConexionesGrupo);
            }
            archivos = System.IO.Directory.GetFiles(DirConexionesGrupo);
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                System.Windows.Forms.ToolStripMenuItem Submenu = new System.Windows.Forms.ToolStripMenuItem();
                Submenu.Text = QuitaDirectorio(archivos[i]);
                //Submenu.Click += new System.EventHandler(this.Conexion_Click);
                //this.conexionesToolStripMenuItem.DropDownItems.Add(Submenu);
                ComboConexiones.Items.Add(Submenu.Text);
            }


        }
        private void ConexionGrupo(string cadena, string nombre, string grupo)
        {
            Grupo = grupo;
            OnConexion2(cadena, nombre);
        }
        private void OnConexion2(string cadena, string nombre)
        {
            AdministrarConexiones.CInstanciadorDB IDB = new AdministrarConexiones.CInstanciadorDB();
            DB = IDB.DameInstancia(DirConexiones+"\\"+Grupo, nombre);
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText("DBCONFIG.TXT");
            sw.WriteLine(DB.ConnectionString);
            sw.WriteLine(nombre);
            sw.Close();
            this.Text = DB.ConnectionString;
            //sincroniso con el combo
            int i, n;
            n = ComboConexiones.Items.Count;
            for (i = 0; i < n; i++)
            {
                string s = (string)ComboConexiones.Items[i];
                if (s == nombre)
                {
                    if (ComboConexiones.SelectedIndex == i)
                        return;
                    ComboConexiones.SelectedIndex = i;
                    return;
                }
            }
            return;
        }
        private void Addgrupo(string noombre)
        {
            //agrega el grupo a la lista
            ComboGrupos.Items.Add(noombre);
        }
        private void DeleteGrupo(string nombre)
        {
            int i, n;
            n = ComboGrupos.Items.Count;
            for (i = 0; i < n; i++)
            {
                string g=(string)ComboGrupos.Items[i];
                if (nombre == g)
                {
                    ComboGrupos.Items.RemoveAt(i);
                    return;
                }
            }
        }
        private void EditarTabla(string tabla)
        {
            Formularios.ForEditTabla dlg = new Visor_sql_2015.Formularios.ForEditTabla(DB,tabla);
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.Show();
            }
            VEditor.AgregaEditor(dlg, tabla);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (FormBucarx == null)
            {
                FormBucarx = new Visor_sql_2015.Formularios.FormBuscar(DB);

                FormBucarx.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
                FormBucarx.MdiParent = this;
                VentanaAcoplable(FormBucarx, 0, false, State.DockLeft);
            }
        }
        private void MuestraDependencias(System.Collections.Generic.List<Objetos.CSysObject> lista)
        {
            #region Nuevo codigo
            Diagramas.CDIagramas fSP = new Visor_sql_2015.Diagramas.CDIagramas(DB, lista);
            fSP.OnEjecuta += new Visor_sql_2015.Formularios.OnCodigoEvent(OnEjecuta);
            fSP.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(OnCodigo);
            fSP.OnDependencias += new Visor_sql_2015.Formularios.OnCodigoEvent(OnDependencias);
            fSP.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            fSP.OnDocuemntar += new Visor_sql_2015.Formularios.OnDocuemntarEvent(OnDocumentar);
            fSP.OnTrasar += new Visor_sql_2015.Formularios.OnCodigoEvent(OnTrasar);
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrar);
                VEditor.Show();
            }
            VEditor.AgregaEditor(fSP, "DIAGRAMA");
            #endregion
        }
        private void TxtConString_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(BConString.Tag.ToString());
            MessageBox.Show("Cadena de Conexion Copiada al Portapapeles");
        }

        private void IncompleteResults_Click(object sender, EventArgs e)
        {
            if (!_ResultadosIncompletos)
            {
                _ResultadosIncompletos = !_ResultadosIncompletos;
                IncompleteResults.Checked = true;
                IncompleteResults.Image = Properties.Resources.checkOk;
            }
            else
            {
                _ResultadosIncompletos = !_ResultadosIncompletos;
                IncompleteResults.Checked = false;
                IncompleteResults.Image = Properties.Resources.CheckX;
            }
        }

        private void administrarPatronesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patrones.FormAdminPatrones dlg = new Visor_sql_2015.patrones.FormAdminPatrones();
            dlg.MdiParent = this;
            dlg.Show();
        }
        private void compararBasesDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FormCompararBases dlg = new Visor_sql_2015.Formularios.FormCompararBases(DB);
            dlg.OnVerObjeto += new Visor_sql_2015.Formularios.OnVerObjetoEvent(MuestraVentana);
            dlg.OnComprarCodigo += new Formularios.OnComprarCodigoEvent(ComparaCadenas);
            dlg.MdiParent = this;
            VentanaAcoplable(dlg, 0, false, State.DockLeft);
        }
        private void ComparaCadenas(string cadena1, string caption1, string cadena2, string caption2)
        {
            ComparadorCadenas comparador = new ComparadorCadenas(cadena1, ComboConexiones.Text, cadena2, caption2);
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.Show();
            }
            VEditor.AgregaEditor(comparador, "Comparar");
        }
        public void OnDocumentar(Formularios.FormDocumentar dlg)
        {
//            Formularios.FormDocumentar dlg = new Formularios.FormDocumentar(tabla, DB);
            if (VEditor == null)
            {
                VEditor = new Visor_sql_2015.Editor.FormEditor(DB);
                VEditor.MdiParent = this;
                VEditor.OnCerrar += new Visor_sql_2015.Editor.OnCerrarEvent(OnCerrarEditor);
                VEditor.OnPuedoCerrar += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(PuedoCerrarPestaña);
                VEditor.onNuevo += new Visor_sql_2015.Editor.OnPuedoCerrarEvent(nuevo);
            }
            VEditor.Show();
            VEditor.AgregaEditor(dlg, DB.Servidor + " - " + DB.BDName);

        }


        private void opcionBoton1_ButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("hola");

        }

        private void CHCadenaConexion_CheckedChanged(object sender, EventArgs e)
        {
            BConString.Visible=CHCadenaConexion.Checked;
        }

        private void opcionBoton5_ButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BCompiar_Click(object sender, EventArgs e)
        {

        }

        private void BCortar_Click(object sender, EventArgs e)
        {

        }

        private void BPegar_ButtonClick(object sender, EventArgs e)
        {

        }

        private void BDesHacer_ButtonClick(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.EdicionReHacer();

        }

        private void BReHacer_ButtonClick(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.EdicionDeshacer();
        }

        private void Bejecutar_ButtonClick(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.Ejecutar();

        }

        private void BComentar_ButtonClick(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.Comentar();

        }

        private void BDescomentar_ButtonClick(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.DesComentar();
        }

        private void BBuscarAnterior_Load(object sender, EventArgs e)
        {

        }

        private void BBuscarSiguiente_ButtonClick(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.FindNext(false, false, "No se encontró el elemento", TxtBuscar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
        }

        private void BBuscarAnterior_ButtonClick(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.FindNext(false, true, "No se encontró el elemento", TxtBuscar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
        }

        private void BRemplazarTodo_Click(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.RemplazarTodo(TxtBuscar.Text, TxtReemplazar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
        }

        private void BRemplazarSiguiente_Click(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.ReemplazarSiguiente(TxtBuscar.Text, TxtReemplazar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked);
        }

        private void LColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            LColor.BackColor = colorDialog1.Color;

        }

        private void BMarcar_Click(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.MarcarCoincidencias(TxtBuscar.Text, CHMayuscMinus.Checked, CHPalabraCompleta.Checked, LColor.BackColor);

        }

        private void BImprimir_ButtonClick(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.Imprimir();

        }

        private void BconfigurarPagina_Click(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.ConfigurarPagina();

        }

        private void BVistaPrevia_Click(object sender, EventArgs e)
        {
            if (VEditor != null)
                VEditor.VistaPrevia();

        }
        private string TabName;
        private void SelectTabByName(string tabName)
        {
            TabName = tabName;
            TselecTab.Enabled = true;
        }

        private void FormTablaActual(Formularios.FormTablaX obj)
        {
            TablaActual = obj;
        }

        private void BSPInter_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.GeneraSPAlta();
        }

        private void BSPDelete_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.GeneraSPDelete();
            
        }

        private void BSPUpdate_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.GeneraSPUpdate();
            
        }

        private void BSPSelect_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.GeneraSPSelect();
            
        }
        private void TselecTab_Tick(object sender, EventArgs e)
        {
            TselecTab.Enabled = false;
            tabControl1.SelectTab(TabName);
            //caso especial si es el editor de texto, asigno el  foco al editor de texto ya que lo pierdo
            if (TabName == "TabEdicion")
            {
                if (VEditor != null)
                    VEditor.SetFocus();
            }
            if (TabName == "Tabtabla")
            {
                if (TablaActual != null)
                {
                    TablaActual.TenFoco();
                }
            }
        }

        private void opcionBoton2_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.AgregaLLaveForanea();

        }

        private void opcionBoton3_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.QuitaLLaveForanea();

        }

        private void opcionBoton4_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.VerDependecias();
        }

        private void opcionBoton6_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.trazar();
        }

        private void opcionBoton7_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.Documentar();
        }

        private void opcionBoton8_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.VerCodigo();

        }

        private void opcionBoton9_ButtonClick(object sender, EventArgs e)
        {
            if (TablaActual != null)
                TablaActual.VerContenido();
        }
        private void VerCodigoTabla(string s)
        {
            OnCodigo("", s);
        }
    }
}