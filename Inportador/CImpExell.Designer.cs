namespace Visor_sql_2015.Inportador
{
    partial class CImpExell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CImpExell));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BBuacar = new System.Windows.Forms.Button();
            this.hojas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ListaCamposOrigen = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BBajarOrigen = new System.Windows.Forms.Button();
            this.BAgregarOrigen = new System.Windows.Forms.Button();
            this.BQuitarOrigen = new System.Windows.Forms.Button();
            this.BSubirOrigen = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ListaCamposOrigen2 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ListaCamposDestino2 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BBajarDestino = new System.Windows.Forms.Button();
            this.BQuitarDestino = new System.Windows.Forms.Button();
            this.BAgregarDestino = new System.Windows.Forms.Button();
            this.BSubirDestino = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.ListaCamposDestino = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BBUscarTablaDestino = new System.Windows.Forms.Button();
            this.TTablaDestino = new System.Windows.Forms.TextBox();
            this.BProgreso = new CBarraProgreso.CBarraProgreso();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TInsertar = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BBuacar);
            this.panel1.Controls.Add(this.hojas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TArchivo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 100);
            this.panel1.TabIndex = 0;
            // 
            // BBuacar
            // 
            this.BBuacar.Image = ((System.Drawing.Image)(resources.GetObject("BBuacar.Image")));
            this.BBuacar.Location = new System.Drawing.Point(298, 7);
            this.BBuacar.Name = "BBuacar";
            this.BBuacar.Size = new System.Drawing.Size(75, 38);
            this.BBuacar.TabIndex = 5;
            this.BBuacar.UseVisualStyleBackColor = true;
            this.BBuacar.Click += new System.EventHandler(this.BBuacar_Click);
            // 
            // hojas
            // 
            this.hojas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hojas.FormattingEnabled = true;
            this.hojas.Location = new System.Drawing.Point(66, 52);
            this.hojas.Name = "hojas";
            this.hojas.Size = new System.Drawing.Size(226, 21);
            this.hojas.TabIndex = 4;
            this.hojas.SelectedIndexChanged += new System.EventHandler(this.hojas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hoja";
            // 
            // TArchivo
            // 
            this.TArchivo.Location = new System.Drawing.Point(66, 17);
            this.TArchivo.Name = "TArchivo";
            this.TArchivo.Size = new System.Drawing.Size(226, 20);
            this.TArchivo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ListaCamposOrigen);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 454);
            this.panel2.TabIndex = 1;
            // 
            // ListaCamposOrigen
            // 
            this.ListaCamposOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCamposOrigen.FormattingEnabled = true;
            this.ListaCamposOrigen.Location = new System.Drawing.Point(0, 13);
            this.ListaCamposOrigen.Name = "ListaCamposOrigen";
            this.ListaCamposOrigen.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCamposOrigen.Size = new System.Drawing.Size(182, 437);
            this.ListaCamposOrigen.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Celdas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BBajarOrigen);
            this.panel3.Controls.Add(this.BAgregarOrigen);
            this.panel3.Controls.Add(this.BQuitarOrigen);
            this.panel3.Controls.Add(this.BSubirOrigen);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(186, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(63, 454);
            this.panel3.TabIndex = 2;
            // 
            // BBajarOrigen
            // 
            this.BBajarOrigen.Image = ((System.Drawing.Image)(resources.GetObject("BBajarOrigen.Image")));
            this.BBajarOrigen.Location = new System.Drawing.Point(3, 292);
            this.BBajarOrigen.Name = "BBajarOrigen";
            this.BBajarOrigen.Size = new System.Drawing.Size(49, 43);
            this.BBajarOrigen.TabIndex = 7;
            this.BBajarOrigen.UseVisualStyleBackColor = true;
            this.BBajarOrigen.Click += new System.EventHandler(this.BBajarOrigen_Click);
            // 
            // BAgregarOrigen
            // 
            this.BAgregarOrigen.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarOrigen.Image")));
            this.BAgregarOrigen.Location = new System.Drawing.Point(3, 194);
            this.BAgregarOrigen.Name = "BAgregarOrigen";
            this.BAgregarOrigen.Size = new System.Drawing.Size(52, 43);
            this.BAgregarOrigen.TabIndex = 6;
            this.BAgregarOrigen.UseVisualStyleBackColor = true;
            this.BAgregarOrigen.Click += new System.EventHandler(this.BAgregarOrigen_Click);
            // 
            // BQuitarOrigen
            // 
            this.BQuitarOrigen.Image = ((System.Drawing.Image)(resources.GetObject("BQuitarOrigen.Image")));
            this.BQuitarOrigen.Location = new System.Drawing.Point(3, 243);
            this.BQuitarOrigen.Name = "BQuitarOrigen";
            this.BQuitarOrigen.Size = new System.Drawing.Size(49, 43);
            this.BQuitarOrigen.TabIndex = 5;
            this.BQuitarOrigen.UseVisualStyleBackColor = true;
            this.BQuitarOrigen.Click += new System.EventHandler(this.BQuitarOrigen_Click);
            // 
            // BSubirOrigen
            // 
            this.BSubirOrigen.Image = ((System.Drawing.Image)(resources.GetObject("BSubirOrigen.Image")));
            this.BSubirOrigen.Location = new System.Drawing.Point(3, 144);
            this.BSubirOrigen.Name = "BSubirOrigen";
            this.BSubirOrigen.Size = new System.Drawing.Size(49, 44);
            this.BSubirOrigen.TabIndex = 4;
            this.BSubirOrigen.UseVisualStyleBackColor = true;
            this.BSubirOrigen.Click += new System.EventHandler(this.BSubirOrigen_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ListaCamposOrigen2);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(249, 100);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(170, 454);
            this.panel7.TabIndex = 8;
            // 
            // ListaCamposOrigen2
            // 
            this.ListaCamposOrigen2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCamposOrigen2.FormattingEnabled = true;
            this.ListaCamposOrigen2.Location = new System.Drawing.Point(0, 13);
            this.ListaCamposOrigen2.Name = "ListaCamposOrigen2";
            this.ListaCamposOrigen2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCamposOrigen2.Size = new System.Drawing.Size(170, 441);
            this.ListaCamposOrigen2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Campos de la tabla";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.ListaCamposDestino2);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(419, 100);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 454);
            this.panel8.TabIndex = 9;
            // 
            // ListaCamposDestino2
            // 
            this.ListaCamposDestino2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCamposDestino2.FormattingEnabled = true;
            this.ListaCamposDestino2.Location = new System.Drawing.Point(0, 13);
            this.ListaCamposDestino2.Name = "ListaCamposDestino2";
            this.ListaCamposDestino2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCamposDestino2.Size = new System.Drawing.Size(200, 441);
            this.ListaCamposDestino2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Campos de la tabla";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.BBajarDestino);
            this.panel9.Controls.Add(this.BQuitarDestino);
            this.panel9.Controls.Add(this.BAgregarDestino);
            this.panel9.Controls.Add(this.BSubirDestino);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(619, 100);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(65, 454);
            this.panel9.TabIndex = 10;
            // 
            // BBajarDestino
            // 
            this.BBajarDestino.Image = ((System.Drawing.Image)(resources.GetObject("BBajarDestino.Image")));
            this.BBajarDestino.Location = new System.Drawing.Point(3, 292);
            this.BBajarDestino.Name = "BBajarDestino";
            this.BBajarDestino.Size = new System.Drawing.Size(49, 43);
            this.BBajarDestino.TabIndex = 3;
            this.BBajarDestino.UseVisualStyleBackColor = true;
            this.BBajarDestino.Click += new System.EventHandler(this.BBajarDestino_Click);
            // 
            // BQuitarDestino
            // 
            this.BQuitarDestino.Image = ((System.Drawing.Image)(resources.GetObject("BQuitarDestino.Image")));
            this.BQuitarDestino.Location = new System.Drawing.Point(3, 243);
            this.BQuitarDestino.Name = "BQuitarDestino";
            this.BQuitarDestino.Size = new System.Drawing.Size(52, 43);
            this.BQuitarDestino.TabIndex = 2;
            this.BQuitarDestino.UseVisualStyleBackColor = true;
            this.BQuitarDestino.Click += new System.EventHandler(this.BQuitarDestino_Click);
            // 
            // BAgregarDestino
            // 
            this.BAgregarDestino.Image = ((System.Drawing.Image)(resources.GetObject("BAgregarDestino.Image")));
            this.BAgregarDestino.Location = new System.Drawing.Point(3, 194);
            this.BAgregarDestino.Name = "BAgregarDestino";
            this.BAgregarDestino.Size = new System.Drawing.Size(49, 43);
            this.BAgregarDestino.TabIndex = 1;
            this.BAgregarDestino.UseVisualStyleBackColor = true;
            this.BAgregarDestino.Click += new System.EventHandler(this.BAgregarDestino_Click);
            // 
            // BSubirDestino
            // 
            this.BSubirDestino.Image = ((System.Drawing.Image)(resources.GetObject("BSubirDestino.Image")));
            this.BSubirDestino.Location = new System.Drawing.Point(3, 144);
            this.BSubirDestino.Name = "BSubirDestino";
            this.BSubirDestino.Size = new System.Drawing.Size(49, 44);
            this.BSubirDestino.TabIndex = 0;
            this.BSubirDestino.UseVisualStyleBackColor = true;
            this.BSubirDestino.Click += new System.EventHandler(this.BSubirDestino_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(684, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 454);
            this.panel4.TabIndex = 11;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.ListaCamposDestino);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 51);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(240, 403);
            this.panel10.TabIndex = 9;
            // 
            // ListaCamposDestino
            // 
            this.ListaCamposDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaCamposDestino.FormattingEnabled = true;
            this.ListaCamposDestino.Location = new System.Drawing.Point(0, 13);
            this.ListaCamposDestino.Name = "ListaCamposDestino";
            this.ListaCamposDestino.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListaCamposDestino.Size = new System.Drawing.Size(240, 390);
            this.ListaCamposDestino.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Campos de la tabla";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.BBUscarTablaDestino);
            this.panel5.Controls.Add(this.TTablaDestino);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 51);
            this.panel5.TabIndex = 6;
            // 
            // BBUscarTablaDestino
            // 
            this.BBUscarTablaDestino.Location = new System.Drawing.Point(163, 19);
            this.BBUscarTablaDestino.Name = "BBUscarTablaDestino";
            this.BBUscarTablaDestino.Size = new System.Drawing.Size(44, 23);
            this.BBUscarTablaDestino.TabIndex = 2;
            this.BBUscarTablaDestino.Text = "...";
            this.BBUscarTablaDestino.UseVisualStyleBackColor = true;
            this.BBUscarTablaDestino.Click += new System.EventHandler(this.BBUscarTablaDestino_Click);
            // 
            // TTablaDestino
            // 
            this.TTablaDestino.Location = new System.Drawing.Point(5, 22);
            this.TTablaDestino.Name = "TTablaDestino";
            this.TTablaDestino.ReadOnly = true;
            this.TTablaDestino.Size = new System.Drawing.Size(152, 20);
            this.TTablaDestino.TabIndex = 1;
            // 
            // BProgreso
            // 
            this.BProgreso.ColorDeBarra = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BProgreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BProgreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BProgreso.Location = new System.Drawing.Point(0, 554);
            this.BProgreso.MostrarTexto = true;
            this.BProgreso.Name = "BProgreso";
            this.BProgreso.Progreso = 0;
            this.BProgreso.ProgresoHorizontal = true;
            this.BProgreso.Size = new System.Drawing.Size(924, 24);
            this.BProgreso.TabIndex = 12;
            this.BProgreso.Texto = null;
            this.BProgreso.ValorMaximo = 100;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TInsertar
            // 
            this.TInsertar.Interval = 1;
            this.TInsertar.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // CImpExell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BProgreso);
            this.Name = "CImpExell";
            this.Size = new System.Drawing.Size(924, 578);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox hojas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListaCamposOrigen;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BBajarOrigen;
        private System.Windows.Forms.Button BAgregarOrigen;
        private System.Windows.Forms.Button BQuitarOrigen;
        private System.Windows.Forms.Button BSubirOrigen;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListBox ListaCamposOrigen2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ListBox ListaCamposDestino2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BBajarDestino;
        private System.Windows.Forms.Button BQuitarDestino;
        private System.Windows.Forms.Button BAgregarDestino;
        private System.Windows.Forms.Button BSubirDestino;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BBUscarTablaDestino;
        private System.Windows.Forms.TextBox TTablaDestino;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ListBox ListaCamposDestino;
        private System.Windows.Forms.Label label7;
        private CBarraProgreso.CBarraProgreso BProgreso;
        private System.Windows.Forms.Button BBuacar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer TInsertar;
        private System.Windows.Forms.Timer timer1;
    }
}
