namespace Visor_sql_2015.Inportador
{
    partial class CImpTextoSeparado 
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CImpTextoSeparado));
            this.label1 = new System.Windows.Forms.Label();
            this.TArchivo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TSeparador = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TTabla = new System.Windows.Forms.TextBox();
            this.TErrores = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cBarraProgreso1 = new CBarraProgreso.CBarraProgreso();
            this.TImportar = new System.Windows.Forms.Timer(this.components);
            this.TimeSubirRegistros = new System.Windows.Forms.Timer(this.components);
            this.CHTabuladores = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del archivo";
            // 
            // TArchivo
            // 
            this.TArchivo.Location = new System.Drawing.Point(109, 23);
            this.TArchivo.Name = "TArchivo";
            this.TArchivo.Size = new System.Drawing.Size(276, 20);
            this.TArchivo.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(391, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Separador";
            // 
            // TSeparador
            // 
            this.TSeparador.Location = new System.Drawing.Point(65, 49);
            this.TSeparador.MaxLength = 1;
            this.TSeparador.Name = "TSeparador";
            this.TSeparador.Size = new System.Drawing.Size(100, 20);
            this.TSeparador.TabIndex = 4;
            this.TSeparador.Text = "|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tabla destino";
            // 
            // TTabla
            // 
            this.TTabla.Location = new System.Drawing.Point(80, 75);
            this.TTabla.Name = "TTabla";
            this.TTabla.Size = new System.Drawing.Size(195, 20);
            this.TTabla.TabIndex = 6;
            // 
            // TErrores
            // 
            this.TErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TErrores.Location = new System.Drawing.Point(0, 108);
            this.TErrores.Multiline = true;
            this.TErrores.Name = "TErrores";
            this.TErrores.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TErrores.Size = new System.Drawing.Size(468, 269);
            this.TErrores.TabIndex = 7;
            this.TErrores.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CHTabuladores);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TArchivo);
            this.panel1.Controls.Add(this.TTabla);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TSeparador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 108);
            this.panel1.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cBarraProgreso1
            // 
            this.cBarraProgreso1.ColorDeBarra = System.Drawing.Color.Lime;
            this.cBarraProgreso1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cBarraProgreso1.Location = new System.Drawing.Point(0, 377);
            this.cBarraProgreso1.MostrarTexto = true;
            this.cBarraProgreso1.Name = "cBarraProgreso1";
            this.cBarraProgreso1.Progreso = 0;
            this.cBarraProgreso1.ProgresoHorizontal = true;
            this.cBarraProgreso1.Size = new System.Drawing.Size(468, 24);
            this.cBarraProgreso1.TabIndex = 9;
            this.cBarraProgreso1.Texto = null;
            this.cBarraProgreso1.ValorMaximo = 100;
            // 
            // TImportar
            // 
            this.TImportar.Interval = 1;
            this.TImportar.Tick += new System.EventHandler(this.TImportar_Tick);
            // 
            // TimeSubirRegistros
            // 
            this.TimeSubirRegistros.Interval = 1;
            this.TimeSubirRegistros.Tick += new System.EventHandler(this.TimeSubirRegistros_Tick);
            // 
            // CHTabuladores
            // 
            this.CHTabuladores.AutoSize = true;
            this.CHTabuladores.Location = new System.Drawing.Point(171, 48);
            this.CHTabuladores.Name = "CHTabuladores";
            this.CHTabuladores.Size = new System.Drawing.Size(85, 17);
            this.CHTabuladores.TabIndex = 7;
            this.CHTabuladores.Text = "Tabuladores";
            this.CHTabuladores.UseVisualStyleBackColor = true;
            // 
            // CImpTextoSeparado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TErrores);
            this.Controls.Add(this.cBarraProgreso1);
            this.Controls.Add(this.panel1);
            this.Name = "CImpTextoSeparado";
            this.Size = new System.Drawing.Size(468, 401);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TArchivo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TSeparador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TTabla;
        private System.Windows.Forms.TextBox TErrores;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CBarraProgreso.CBarraProgreso cBarraProgreso1;
        private System.Windows.Forms.Timer TImportar;
        private System.Windows.Forms.Timer TimeSubirRegistros;
        private System.Windows.Forms.CheckBox CHTabuladores;
    }
}
