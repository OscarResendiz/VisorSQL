namespace Visor_sql_2015.Formularios
{
    partial class ForEditTabla
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
            this.cidGrid1 = new Cid_Utilities.Grid.CidGrid();
            this.SuspendLayout();
            // 
            // cidGrid1
            // 
            this.cidGrid1.AutoRowSizing = false;
            this.cidGrid1.Botones_Catalogo = 1;
            this.cidGrid1.Catalogo = "";
            this.cidGrid1.Conexion = null;
            this.cidGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cidGrid1.Location = new System.Drawing.Point(0, 0);
            this.cidGrid1.Name = "cidGrid1";
            this.cidGrid1.Ordenamiento = false;
            this.cidGrid1.RawTitles = null;
            this.cidGrid1.SentenciaSQL = null;
            this.cidGrid1.Size = new System.Drawing.Size(713, 467);
            this.cidGrid1.Stored_Procedure = null;
            this.cidGrid1.TabIndex = 0;
            this.cidGrid1.TipoConexion = Cid_Utilities.Grid.CidGrid.ConnectionType.Table;
            this.cidGrid1.Titulo = "Titulo";
            // 
            // ForEditTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cidGrid1);
            this.Name = "ForEditTabla";
            this.Size = new System.Drawing.Size(713, 467);
            this.ResumeLayout(false);

        }

        #endregion

        private Cid_Utilities.Grid.CidGrid cidGrid1;
    }
}
