namespace Visor_sql_2015.Formularios
{
    partial class FormBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscar));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LEncontrados = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.animatedWaitTextBox1 = new Visor_sql_2015.AnimatedWaitTextBox();
            this.ComboTipos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ListaObjetos = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarTodosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 26);
            // 
            // mostrarTodosToolStripMenuItem
            // 
            this.mostrarTodosToolStripMenuItem.Name = "mostrarTodosToolStripMenuItem";
            this.mostrarTodosToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.mostrarTodosToolStripMenuItem.Text = "Mostrar Todos";
            this.mostrarTodosToolStripMenuItem.Click += new System.EventHandler(this.mostrarTodosToolStripMenuItem_Click);
            // 
            // LEncontrados
            // 
            this.LEncontrados.AutoSize = true;
            this.LEncontrados.BackColor = System.Drawing.Color.Transparent;
            this.LEncontrados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LEncontrados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LEncontrados.Location = new System.Drawing.Point(0, 495);
            this.LEncontrados.Name = "LEncontrados";
            this.LEncontrados.Size = new System.Drawing.Size(79, 13);
            this.LEncontrados.TabIndex = 7;
            this.LEncontrados.Text = "Encontrados=0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.animatedWaitTextBox1);
            this.panel1.Controls.Add(this.ComboTipos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 64);
            this.panel1.TabIndex = 0;
            // 
            // animatedWaitTextBox1
            // 
            this.animatedWaitTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animatedWaitTextBox1.ImagenInicial = global::Visor_sql_2015.Properties.Resources.Pencil_22;
            this.animatedWaitTextBox1.Location = new System.Drawing.Point(58, 4);
            this.animatedWaitTextBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.animatedWaitTextBox1.Name = "animatedWaitTextBox1";
            this.animatedWaitTextBox1.Size = new System.Drawing.Size(185, 20);
            this.animatedWaitTextBox1.TabIndex = 7;
            this.animatedWaitTextBox1.WaitInterval = 20;
            this.animatedWaitTextBox1.EsperaCompletada += new Visor_sql_2015.OnTextWaitEnded(this.animatedWaitTextBox1_EsperaCompletada);
            // 
            // ComboTipos
            // 
            this.ComboTipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ComboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipos.ForeColor = System.Drawing.Color.White;
            this.ComboTipos.FormattingEnabled = true;
            this.ComboTipos.Items.AddRange(new object[] {
            "Todos",
            "Tablas",
            "Vistas",
            "Procedimientos almacenados",
            "Buscar en el código",
            "tablas y istas",
            "Buscar campo en tablas"});
            this.ComboTipos.Location = new System.Drawing.Point(58, 33);
            this.ComboTipos.Name = "ComboTipos";
            this.ComboTipos.Size = new System.Drawing.Size(185, 21);
            this.ComboTipos.TabIndex = 1;
            this.ComboTipos.SelectedIndexChanged += new System.EventHandler(this.ComboTipos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ttipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ListaObjetos.ContextMenuStrip = this.contextMenuStrip1;
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaObjetos.ImageIndex = 0;
            this.ListaObjetos.ImageList = this.imageList1;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 64);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectedImageIndex = 0;
            this.ListaObjetos.Size = new System.Drawing.Size(291, 431);
            this.ListaObjetos.StateImageList = this.imageList1;
            this.ListaObjetos.TabIndex = 8;
            this.ListaObjetos.DoubleClick += new System.EventHandler(this.ListaObjetos_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "yast_help.gif");
            this.imageList1.Images.SetKeyName(1, "mdf_ndf_dbfiles.ico");
            this.imageList1.Images.SetKeyName(2, "demo.png");
            this.imageList1.Images.SetKeyName(3, "FORM02C.ICO");
            this.imageList1.Images.SetKeyName(4, "clanbomber.png");
            this.imageList1.Images.SetKeyName(5, "Access_019.ico");
            this.imageList1.Images.SetKeyName(6, "105.ICO");
            this.imageList1.Images.SetKeyName(7, "ATLConsumer.ico");
            // 
            // formOpacador1
            // 
            this.formOpacador1.AutoCerrar = false;
            this.formOpacador1.Degradado = true;
            this.formOpacador1.Formulario = this;
            this.formOpacador1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.formOpacador1.PrimerColor = System.Drawing.Color.Gray;
            this.formOpacador1.SegundoColor = System.Drawing.Color.Black;
            this.formOpacador1.Tiempo = 100;
            this.formOpacador1.Visible = true;
            // 
            // FormBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 508);
            this.Controls.Add(this.ListaObjetos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LEncontrados);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Buscar en la base de datos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBuscar_FormClosing);
            this.Load += new System.EventHandler(this.FormBuscar_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LEncontrados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ComboTipos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarTodosToolStripMenuItem;
        private System.Windows.Forms.TreeView ListaObjetos;
        private System.Windows.Forms.ImageList imageList1;
        private AnimatedWaitTextBox animatedWaitTextBox1;
        private Opacador.FormOpacador formOpacador1;
    }
}