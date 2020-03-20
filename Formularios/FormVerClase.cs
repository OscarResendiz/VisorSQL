using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//    public class FormVerClase : Form

namespace Visor_sql_2015.Formularios
{
    /// <summary>
    /// Summary description for FormVerClase.
    /// </summary>
    public partial class FormVerClase : FormBase
    {

        public FormVerClase()
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
            this.TCodigo = new System.Windows.Forms.RichTextBox();
            this.cTextColor1 = new TextColor.CTextColor(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // TCodigo
            // 
            this.TCodigo.AcceptsTab = true;
            this.TCodigo.BackColor = System.Drawing.Color.Navy;
            this.TCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCodigo.ForeColor = System.Drawing.Color.Yellow;
            this.TCodigo.Location = new System.Drawing.Point(0, 0);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.TCodigo.Size = new System.Drawing.Size(688, 405);
            this.TCodigo.TabIndex = 1;
            this.TCodigo.Text = "";
            this.TCodigo.WordWrap = false;
            // 
            // cTextColor1
            // 
            this.cTextColor1.BackColor = System.Drawing.Color.Navy;
            this.cTextColor1.ColorCadena = System.Drawing.Color.White;
            this.cTextColor1.ColorComentario = System.Drawing.Color.Red;
            this.cTextColor1.ColorIdentificador = System.Drawing.Color.Yellow;
            this.cTextColor1.ColorNumero = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cTextColor1.ColorOtro = System.Drawing.Color.Yellow;
            this.cTextColor1.ColorPalabraRserevada = System.Drawing.Color.Lime;
            this.cTextColor1.ColorSimbolo = System.Drawing.Color.Cyan;
            this.cTextColor1.ColorVariable = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cTextColor1.RichTextBox = this.TCodigo;
            // 
            // FormVerClase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(688, 405);
            this.Controls.Add(this.TCodigo);
            this.Name = "FormVerClase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Codigo de la clase";
            this.Load += new System.EventHandler(this.FormVerClase_Load);
            this.ResumeLayout(false);

        }
        #endregion
        public void CreaCodigoTabla(string clase, System.Collections.Generic.List<Objetos.CParametro> parametros)
        {
            TCodigo.Text = "";
            string s;
            s = "using System;\r\n";
            s = s + "namespace //namespace\r\n";
            s = s + "{\r\n";
            s = s + "\t/// <summary>\r\n";
            s = s + "\t/// Summary description for " + clase + ".\r\n";
            s = s + "\t/// </summary>\r\n";
            s = s + "\tpublic class " + clase + "\r\n";
            s = s + "\t{\r\n";
            s = s + "\t\tpublic " + clase + "()\r\n";
            s = s + "\t\t{\r\n";
            s = s + "\t\t//\r\n";
            s = s + "\t\t// TODO: Add constructor logic here\r\n";
            s = s + "\t\t//\r\n";
            s = s + "\t\t}\r\n";
            Objetos.CConvertidor conv = new Objetos.CConvertidor();
            int i, n;
            n = parametros.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro par = parametros[i];
                s = s + "\t\tpublic " + par.TipoNet + " " + par.nombre + "\r\n";
                s = s + "\t\t{\r\n";
                s = s + "\t\t\tget;\r\n";
                s = s + "\t\t\tset;\r\n";
                s = s + "\t\t}\r\n";
            }
            s = s + "\t}\r\n";
            s = s + "}\r\n";
            TCodigo.Text = s;
            cTextColor1.AnalizaTexto();
        }

        private RichTextBox TCodigo;
        private IContainer components;
        private TextColor.CTextColor cTextColor1;
    
        public string Texto
        {
            set
            {
                TCodigo.Text = value;
                cTextColor1.AnalizaTexto();
            }
        }

        private void FormVerClase_Load(object sender, EventArgs e)
        {
            TCodigo.Text = TCodigo.Text + " ";
            cTextColor1.AnalizaTexto();
        }
        public override void Guardar()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText(saveFileDialog1.FileName);
            sw.WriteLine(TCodigo.Text);
            sw.Close();
        }

        private SaveFileDialog saveFileDialog1;
    }
}
