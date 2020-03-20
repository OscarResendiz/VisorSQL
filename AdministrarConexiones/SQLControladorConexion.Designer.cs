namespace Visor_sql_2015.AdministrarConexiones
{
    partial class SQLControladorConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLControladorConexion));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CHContraseña = new System.Windows.Forms.CheckBox();
            this.ComboServidores = new System.Windows.Forms.ComboBox();
            this.ComboAutentication = new System.Windows.Forms.ComboBox();
            this.TUsuario = new System.Windows.Forms.TextBox();
            this.TPassword = new System.Windows.Forms.TextBox();
            this.ComboBases = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 82);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Autenticacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Base de datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nombre del usuario";
            // 
            // CHContraseña
            // 
            this.CHContraseña.AutoSize = true;
            this.CHContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CHContraseña.Location = new System.Drawing.Point(192, 265);
            this.CHContraseña.Name = "CHContraseña";
            this.CHContraseña.Size = new System.Drawing.Size(197, 24);
            this.CHContraseña.TabIndex = 6;
            this.CHContraseña.Text = "Recordar contraseña";
            this.CHContraseña.UseVisualStyleBackColor = true;
            // 
            // ComboServidores
            // 
            this.ComboServidores.FormattingEnabled = true;
            this.ComboServidores.Location = new System.Drawing.Point(192, 118);
            this.ComboServidores.Name = "ComboServidores";
            this.ComboServidores.Size = new System.Drawing.Size(263, 21);
            this.ComboServidores.TabIndex = 7;
            this.ComboServidores.DropDown += new System.EventHandler(this.ComboServidores_DropDown);
            // 
            // ComboAutentication
            // 
            this.ComboAutentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAutentication.FormattingEnabled = true;
            this.ComboAutentication.Items.AddRange(new object[] {
            "Autenticación de Windows",
            "Autenticación de SQL Server"});
            this.ComboAutentication.Location = new System.Drawing.Point(192, 159);
            this.ComboAutentication.Name = "ComboAutentication";
            this.ComboAutentication.Size = new System.Drawing.Size(263, 21);
            this.ComboAutentication.TabIndex = 8;
            this.ComboAutentication.SelectedIndexChanged += new System.EventHandler(this.ComboAutentication_SelectedIndexChanged);
            // 
            // TUsuario
            // 
            this.TUsuario.Location = new System.Drawing.Point(192, 202);
            this.TUsuario.Name = "TUsuario";
            this.TUsuario.Size = new System.Drawing.Size(263, 20);
            this.TUsuario.TabIndex = 9;
            // 
            // TPassword
            // 
            this.TPassword.Location = new System.Drawing.Point(192, 239);
            this.TPassword.Name = "TPassword";
            this.TPassword.PasswordChar = '*';
            this.TPassword.Size = new System.Drawing.Size(263, 20);
            this.TPassword.TabIndex = 10;
            // 
            // ComboBases
            // 
            this.ComboBases.FormattingEnabled = true;
            this.ComboBases.Location = new System.Drawing.Point(192, 297);
            this.ComboBases.Name = "ComboBases";
            this.ComboBases.Size = new System.Drawing.Size(263, 21);
            this.ComboBases.TabIndex = 11;
            this.ComboBases.DropDown += new System.EventHandler(this.ComboBases_DropDown);
            // 
            // SQLControladorConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.ComboBases);
            this.Controls.Add(this.TPassword);
            this.Controls.Add(this.TUsuario);
            this.Controls.Add(this.ComboAutentication);
            this.Controls.Add(this.ComboServidores);
            this.Controls.Add(this.CHContraseña);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SQLControladorConexion";
            this.Size = new System.Drawing.Size(500, 348);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CHContraseña;
        private System.Windows.Forms.ComboBox ComboServidores;
        private System.Windows.Forms.ComboBox ComboAutentication;
        private System.Windows.Forms.TextBox TUsuario;
        private System.Windows.Forms.TextBox TPassword;
        private System.Windows.Forms.ComboBox ComboBases;
    }
}
