namespace Visor_sql_2015
{
    partial class ComparadorCadenas
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Grupo1 = new System.Windows.Forms.GroupBox();
            this.Texto1 = new System.Windows.Forms.RichTextBox();
            this.Grupo2 = new System.Windows.Forms.GroupBox();
            this.Texto2 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.volverACompararToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Grupo1.SuspendLayout();
            this.Grupo2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Grupo1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Grupo2);
            this.splitContainer1.Size = new System.Drawing.Size(633, 359);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 0;
            // 
            // Grupo1
            // 
            this.Grupo1.Controls.Add(this.Texto1);
            this.Grupo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grupo1.Location = new System.Drawing.Point(0, 0);
            this.Grupo1.Name = "Grupo1";
            this.Grupo1.Size = new System.Drawing.Size(317, 359);
            this.Grupo1.TabIndex = 0;
            this.Grupo1.TabStop = false;
            this.Grupo1.Text = "groupBox1";
            // 
            // Texto1
            // 
            this.Texto1.AcceptsTab = true;
            this.Texto1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Texto1.ContextMenuStrip = this.contextMenuStrip1;
            this.Texto1.DetectUrls = false;
            this.Texto1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Texto1.ForeColor = System.Drawing.Color.Yellow;
            this.Texto1.Location = new System.Drawing.Point(3, 16);
            this.Texto1.Name = "Texto1";
            this.Texto1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Texto1.Size = new System.Drawing.Size(311, 340);
            this.Texto1.TabIndex = 0;
            this.Texto1.Text = "hola";
            this.Texto1.WordWrap = false;
            // 
            // Grupo2
            // 
            this.Grupo2.Controls.Add(this.Texto2);
            this.Grupo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grupo2.Location = new System.Drawing.Point(0, 0);
            this.Grupo2.Name = "Grupo2";
            this.Grupo2.Size = new System.Drawing.Size(312, 359);
            this.Grupo2.TabIndex = 0;
            this.Grupo2.TabStop = false;
            this.Grupo2.Text = "groupBox2";
            // 
            // Texto2
            // 
            this.Texto2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Texto2.ContextMenuStrip = this.contextMenuStrip1;
            this.Texto2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Texto2.ForeColor = System.Drawing.Color.Yellow;
            this.Texto2.Location = new System.Drawing.Point(3, 16);
            this.Texto2.Name = "Texto2";
            this.Texto2.Size = new System.Drawing.Size(306, 340);
            this.Texto2.TabIndex = 0;
            this.Texto2.Text = "hola";
            this.Texto2.WordWrap = false;
            this.Texto2.VScroll += new System.EventHandler(this.Texto2_VScroll);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volverACompararToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 48);
            // 
            // volverACompararToolStripMenuItem
            // 
            this.volverACompararToolStripMenuItem.Name = "volverACompararToolStripMenuItem";
            this.volverACompararToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.volverACompararToolStripMenuItem.Text = "Volver a comparar";
            this.volverACompararToolStripMenuItem.Click += new System.EventHandler(this.volverACompararToolStripMenuItem_Click);
            // 
            // ComparadorCadenas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ComparadorCadenas";
            this.Size = new System.Drawing.Size(633, 359);
            this.Load += new System.EventHandler(this.ComparadorCadenas_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.Grupo1.ResumeLayout(false);
            this.Grupo2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox Grupo1;
        private System.Windows.Forms.RichTextBox Texto1;
        private System.Windows.Forms.GroupBox Grupo2;
        private System.Windows.Forms.RichTextBox Texto2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem volverACompararToolStripMenuItem;

    }
}
