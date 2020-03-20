namespace Visor_sql_2015.Editor
{
    partial class TextEditX 
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditX));
            this.LY = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TCodigo = new ICSharpCode.TextEditor.TextEditorControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.convertirAMayúsculasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertirAMinúsculasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.SFilename = new System.Windows.Forms.ToolStripStatusLabel();
            this.LX = new System.Windows.Forms.Label();
            this.Lfecha = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cAnaLex1 = new AnalizadorLexico.CAnaLex(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CHNumeroLinea = new System.Windows.Forms.CheckBox();
            this.ThrowEx = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BToCSharp = new System.Windows.Forms.ToolStripButton();
            this.BDependency = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.inteliences1 = new Visor_sql_2015.Inteliences(this.components);
            this.panel2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.BarraEstado.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // panel2
            // 
            this.panel2.Controls.Add(this.TCodigo);
            this.panel2.Controls.Add(this.BarraEstado);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(871, 464);
            this.panel2.TabIndex = 6;
            // 
            // TCodigo
            // 
            this.TCodigo.ContextMenuStrip = this.contextMenuStrip2;
            this.TCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCodigo.IsReadOnly = false;
            this.TCodigo.Location = new System.Drawing.Point(0, 0);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.ShowLineNumbers = false;
            this.TCodigo.ShowVRuler = false;
            this.TCodigo.Size = new System.Drawing.Size(871, 442);
            this.TCodigo.TabIndex = 4;
            this.TCodigo.Enter += new System.EventHandler(this.TCodigo_Enter);
            this.TCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TCodigo_KeyDown);
            this.TCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TCodigo_KeyUp);
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
            // BarraEstado
            // 
            this.BarraEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SFilename});
            this.BarraEstado.Location = new System.Drawing.Point(0, 442);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(871, 22);
            this.BarraEstado.TabIndex = 3;
            this.BarraEstado.Text = "statusStrip1";
            // 
            // SFilename
            // 
            this.SFilename.Name = "SFilename";
            this.SFilename.Size = new System.Drawing.Size(0, 17);
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
            this.TNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TNombre.ForeColor = System.Drawing.Color.White;
            this.TNombre.Location = new System.Drawing.Point(53, 6);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(323, 20);
            this.TNombre.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cAnaLex1
            // 
            this.cAnaLex1.Texto = null;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "*.sql";
            this.saveFileDialog1.Filter = "CONSULTAS|*.sql";
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CHNumeroLinea);
            this.panel1.Controls.Add(this.ThrowEx);
            this.panel1.Controls.Add(this.LY);
            this.panel1.Controls.Add(this.LX);
            this.panel1.Controls.Add(this.Lfecha);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 51);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(709, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // CHNumeroLinea
            // 
            this.CHNumeroLinea.AutoSize = true;
            this.CHNumeroLinea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CHNumeroLinea.Location = new System.Drawing.Point(438, 33);
            this.CHNumeroLinea.Name = "CHNumeroLinea";
            this.CHNumeroLinea.Size = new System.Drawing.Size(125, 17);
            this.CHNumeroLinea.TabIndex = 6;
            this.CHNumeroLinea.Text = "Ver numero de lineas";
            this.CHNumeroLinea.UseVisualStyleBackColor = true;
            this.CHNumeroLinea.CheckedChanged += new System.EventHandler(this.CHNumeroLinea_CheckedChanged);
            // 
            // ThrowEx
            // 
            this.ThrowEx.AutoSize = true;
            this.ThrowEx.Checked = true;
            this.ThrowEx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ThrowEx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ThrowEx.Location = new System.Drawing.Point(438, 9);
            this.ThrowEx.Name = "ThrowEx";
            this.ThrowEx.Size = new System.Drawing.Size(205, 17);
            this.ThrowEx.TabIndex = 5;
            this.ThrowEx.Text = "Generar Codigo Con Throw Exception";
            this.ThrowEx.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BToCSharp,
            this.BDependency});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(871, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BToCSharp
            // 
            this.BToCSharp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BToCSharp.Image = ((System.Drawing.Image)(resources.GetObject("BToCSharp.Image")));
            this.BToCSharp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BToCSharp.Name = "BToCSharp";
            this.BToCSharp.Size = new System.Drawing.Size(23, 22);
            this.BToCSharp.Text = "Generar Codigo para C#";
            this.BToCSharp.Click += new System.EventHandler(this.BToCSharp_Click);
            // 
            // BDependency
            // 
            this.BDependency.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BDependency.Image = ((System.Drawing.Image)(resources.GetObject("BDependency.Image")));
            this.BDependency.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BDependency.Name = "BDependency";
            this.BDependency.Size = new System.Drawing.Size(23, 22);
            this.BDependency.Text = "Ver dependencias";
            this.BDependency.Click += new System.EventHandler(this.BDependency_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.sql";
            this.openFileDialog1.Filter = "CONSULTAS|*.sql";
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Table_24.png");
            this.imageList1.Images.SetKeyName(1, "Glasses_22.png");
            this.imageList1.Images.SetKeyName(2, "24_Lighting.png");
            this.imageList1.Images.SetKeyName(3, "24_Field.png");
            this.imageList1.Images.SetKeyName(4, "ShortCut_24.png");
            this.imageList1.Images.SetKeyName(5, "22_PKey.png");
            this.imageList1.Images.SetKeyName(6, "16_@.png");
            this.imageList1.Images.SetKeyName(7, "22_Snippet.png");
            this.imageList1.Images.SetKeyName(8, "Database_24.png");
            // 
            // inteliences1
            // 
            this.inteliences1.DB = null;
            this.inteliences1.FireAt = 0;
            this.inteliences1.TextEditorControl = this.TCodigo;
            this.inteliences1.Buscar += new Visor_sql_2015.OnEventoInteliencesEvent(this.inteliences1_Buscar);
            this.inteliences1.Guardar += new Visor_sql_2015.OnEventoInteliencesEvent(this.inteliences1_Guardar);
            this.inteliences1.Abrir += new Visor_sql_2015.OnEventoInteliencesEvent(this.inteliences1_Abrir);
            this.inteliences1.OnParentForm += new Visor_sql_2015.OnParentFormEvent(this.inteliences1_OnParentForm);
            this.inteliences1.OnKey += new Visor_sql_2015.OnKeyEventx(this.inteliences1_OnKey);
            // 
            // TextEditX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TextEditX";
            this.Size = new System.Drawing.Size(871, 540);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LY;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem convertirAMayúsculasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertirAMinúsculasToolStripMenuItem;
        private System.Windows.Forms.Label LX;
        private System.Windows.Forms.Label Lfecha;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Timer timer1;
        private AnalizadorLexico.CAnaLex cAnaLex1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton BDependency;
        private System.Windows.Forms.ToolStripButton BToCSharp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.CheckBox ThrowEx;
        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel SFilename;
        private ICSharpCode.TextEditor.TextEditorControl TCodigo;
        private System.Windows.Forms.CheckBox CHNumeroLinea;
        private System.Windows.Forms.ImageList imageList1;
        private Inteliences inteliences1;
        private System.Windows.Forms.Label label2;
    }
}
