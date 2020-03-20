namespace Visor_sql_2015.patrones
{
    partial class FormSelPatron
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelPatron));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.ListaPatrones = new System.Windows.Forms.ListBox();
            this.TCodigo = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.BCancelar);
            this.panel1.Controls.Add(this.BAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 324);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 58);
            this.panel1.TabIndex = 0;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.Black;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(170, 10);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(90, 41);
            this.BCancelar.TabIndex = 1;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.Black;
            this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BAceptar.Image")));
            this.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAceptar.Location = new System.Drawing.Point(24, 10);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(90, 41);
            this.BAceptar.TabIndex = 0;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAceptar.UseVisualStyleBackColor = false;
            // 
            // ListaPatrones
            // 
            this.ListaPatrones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaPatrones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaPatrones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaPatrones.FormattingEnabled = true;
            this.ListaPatrones.Location = new System.Drawing.Point(0, 0);
            this.ListaPatrones.Name = "ListaPatrones";
            this.ListaPatrones.Size = new System.Drawing.Size(272, 316);
            this.ListaPatrones.Sorted = true;
            this.ListaPatrones.TabIndex = 1;
            // 
            // TCodigo
            // 
            this.TCodigo.Location = new System.Drawing.Point(47, 140);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.Size = new System.Drawing.Size(100, 96);
            this.TCodigo.TabIndex = 2;
            this.TCodigo.Text = "";
            this.TCodigo.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formOpacador1
            // 
            this.formOpacador1.AutoCerrar = true;
            this.formOpacador1.Degradado = true;
            this.formOpacador1.Formulario = this;
            this.formOpacador1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.formOpacador1.PrimerColor = System.Drawing.Color.Gray;
            this.formOpacador1.SegundoColor = System.Drawing.Color.Black;
            this.formOpacador1.Tiempo = 10;
            this.formOpacador1.Visible = true;
            // 
            // FormSelPatron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 382);
            this.ControlBox = false;
            this.Controls.Add(this.TCodigo);
            this.Controls.Add(this.ListaPatrones);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSelPatron";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de patrón";
            this.Load += new System.EventHandler(this.FormSelPatron_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.ListBox ListaPatrones;
        private System.Windows.Forms.RichTextBox TCodigo;
        private System.Windows.Forms.Timer timer1;
        private Opacador.FormOpacador formOpacador1;
    }
}