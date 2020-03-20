namespace Visor_sql_2015.Formularios
{
    partial class FormCompararBases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCompararBases));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboGrupos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboTipos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ComboConexiones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBarraProgreso1 = new CBarraProgreso.CBarraProgreso();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ListaObjetos = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarCadenasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearScripDeCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ComboVer = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ComboVer);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ComboGrupos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ComboTipos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.ComboConexiones);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 152);
            this.panel1.TabIndex = 0;
            // 
            // ComboGrupos
            // 
            this.ComboGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGrupos.FormattingEnabled = true;
            this.ComboGrupos.Items.AddRange(new object[] {
            "Todos",
            "Tablas",
            "Vistas",
            "Procedimientos almacenados",
            "Buscar en el código"});
            this.ComboGrupos.Location = new System.Drawing.Point(4, 16);
            this.ComboGrupos.Name = "ComboGrupos";
            this.ComboGrupos.Size = new System.Drawing.Size(198, 21);
            this.ComboGrupos.TabIndex = 9;
            this.ComboGrupos.SelectedIndexChanged += new System.EventHandler(this.ComboGrupos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Grupo";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ComboTipos
            // 
            this.ComboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipos.FormattingEnabled = true;
            this.ComboTipos.Items.AddRange(new object[] {
            "Todos",
            "Tablas",
            "Vistas",
            "Procedimientos almacenados",
            "Buscar en el código"});
            this.ComboTipos.Location = new System.Drawing.Point(4, 98);
            this.ComboTipos.Name = "ComboTipos";
            this.ComboTipos.Size = new System.Drawing.Size(198, 21);
            this.ComboTipos.TabIndex = 7;
            this.ComboTipos.SelectedIndexChanged += new System.EventHandler(this.ComboTipos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ttipo";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(207, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 43);
            this.button2.TabIndex = 0;
            this.button2.Text = "Analizar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ComboConexiones
            // 
            this.ComboConexiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboConexiones.FormattingEnabled = true;
            this.ComboConexiones.Location = new System.Drawing.Point(2, 60);
            this.ComboConexiones.Name = "ComboConexiones";
            this.ComboConexiones.Size = new System.Drawing.Size(199, 21);
            this.ComboConexiones.TabIndex = 1;
            this.ComboConexiones.SelectedIndexChanged += new System.EventHandler(this.ComboConexiones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base de datos a comparar";
            // 
            // cBarraProgreso1
            // 
            this.cBarraProgreso1.BackColor = System.Drawing.Color.Transparent;
            this.cBarraProgreso1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cBarraProgreso1.ColorDeBarra = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cBarraProgreso1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBarraProgreso1.ForeColor = System.Drawing.Color.Red;
            this.cBarraProgreso1.Location = new System.Drawing.Point(0, 484);
            this.cBarraProgreso1.MostrarTexto = true;
            this.cBarraProgreso1.Name = "cBarraProgreso1";
            this.cBarraProgreso1.Progreso = 0;
            this.cBarraProgreso1.ProgresoHorizontal = true;
            this.cBarraProgreso1.Size = new System.Drawing.Size(311, 24);
            this.cBarraProgreso1.TabIndex = 1;
            this.cBarraProgreso1.Texto = null;
            this.cBarraProgreso1.ValorMaximo = 100;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ListaObjetos);
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(311, 332);
            this.panel3.TabIndex = 4;
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaObjetos.ContextMenuStrip = this.contextMenuStrip1;
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaObjetos.FormattingEnabled = true;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 23);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.Size = new System.Drawing.Size(307, 236);
            this.ListaObjetos.TabIndex = 1;
            this.ListaObjetos.SelectedIndexChanged += new System.EventHandler(this.ListaObjetos_SelectedIndexChanged);
            this.ListaObjetos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListaObjetos_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarTodosToolStripMenuItem,
            this.comprarCadenasToolStripMenuItem,
            this.crearScripDeCambiosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 70);
            // 
            // mostrarTodosToolStripMenuItem
            // 
            this.mostrarTodosToolStripMenuItem.Name = "mostrarTodosToolStripMenuItem";
            this.mostrarTodosToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.mostrarTodosToolStripMenuItem.Text = "Mostrar Todos";
            this.mostrarTodosToolStripMenuItem.Click += new System.EventHandler(this.mostrarTodosToolStripMenuItem_Click);
            // 
            // comprarCadenasToolStripMenuItem
            // 
            this.comprarCadenasToolStripMenuItem.Name = "comprarCadenasToolStripMenuItem";
            this.comprarCadenasToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.comprarCadenasToolStripMenuItem.Text = "Comprar Cadenas";
            this.comprarCadenasToolStripMenuItem.Click += new System.EventHandler(this.comprarCadenasToolStripMenuItem_Click);
            // 
            // crearScripDeCambiosToolStripMenuItem
            // 
            this.crearScripDeCambiosToolStripMenuItem.Name = "crearScripDeCambiosToolStripMenuItem";
            this.crearScripDeCambiosToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.crearScripDeCambiosToolStripMenuItem.Text = "Crear Scrip de cambios";
            this.crearScripDeCambiosToolStripMenuItem.Click += new System.EventHandler(this.crearScripDeCambiosToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 259);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(307, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 262);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(307, 66);
            this.textBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Objetos con diferencias";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ver";
            // 
            // ComboVer
            // 
            this.ComboVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboVer.FormattingEnabled = true;
            this.ComboVer.Items.AddRange(new object[] {
            "Todos",
            "Nuevos",
            "Con diferencias"});
            this.ComboVer.Location = new System.Drawing.Point(32, 125);
            this.ComboVer.Name = "ComboVer";
            this.ComboVer.Size = new System.Drawing.Size(170, 21);
            this.ComboVer.TabIndex = 12;
            // 
            // FormCompararBases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 508);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cBarraProgreso1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCompararBases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparar bases de datos";
            this.Load += new System.EventHandler(this.FormCompararBases_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ComboConexiones;
        private System.Windows.Forms.Label label1;
        private CBarraProgreso.CBarraProgreso cBarraProgreso1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListaObjetos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox ComboTipos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarTodosToolStripMenuItem;
        private System.Windows.Forms.ComboBox ComboGrupos;
        private System.Windows.Forms.Label label4;
        private Opacador.FormOpacador formOpacador1;
        private System.Windows.Forms.ToolStripMenuItem comprarCadenasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearScripDeCambiosToolStripMenuItem;
        private System.Windows.Forms.ComboBox ComboVer;
        private System.Windows.Forms.Label label5;
    }
}