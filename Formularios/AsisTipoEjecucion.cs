using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class AsisTipoEjecucion : AsisBase
    {
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.ComponentModel.IContainer components = null;

        public AsisTipoEjecucion()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
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

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // LTitulo
            // 
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Text = "TIPO DE EJECUCION";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 64);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "Solo ejecutar";
            // 
            // radioButton2
            // 
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 104);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(232, 24);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Devolver record set";
            // 
            // AsisTipoEjecucion
            // 
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "AsisTipoEjecucion";
            this.Controls.SetChildIndex(this.radioButton1, 0);
            this.Controls.SetChildIndex(this.radioButton2, 0);
            this.Controls.SetChildIndex(this.LTitulo, 0);
            this.ResumeLayout(false);

        }
        #endregion
        public override void Muestrate()
        {
            Dock = System.Windows.Forms.DockStyle.Fill;
            this.Visible = true;
            this.EnableAnterio = true;
            this.EnableSiguiente = true;
            this.EnableCancelar = true;
            Asigname(this);
        }
        public bool RegresaDatos
        {
            get
            {
                if (radioButton2.Checked)
                    return true;
                return false;
            }
        }
    }
}

