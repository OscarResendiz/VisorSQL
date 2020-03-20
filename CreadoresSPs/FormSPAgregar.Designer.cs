namespace Visor_sql_2005.CreadoresSPs
{
    partial class FormSPAgregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSPAgregar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BSiguiente = new System.Windows.Forms.Button();
            this.BAnterior = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.BAnterior);
            this.panel1.Controls.Add(this.BSiguiente);
            this.panel1.Controls.Add(this.BCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 64);
            this.panel1.TabIndex = 0;
            // 
            // BCancelar
            // 
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(516, 7);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(92, 46);
            this.BCancelar.TabIndex = 2;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // BSiguiente
            // 
            this.BSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("BSiguiente.Image")));
            this.BSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BSiguiente.Location = new System.Drawing.Point(272, 7);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(92, 46);
            this.BSiguiente.TabIndex = 1;
            this.BSiguiente.Text = "Siguiente";
            this.BSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BSiguiente.UseVisualStyleBackColor = true;
            // 
            // BAnterior
            // 
            this.BAnterior.Image = ((System.Drawing.Image)(resources.GetObject("BAnterior.Image")));
            this.BAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAnterior.Location = new System.Drawing.Point(35, 7);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(92, 46);
            this.BAnterior.TabIndex = 0;
            this.BAnterior.Text = "Anterior";
            this.BAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAnterior.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 390);
            this.panel2.TabIndex = 1;
            // 
            // FormSPAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 454);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormSPAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistente para crear procedimientos almacenados de inserción";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BSiguiente;
        private System.Windows.Forms.Button BAnterior;
        private System.Windows.Forms.Panel panel2;

    }
}