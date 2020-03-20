using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormConfColores : Form
    {
        private System.Collections.Generic.List<System.Windows.Forms.Label> Colores;
        Label CurrentColor;
        public FormConfColores()
        {
            InitializeComponent();
            //creo mi lista de colores
            Colores= new List<Label>();
            Colores.Add(LC1);
            Colores.Add(LC2);
            Colores.Add(LC3);
            Colores.Add(LC4);
            Colores.Add(LC5);
            Colores.Add(LC6);
            Colores.Add(LC7);
            Colores.Add(LC8);
            Colores.Add(LC9);
            Colores.Add(LC10);
            Colores.Add(LC11);
            Colores.Add(LC12);
            Colores.Add(LC13);
            Colores.Add(LC14);
            Colores.Add(LC15);
            Colores.Add(LC16);
            foreach (Label l in Colores)
            {
                l.Text = "";
                l.Click += new EventHandler(Color_Click);
            }
            CargaColor();
            cTextColor1.AnalizaTexto();
            Elementos.SelectedIndex = 0;
            Elementos_SelectedIndexChanged(null, null);
            CargaColores();
        }

        private void FormConfColores_Load(object sender, EventArgs e)
        {
            cTextColor1.AnalizaTexto();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            CurrentColor = (Label)sender;
            foreach (Label l2 in Colores)
            {
                if (l2 != CurrentColor)
                {
                    l2.Text = "";
                }
            }
            CurrentColor.Text = "FG";
            //aplico el color al elemento que esta seleccionado
            switch (Elementos.SelectedIndex)
            {
                case 0:
                    cTextColor1.ColorCadena = CurrentColor.BackColor;
                    break;
                case 1:
                    cTextColor1.BackColor = CurrentColor.BackColor;
                    break;
                case 2:
                    cTextColor1.ColorComentario = CurrentColor.BackColor;
                    break;
                case 3:
                    cTextColor1.ColorIdentificador = CurrentColor.BackColor;
                    break;
                case 4:
                    cTextColor1.ColorNumero = CurrentColor.BackColor;
                    break;
                case 5:
                    cTextColor1.ColorOtro = CurrentColor.BackColor;
                    break;
                case 6:
                    cTextColor1.ColorPalabraRserevada = CurrentColor.BackColor;
                    break;
                case 7:
                    cTextColor1.ColorSimbolo = CurrentColor.BackColor;
                    break;
                case 8:
                    cTextColor1.ColorVariable = CurrentColor.BackColor;
                    break;
            }
            cTextColor1.AnalizaTexto();
        }

        private void Elementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label l = new Label();
            switch (Elementos.SelectedIndex)
            {
                case 0:
                    l.BackColor = cTextColor1.ColorCadena;
                    break;
                case 1:
                    l.BackColor = cTextColor1.BackColor;
                    break;
                case 2:
                    l.BackColor = cTextColor1.ColorComentario;
                    break;
                case 3:
                    l.BackColor = cTextColor1.ColorIdentificador;
                    break;
                case 4:
                    l.BackColor = cTextColor1.ColorNumero;
                    break;
                case 5:
                    l.BackColor = cTextColor1.ColorOtro;
                    break;
                case 6:
                    l.BackColor = cTextColor1.ColorPalabraRserevada;
                    break;
                case 7:
                    l.BackColor = cTextColor1.ColorSimbolo;
                    break;
                case 8:
                    l.BackColor = cTextColor1.ColorVariable;
                    break;
            }
            foreach (Label l2 in Colores)
            {
                if (l.BackColor != l2.BackColor)
                {
                    l2.Text = "";
                }
                else
                {
                    CurrentColor = l2;
                    CurrentColor.Text = "FG";
                }
            }
        }
        public string DirColores
        {
            get
            {
                string s, dir = Application.ExecutablePath;
                int i, n;
                n = dir.Length;
                for (i = n - 1; i > 0; i--)
                {
                    if (dir[i] == '\\')
                        break;
                }
                s = dir.Substring(0, i);
                return s + "\\Colores";
            }
        }
        public string DirColor
        {
            get
            {
                string s, dir = Application.ExecutablePath;
                int i, n;
                n = dir.Length;
                for (i = n - 1; i > 0; i--)
                {
                    if (dir[i] == '\\')
                        break;
                }
                s = dir.Substring(0, i);
                return s + "\\Color";
            }
        }
        private void CargaColores()
        {
            int i, n;
            string[] archivos;
            ComboColores.Items.Clear();
            try
            {
                archivos = System.IO.Directory.GetFiles(DirColores);
            }
            catch (System.Exception)
            {
                return;
            }
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                string s = archivos[i];
                ComboColores.Items.Add(QuitaDirectorio(s));
            }
        }
        private void GuardaColor()
        {
            if (System.IO.Directory.Exists(DirColor) == false)
            {
                //crea el directorio
                System.IO.Directory.CreateDirectory(DirColor);
            }
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText(DirColor + "\\Color");
            sw.WriteLine(cTextColor1.BackColor.R.ToString());
            sw.WriteLine(cTextColor1.BackColor.G.ToString());
            sw.WriteLine(cTextColor1.BackColor.B.ToString());

            sw.WriteLine(cTextColor1.ColorCadena.R.ToString());
            sw.WriteLine(cTextColor1.ColorCadena.G.ToString());
            sw.WriteLine(cTextColor1.ColorCadena.B.ToString());

            sw.WriteLine(cTextColor1.ColorComentario.R.ToString());
            sw.WriteLine(cTextColor1.ColorComentario.G.ToString());
            sw.WriteLine(cTextColor1.ColorComentario.B.ToString());

            sw.WriteLine(cTextColor1.ColorIdentificador.R.ToString());
            sw.WriteLine(cTextColor1.ColorIdentificador.G.ToString());
            sw.WriteLine(cTextColor1.ColorIdentificador.B.ToString());

            sw.WriteLine(cTextColor1.ColorNumero.R.ToString());
            sw.WriteLine(cTextColor1.ColorNumero.G.ToString());
            sw.WriteLine(cTextColor1.ColorNumero.B.ToString());

            sw.WriteLine(cTextColor1.ColorOtro.R.ToString());
            sw.WriteLine(cTextColor1.ColorOtro.G.ToString());
            sw.WriteLine(cTextColor1.ColorOtro.B.ToString());

            sw.WriteLine(cTextColor1.ColorPalabraRserevada.R.ToString());
            sw.WriteLine(cTextColor1.ColorPalabraRserevada.G.ToString());
            sw.WriteLine(cTextColor1.ColorPalabraRserevada.B.ToString());

            sw.WriteLine(cTextColor1.ColorSimbolo.R.ToString());
            sw.WriteLine(cTextColor1.ColorSimbolo.G.ToString());
            sw.WriteLine(cTextColor1.ColorSimbolo.B.ToString());

            sw.WriteLine(cTextColor1.ColorVariable.R.ToString());
            sw.WriteLine(cTextColor1.ColorVariable.G.ToString());
            sw.WriteLine(cTextColor1.ColorVariable.B.ToString());
            sw.Close();
        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(DirColores) == false)
            {
                //crea el directorio
                System.IO.Directory.CreateDirectory(DirColores);
            }
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText(DirColores + "\\" + ComboColores.Text);
            sw.WriteLine(cTextColor1.BackColor.R.ToString());
            sw.WriteLine(cTextColor1.BackColor.G.ToString());
            sw.WriteLine(cTextColor1.BackColor.B.ToString());

            sw.WriteLine(cTextColor1.ColorCadena.R.ToString());
            sw.WriteLine(cTextColor1.ColorCadena.G.ToString());
            sw.WriteLine(cTextColor1.ColorCadena.B.ToString());

            sw.WriteLine(cTextColor1.ColorComentario.R.ToString());
            sw.WriteLine(cTextColor1.ColorComentario.G.ToString());
            sw.WriteLine(cTextColor1.ColorComentario.B.ToString());

            sw.WriteLine(cTextColor1.ColorIdentificador.R.ToString());
            sw.WriteLine(cTextColor1.ColorIdentificador.G.ToString());
            sw.WriteLine(cTextColor1.ColorIdentificador.B.ToString());

            sw.WriteLine(cTextColor1.ColorNumero.R.ToString());
            sw.WriteLine(cTextColor1.ColorNumero.G.ToString());
            sw.WriteLine(cTextColor1.ColorNumero.B.ToString());

            sw.WriteLine(cTextColor1.ColorOtro.R.ToString());
            sw.WriteLine(cTextColor1.ColorOtro.G.ToString());
            sw.WriteLine(cTextColor1.ColorOtro.B.ToString());

            sw.WriteLine(cTextColor1.ColorPalabraRserevada.R.ToString());
            sw.WriteLine(cTextColor1.ColorPalabraRserevada.G.ToString());
            sw.WriteLine(cTextColor1.ColorPalabraRserevada.B.ToString());

            sw.WriteLine(cTextColor1.ColorSimbolo.R.ToString());
            sw.WriteLine(cTextColor1.ColorSimbolo.G.ToString());
            sw.WriteLine(cTextColor1.ColorSimbolo.B.ToString());
            
            sw.WriteLine(cTextColor1.ColorVariable.R.ToString());
            sw.WriteLine(cTextColor1.ColorVariable.G.ToString());
            sw.WriteLine(cTextColor1.ColorVariable.B.ToString());
            sw.Close();
            GuardaColor();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ComboColores.Text.Trim() == "")
                ok = false;
            BAceptar.Enabled = ok;
        }
        private void CargaColor()
        {

            string archivo = DirColor + "\\Color";
            if (!System.IO.File.Exists(archivo))
            {
                return;
            }
            System.IO.StreamReader rt;
            rt = System.IO.File.OpenText(archivo);
            cTextColor1.BackColor=DameColor(rt).Color;
            cTextColor1.ColorCadena=DameColor(rt).Color;
            cTextColor1.ColorComentario=DameColor(rt).Color;
            cTextColor1.ColorIdentificador=DameColor(rt).Color;
            cTextColor1.ColorNumero=DameColor(rt).Color;
            cTextColor1.ColorOtro=DameColor(rt).Color;
            cTextColor1.ColorPalabraRserevada=DameColor(rt).Color;
            cTextColor1.ColorSimbolo=DameColor(rt).Color;
            cTextColor1.ColorVariable = DameColor(rt).Color;
            rt.Close();

        }
        private System.Drawing.Pen DameColor(System.IO.StreamReader rt)
        {
            int r, g, b;
            string s;
            s = rt.ReadLine();
            r = int.Parse(s);
            s = rt.ReadLine();
            g = int.Parse(s);
            s = rt.ReadLine();
            b = int.Parse(s);
            System.Drawing.Pen p;
            p = new System.Drawing.Pen(System.Drawing.Color.FromArgb(r, g, b));
            return p;
        }

        private void ComboColores_SelectedIndexChanged(object sender, EventArgs e)
        {

            string NombreArchivo =(string) ComboColores.Items[ComboColores.SelectedIndex];
            string archivo = DirColores + "\\" + NombreArchivo;
            if (!System.IO.File.Exists(archivo))
            {
                return;
            }
            System.IO.StreamReader rt;
            rt = System.IO.File.OpenText(archivo);
            cTextColor1.BackColor = DameColor(rt).Color;
            cTextColor1.ColorCadena = DameColor(rt).Color;
            cTextColor1.ColorComentario = DameColor(rt).Color;
            cTextColor1.ColorIdentificador = DameColor(rt).Color;
            cTextColor1.ColorNumero = DameColor(rt).Color;
            cTextColor1.ColorOtro = DameColor(rt).Color;
            cTextColor1.ColorPalabraRserevada = DameColor(rt).Color;
            cTextColor1.ColorSimbolo = DameColor(rt).Color;
            cTextColor1.ColorVariable = DameColor(rt).Color;
            rt.Close();
            cTextColor1.AnalizaTexto();
        }
        private string QuitaDirectorio(string nombre)
        {
            string s = "";
            int i, n;
            n = nombre.Length;
            for (i = 0; i < n; i++)
            {
                if (nombre[i] == '\\')
                    s = "";
                else
                    s = s + nombre[i];
            }
            return s;
        }

        private void cTextColor1_OnCambiaFoco()
        {
            Elementos.Focus();
        }
    }
}