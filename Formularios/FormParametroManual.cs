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
    /// Summary description for FormParametroManual.
    public delegate void OnDatoManualEvent(string nombre, string tipo);	/// </summary>
    public partial class FormParametroManual : FormBase
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.ComboBox ComboTipo;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        public event OnDatoManualEvent OnDatoManual;

        public FormParametroManual()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParametroManual));
            this.label1 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ComboTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(56, 16);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(100, 20);
            this.TNombre.TabIndex = 1;
            this.TNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TNombre_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(176, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Agregar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(175, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cerrar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ComboTipo
            // 
            this.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipo.Items.AddRange(new object[] {
            "int",
            "System.DateTime",
            "float",
            "string"});
            this.ComboTipo.Location = new System.Drawing.Point(48, 48);
            this.ComboTipo.Name = "ComboTipo";
            this.ComboTipo.Size = new System.Drawing.Size(121, 21);
            this.ComboTipo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(0, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // FormParametroManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(276, 93);
            this.ControlBox = false;
            this.Controls.Add(this.ComboTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Name = "FormParametroManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void button2_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            bool ok = true;
            if (this.TNombre.Text.Trim() == "")
                ok = false;
            if (this.ComboTipo.SelectedIndex == -1)
                ok = false;
            button1.Enabled = ok;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (OnDatoManual != null)
                OnDatoManual(this.TNombre.Text, (string)this.ComboTipo.Items[this.ComboTipo.SelectedIndex]);
            TNombre.Text = "";
            TNombre.Focus();
        }

        private void TNombre_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (button1.Enabled == true)
                    button1_Click(null, null);

            }
        }

        private Opacador.FormOpacador formOpacador1;
    }
}
