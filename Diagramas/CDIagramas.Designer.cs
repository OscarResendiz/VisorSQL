namespace Visor_sql_2015.Diagramas
{
    partial class CDIagramas
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
            this.Diseñador = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBarraProgreso1 = new CBarraProgreso.CBarraProgreso();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Diseñador
            // 
            this.Diseñador.BackColor = System.Drawing.Color.White;
            this.Diseñador.Location = new System.Drawing.Point(3, 3);
            this.Diseñador.Name = "Diseñador";
            this.Diseñador.Size = new System.Drawing.Size(2000, 2500);
            this.Diseñador.TabIndex = 0;
            this.Diseñador.Paint += new System.Windows.Forms.PaintEventHandler(this.Diseñador_Paint);
            this.Diseñador.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Diseñador_MouseMove);
            this.Diseñador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Diseñador_MouseDoubleClick);
            this.Diseñador.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Diseñador_MouseClick);
            this.Diseñador.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Diseñador_MouseDown);
            this.Diseñador.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Diseñador_MouseUp);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Diseñador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 526);
            this.panel1.TabIndex = 1;
            // 
            // cBarraProgreso1
            // 
            this.cBarraProgreso1.ColorDeBarra = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cBarraProgreso1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBarraProgreso1.ForeColor = System.Drawing.Color.Red;
            this.cBarraProgreso1.Location = new System.Drawing.Point(0, 526);
            this.cBarraProgreso1.MostrarTexto = true;
            this.cBarraProgreso1.Name = "cBarraProgreso1";
            this.cBarraProgreso1.Progreso = 0;
            this.cBarraProgreso1.ProgresoHorizontal = true;
            this.cBarraProgreso1.Size = new System.Drawing.Size(813, 24);
            this.cBarraProgreso1.TabIndex = 4;
            this.cBarraProgreso1.Texto = "";
            this.cBarraProgreso1.ValorMaximo = 100;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CDIagramas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cBarraProgreso1);
            this.Name = "CDIagramas";
            this.Size = new System.Drawing.Size(813, 550);
            this.Load += new System.EventHandler(this.FormDiagrama_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Diseñador;
        private System.Windows.Forms.Panel panel1;
        private CBarraProgreso.CBarraProgreso cBarraProgreso1;
        private System.Windows.Forms.Timer timer1;
    }
}