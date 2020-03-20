namespace Visor_sql_2015.CrearTablas
{
    partial class FormUnicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnicos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListaUnicos = new System.Windows.Forms.CheckedListBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ListaUnicos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 129);
            this.panel1.TabIndex = 0;
            // 
            // ListaUnicos
            // 
            this.ListaUnicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaUnicos.FormattingEnabled = true;
            this.ListaUnicos.Location = new System.Drawing.Point(0, 0);
            this.ListaUnicos.Name = "ListaUnicos";
            this.ListaUnicos.Size = new System.Drawing.Size(341, 129);
            this.ListaUnicos.TabIndex = 0;
            // 
            // BAceptar
            // 
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(22, 137);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(82, 41);
            this.BAceptar.TabIndex = 1;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = true;
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(242, 137);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(87, 41);
            this.BCancelar.TabIndex = 2;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // FormUnicos
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(341, 185);
            this.ControlBox = false;
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormUnicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Campos unicos";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox ListaUnicos;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
    }
}