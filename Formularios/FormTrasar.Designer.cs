namespace Visor_sql_2015.Formularios
{
    partial class FormTrasar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrasar));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verTablaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDiagramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(330, 558);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTablaToolStripMenuItem,
            this.verDiagramaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 48);
            // 
            // verTablaToolStripMenuItem
            // 
            this.verTablaToolStripMenuItem.Name = "verTablaToolStripMenuItem";
            this.verTablaToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.verTablaToolStripMenuItem.Text = "Ver Tabla";
            this.verTablaToolStripMenuItem.Click += new System.EventHandler(this.verTablaToolStripMenuItem_Click);
            // 
            // verDiagramaToolStripMenuItem
            // 
            this.verDiagramaToolStripMenuItem.Name = "verDiagramaToolStripMenuItem";
            this.verDiagramaToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.verDiagramaToolStripMenuItem.Text = "Ver Diagrama";
            this.verDiagramaToolStripMenuItem.Click += new System.EventHandler(this.verDiagramaToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ATLConsumer.ico");
            this.imageList1.Images.SetKeyName(1, "BUILD00H.ICO");
            this.imageList1.Images.SetKeyName(2, "Shaded Controls.ico");
            this.imageList1.Images.SetKeyName(3, "Shaded Right Tab.ico");
            // 
            // FormTrasar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 558);
            this.Controls.Add(this.treeView1);
            this.Name = "FormTrasar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTrasar";
            this.Load += new System.EventHandler(this.FormTrasar_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verTablaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDiagramaToolStripMenuItem;
    }
}