namespace Visor_sql_2015.patrones
{
    partial class FormAdminPatrones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminPatrones));
            this.Grupos = new System.Windows.Forms.ListView();
            this.MenuGrupos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGrupo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGrupos.SuspendLayout();
            this.MenuGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupos
            // 
            this.Grupos.ContextMenuStrip = this.MenuGrupos;
            this.Grupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grupos.LargeImageList = this.imageList1;
            this.Grupos.Location = new System.Drawing.Point(0, 0);
            this.Grupos.Name = "Grupos";
            this.Grupos.Size = new System.Drawing.Size(743, 383);
            this.Grupos.SmallImageList = this.imageList1;
            this.Grupos.StateImageList = this.imageList1;
            this.Grupos.TabIndex = 2;
            this.Grupos.UseCompatibleStateImageBehavior = false;
            this.Grupos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Grupos_MouseDoubleClick);
            this.Grupos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Grupos_KeyUp);
            // 
            // MenuGrupos
            // 
            this.MenuGrupos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarGrupoToolStripMenuItem});
            this.MenuGrupos.Name = "contextMenuStrip1";
            this.MenuGrupos.Size = new System.Drawing.Size(153, 26);
            // 
            // agregarGrupoToolStripMenuItem
            // 
            this.agregarGrupoToolStripMenuItem.Name = "agregarGrupoToolStripMenuItem";
            this.agregarGrupoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.agregarGrupoToolStripMenuItem.Text = "Agregar nuevo";
            this.agregarGrupoToolStripMenuItem.Click += new System.EventHandler(this.agregarGrupoToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "kedit2.png");
            this.imageList1.Images.SetKeyName(1, "file-manager.png");
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.abrirToolStripMenuItem.Text = "Editar";
            // 
            // MenuGrupo
            // 
            this.MenuGrupo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuGrupo.Name = "MenuGrupo";
            this.MenuGrupo.Size = new System.Drawing.Size(118, 48);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // FormAdminPatrones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 383);
            this.Controls.Add(this.Grupos);
            this.Name = "FormAdminPatrones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de patrones";
            this.Load += new System.EventHandler(this.FormAdminPatrones_Load);
            this.MenuGrupos.ResumeLayout(false);
            this.MenuGrupo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Grupos;
        private System.Windows.Forms.ContextMenuStrip MenuGrupos;
        private System.Windows.Forms.ToolStripMenuItem agregarGrupoToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuGrupo;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;

    }
}