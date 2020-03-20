namespace Visor_sql_2015.Formularios
{
    partial class FormModelDominio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModelDominio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListaObjetos = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LEncontrados = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ComboTipos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BAnalizar = new System.Windows.Forms.Button();
            this.BCerrar = new System.Windows.Forms.Button();
            this.BQuitar = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lista2 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ListaObjetos);
            this.panel1.Controls.Add(this.LEncontrados);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 469);
            this.panel1.TabIndex = 0;
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.ContextMenuStrip = this.contextMenuStrip1;
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.FormattingEnabled = true;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 63);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaObjetos.Size = new System.Drawing.Size(263, 381);
            this.ListaObjetos.TabIndex = 4;
            this.ListaObjetos.DoubleClick += new System.EventHandler(this.ListaObjetos_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarTodosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 26);
            // 
            // mostrarTodosToolStripMenuItem
            // 
            this.mostrarTodosToolStripMenuItem.Name = "mostrarTodosToolStripMenuItem";
            this.mostrarTodosToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.mostrarTodosToolStripMenuItem.Text = "Mostrar Todos";
            this.mostrarTodosToolStripMenuItem.Click += new System.EventHandler(this.mostrarTodosToolStripMenuItem_Click);
            // 
            // LEncontrados
            // 
            this.LEncontrados.AutoSize = true;
            this.LEncontrados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LEncontrados.Location = new System.Drawing.Point(0, 452);
            this.LEncontrados.Name = "LEncontrados";
            this.LEncontrados.Size = new System.Drawing.Size(79, 13);
            this.LEncontrados.TabIndex = 8;
            this.LEncontrados.Text = "Encontrados=0";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ComboTipos);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TNombre);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 63);
            this.panel2.TabIndex = 3;
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
            "Buscar en el código",
            "vistas y tablas"});
            this.ComboTipos.Location = new System.Drawing.Point(58, 33);
            this.ComboTipos.Name = "ComboTipos";
            this.ComboTipos.Size = new System.Drawing.Size(198, 21);
            this.ComboTipos.TabIndex = 1;
            this.ComboTipos.SelectedIndexChanged += new System.EventHandler(this.ComboTipos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ttipo";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(58, 7);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(198, 20);
            this.TNombre.TabIndex = 0;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BAnalizar);
            this.panel3.Controls.Add(this.BCerrar);
            this.panel3.Controls.Add(this.BQuitar);
            this.panel3.Controls.Add(this.BAgregar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(267, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(105, 469);
            this.panel3.TabIndex = 1;
            // 
            // BAnalizar
            // 
            this.BAnalizar.Image = ((System.Drawing.Image)(resources.GetObject("BAnalizar.Image")));
            this.BAnalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAnalizar.Location = new System.Drawing.Point(7, 219);
            this.BAnalizar.Name = "BAnalizar";
            this.BAnalizar.Size = new System.Drawing.Size(89, 48);
            this.BAnalizar.TabIndex = 3;
            this.BAnalizar.Text = "Analizar";
            this.BAnalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAnalizar.UseVisualStyleBackColor = true;
            this.BAnalizar.Click += new System.EventHandler(this.BAnalizar_Click);
            // 
            // BCerrar
            // 
            this.BCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(7, 289);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(89, 48);
            this.BCerrar.TabIndex = 2;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Visible = false;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // BQuitar
            // 
            this.BQuitar.Image = ((System.Drawing.Image)(resources.GetObject("BQuitar.Image")));
            this.BQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BQuitar.Location = new System.Drawing.Point(7, 149);
            this.BQuitar.Name = "BQuitar";
            this.BQuitar.Size = new System.Drawing.Size(89, 48);
            this.BQuitar.TabIndex = 1;
            this.BQuitar.Text = "Quitar";
            this.BQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BQuitar.UseVisualStyleBackColor = true;
            this.BQuitar.Click += new System.EventHandler(this.BQuitar_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregar.Location = new System.Drawing.Point(7, 85);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(89, 48);
            this.BAgregar.TabIndex = 0;
            this.BAgregar.Text = "Agregar";
            this.BAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregar.UseVisualStyleBackColor = true;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.Lista2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(372, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 469);
            this.panel4.TabIndex = 2;
            // 
            // Lista2
            // 
            this.Lista2.ContextMenuStrip = this.contextMenuStrip2;
            this.Lista2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lista2.FormattingEnabled = true;
            this.Lista2.Location = new System.Drawing.Point(0, 0);
            this.Lista2.Name = "Lista2";
            this.Lista2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Lista2.Size = new System.Drawing.Size(252, 459);
            this.Lista2.TabIndex = 0;
            this.Lista2.DoubleClick += new System.EventHandler(this.Lista2_DoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(155, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem1.Text = "Mostrar Todos";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormModelDominio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FormModelDominio";
            this.Size = new System.Drawing.Size(628, 469);
            this.Load += new System.EventHandler(this.FormModelDominio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ListaObjetos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ComboTipos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BAnalizar;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.Button BQuitar;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox Lista2;
        private System.Windows.Forms.Label LEncontrados;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarTodosToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}