namespace Visor_sql_2015.Formularios
{
    partial class FormFK
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TTablaExterna = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TTablaPrimaria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CamposPrimaria = new System.Windows.Forms.ListBox();
            this.CamposExternos = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.TTablaExterna);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TTablaPrimaria);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 49);
            this.panel1.TabIndex = 0;
            // 
            // TTablaExterna
            // 
            this.TTablaExterna.Location = new System.Drawing.Point(187, 21);
            this.TTablaExterna.Name = "TTablaExterna";
            this.TTablaExterna.ReadOnly = true;
            this.TTablaExterna.Size = new System.Drawing.Size(157, 20);
            this.TTablaExterna.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tabla de clave externa";
            // 
            // TTablaPrimaria
            // 
            this.TTablaPrimaria.Location = new System.Drawing.Point(3, 17);
            this.TTablaPrimaria.Name = "TTablaPrimaria";
            this.TTablaPrimaria.ReadOnly = true;
            this.TTablaPrimaria.Size = new System.Drawing.Size(143, 20);
            this.TTablaPrimaria.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla de clave primaria";
            // 
            // CamposPrimaria
            // 
            this.CamposPrimaria.Dock = System.Windows.Forms.DockStyle.Left;
            this.CamposPrimaria.FormattingEnabled = true;
            this.CamposPrimaria.Location = new System.Drawing.Point(0, 49);
            this.CamposPrimaria.Name = "CamposPrimaria";
            this.CamposPrimaria.Size = new System.Drawing.Size(154, 212);
            this.CamposPrimaria.TabIndex = 1;
            // 
            // CamposExternos
            // 
            this.CamposExternos.Dock = System.Windows.Forms.DockStyle.Right;
            this.CamposExternos.FormattingEnabled = true;
            this.CamposExternos.Location = new System.Drawing.Point(189, 49);
            this.CamposExternos.Name = "CamposExternos";
            this.CamposExternos.Size = new System.Drawing.Size(161, 212);
            this.CamposExternos.TabIndex = 2;
            // 
            // FormFK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 266);
            this.Controls.Add(this.CamposExternos);
            this.Controls.Add(this.CamposPrimaria);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFK";
            this.Load += new System.EventHandler(this.FormFK_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TTablaExterna;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TTablaPrimaria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CamposPrimaria;
        private System.Windows.Forms.ListBox CamposExternos;
    }
}