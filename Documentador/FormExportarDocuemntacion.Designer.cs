namespace Visor_sql_2015.Documentador
{
    partial class FormExportarDocuemntacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportarDocuemntacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboGrupos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BAnalizar = new System.Windows.Forms.Button();
            this.ComboConexiones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBarraProgreso1 = new CBarraProgreso.CBarraProgreso();
            this.TimerDocumentar = new System.Windows.Forms.Timer(this.components);
            this.TablasDocuemntadas = new System.Windows.Forms.ListBox();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ComboGrupos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BAnalizar);
            this.panel1.Controls.Add(this.ComboConexiones);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 98);
            this.panel1.TabIndex = 1;
            // 
            // ComboGrupos
            // 
            this.ComboGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGrupos.FormattingEnabled = true;
            this.ComboGrupos.Location = new System.Drawing.Point(8, 23);
            this.ComboGrupos.Name = "ComboGrupos";
            this.ComboGrupos.Size = new System.Drawing.Size(199, 21);
            this.ComboGrupos.TabIndex = 3;
            this.ComboGrupos.SelectedIndexChanged += new System.EventHandler(this.ComboGrupos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grupo";
            // 
            // BAnalizar
            // 
            this.BAnalizar.BackColor = System.Drawing.Color.Black;
            this.BAnalizar.Enabled = false;
            this.BAnalizar.Image = ((System.Drawing.Image)(resources.GetObject("BAnalizar.Image")));
            this.BAnalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAnalizar.Location = new System.Drawing.Point(216, 29);
            this.BAnalizar.Name = "BAnalizar";
            this.BAnalizar.Size = new System.Drawing.Size(92, 43);
            this.BAnalizar.TabIndex = 0;
            this.BAnalizar.Text = "Exportar";
            this.BAnalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAnalizar.UseVisualStyleBackColor = false;
            this.BAnalizar.Click += new System.EventHandler(this.button2_Click);
            // 
            // ComboConexiones
            // 
            this.ComboConexiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboConexiones.FormattingEnabled = true;
            this.ComboConexiones.Location = new System.Drawing.Point(8, 63);
            this.ComboConexiones.Name = "ComboConexiones";
            this.ComboConexiones.Size = new System.Drawing.Size(199, 21);
            this.ComboConexiones.TabIndex = 1;
            this.ComboConexiones.SelectedIndexChanged += new System.EventHandler(this.ComboConexiones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base de datos a documentar";
            // 
            // cBarraProgreso1
            // 
            this.cBarraProgreso1.BackColor = System.Drawing.Color.Transparent;
            this.cBarraProgreso1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cBarraProgreso1.ColorDeBarra = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cBarraProgreso1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBarraProgreso1.ForeColor = System.Drawing.Color.Red;
            this.cBarraProgreso1.Location = new System.Drawing.Point(0, 425);
            this.cBarraProgreso1.MostrarTexto = true;
            this.cBarraProgreso1.Name = "cBarraProgreso1";
            this.cBarraProgreso1.Progreso = 0;
            this.cBarraProgreso1.ProgresoHorizontal = true;
            this.cBarraProgreso1.Size = new System.Drawing.Size(322, 24);
            this.cBarraProgreso1.TabIndex = 2;
            this.cBarraProgreso1.Texto = null;
            this.cBarraProgreso1.ValorMaximo = 100;
            // 
            // TimerDocumentar
            // 
            this.TimerDocumentar.Tick += new System.EventHandler(this.TimerDocumentar_Tick);
            // 
            // TablasDocuemntadas
            // 
            this.TablasDocuemntadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TablasDocuemntadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablasDocuemntadas.FormattingEnabled = true;
            this.TablasDocuemntadas.Location = new System.Drawing.Point(0, 98);
            this.TablasDocuemntadas.Name = "TablasDocuemntadas";
            this.TablasDocuemntadas.Size = new System.Drawing.Size(322, 316);
            this.TablasDocuemntadas.TabIndex = 3;
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
            // FormExportarDocuemntacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 449);
            this.Controls.Add(this.TablasDocuemntadas);
            this.Controls.Add(this.cBarraProgreso1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Name = "FormExportarDocuemntacion";
            this.Text = "Exportar documentación";
            this.Load += new System.EventHandler(this.FormExportarDocuemntacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BAnalizar;
        private System.Windows.Forms.ComboBox ComboConexiones;
        private System.Windows.Forms.Label label1;
        private CBarraProgreso.CBarraProgreso cBarraProgreso1;
        private System.Windows.Forms.Timer TimerDocumentar;
        private System.Windows.Forms.ListBox TablasDocuemntadas;
        private System.Windows.Forms.ComboBox ComboGrupos;
        private System.Windows.Forms.Label label2;
        private Opacador.FormOpacador formOpacador1;
    }
}