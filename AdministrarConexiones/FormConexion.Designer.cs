namespace Visor_sql_2015.AdministrarConexiones
{
    partial class FormConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConexion));
            this.label1 = new System.Windows.Forms.Label();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TConexion = new System.Windows.Forms.TextBox();
            this.BConexion = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dialogConecSQL20051 = new DialogConecSQL2005.DialogConecSQL2005(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboMotor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(62, 18);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(335, 20);
            this.TNombre.TabIndex = 1;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(312, 10);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(85, 37);
            this.BAceptar.TabIndex = 2;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(37, 10);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(85, 37);
            this.BCancelar.TabIndex = 3;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(34, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Conexion";
            this.label2.Visible = false;
            // 
            // TConexion
            // 
            this.TConexion.Location = new System.Drawing.Point(112, 97);
            this.TConexion.Name = "TConexion";
            this.TConexion.Size = new System.Drawing.Size(183, 20);
            this.TConexion.TabIndex = 5;
            this.TConexion.Visible = false;
            // 
            // BConexion
            // 
            this.BConexion.BackColor = System.Drawing.Color.Black;
            this.BConexion.Image = ((System.Drawing.Image)(resources.GetObject("BConexion.Image")));
            this.BConexion.Location = new System.Drawing.Point(301, 97);
            this.BConexion.Name = "BConexion";
            this.BConexion.Size = new System.Drawing.Size(53, 35);
            this.BConexion.TabIndex = 6;
            this.BConexion.Text = "...";
            this.BConexion.UseVisualStyleBackColor = false;
            this.BConexion.Visible = false;
            this.BConexion.Click += new System.EventHandler(this.BConexion_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dialogConecSQL20051
            // 
            this.dialogConecSQL20051.ConnectionString = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.ComboMotor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 73);
            this.panel1.TabIndex = 7;
            // 
            // ComboMotor
            // 
            this.ComboMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMotor.FormattingEnabled = true;
            this.ComboMotor.Location = new System.Drawing.Point(62, 47);
            this.ComboMotor.Name = "ComboMotor";
            this.ComboMotor.Size = new System.Drawing.Size(335, 21);
            this.ComboMotor.TabIndex = 3;
            this.ComboMotor.SelectedIndexChanged += new System.EventHandler(this.ComboMotor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Motor";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.BAceptar);
            this.panel2.Controls.Add(this.BCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 50);
            this.panel2.TabIndex = 8;
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 73);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(494, 144);
            this.Contenedor.TabIndex = 9;
            // 
            // FormConexion
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(494, 267);
            this.Controls.Add(this.BConexion);
            this.Controls.Add(this.TConexion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexion";
            this.Load += new System.EventHandler(this.FormConexion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TConexion;
        private System.Windows.Forms.Button BConexion;
        private System.Windows.Forms.Timer timer1;
        private DialogConecSQL2005.DialogConecSQL2005 dialogConecSQL20051;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ComboMotor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Contenedor;
    }
}