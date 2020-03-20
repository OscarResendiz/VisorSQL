using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public partial class FormAsistSP : Form
    {
        public event Formularios.OnCodigoSPEvent OnCodigoSP;
        Controladores_DB.IDataBase DB;
        private AsistBaseSP Asistente;
        public string Tabla;
        int Modo;
        public FormAsistSP(Controladores_DB.IDataBase db, int modo)
        {
            Modo = modo;
            DB = db;
            InitializeComponent();
        }
        #region Propiedades del boton Anterior
        public bool EnableAnterior
        {
            get
            {
                return BAnterior.Enabled;
            }
            set
            {
                BAnterior.Enabled = value;
            }
        }
        public string TextAnterior
        {
            get
            {
                return BAnterior.Text;
            }
            set
            {
                BAnterior.Text = value;
            }
        }
        #endregion
        #region Propiedades del boton Siguiente
        public bool EnableSiguiente
        {
            get
            {
                return BSiguiente.Enabled;
            }
            set
            {
                BSiguiente.Enabled = value;
            }
        }
        public string TextSiguiente
        {
            get
            {
                return BSiguiente.Text;
            }
            set
            {
                BSiguiente.Text = value;
            }
        }
        #endregion
        #region Propiedades del boton Cancelar
        public bool EnableCancelar
        {
            get
            {
                return BCancelar.Enabled;
            }
            set
            {
                BCancelar.Enabled = value;
            }
        }
        public string TextCancelar
        {
            get
            {
                return BCancelar.Text;
            }
            set
            {
                BCancelar.Text = value;
            }
        }
        #endregion
        #region manejo de eventos
        protected void FEnableAnterior(bool Valor)
        {
            EnableAnterior = Valor;
        }
        protected void FEnableSiguiente(bool Valor)
        {
            EnableSiguiente = Valor;
        }
        protected void FEnableCancelar(bool Valor)
        {
            EnableCancelar = Valor;
        }
        protected void FTextoAnterior(string Texto)
        {
            TextAnterior = Texto;
        }
        protected void FTextoSiguiente(string Texto)
        {
            TextSiguiente = Texto;
        }
        protected void FTextoCancelar(string Texto)
        {
            TextCancelar = Texto;
        }
        protected void FTextoPntalla(string Texto)
        {
            Text = Texto;
        }
        #endregion
        protected void OnInstalaAsistente(AsistBaseSP obj)
        {
            //se llama cuando el asistente base cambia
            if (Asistente != null)
            {
                if (Asistente == obj)
                    return;
                Asistente.Visible = false;
            }
            Asistente = obj;
           //le asigno todos sus eventos
            Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
            Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
            Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
            Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
            Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
            Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
            Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
            Asistente.OnCodigoSP += new Visor_sql_2015.Formularios.OnCodigoSPEvent(CodigoSP);
            Asistente.OnClose += new OnCloseEvent(CloseEvent);
            Asistente.Parent = Contenedor;
            Asistente.Dock = DockStyle.Fill;
            Asistente.Inicializate();
            Asistente.Visible = true;
        }

        private void FormAsistSP_Load(object sender, EventArgs e)
        {
            switch (Modo)
            {
                case 1: //SELECCION
                    Asistente = new AsistSps.AsisBienVenidaSelect(DB);
                    Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
                    Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
                    Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
                    Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
                    Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
                    Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
                    Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
                    Asistente.Parent = Contenedor;
                    Asistente.Dock = DockStyle.Fill;
                    AsistSps.AsisBienVenidaSelect tmp = (AsistSps.AsisBienVenidaSelect)Asistente;
                    tmp.NombreTabla = Tabla;
                    Asistente.Visible = true;
                    break;
                case 2: //INSERCION
                    Asistente = new AsistSps.AsisBienVenidaInsert(DB);
                    Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
                    Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
                    Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
                    Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
                    Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
                    Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
                    Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
                    Asistente.Parent = Contenedor;
                    Asistente.Dock = DockStyle.Fill;
                    AsistSps.AsisBienVenidaInsert tmp2 = (AsistSps.AsisBienVenidaInsert)Asistente;
                    tmp2.NombreTabla = Tabla;
                    Asistente.Visible = true;
                    break;
                case 3://actualizacion
                    Asistente = new AsistSps.AsisBienVenidaUpdate(DB);
                    Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
                    Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
                    Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
                    Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
                    Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
                    Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
                    Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
                    Asistente.Parent = Contenedor;
                    Asistente.Dock = DockStyle.Fill;
                    AsistSps.AsisBienVenidaUpdate tmp3 = (AsistSps.AsisBienVenidaUpdate)Asistente;
                    tmp3.NombreTabla = Tabla;
                    Asistente.Visible = true;
                    break;
                case 4://Borrado
                    Asistente = new AsistSps.AsisBienVenidaDelete(DB);
                    Asistente.OnEnableAnterior += new OnEnableEvent(FEnableAnterior);
                    Asistente.OnEnableCancelar += new OnEnableEvent(FEnableCancelar);
                    Asistente.OnEnableSiguiente += new OnEnableEvent(FEnableSiguiente);
                    Asistente.OnTextoAnterior += new OnCambiaTexto(FTextoAnterior);
                    Asistente.OnTextoCancelar += new OnCambiaTexto(FTextoCancelar);
                    Asistente.OnTextoSiguiente += new OnCambiaTexto(FTextoSiguiente);
                    Asistente.InstalameEvent += new OnInstalameEvent(OnInstalaAsistente);
                    Asistente.Parent = Contenedor;
                    Asistente.Dock = DockStyle.Fill;
                    AsistSps.AsisBienVenidaDelete tmp4 = (AsistSps.AsisBienVenidaDelete)Asistente;
                    tmp4.NombreTabla = Tabla;
                    Asistente.Visible = true;
                    break;
            }
        }

        private void BAnterior_Click(object sender, EventArgs e)
        {
            Asistente.BAnterio();
        }

        private void BSiguiente_Click(object sender, EventArgs e)
        {
            Asistente.BSiguiente();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Desea salir del asistente?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
              //  return;
            Close();
        }
        public void CodigoSP(string Nombre, string Codigo)
        {
            if (OnCodigoSP != null)
                OnCodigoSP(Nombre, Codigo);
        }
        public void CloseEvent()
        {
            Close();
        }

    }
}