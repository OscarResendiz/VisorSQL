namespace Visor_sql_2015.AdministrarConexiones
{
    partial class FormAdminConexiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminConexiones));
            this.ListaConexiones = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BConectar = new System.Windows.Forms.Button();
            this.BEliminar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.SuspendLayout();
            // 
            // ListaConexiones
            // 
            this.ListaConexiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ListaConexiones.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListaConexiones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaConexiones.FormattingEnabled = true;
            this.ListaConexiones.Location = new System.Drawing.Point(0, 0);
            this.ListaConexiones.Name = "ListaConexiones";
            this.ListaConexiones.Size = new System.Drawing.Size(384, 433);
            this.ListaConexiones.TabIndex = 0;
            this.ListaConexiones.DoubleClick += new System.EventHandler(this.ListaConexiones_DoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Agregar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BConectar
            // 
            this.BConectar.BackColor = System.Drawing.Color.Black;
            this.BConectar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BConectar.Image = ((System.Drawing.Image)(resources.GetObject("BConectar.Image")));
            this.BConectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BConectar.Location = new System.Drawing.Point(105, 441);
            this.BConectar.Name = "BConectar";
            this.BConectar.Size = new System.Drawing.Size(87, 44);
            this.BConectar.TabIndex = 2;
            this.BConectar.Text = "Conectar";
            this.BConectar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BConectar.UseVisualStyleBackColor = false;
            this.BConectar.Click += new System.EventHandler(this.BConectar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.BackColor = System.Drawing.Color.Black;
            this.BEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BEliminar.Image")));
            this.BEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminar.Location = new System.Drawing.Point(198, 441);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(87, 44);
            this.BEliminar.TabIndex = 3;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEliminar.UseVisualStyleBackColor = false;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(291, 441);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 44);
            this.button4.TabIndex = 4;
            this.button4.Text = "Cerrar";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            // FormAdminConexiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 488);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.BConectar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListaConexiones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdminConexiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar conexiones";
            this.Load += new System.EventHandler(this.FormAdminConexiones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListaConexiones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BConectar;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private Opacador.FormOpacador formOpacador1;
    }
}