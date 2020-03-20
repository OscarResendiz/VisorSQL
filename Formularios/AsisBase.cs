using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    /// <summary>
    /// Descripción breve de AsisBase.
    public delegate void OnPantallaEvent(AsisBase sender);
    public delegate void OnBotonEvent(object sender);
    public delegate void OnBotonEnableEvent(object sender, bool valor);
    /// </summary>
    public partial  class AsisBase : System.Windows.Forms.UserControl
    {
        public AsisBase FAnterior, FSiguiente;
        public System.Windows.Forms.Label LTitulo;
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        public event OnBotonEvent OnSiguiente;
        public event OnBotonEvent OnAnterior;
        public event OnBotonEnableEvent OnEnableSiguiente;
        public event OnBotonEnableEvent OnEnableAnterior;
        public event OnBotonEnableEvent OnEnableCancelar;
        public event OnPantallaEvent OnPantalla;
        private System.ComponentModel.Container components = null;

        public AsisBase()
        {
            // Llamada necesaria para el Diseñador de formularios Windows.Forms.
            InitializeComponent();

            // TODO: agregar cualquier inicialización después de llamar a InitializeComponent

        }

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
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

        #region Código generado por el Diseñador de componentes
        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LTitulo
            // 
            this.LTitulo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(64)));
            this.LTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.Color.Red;
            this.LTitulo.Location = new System.Drawing.Point(0, 0);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(432, 40);
            this.LTitulo.TabIndex = 1;
            this.LTitulo.Text = "Titulo";
            this.LTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AsisBase
            // 
            this.Controls.Add(this.LTitulo);
            this.Name = "AsisBase";
            this.Size = new System.Drawing.Size(432, 216);
            this.ResumeLayout(false);

        }
        #endregion
        public virtual void Siguiente()
        {
            if (OnSiguiente != null)
                OnSiguiente(this);
            else if (FSiguiente != null)
            {
                FSiguiente.Muestrate();
                this.Visible = false;
            }
        }
        public virtual void Anterior()
        {
            if (this.FAnterior != null)
            {
                FAnterior.Muestrate();
                this.Visible = false;
            }
            if (this.OnAnterior != null)
                OnAnterior(this);
        }
        protected bool EnableSiguiente
        {
            set
            {

                if (this.OnEnableSiguiente != null)
                    OnEnableSiguiente(this, value);
            }
        }
        protected bool EnableAnterio
        {
            set
            {
                if (this.OnEnableAnterior != null)
                    OnEnableAnterior(this, value);
            }
        }
        protected bool EnableCancelar
        {
            set
            {
                if (this.OnEnableCancelar != null)
                    OnEnableCancelar(this, value);
            }
        }
        public virtual void Muestrate()
        {
            Dock = System.Windows.Forms.DockStyle.Fill;
            this.Visible = true;
            this.EnableAnterio = true;
            this.EnableSiguiente = true;
            this.EnableCancelar = true;
            Asigname(this);
        }
        protected void Asigname(AsisBase pantalla)
        {
            if (OnPantalla != null)
                OnPantalla(pantalla);
        }

    }
}
