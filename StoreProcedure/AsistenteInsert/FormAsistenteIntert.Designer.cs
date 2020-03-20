namespace Visor_sql_2015.StoreProcedure.AsistenteInsert
{
    partial class FormAsistenteIntert
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
            this.BAnterior = new System.Windows.Forms.Button();
            this.BSiguiente = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BCancelar);
            this.panel1.Controls.Add(this.BSiguiente);
            this.panel1.Controls.Add(this.BAnterior);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 342);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 51);
            this.panel1.TabIndex = 0;
            // 
            // BAnterior
            // 
            this.BAnterior.Location = new System.Drawing.Point(22, 16);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(75, 23);
            this.BAnterior.TabIndex = 0;
            this.BAnterior.Text = "Anterior";
            this.BAnterior.UseVisualStyleBackColor = true;
            // 
            // BSiguiente
            // 
            this.BSiguiente.Location = new System.Drawing.Point(269, 16);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(75, 23);
            this.BSiguiente.TabIndex = 1;
            this.BSiguiente.Text = "Siguiente";
            this.BSiguiente.UseVisualStyleBackColor = true;
            // 
            // BCancelar
            // 
            this.BCancelar.Location = new System.Drawing.Point(591, 16);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 2;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 0);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(694, 342);
            this.Contenedor.TabIndex = 1;
            // 
            // FormAsistenteIntert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 393);
            this.ControlBox = false;
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAsistenteIntert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistente de insercion";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BSiguiente;
        private System.Windows.Forms.Button BAnterior;
        private System.Windows.Forms.Panel Contenedor;
    }
}