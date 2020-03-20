namespace Visor_sql_2015.TablaComponentes
{
    partial class OpcionBoton
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
            this.LTexto = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LTexto
            // 
            this.LTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LTexto.Location = new System.Drawing.Point(0, 64);
            this.LTexto.Name = "LTexto";
            this.LTexto.Size = new System.Drawing.Size(64, 26);
            this.LTexto.TabIndex = 0;
            this.LTexto.Text = "Nombre";
            this.LTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 64);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OpcionBoton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LTexto);
            this.Controls.Add(this.button1);
            this.Name = "OpcionBoton";
            this.Size = new System.Drawing.Size(64, 90);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LTexto;
        private System.Windows.Forms.Button button1;
    }
}
