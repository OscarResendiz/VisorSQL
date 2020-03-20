namespace Visor_sql_2015.Inportador
{
    partial class CImpTablasSql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CImpTablasSql));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboConexionOrigen = new System.Windows.Forms.ComboBox();
            this.ComboConexionesDestino = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ListaCamposOrigen2 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BBajarOrigen = new System.Windows.Forms.Button();
            this.BAgregarOrigen = new System.Windows.Forms.Button();
            this.BQuitarOrigen = new System.Windows.Forms.Button();
            this.BSubirOrigen = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ListaCamposOrigen = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TFiltro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BBuscarTablaOrigen = new System.Windows.Forms.Button();
            this.TTablaOrigen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboGrupos = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ListaCamposDestino2 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BBajarDestino = new System.Windows.Forms.Button();
            this.BQuitarDestino = new System.Windows.Forms.Button();
            this.BAgregarDestino = new System.Windows.Forms.Button();
            this.BSubirDestino = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.ListaCamposDestino = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.RcrearTablaDestino = new System.Windows.Forms.RadioButton();
            this.BBUscarTablaDestino = new System.Windows.Forms.Button();
            this.TTablaDestino = new System.Windows.Forms.TextBox();
            this.RSeleccionarTablaDestino = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ComboGrupos2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cBarraProgreso1 = new CBarraProgreso.CBarraProgreso();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conexión origen";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(462, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Conexión destino";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboConexionOrigen
            // 
            this.ComboConexionOrigen.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComboConexionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboConexionOrigen.FormattingEnabled = true;
            this.ComboConexionOrigen.Location = new System.Drawing.Point(0, 57);
            this.ComboConexionOrigen.Name = "ComboConexionOrigen";
            this.ComboConexionOrigen.Size = new System.Drawing.Size(456, 21);
            this.ComboConexionOrigen.TabIndex = 2;
            this.ComboConexionOrigen.SelectedIndexChanged += new System.EventHandler(this.ComboConexionOrigen_SelectedIndexChanged);
            // 
            // ComboConexionesDestino
            // 
            this.ComboConexionesDestino.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComboConexionesDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboConexionesDestino.FormattingEnabled = true;
            this.ComboConexionesDestino.Location = new System.Drawing.Point(0, 57);
            this.ComboConexionesDestino.Name = "ComboConexionesDestino";
            this.ComboConexionesDestino.Size = new System.Drawing.Size(462, 21);
            this.ComboConexionesDestino.TabIndex = 3;
            this.ComboConexionesDestino.SelectedIndexChanged += new System.EventHandler(this.ComboConexionesDestino_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel7);
            this.splitContainer1.Panel1.Controls.Add(this.panel6);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel8);
            this.splitContainer1.Panel2.Controls.Add(this.panel9);
            this.splitContainer1.Panel2.Controls.Add(this.panel10);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(938, 454);
            this.splitContainer1.SplitterDistance = 464;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ListaCamposOrigen2);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(220, 139);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 311);
            this.panel7.TabIndex = 7;
            // 
            // ListaCamposOrigen2
            // 
            this.ListaCamposOrigen2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCamposOrigen2.FormattingEnabled = true;
            this.ListaCamposOrigen2.Location = new System.Drawing.Point(0, 13);
            this.ListaCamposOrigen2.Name = "ListaCamposOrigen2";
            this.ListaCamposOrigen2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCamposOrigen2.Size = new System.Drawing.Size(240, 298);
            this.ListaCamposOrigen2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Campos de la tabla";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BBajarOrigen);
            this.panel6.Controls.Add(this.BAgregarOrigen);
            this.panel6.Controls.Add(this.BQuitarOrigen);
            this.panel6.Controls.Add(this.BSubirOrigen);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(156, 139);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(64, 311);
            this.panel6.TabIndex = 6;
            // 
            // BBajarOrigen
            // 
            this.BBajarOrigen.Image = ((System.Drawing.Image)(resources.GetObject("BBajarOrigen.Image")));
            this.BBajarOrigen.Location = new System.Drawing.Point(6, 214);
            this.BBajarOrigen.Name = "BBajarOrigen";
            this.BBajarOrigen.Size = new System.Drawing.Size(49, 43);
            this.BBajarOrigen.TabIndex = 3;
            this.BBajarOrigen.UseVisualStyleBackColor = true;
            this.BBajarOrigen.Click += new System.EventHandler(this.BBajarOrigen_Click);
            // 
            // BAgregarOrigen
            // 
            this.BAgregarOrigen.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarOrigen.Image")));
            this.BAgregarOrigen.Location = new System.Drawing.Point(6, 116);
            this.BAgregarOrigen.Name = "BAgregarOrigen";
            this.BAgregarOrigen.Size = new System.Drawing.Size(52, 43);
            this.BAgregarOrigen.TabIndex = 2;
            this.BAgregarOrigen.UseVisualStyleBackColor = true;
            this.BAgregarOrigen.Click += new System.EventHandler(this.BAgregarOrigen_Click);
            // 
            // BQuitarOrigen
            // 
            this.BQuitarOrigen.Image = ((System.Drawing.Image)(resources.GetObject("BQuitarOrigen.Image")));
            this.BQuitarOrigen.Location = new System.Drawing.Point(6, 165);
            this.BQuitarOrigen.Name = "BQuitarOrigen";
            this.BQuitarOrigen.Size = new System.Drawing.Size(49, 43);
            this.BQuitarOrigen.TabIndex = 1;
            this.BQuitarOrigen.UseVisualStyleBackColor = true;
            this.BQuitarOrigen.Click += new System.EventHandler(this.BQuitarOrigen_Click);
            // 
            // BSubirOrigen
            // 
            this.BSubirOrigen.Image = ((System.Drawing.Image)(resources.GetObject("BSubirOrigen.Image")));
            this.BSubirOrigen.Location = new System.Drawing.Point(6, 66);
            this.BSubirOrigen.Name = "BSubirOrigen";
            this.BSubirOrigen.Size = new System.Drawing.Size(49, 44);
            this.BSubirOrigen.TabIndex = 0;
            this.BSubirOrigen.UseVisualStyleBackColor = true;
            this.BSubirOrigen.Click += new System.EventHandler(this.BSubirOrigen_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ListaCamposOrigen);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 139);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 311);
            this.panel5.TabIndex = 5;
            // 
            // ListaCamposOrigen
            // 
            this.ListaCamposOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCamposOrigen.FormattingEnabled = true;
            this.ListaCamposOrigen.Location = new System.Drawing.Point(0, 13);
            this.ListaCamposOrigen.Name = "ListaCamposOrigen";
            this.ListaCamposOrigen.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCamposOrigen.Size = new System.Drawing.Size(156, 298);
            this.ListaCamposOrigen.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Campos de la tabla";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.TFiltro);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.BBuscarTablaOrigen);
            this.panel3.Controls.Add(this.TTablaOrigen);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 51);
            this.panel3.TabIndex = 4;
            // 
            // TFiltro
            // 
            this.TFiltro.Location = new System.Drawing.Point(75, 27);
            this.TFiltro.Name = "TFiltro";
            this.TFiltro.Size = new System.Drawing.Size(280, 20);
            this.TFiltro.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "WHERE";
            // 
            // BBuscarTablaOrigen
            // 
            this.BBuscarTablaOrigen.Location = new System.Drawing.Point(311, -1);
            this.BBuscarTablaOrigen.Name = "BBuscarTablaOrigen";
            this.BBuscarTablaOrigen.Size = new System.Drawing.Size(44, 23);
            this.BBuscarTablaOrigen.TabIndex = 2;
            this.BBuscarTablaOrigen.Text = "...";
            this.BBuscarTablaOrigen.UseVisualStyleBackColor = true;
            this.BBuscarTablaOrigen.Click += new System.EventHandler(this.BBuscarTablaOrigen_Click);
            // 
            // TTablaOrigen
            // 
            this.TTablaOrigen.Location = new System.Drawing.Point(75, 1);
            this.TTablaOrigen.Name = "TTablaOrigen";
            this.TTablaOrigen.ReadOnly = true;
            this.TTablaOrigen.Size = new System.Drawing.Size(230, 20);
            this.TTablaOrigen.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tabla origen";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ComboConexionOrigen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ComboGrupos);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 88);
            this.panel1.TabIndex = 3;
            // 
            // ComboGrupos
            // 
            this.ComboGrupos.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComboGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGrupos.FormattingEnabled = true;
            this.ComboGrupos.Items.AddRange(new object[] {
            "Todos",
            "Tablas",
            "Vistas",
            "Procedimientos almacenados",
            "Buscar en el código"});
            this.ComboGrupos.Location = new System.Drawing.Point(0, 13);
            this.ComboGrupos.Name = "ComboGrupos";
            this.ComboGrupos.Size = new System.Drawing.Size(456, 21);
            this.ComboGrupos.TabIndex = 11;
            this.ComboGrupos.SelectedIndexChanged += new System.EventHandler(this.ComboGrupos_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(456, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Grupo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.ListaCamposDestino2);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 139);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(250, 311);
            this.panel8.TabIndex = 6;
            // 
            // ListaCamposDestino2
            // 
            this.ListaCamposDestino2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCamposDestino2.FormattingEnabled = true;
            this.ListaCamposDestino2.Location = new System.Drawing.Point(0, 13);
            this.ListaCamposDestino2.Name = "ListaCamposDestino2";
            this.ListaCamposDestino2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCamposDestino2.Size = new System.Drawing.Size(250, 298);
            this.ListaCamposDestino2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Campos de la tabla";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.BBajarDestino);
            this.panel9.Controls.Add(this.BQuitarDestino);
            this.panel9.Controls.Add(this.BAgregarDestino);
            this.panel9.Controls.Add(this.BSubirDestino);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(250, 139);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(64, 311);
            this.panel9.TabIndex = 7;
            // 
            // BBajarDestino
            // 
            this.BBajarDestino.Image = ((System.Drawing.Image)(resources.GetObject("BBajarDestino.Image")));
            this.BBajarDestino.Location = new System.Drawing.Point(6, 214);
            this.BBajarDestino.Name = "BBajarDestino";
            this.BBajarDestino.Size = new System.Drawing.Size(49, 43);
            this.BBajarDestino.TabIndex = 3;
            this.BBajarDestino.UseVisualStyleBackColor = true;
            this.BBajarDestino.Click += new System.EventHandler(this.BBajarDestino_Click);
            // 
            // BQuitarDestino
            // 
            this.BQuitarDestino.Image = ((System.Drawing.Image)(resources.GetObject("BQuitarDestino.Image")));
            this.BQuitarDestino.Location = new System.Drawing.Point(6, 165);
            this.BQuitarDestino.Name = "BQuitarDestino";
            this.BQuitarDestino.Size = new System.Drawing.Size(52, 43);
            this.BQuitarDestino.TabIndex = 2;
            this.BQuitarDestino.UseVisualStyleBackColor = true;
            this.BQuitarDestino.Click += new System.EventHandler(this.BQuitarDestino_Click);
            // 
            // BAgregarDestino
            // 
            this.BAgregarDestino.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarDestino.Image")));
            this.BAgregarDestino.Location = new System.Drawing.Point(6, 116);
            this.BAgregarDestino.Name = "BAgregarDestino";
            this.BAgregarDestino.Size = new System.Drawing.Size(49, 43);
            this.BAgregarDestino.TabIndex = 1;
            this.BAgregarDestino.UseVisualStyleBackColor = true;
            this.BAgregarDestino.Click += new System.EventHandler(this.BAgregarDestino_Click);
            // 
            // BSubirDestino
            // 
            this.BSubirDestino.Image = ((System.Drawing.Image)(resources.GetObject("BSubirDestino.Image")));
            this.BSubirDestino.Location = new System.Drawing.Point(6, 66);
            this.BSubirDestino.Name = "BSubirDestino";
            this.BSubirDestino.Size = new System.Drawing.Size(49, 44);
            this.BSubirDestino.TabIndex = 0;
            this.BSubirDestino.UseVisualStyleBackColor = true;
            this.BSubirDestino.Click += new System.EventHandler(this.BSubirDestino_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.ListaCamposDestino);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(314, 139);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(152, 311);
            this.panel10.TabIndex = 8;
            // 
            // ListaCamposDestino
            // 
            this.ListaCamposDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCamposDestino.FormattingEnabled = true;
            this.ListaCamposDestino.Location = new System.Drawing.Point(0, 13);
            this.ListaCamposDestino.Name = "ListaCamposDestino";
            this.ListaCamposDestino.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCamposDestino.Size = new System.Drawing.Size(152, 298);
            this.ListaCamposDestino.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Campos de la tabla";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.RcrearTablaDestino);
            this.panel4.Controls.Add(this.BBUscarTablaDestino);
            this.panel4.Controls.Add(this.TTablaDestino);
            this.panel4.Controls.Add(this.RSeleccionarTablaDestino);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 88);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(466, 51);
            this.panel4.TabIndex = 5;
            // 
            // RcrearTablaDestino
            // 
            this.RcrearTablaDestino.AutoSize = true;
            this.RcrearTablaDestino.Checked = true;
            this.RcrearTablaDestino.Location = new System.Drawing.Point(20, 1);
            this.RcrearTablaDestino.Name = "RcrearTablaDestino";
            this.RcrearTablaDestino.Size = new System.Drawing.Size(113, 17);
            this.RcrearTablaDestino.TabIndex = 4;
            this.RcrearTablaDestino.TabStop = true;
            this.RcrearTablaDestino.Text = "Crear tabla destino";
            this.RcrearTablaDestino.UseVisualStyleBackColor = true;
            this.RcrearTablaDestino.CheckedChanged += new System.EventHandler(this.RcrearTablaDestino_CheckedChanged);
            // 
            // BBUscarTablaDestino
            // 
            this.BBUscarTablaDestino.Location = new System.Drawing.Point(236, 19);
            this.BBUscarTablaDestino.Name = "BBUscarTablaDestino";
            this.BBUscarTablaDestino.Size = new System.Drawing.Size(44, 23);
            this.BBUscarTablaDestino.TabIndex = 2;
            this.BBUscarTablaDestino.Text = "...";
            this.BBUscarTablaDestino.UseVisualStyleBackColor = true;
            this.BBUscarTablaDestino.Click += new System.EventHandler(this.BBUscarTablaDestino_Click);
            // 
            // TTablaDestino
            // 
            this.TTablaDestino.Location = new System.Drawing.Point(5, 22);
            this.TTablaDestino.Name = "TTablaDestino";
            this.TTablaDestino.ReadOnly = true;
            this.TTablaDestino.Size = new System.Drawing.Size(230, 20);
            this.TTablaDestino.TabIndex = 1;
            this.TTablaDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TTablaDestino_KeyPress);
            // 
            // RSeleccionarTablaDestino
            // 
            this.RSeleccionarTablaDestino.AutoSize = true;
            this.RSeleccionarTablaDestino.Location = new System.Drawing.Point(156, 2);
            this.RSeleccionarTablaDestino.Name = "RSeleccionarTablaDestino";
            this.RSeleccionarTablaDestino.Size = new System.Drawing.Size(89, 17);
            this.RSeleccionarTablaDestino.TabIndex = 3;
            this.RSeleccionarTablaDestino.Text = "Tabla destino";
            this.RSeleccionarTablaDestino.UseVisualStyleBackColor = true;
            this.RSeleccionarTablaDestino.CheckedChanged += new System.EventHandler(this.RSeleccionarTablaDestino_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ComboConexionesDestino);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ComboGrupos2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 88);
            this.panel2.TabIndex = 4;
            // 
            // ComboGrupos2
            // 
            this.ComboGrupos2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComboGrupos2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGrupos2.FormattingEnabled = true;
            this.ComboGrupos2.Items.AddRange(new object[] {
            "Todos",
            "Tablas",
            "Vistas",
            "Procedimientos almacenados",
            "Buscar en el código"});
            this.ComboGrupos2.Location = new System.Drawing.Point(0, 13);
            this.ComboGrupos2.Name = "ComboGrupos2";
            this.ComboGrupos2.Size = new System.Drawing.Size(462, 21);
            this.ComboGrupos2.TabIndex = 13;
            this.ComboGrupos2.SelectedIndexChanged += new System.EventHandler(this.ComboGrupos2_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(462, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Grupo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cBarraProgreso1
            // 
            this.cBarraProgreso1.ColorDeBarra = System.Drawing.Color.Lime;
            this.cBarraProgreso1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBarraProgreso1.Location = new System.Drawing.Point(0, 454);
            this.cBarraProgreso1.MostrarTexto = true;
            this.cBarraProgreso1.Name = "cBarraProgreso1";
            this.cBarraProgreso1.Progreso = 0;
            this.cBarraProgreso1.ProgresoHorizontal = true;
            this.cBarraProgreso1.Size = new System.Drawing.Size(938, 24);
            this.cBarraProgreso1.TabIndex = 5;
            this.cBarraProgreso1.Texto = "";
            this.cBarraProgreso1.ValorMaximo = 100;
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // CImpTablasSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cBarraProgreso1);
            this.Name = "CImpTablasSql";
            this.Size = new System.Drawing.Size(938, 478);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboConexionesDestino;
        private System.Windows.Forms.ComboBox ComboConexionOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BBuscarTablaOrigen;
        private System.Windows.Forms.TextBox TTablaOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton RcrearTablaDestino;
        private System.Windows.Forms.Button BBUscarTablaDestino;
        private System.Windows.Forms.TextBox TTablaDestino;
        private System.Windows.Forms.RadioButton RSeleccionarTablaDestino;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BQuitarOrigen;
        private System.Windows.Forms.Button BSubirOrigen;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BBajarOrigen;
        private System.Windows.Forms.Button BAgregarOrigen;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListBox ListaCamposOrigen2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ListBox ListaCamposDestino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BBajarDestino;
        private System.Windows.Forms.Button BQuitarDestino;
        private System.Windows.Forms.Button BAgregarDestino;
        private System.Windows.Forms.Button BSubirDestino;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ListBox ListaCamposDestino2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private CBarraProgreso.CBarraProgreso cBarraProgreso1;
        private System.Windows.Forms.ListBox ListaCamposOrigen;
        private System.Windows.Forms.ComboBox ComboGrupos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboGrupos2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TFiltro;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}
