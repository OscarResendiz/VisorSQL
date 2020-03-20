using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public delegate void OnCodigoEvent(string Nombre, string Codigo);
    public delegate void OnDocuemntarEvent(Formularios.FormDocumentar dlg);
    public delegate void OnEditarEvent(string tabla);
    public delegate void OnMuestraTablaPadreEvent(string tabla, string campo);
    public delegate void OnFormTablaActualEvent(FormTablaX tabla);
    public partial class FormTablaX : FormBase
    {
        private System.Windows.Forms.TextBox ComponenteActual;
        public event OnVerTablaPadreEvent OnCampoSeleccionado;
        public event OnVerObjetoEvent OnVerObjeto;
        private Controladores_DB.TIPOOBJETO Tipo;
        public event OnMuestraTablaPadreEvent OnMuestraTablaPadre;
        public event OnDocuemntarEvent OnDocuemntar;
        Controladores_DB.IDataBase DB;
        public event OnCodigoEvent OnCodigo;
        public event OnCodigoEvent OnEjecuta;
        public event OnCodigoEvent OnDependencias;
        public event OnCodigoEvent OnDependientes;
        public event OnCodigoEvent OnTrasar;
        public event OnEditarEvent OnEditarTabla;
        public event OnEditarEvent OnChageCampo;
        public event SelectTabByNameEvent SelectTab;
        public event OnFormTablaActualEvent OnFormTablaActual;
        private System.Collections.Generic.List<Objetos.CParametro> Campos = null;
        public FormTablaX(string Nombre, Controladores_DB.IDataBase db, Controladores_DB.TIPOOBJETO tipo)
        {
            DB = db;
            Tipo = tipo;
            InitializeComponent();
            TNombre.Text = Nombre;
            Text = Nombre;
            Lfecha.Text = "Fecha de modificacion: " + DB.DameFechaModificacion(TNombre.Text);
            Campos = DB.DameCamposTabla(TNombre.Text);
            MuestraCampos();
            if (cTabla1.VerticalScroll == true)
            {
                //tiene el scrol porll que asigno el tamaño
                Width = 308;
            }
            else
            {
                Width = 287;
            }
        }
        private void MuestraCampos()
        {
            cTabla1.Clear();
            foreach (Objetos.CParametro dato in Campos)
            {
                bool nulos = false;
                if (dato.NULOS.ToUpper().Trim() == "SI")
                    nulos = true;
                bool pk = DB.EsLLavePrimaria(TNombre.Text, dato.nombre);
                bool fk = DB.EsLLaveForanea(TNombre.Text, dato.nombre);
                string documentacion = DB.DameDescripcionCampo(TNombre.Text, dato.nombre);
                cTabla1.Add(dato.nombre, dato.tipo + "(" + dato.Logitud + ")", pk, fk, nulos, documentacion);
            }
            //Height = toolStrip1.Height + panel1.Height + cTabla1.Tamaño+35;
        }

        private void FormTabla_Load(object sender, EventArgs e)
        {
            //            Lfecha.Text = "Fecha de modificacion: " + DB.DameFechaModificacion(TNombre.Text);
            //            Campos = DB.DameCamposTabla(TNombre.Text);
            //            MuestraCampos();
            ////            timer1.Enabled = true;
        }

        private void generarClaseCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string codigo = DB.CreaCodigoTabla(TNombre.Text);
            if (OnCodigo != null)
                OnCodigo("Clase " + TNombre.Text, codigo);
        }

        public void GeneraSPAlta()
        {
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 2);
            dlg.Tabla = TNombre.Text;
            dlg.OnCodigoSP += new OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();
        }
        public void GeneraSPDelete()
        {
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 4);
            dlg.Tabla = TNombre.Text;
            dlg.OnCodigoSP += new OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();
        }

        public void GeneraSPUpdate()
        {
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 3);
            dlg.Tabla = TNombre.Text;
            dlg.OnCodigoSP += new OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();
        }
        public void GeneraSPSelect()
        {
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 1);
            dlg.Tabla = TNombre.Text;
            dlg.OnCodigoSP += new OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();
        }
        private void GenCodigo(string nombre, string codigo)
        {
            if (OnCodigo != null)
                OnCodigo(nombre, codigo);
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void verDependientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnDependientes != null)
                OnDependientes("Dependientes de " + TNombre.Text, TNombre.Text);

        }




        private void cTabla1_OnVerTablaPadre(string campo)
        {
            if (OnMuestraTablaPadre != null)
                OnMuestraTablaPadre(TNombre.Text, campo);
        }
        public string Nombre
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text = value;
            }
        }
        private void MuestraCodigoVista()
        {
            System.Collections.Generic.List<Objetos.CSysObject> l;
            l = DB.BuscaObjetos(TNombre.Text, Tipo);
            if (OnVerObjeto != null)
                OnVerObjeto(l[0]);
        }
        public override void Guardar()
        {
            saveFileDialog1.FileName = TNombre.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText(saveFileDialog1.FileName);
            if (Tipo == Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTA)
            {
                sw.WriteLine(DB.DameCodigo(TNombre.Text));
                sw.Close();
                return;
            }
            sw.WriteLine(DB.GeneraCodigoTabla(Nombre, Campos));
            sw.Close();
        }

        private void cTabla1_OnCampoSeleccionado(string campo)
        {
            if (OnCampoSeleccionado != null)
                OnCampoSeleccionado(campo);
            if (SelectTab != null)
                SelectTab("Tabtabla");
            if (OnFormTablaActual != null)
                OnFormTablaActual(this);
        }

        private void TNombre_Enter(object sender, EventArgs e)
        {
            ComponenteActual = TNombre;
            if (OnCampoSeleccionado != null)
                OnCampoSeleccionado("Tabla "+Nombre);
            if (SelectTab != null)
                SelectTab("Tabtabla");
            if (OnFormTablaActual != null)
                OnFormTablaActual(this);
        }

        private void cTabla1_OnFocoEnter(Component componente)
        {
            ComponenteActual = (System.Windows.Forms.TextBox)componente;
        }
        public void TenFoco()
        {
            if (ComponenteActual != null)
                ComponenteActual.Focus();
        }
        public void AgregaLLaveForanea()
        {
            List<string> lista = new List<string>();
            foreach (Objetos.CParametro obj in Campos)
            {
                lista.Add(obj.nombre);
            }
            CrearTablas.FormRelaciones dlg = new Visor_sql_2015.CrearTablas.FormRelaciones(lista, DB, Nombre);
            //dlg.o
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            string s = dlg.CreaRelacion();
            try
            {
                DB.Ejecuta(s);
                FormTabla_Load(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public void QuitaLLaveForanea()
        {
            List<Objetos.CParametro> l;
            l = new List<Visor_sql_2015.Objetos.CParametro>();
            List<Objetos.CLLaveForanea> f;
            f = DB.DameLLavesForaneas(Nombre);
            foreach (Objetos.CLLaveForanea obj in f)
            {
                Objetos.CParametro p = new Visor_sql_2015.Objetos.CParametro();
                p.nombre = obj.name;
                l.Add(p);
            }
            CrearTablas.FormSeleccionarCampos dlg = new CrearTablas.FormSeleccionarCampos(l);
            dlg.Text = "Eliminar Relación";
            dlg.Texto = "Relacón";
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            string s = "alter table " + Nombre + " drop constraint " + dlg.Campo.nombre;
            try
            {
                DB.Ejecuta(s);
                FormTabla_Load(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public void VerDependecias()
        {
            if (OnDependencias != null)
                OnDependencias("Dependencia de " + TNombre.Text, TNombre.Text);
        }
        public void trazar()
        {
            if (OnTrasar != null)
                OnTrasar(TNombre.Text, TNombre.Text);
        }
        public void Documentar()
        {
            if (OnDocuemntar != null)
            {
                Formularios.FormDocumentar dlg = new Formularios.FormDocumentar(this.Nombre, DB);
                this.OnCampoSeleccionado = new OnVerTablaPadreEvent(dlg.CampoSeleccionado);
                OnDocuemntar(dlg);
            }
        }
        public void VerCodigo()
        {
            if (Tipo == Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTA)
            {
                MuestraCodigoVista();
                return;
            }
            if (OnCodigo != null)
                OnCodigo("Codigo para crear la tabla " + Nombre, DB.GeneraCodigoTabla(Nombre, Campos));
        }
        public void VerContenido()
        {
            if (OnEditarTabla != null)
            {
                OnEditarTabla(Nombre);
            }
        }
    }
}

