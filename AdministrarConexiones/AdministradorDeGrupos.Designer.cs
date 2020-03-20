namespace Visor_sql_2015.AdministrarConexiones
{
    partial class AdministradorDeGrupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministradorDeGrupos));
            this.Grupos = new System.Windows.Forms.ListView();
            this.MenuGrupos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MenuGrupo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.MenuGrupos.SuspendLayout();
            this.MenuGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupos
            // 
            this.Grupos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Grupos.ContextMenuStrip = this.MenuGrupos;
            this.Grupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Grupos.LargeImageList = this.imageList1;
            this.Grupos.Location = new System.Drawing.Point(0, 0);
            this.Grupos.Name = "Grupos";
            this.Grupos.Size = new System.Drawing.Size(770, 396);
            this.Grupos.SmallImageList = this.imageList1;
            this.Grupos.StateImageList = this.imageList1;
            this.Grupos.TabIndex = 0;
            this.Grupos.UseCompatibleStateImageBehavior = false;
            this.Grupos.DoubleClick += new System.EventHandler(this.Grupos_DoubleClick);
            this.Grupos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Grupos_MouseDown);
            // 
            // MenuGrupos
            // 
            this.MenuGrupos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarGrupoToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.MenuGrupos.Name = "contextMenuStrip1";
            this.MenuGrupos.Size = new System.Drawing.Size(152, 48);
            // 
            // agregarGrupoToolStripMenuItem
            // 
            this.agregarGrupoToolStripMenuItem.Name = "agregarGrupoToolStripMenuItem";
            this.agregarGrupoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.agregarGrupoToolStripMenuItem.Text = "Agregar grupo";
            this.agregarGrupoToolStripMenuItem.Click += new System.EventHandler(this.agregarGrupoToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file-manager.png");
            // 
            // MenuGrupo
            // 
            this.MenuGrupo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.MenuGrupo.Name = "MenuGrupo";
            this.MenuGrupo.Size = new System.Drawing.Size(118, 48);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // formOpacador1
            // 
            this.formOpacador1.AutoCerrar = true;
            this.formOpacador1.Degradado = true;
            this.formOpacador1.Formulario = null;
            this.formOpacador1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.formOpacador1.PrimerColor = System.Drawing.Color.Silver;
            this.formOpacador1.SegundoColor = System.Drawing.Color.Black;
            this.formOpacador1.Tiempo = 1;
            this.formOpacador1.Visible = true;
            // 
            // AdministradorDeGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 396);
            this.Controls.Add(this.Grupos);
            this.Name = "AdministradorDeGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de grupos";
            this.Load += new System.EventHandler(this.AdministradorDeGrupos_Load);
            this.MenuGrupos.ResumeLayout(false);
            this.MenuGrupo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Grupos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip MenuGrupos;
        private System.Windows.Forms.ToolStripMenuItem agregarGrupoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuGrupo;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private Opacador.FormOpacador formOpacador1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
    }
}