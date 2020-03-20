using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class AsisSelTipoX : AsisBase
    {
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.ComponentModel.IContainer components = null;

        public AsisSelTipoX()
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
            this.LTitulo.Text = "Tipo de datos";
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 88);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(256, 24);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Obtener los datos desde una tabla o vista";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 136);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(232, 24);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "Especificar los datos en forma mnul";
            this.radioButton2.Visible = false;
            // 
            // AsisSelTipo
            // 
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "AsisSelTipo";
            this.Size = new System.Drawing.Size(432, 312);
            this.Controls.SetChildIndex(this.radioButton1, 0);
            this.Controls.SetChildIndex(this.radioButton2, 0);
            this.Controls.SetChildIndex(this.LTitulo, 0);
            this.ResumeLayout(false);

        }
        #endregion
        public bool SeleccionarDeTablas
        {
            get
            {
                return radioButton1.Checked;
            }
        }
    }
}

