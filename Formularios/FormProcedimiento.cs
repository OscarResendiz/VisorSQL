using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    /// <summary>
    /// Summary description for FormProcedimiento.
    /// </summary>
    public partial class FormProcedimiento : FormBase
    {
        private string FNombreProcedimiento;
        private DialogResult resultado;
        Controladores_DB.IDataBase DB;
        public bool RegresaDatos;
        public string Nombre;
        private AsisBase Actual;
        private AsistInicio Inicio;
        private AsisSelCampos SelCampos;
        private AsisTipoRetorno AsisTipoRetorno;
        private AsisTipoEjecucion TipoEjecucion=null;
        private bool FEstatica;
        private bool FCrearSqlConnection;
        private bool FLeerConfiguracionASP;
        private string FSConnectionStrings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BSiguiente;
        private System.Windows.Forms.Button BAnterior;
        private System.Windows.Forms.Panel PanelPrincipal;

        public FormProcedimiento(Controladores_DB.IDataBase db, string NombreProcedimiento)//System.Data.SqlClient.SqlConnection conexion)
        {
            FNombreProcedimiento = NombreProcedimiento;
            InitializeComponent();
            DB = db;
            FEstatica = false;
            RegresaDatos = true;
            resultado = DialogResult;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcedimiento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BAnterior = new System.Windows.Forms.Button();
            this.BSiguiente = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.BAnterior);
            this.panel1.Controls.Add(this.BSiguiente);
            this.panel1.Controls.Add(this.BCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 369);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 69);
            this.panel1.TabIndex = 6;
            // 
            // BAnterior
            // 
            this.BAnterior.BackColor = System.Drawing.Color.Black;
            this.BAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BAnterior.Image = ((System.Drawing.Image)(resources.GetObject("BAnterior.Image")));
            this.BAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAnterior.Location = new System.Drawing.Point(57, 4);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(91, 51);
            this.BAnterior.TabIndex = 0;
            this.BAnterior.Text = "Anterior";
            this.BAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAnterior.UseVisualStyleBackColor = false;
            this.BAnterior.Click += new System.EventHandler(this.BAnterior_Click);
            // 
            // BSiguiente
            // 
            this.BSiguiente.BackColor = System.Drawing.Color.Black;
            this.BSiguiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("BSiguiente.Image")));
            this.BSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BSiguiente.Location = new System.Drawing.Point(343, 4);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(91, 51);
            this.BSiguiente.TabIndex = 1;
            this.BSiguiente.Text = "Siguiente ";
            this.BSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BSiguiente.UseVisualStyleBackColor = false;
            this.BSiguiente.Click += new System.EventHandler(this.BSiguiente_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(635, 3);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(91, 52);
            this.BCancelar.TabIndex = 2;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(815, 369);
            this.PanelPrincipal.TabIndex = 7;
            // 
            // formOpacador1
            // 
            this.formOpacador1.AutoCerrar = true;
            this.formOpacador1.Degradado = true;
            this.formOpacador1.Formulario = this;
            this.formOpacador1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.formOpacador1.PrimerColor = System.Drawing.Color.Gray;
            this.formOpacador1.SegundoColor = System.Drawing.Color.Black;
            this.formOpacador1.Tiempo = 10;
            this.formOpacador1.Visible = true;
            // 
            // FormProcedimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(815, 438);
            this.ControlBox = false;
            this.Controls.Add(this.PanelPrincipal);
            this.Controls.Add(this.panel1);
            this.Name = "FormProcedimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistente para crear procedimientos";
            this.Load += new System.EventHandler(this.FormProcedimiento_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProcedimiento_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void FormProcedimiento_Load(object sender, System.EventArgs e)
        {
            Inicio = new AsistInicio();
            Inicio.Parent = this.PanelPrincipal;
            Inicio.OnEnableAnterior += new OnBotonEnableEvent(this.EnableAnterior);
            Inicio.OnEnableSiguiente += new OnBotonEnableEvent(this.EnableSiguiente);
            Inicio.OnEnableCancelar += new OnBotonEnableEvent(this.EnableCancelar);
            Inicio.OnPantalla += new OnPantallaEvent(OnPantalla);
            Inicio.OnSiguiente += new OnBotonEvent(Inicio_Sigueinte);
            Inicio.Nombre = this.Nombre;
            Inicio.Muestrate();

        }
        #region funciones para contrl de los botones
        private void EnableAnterior(object sender, bool valor)
        {
            this.BAnterior.Enabled = valor;
        }
        private void EnableSiguiente(object sender, bool valor)
        {
            this.BSiguiente.Enabled = valor;
        }
        private void EnableCancelar(object sender, bool valor)
        {
            this.BCancelar.Enabled = valor;
        }
        #endregion
        private void Inicio_Sigueinte(object sender)
        {
            this.Nombre = Inicio.Nombre;
            this.FEstatica = Inicio.Estatica;
            FCrearSqlConnection = Inicio.CrearSqlConnection;
            FLeerConfiguracionASP = Inicio.LeerConfiguracionASP;
            FSConnectionStrings = Inicio.SConnectionStrings;
            if (SelCampos == null)
            {
                SelCampos = new AsisSelCampos(DB, FNombreProcedimiento);
                SelCampos.Parent = this.PanelPrincipal;
                SelCampos.OnEnableAnterior += new OnBotonEnableEvent(this.EnableAnterior);
                SelCampos.OnEnableSiguiente += new OnBotonEnableEvent(this.EnableSiguiente);
                SelCampos.OnEnableCancelar += new OnBotonEnableEvent(this.EnableCancelar);
                SelCampos.OnPantalla += new OnPantallaEvent(OnPantalla);
                SelCampos.OnSiguiente += new OnBotonEvent(SelCampos_Sigueinte);
                SelCampos.OnNoDatos += new OnNoDatosEvent(OnNoDatos);
                SelCampos.FAnterior = Inicio;
            }
            Inicio.FSiguiente = SelCampos;
            SelCampos.Muestrate();
            Inicio.Visible = false;
            return;
        }
        private void OnNoDatos()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            resultado = DialogResult;
            RegresaDatos = false;
           // Close();
        }
        private void OnPantalla(AsisBase pantalla)
        {
            Actual = pantalla;
        }

        private void BCancelar_Click(object sender, System.EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Seguro que desea salir del asistente", "salir", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BSiguiente_Click(object sender, System.EventArgs e)
        {
            Actual.Siguiente();
        }

        private void BAnterior_Click(object sender, System.EventArgs e)
        {
            Actual.Anterior();
        }
        public string Retorno
        {
            get
            {
                string s = "void";
                switch (TipoRetornoX)
                {
                    case ENUMTipoRetorno.DATO:
                        s = this.Clase;
                        break;
                    case ENUMTipoRetorno.LISTA:
                        s = "System.Collections.ArrayList";
                        break;
                    case ENUMTipoRetorno.LISTA_GENERICA:
                        s = "System.Collections.Generic.List<" + Clase + "> ";
                        break;
                }
                return s;
            }
        }
        private void TipoEjecucion_Sigueinte(object sender)
        {
            this.RegresaDatos = TipoEjecucion.RegresaDatos;
            if (!RegresaDatos)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                resultado = DialogResult;
                Close();
            }
            if (SelCampos == null)
            {
                SelCampos = new AsisSelCampos(DB, FNombreProcedimiento);
                SelCampos.Parent = this.PanelPrincipal;
                SelCampos.OnEnableAnterior += new OnBotonEnableEvent(this.EnableAnterior);
                SelCampos.OnEnableSiguiente += new OnBotonEnableEvent(this.EnableSiguiente);
                SelCampos.OnEnableCancelar += new OnBotonEnableEvent(this.EnableCancelar);
                SelCampos.OnPantalla += new OnPantallaEvent(OnPantalla);
                SelCampos.OnSiguiente += new OnBotonEvent(SelCampos_Sigueinte);
                SelCampos.FAnterior = SelCampos;
            }
            SelCampos.FSiguiente = SelCampos;
            SelCampos.Muestrate();
            TipoEjecucion.Visible = false;
            return;
        }
        public bool CrearComponente
        {
            get
            {
                return this.Inicio.CrearComponente;
            }
        }
        private void SelCampos_Sigueinte(object sender)
        {
            if (AsisTipoRetorno == null)
            {
                AsisTipoRetorno = new AsisTipoRetorno();
                AsisTipoRetorno.Parent = this.PanelPrincipal;
                AsisTipoRetorno.OnEnableAnterior += new OnBotonEnableEvent(this.EnableAnterior);
                AsisTipoRetorno.OnEnableSiguiente += new OnBotonEnableEvent(this.EnableSiguiente);
                AsisTipoRetorno.OnEnableCancelar += new OnBotonEnableEvent(this.EnableCancelar);
                AsisTipoRetorno.OnPantalla += new OnPantallaEvent(OnPantalla);
                AsisTipoRetorno.OnSiguiente += new OnBotonEvent(AsisTipoRetorno_Sigueinte);
                AsisTipoRetorno.FAnterior = SelCampos;
            }
            SelCampos.FSiguiente = AsisTipoRetorno;
            AsisTipoRetorno.Muestrate();
            SelCampos.Visible = false;
        }
        private void AsisTipoRetorno_Sigueinte(object sender)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            resultado=DialogResult;
            Close();


        }

        private Opacador.FormOpacador formOpacador1;
        private IContainer components;
    
        public ENUMTipoRetorno TipoRetornoX
        {
            get
            {
                if (AsisTipoRetorno != null)
                    return AsisTipoRetorno.TipoRetornoX;
                return ENUMTipoRetorno.NADA;
            }
        }
        public System.Collections.Generic.List<Objetos.CParametro> CamposRegresar
        {
            get
            {
                if (SelCampos!=null)
                {
                    return SelCampos.CamposRegresar;
                }
                return new System.Collections.Generic.List<Objetos.CParametro>();
            }
        }
        public string Clase
        {
            get
            {
                return this.SelCampos.Clase;
            }
        }
        public bool Estatica
        {
            get
            {
                return FEstatica;
            }
        }
        public bool CrearSqlConnection
        {
            get
            {
                return FCrearSqlConnection;
            }
        }
        public bool LeerConfiguracionASP
        {
            get
            {
                return FLeerConfiguracionASP;
            }
        }
        public string SConnectionStrings
        {
            get
            {
                return FSConnectionStrings;
            }
        }

        private void FormProcedimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = resultado;
        }
    }
}
