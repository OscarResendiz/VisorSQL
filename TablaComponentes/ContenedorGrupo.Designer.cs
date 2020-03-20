namespace Visor_sql_2015.TablaComponentes
{
    partial class ContenedorGrupo
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            this.LTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LTitulo
            // 
            this.LTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LTitulo.Location = new System.Drawing.Point(0, 135);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(285, 13);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "Titulo Grupo";
            this.LTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContenedorGrupo
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LTitulo);
            this.Name = "ContenedorGrupo";
            this.Size = new System.Drawing.Size(285, 148);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LTitulo;
    }
}
