namespace Visor_sql_2015.AdministrarConexiones
{
    partial class MySQLControladorConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MySQLControladorConexion));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ComboBases = new System.Windows.Forms.ComboBox();
            this.TPassword = new System.Windows.Forms.TextBox();
            this.TUsuario = new System.Windows.Forms.TextBox();
            this.ComboServidores = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ComboBases
            // 
            this.ComboBases.FormattingEnabled = true;
            this.ComboBases.Location = new System.Drawing.Point(189, 228);
            this.ComboBases.Name = "ComboBases";
            this.ComboBases.Size = new System.Drawing.Size(263, 21);
            this.ComboBases.TabIndex = 19;
            this.ComboBases.DropDown += new System.EventHandler(this.ComboBases_DropDown);
            // 
            // TPassword
            // 
            this.TPassword.Location = new System.Drawing.Point(189, 187);
            this.TPassword.Name = "TPassword";
            this.TPassword.PasswordChar = '*';
            this.TPassword.Size = new System.Drawing.Size(263, 20);
            this.TPassword.TabIndex = 18;
            // 
            // TUsuario
            // 
            this.TUsuario.Location = new System.Drawing.Point(189, 150);
            this.TUsuario.Name = "TUsuario";
            this.TUsuario.Size = new System.Drawing.Size(263, 20);
            this.TUsuario.TabIndex = 17;
            // 
            // ComboServidores
            // 
            this.ComboServidores.FormattingEnabled = true;
            this.ComboServidores.Location = new System.Drawing.Point(189, 111);
            this.ComboServidores.Name = "ComboServidores";
            this.ComboServidores.Size = new System.Drawing.Size(263, 21);
            this.ComboServidores.TabIndex = 16;
            this.ComboServidores.DropDown += new System.EventHandler(this.ComboServidores_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nombre del usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Base de datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre del servidor";
            // 
            // MySQLControladorConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.ComboBases);
            this.Controls.Add(this.TPassword);
            this.Controls.Add(this.TUsuario);
            this.Controls.Add(this.ComboServidores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MySQLControladorConexion";
            this.Size = new System.Drawing.Size(495, 279);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox ComboBases;
        private System.Windows.Forms.TextBox TPassword;
        private System.Windows.Forms.TextBox TUsuario;
        private System.Windows.Forms.ComboBox ComboServidores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
