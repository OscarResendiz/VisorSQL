namespace Visor_sql_2015.Formularios
{
    partial class FormSPX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSPX));
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TCodigo = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.convertirAMayúsculasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertirAMinúsculasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LY = new System.Windows.Forms.Label();
            this.LX = new System.Windows.Forms.Label();
            this.Lfecha = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ComboZoom = new System.Windows.Forms.ToolStripComboBox();
            this.cTextColor1 = new TextColor.CTextColor(this.components);
            this.cAnaLex1 = new AnalizadorLexico.CAnaLex(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 475);
            this.panel2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TCodigo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Size = new System.Drawing.Size(943, 475);
            this.splitContainer1.SplitterDistance = 431;
            this.splitContainer1.TabIndex = 1;
            // 
            // TCodigo
            // 
            this.TCodigo.AcceptsTab = true;
            this.TCodigo.AutoWordSelection = true;
            this.TCodigo.BackColor = System.Drawing.Color.Navy;
            this.TCodigo.ContextMenuStrip = this.contextMenuStrip2;
            this.TCodigo.DetectUrls = false;
            this.TCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCodigo.EnableAutoDragDrop = true;
            this.TCodigo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCodigo.ForeColor = System.Drawing.Color.Yellow;
            this.TCodigo.Location = new System.Drawing.Point(0, 0);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.TCodigo.Size = new System.Drawing.Size(943, 431);
            this.TCodigo.TabIndex = 0;
            this.TCodigo.Text = "";
            this.TCodigo.WordWrap = false;
            this.TCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TCodigo_KeyDown);
            this.TCodigo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TCodigo_MouseDown);
            this.TCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TCodigo_KeyPress);
            this.TCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TCodigo_KeyUp);
            this.TCodigo.TextChanged += new System.EventHandler(this.TCodigo_TextChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.convertirAMayúsculasToolStripMenuItem,
            this.convertirAMinúsculasToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(201, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem1.Text = "Ir a la definición";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // convertirAMayúsculasToolStripMenuItem
            // 
            this.convertirAMayúsculasToolStripMenuItem.Name = "convertirAMayúsculasToolStripMenuItem";
            this.convertirAMayúsculasToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.convertirAMayúsculasToolStripMenuItem.Text = "Convertir  a mayúsculas";
            this.convertirAMayúsculasToolStripMenuItem.Click += new System.EventHandler(this.convertirAMayúsculasToolStripMenuItem_Click);
            // 
            // convertirAMinúsculasToolStripMenuItem
            // 
            this.convertirAMinúsculasToolStripMenuItem.Name = "convertirAMinúsculasToolStripMenuItem";
            this.convertirAMinúsculasToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.convertirAMinúsculasToolStripMenuItem.Text = "Convertir a minúsculas";
            this.convertirAMinúsculasToolStripMenuItem.Click += new System.EventHandler(this.convertirAMinúsculasToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aaaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // aaaToolStripMenuItem
            // 
            this.aaaToolStripMenuItem.Name = "aaaToolStripMenuItem";
            this.aaaToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.aaaToolStripMenuItem.Text = "aaa";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.LY);
            this.panel1.Controls.Add(this.LX);
            this.panel1.Controls.Add(this.Lfecha);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 51);
            this.panel1.TabIndex = 2;
            // 
            // LY
            // 
            this.LY.AutoSize = true;
            this.LY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LY.Location = new System.Drawing.Point(391, 32);
            this.LY.Name = "LY";
            this.LY.Size = new System.Drawing.Size(26, 13);
            this.LY.TabIndex = 4;
            this.LY.Text = "Y=0";
            // 
            // LX
            // 
            this.LX.AutoSize = true;
            this.LX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LX.Location = new System.Drawing.Point(391, 9);
            this.LX.Name = "LX";
            this.LX.Size = new System.Drawing.Size(26, 13);
            this.LX.TabIndex = 3;
            this.LX.Text = "X=0";
            // 
            // Lfecha
            // 
            this.Lfecha.AutoSize = true;
            this.Lfecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Lfecha.Location = new System.Drawing.Point(6, 32);
            this.Lfecha.Name = "Lfecha";
            this.Lfecha.Size = new System.Drawing.Size(35, 13);
            this.Lfecha.TabIndex = 2;
            this.Lfecha.Text = "label2";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 6);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(323, 20);
            this.TNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton6,
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton3,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.ComboZoom});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(943, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Generar Codigo para C#";
            this.toolStripButton1.Click += new System.EventHandler(this.generarCodigoDeCToolStripMenuItem_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Ver dependencias";
            this.toolStripButton6.Click += new System.EventHandler(this.verDependenciasToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Ejecutar";
            this.toolStripButton2.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Comentar";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Descomentar";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Buacar";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(300, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Zoom";
            // 
            // ComboZoom
            // 
            this.ComboZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboZoom.Name = "ComboZoom";
            this.ComboZoom.Size = new System.Drawing.Size(121, 25);
            this.ComboZoom.SelectedIndexChanged += new System.EventHandler(this.ComboZoom_SelectedIndexChanged);
            // 
            // cTextColor1
            // 
            this.cTextColor1.BackColor = System.Drawing.Color.Navy;
            this.cTextColor1.ColorCadena = System.Drawing.Color.White;
            this.cTextColor1.ColorComentario = System.Drawing.Color.Red;
            this.cTextColor1.ColorIdentificador = System.Drawing.Color.Yellow;
            this.cTextColor1.ColorNumero = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cTextColor1.ColorOtro = System.Drawing.Color.Yellow;
            this.cTextColor1.ColorPalabraRserevada = System.Drawing.Color.Lime;
            this.cTextColor1.ColorSimbolo = System.Drawing.Color.Cyan;
            this.cTextColor1.ColorVariable = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cTextColor1.RichTextBox = this.TCodigo;
            this.cTextColor1.Tiempo = 50;
            this.cTextColor1.OnCambiaFoco += new TextColor.OnCambiaFocoEvent(this.cTextColor1_OnCambiaFoco);
            // 
            // cAnaLex1
            // 
            this.cAnaLex1.Texto = null;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "*.sql";
            this.saveFileDialog1.Filter = "CONSULTAS|*.sql";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.sql";
            this.openFileDialog1.Filter = "CONSULTAS|*.sql";
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
            // FormSPX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 551);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormSPX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormCodigo";
            this.Load += new System.EventHandler(this.FormSP_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.RichTextBox TCodigo;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Label Lfecha;
        private TextColor.CTextColor cTextColor1;
        private AnalizadorLexico.CAnaLex cAnaLex1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaaToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ComboZoom;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label LY;
        private System.Windows.Forms.Label LX;
        private System.Windows.Forms.ToolStripMenuItem convertirAMayúsculasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertirAMinúsculasToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private Opacador.FormOpacador formOpacador1;
    }
}