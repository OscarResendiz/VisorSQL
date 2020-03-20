namespace Visor_sql_2015.Formularios
{
    partial class FormCrearDiccionario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListaObjetosDestino = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BAgregarTodo = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
            this.BQuitar = new System.Windows.Forms.Button();
            this.BQuitarTodo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ListaObjetos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.BCrear = new System.Windows.Forms.Button();
            this.BNavegar = new System.Windows.Forms.Button();
            this.TArchivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ListaObjetosDestino);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 429);
            this.panel1.TabIndex = 0;
            // 
            // ListaObjetosDestino
            // 
            this.ListaObjetosDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaObjetosDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetosDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaObjetosDestino.FormattingEnabled = true;
            this.ListaObjetosDestino.Location = new System.Drawing.Point(286, 13);
            this.ListaObjetosDestino.Name = "ListaObjetosDestino";
            this.ListaObjetosDestino.Size = new System.Drawing.Size(205, 407);
            this.ListaObjetosDestino.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(286, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TABLAS A TOMAR EN CUENTA";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BAgregarTodo);
            this.panel3.Controls.Add(this.BAgregar);
            this.panel3.Controls.Add(this.BQuitar);
            this.panel3.Controls.Add(this.BQuitarTodo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(86, 429);
            this.panel3.TabIndex = 1;
            // 
            // BAgregarTodo
            // 
            this.BAgregarTodo.BackColor = System.Drawing.Color.Black;
            this.BAgregarTodo.Location = new System.Drawing.Point(3, 130);
            this.BAgregarTodo.Name = "BAgregarTodo";
            this.BAgregarTodo.Size = new System.Drawing.Size(75, 23);
            this.BAgregarTodo.TabIndex = 5;
            this.BAgregarTodo.Text = ">>";
            this.BAgregarTodo.UseVisualStyleBackColor = false;
            this.BAgregarTodo.Click += new System.EventHandler(this.BAgregarTodo_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.Color.Black;
            this.BAgregar.Location = new System.Drawing.Point(3, 169);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(75, 23);
            this.BAgregar.TabIndex = 4;
            this.BAgregar.Text = ">";
            this.BAgregar.UseVisualStyleBackColor = false;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // BQuitar
            // 
            this.BQuitar.BackColor = System.Drawing.Color.Black;
            this.BQuitar.Location = new System.Drawing.Point(6, 252);
            this.BQuitar.Name = "BQuitar";
            this.BQuitar.Size = new System.Drawing.Size(75, 23);
            this.BQuitar.TabIndex = 3;
            this.BQuitar.Text = "<";
            this.BQuitar.UseVisualStyleBackColor = false;
            this.BQuitar.Click += new System.EventHandler(this.BQuitar_Click);
            // 
            // BQuitarTodo
            // 
            this.BQuitarTodo.BackColor = System.Drawing.Color.Black;
            this.BQuitarTodo.Location = new System.Drawing.Point(6, 209);
            this.BQuitarTodo.Name = "BQuitarTodo";
            this.BQuitarTodo.Size = new System.Drawing.Size(75, 23);
            this.BQuitarTodo.TabIndex = 2;
            this.BQuitarTodo.Text = "<<";
            this.BQuitarTodo.UseVisualStyleBackColor = false;
            this.BQuitarTodo.Click += new System.EventHandler(this.BQuitarTodo_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ListaObjetos);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 429);
            this.panel2.TabIndex = 0;
            // 
            // ListaObjetos
            // 
            this.ListaObjetos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListaObjetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaObjetos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ListaObjetos.FormattingEnabled = true;
            this.ListaObjetos.Location = new System.Drawing.Point(0, 13);
            this.ListaObjetos.Name = "ListaObjetos";
            this.ListaObjetos.Size = new System.Drawing.Size(200, 407);
            this.ListaObjetos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "LISTA DE TABLAS ORIGEN";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.TNombre);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.BCrear);
            this.panel4.Controls.Add(this.BNavegar);
            this.panel4.Controls.Add(this.TArchivo);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(491, 59);
            this.panel4.TabIndex = 1;
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(62, 33);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(258, 20);
            this.TNombre.TabIndex = 6;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(397, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // BCrear
            // 
            this.BCrear.BackColor = System.Drawing.Color.Black;
            this.BCrear.Location = new System.Drawing.Point(397, 5);
            this.BCrear.Name = "BCrear";
            this.BCrear.Size = new System.Drawing.Size(75, 23);
            this.BCrear.TabIndex = 3;
            this.BCrear.Text = "Crear";
            this.BCrear.UseVisualStyleBackColor = false;
            this.BCrear.Click += new System.EventHandler(this.BCrear_Click);
            // 
            // BNavegar
            // 
            this.BNavegar.BackColor = System.Drawing.Color.Black;
            this.BNavegar.Location = new System.Drawing.Point(326, 7);
            this.BNavegar.Name = "BNavegar";
            this.BNavegar.Size = new System.Drawing.Size(42, 23);
            this.BNavegar.TabIndex = 2;
            this.BNavegar.Text = "...";
            this.BNavegar.UseVisualStyleBackColor = false;
            this.BNavegar.Click += new System.EventHandler(this.BNavegar_Click);
            // 
            // TArchivo
            // 
            this.TArchivo.Location = new System.Drawing.Point(62, 9);
            this.TArchivo.Name = "TArchivo";
            this.TArchivo.Size = new System.Drawing.Size(258, 20);
            this.TArchivo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Archivo";
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
            // FormCrearDiccionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(491, 488);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCrearDiccionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diccionario de datos";
            this.Load += new System.EventHandler(this.FormCrearDiccionario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ListaObjetosDestino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BAgregarTodo;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.Button BQuitar;
        private System.Windows.Forms.Button BQuitarTodo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox ListaObjetos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BCrear;
        private System.Windows.Forms.Button BNavegar;
        private System.Windows.Forms.TextBox TArchivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label4;
        private Opacador.FormOpacador formOpacador1;
    }
}