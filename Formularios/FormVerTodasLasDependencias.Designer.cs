namespace Visor_sql_2015.Formularios
{
    partial class FormVerTodasLasDependencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerTodasLasDependencias));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verTablaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RBDependeDe = new System.Windows.Forms.RadioButton();
            this.RBDependende = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Progreso = new CBarraProgreso.CBarraProgreso();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ATLConsumer.ico");
            this.imageList1.Images.SetKeyName(1, "BUILD00H.ICO");
            this.imageList1.Images.SetKeyName(2, "Shaded Controls.ico");
            this.imageList1.Images.SetKeyName(3, "Shaded Right Tab.ico");
            this.imageList1.Images.SetKeyName(4, "Doc-087.ico");
            this.imageList1.Images.SetKeyName(5, "#DOC65B.ICO");
            this.imageList1.Images.SetKeyName(6, "FORM02C.ICO");
            this.imageList1.Images.SetKeyName(7, "Doc-213.ico");
            this.imageList1.Images.SetKeyName(8, "SP.ICO");
            this.imageList1.Images.SetKeyName(9, "DOC00H.ICO");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTablaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(92, 26);
            // 
            // verTablaToolStripMenuItem
            // 
            this.verTablaToolStripMenuItem.Name = "verTablaToolStripMenuItem";
            this.verTablaToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.verTablaToolStripMenuItem.Text = "Ver";
            this.verTablaToolStripMenuItem.Click += new System.EventHandler(this.verTablaToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(0, 56);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(272, 356);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 3;
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RBDependeDe);
            this.panel1.Controls.Add(this.RBDependende);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 56);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(157, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(147, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // RBDependeDe
            // 
            this.RBDependeDe.AutoSize = true;
            this.RBDependeDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RBDependeDe.Location = new System.Drawing.Point(3, 26);
            this.RBDependeDe.Name = "RBDependeDe";
            this.RBDependeDe.Size = new System.Drawing.Size(158, 17);
            this.RBDependeDe.TabIndex = 9;
            this.RBDependeDe.Text = "Objetos de los que depende";
            this.RBDependeDe.UseVisualStyleBackColor = true;
            // 
            // RBDependende
            // 
            this.RBDependende.AutoSize = true;
            this.RBDependende.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RBDependende.Location = new System.Drawing.Point(3, 3);
            this.RBDependende.Name = "RBDependende";
            this.RBDependende.Size = new System.Drawing.Size(148, 17);
            this.RBDependende.TabIndex = 8;
            this.RBDependende.Text = "Objetos que dependen de";
            this.RBDependende.UseVisualStyleBackColor = true;
            this.RBDependende.CheckedChanged += new System.EventHandler(this.RBDependende_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Progreso
            // 
            this.Progreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Progreso.ColorDeBarra = System.Drawing.Color.Lime;
            this.Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progreso.ForeColor = System.Drawing.Color.Red;
            this.Progreso.Location = new System.Drawing.Point(0, 412);
            this.Progreso.MostrarTexto = true;
            this.Progreso.Name = "Progreso";
            this.Progreso.Progreso = 0;
            this.Progreso.ProgresoHorizontal = true;
            this.Progreso.Size = new System.Drawing.Size(272, 18);
            this.Progreso.TabIndex = 9;
            this.Progreso.Texto = null;
            this.Progreso.ValorMaximo = 100;
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
            // FormVerTodasLasDependencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 430);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Progreso);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVerTodasLasDependencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVerTodasLasDependencias";
            this.Load += new System.EventHandler(this.FormVerTodasLasDependencias_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verTablaToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBDependeDe;
        private System.Windows.Forms.RadioButton RBDependende;
        private System.Windows.Forms.Timer timer1;
        private CBarraProgreso.CBarraProgreso Progreso;
        private Opacador.FormOpacador formOpacador1;

    }
}