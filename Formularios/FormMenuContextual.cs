using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    /// <summary>
    /// Summary description for FormMenuContextual.
    /// </summary>
    public partial class FormMenuContextual : FormBase
    {
        public event OnCodigoEvent OnCodigo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.Button Genrar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        public FormMenuContextual()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuContextual));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BAgregar = new System.Windows.Forms.Button();
            this.BEliminar = new System.Windows.Forms.Button();
            this.Genrar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 264);
            this.listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.Color.Black;
            this.BAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BAgregar.Image")));
            this.BAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgregar.Location = new System.Drawing.Point(176, 50);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(92, 36);
            this.BAgregar.TabIndex = 2;
            this.BAgregar.Text = "Agregar";
            this.BAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgregar.UseVisualStyleBackColor = false;
            this.BAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.BackColor = System.Drawing.Color.Black;
            this.BEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BEliminar.Image")));
            this.BEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEliminar.Location = new System.Drawing.Point(176, 92);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(92, 36);
            this.BEliminar.TabIndex = 3;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEliminar.UseVisualStyleBackColor = false;
            this.BEliminar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Genrar
            // 
            this.Genrar.BackColor = System.Drawing.Color.Black;
            this.Genrar.Image = ((System.Drawing.Image)(resources.GetObject("Genrar.Image")));
            this.Genrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Genrar.Location = new System.Drawing.Point(176, 142);
            this.Genrar.Name = "Genrar";
            this.Genrar.Size = new System.Drawing.Size(92, 36);
            this.Genrar.TabIndex = 4;
            this.Genrar.Text = "Generar";
            this.Genrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Genrar.UseVisualStyleBackColor = false;
            this.Genrar.Click += new System.EventHandler(this.Genrar_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(176, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 36);
            this.button3.TabIndex = 5;
            this.button3.Text = "Cerrar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
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
            // FormMenuContextual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(288, 273);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Genrar);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.BAgregar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenuContextual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de menús";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void button1_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Add(this.textBox1.Text);
            textBox1.Text = "";
            textBox1.Focus();

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
        private string DameNombre(int pos)
        {
            string s = (string)listBox1.Items[pos];
            string s2 = "";
            int i, n;
            n = s.Length;
            for (i = 0; i < n; i++)
            {
                if (s[i] == ' ')
                {
                    s2 = s2 + "_";
                }
                else
                    s2=s2+s[i];
            }
            return s2;
        }
        private void Genrar_Click(object sender, System.EventArgs e)
        {
            string s = "";
            string nombre;
            s = "#region Control del menu\r\n";
            s = s + "public System.Windows.Forms.ContextMenu Menu\r\n";
            s = s + "{\r\n";
            s = s + "\tget\r\n";
            s = s + "\t{\r\n";
            s = s + "\t\tSystem.Windows.Forms.ContextMenu contextMenu1;\r\n";
            s = s + "\t\tcontextMenu1 = new System.Windows.Forms.ContextMenu();\r\n";
            int i, n;
            n = this.listBox1.Items.Count;
            s = s + "\t\t//creando los items del menu \r\n";
            for (i = 0; i < n; i++)
            {
                nombre = DameNombre(i);
                s = s + "\t\tSystem.Windows.Forms.MenuItem Menu" + nombre + "; \r\n";
                s = s + "\t\tMenu" + nombre + "=new System.Windows.Forms.MenuItem();\r\n";
                s = s + "\t\tMenu" + nombre + ".Index =" + i.ToString() + " ;\r\n";
                s = s + "\t\tMenu" + nombre + ".Text = \"" + (string)this.listBox1.Items[i] + "\";\r\n";
                s = s + "\t\tMenu" + nombre + ".Click += new System.EventHandler(Menu" + nombre + "Click);\r\n";
                s = s + "\t\tcontextMenu1.MenuItems.Add(Menu" + nombre + ");\r\n";
            }
            s = s + "\t\treturn contextMenu1;\r\n";
            s = s + "\t} \r\n";
            s = s + "} \r\n";
            s = s + "//eventos \r\n";
            for (i = 0; i < n; i++)
            {
                nombre = DameNombre(i);
                s = s + "private void Menu" + nombre + "Click(object sender, System.EventArgs e)\r\n";
                s = s + "{\r\n";
                s = s + "\t//Colocar el codigo aqui para " + (string)this.listBox1.Items[i] + "\r\n";
                s = s + "}\r\n";
            }
            s = s + "#endregion\r\n";
            if (OnCodigo != null)
                OnCodigo("Menu", s);
            //FormVerClase dlg = new FormVerClase();
            //dlg.Texto = s;
            //dlg.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.BAgregar.Enabled == true)
                    button1_Click(null, null);
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            bool ok = true;
            if (this.textBox1.Text.Trim() == "")
                ok = false;
            this.BAgregar.Enabled = ok;
            ok = true;
            if (listBox1.SelectedIndex == -1)
                ok = false;
            BEliminar.Enabled = ok;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool ok = true;
            if (textBox1.Text.Trim() == "")
                ok = false;
            BAgregar.Enabled = ok;
        }
        public override void Guardar()
        {
            Genrar_Click(null, null);
        }

        private Opacador.FormOpacador formOpacador1;
    }
}
