namespace Visor_sql_2015.Formularios
{
    partial class FormTablaX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lfecha = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cTabla1 = new Visor_sql_2015.Componentes.CTabla();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.Lfecha);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 45);
            this.panel1.TabIndex = 0;
            // 
            // Lfecha
            // 
            this.Lfecha.AutoSize = true;
            this.Lfecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Lfecha.Location = new System.Drawing.Point(3, 25);
            this.Lfecha.Name = "Lfecha";
            this.Lfecha.Size = new System.Drawing.Size(114, 13);
            this.Lfecha.TabIndex = 2;
            this.Lfecha.Text = "Fecha de modificacion";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 4);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(200, 20);
            this.TNombre.TabIndex = 1;
            this.TNombre.Enter += new System.EventHandler(this.TNombre_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.cTabla1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 458);
            this.panel2.TabIndex = 1;
            // 
            // cTabla1
            // 
            this.cTabla1.BackColor = System.Drawing.Color.Transparent;
            this.cTabla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTabla1.Location = new System.Drawing.Point(0, 0);
            this.cTabla1.Name = "cTabla1";
            this.cTabla1.Size = new System.Drawing.Size(271, 458);
            this.cTabla1.TabIndex = 0;
            this.cTabla1.OnVerTablaPadre += new Visor_sql_2015.OnVerTablaPadreEvent(this.cTabla1_OnVerTablaPadre);
            this.cTabla1.OnCampoSeleccionado += new Visor_sql_2015.OnVerTablaPadreEvent(this.cTabla1_OnCampoSeleccionado);
            this.cTabla1.OnFocoEnter += new Visor_sql_2015.OnFocoEnterEvent(this.cTabla1_OnFocoEnter);
            // 
            // formOpacador1
            // 
            this.formOpacador1.AutoCerrar = true;
            this.formOpacador1.Degradado = true;
            this.formOpacador1.Formulario = this;
            this.formOpacador1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.formOpacador1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.formOpacador1.SegundoColor = System.Drawing.Color.Black;
            this.formOpacador1.Tiempo = 10;
            this.formOpacador1.Visible = true;
            // 
            // FormTablaX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTablaX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades de la tabla";
            this.Load += new System.EventHandler(this.FormTabla_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Visor_sql_2015.Componentes.CTabla cTabla1;
        private System.Windows.Forms.Label Lfecha;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Opacador.FormOpacador formOpacador1;
    }
}