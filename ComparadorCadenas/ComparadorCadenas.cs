using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015
{
    public partial class ComparadorCadenas : EditorGenerico
    {
        private string Codigo1;
        private string Codigo2;
        private string Caption1;
        private string Caption2;
        public ComparadorCadenas(string codigo1, string caption1, string codigo2, string caption2)
        {
            Codigo1=codigo1;
            Codigo2=codigo2;
            Caption1=caption1;
            Caption2 = caption2;
            InitializeComponent();

        }

        private void ComparadorCadenas_Load(object sender, EventArgs e)
        {
            // paso los datos a los componentes indicados
            Texto1.Text = Codigo1;
            Texto2.Text = Codigo2;
            Grupo1.Text = Caption1;
            Grupo2.Text = Caption2;
            ComparaCadenas();
        }
        void ComparaCadenas()
        {
            int i, n;
            if(Codigo1.Length<=Codigo2.Length)
                n = Codigo1.Length;
            else
                n=Codigo2.Length;
            for (i = 0; i < n; i++)
            {
                if (Codigo1[i] != Codigo2[i])
                {
                    // hay una diferencia
                    //la marco en los dos editores
                    Texto1.SelectionStart = i;
                    Texto1.SelectionLength = 1;
                    Texto1.SelectionColor = Color.Red;
                    Texto1.SelectionBackColor = Color.DarkGray;

                    Texto2.SelectionStart = i;
                    Texto2.SelectionLength = 1;
                    Texto2.SelectionColor = Color.Red;
                    Texto2.SelectionBackColor = Color.DarkGray;
                }
            }
        }

        private void Texto2_HScroll(object sender, EventArgs e)
        {


        }

        private void Texto2_VScroll(object sender, EventArgs e)
        {
        /*    RichTextBox obj = (RichTextBox)sender;
            int pos = obj.GetFirstCharIndexFromLine(obj.GetLineFromCharIndex(obj.GetCharIndexFromPosition(obj.AutoScrollOffset)));
            Texto1.SelectionStart = pos;// obj.GetFirstCharIndexFromLine(obj.GetLineFromCharIndex(obj.GetCharIndexFromPosition(obj.AutoScrollOffset)));
            Texto2.SelectionStart = pos;
            Texto1.SelectionLength = 0;
            Texto2.SelectionLength = 0;
          //  Texto1.SelectionStart = Texto2.SelectionStart;
            Texto1.ScrollToCaret();
            Texto2.ScrollToCaret();
//            
            //int po = obj.GetPositionFromCharIndex(0).Y;
//            e.
         */
        }

        private void volverACompararToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Texto1.SelectionStart = 0;
            Texto1.SelectionLength = Texto1.Text.Length;
            Texto1.SelectionColor = Color.Yellow;
            Texto1.SelectionBackColor = Texto1.BackColor;

            Texto2.SelectionStart = 0;
            Texto2.SelectionLength = Texto2.Text.Length;
            Texto2.SelectionColor = Color.Yellow;
            Texto2.SelectionBackColor = Texto2.BackColor;

//            Texto1.ForeColor = Color.Yellow;
//            Texto2.ForeColor = Color.Yellow;
            Codigo1 = Texto1.Text;
            Codigo2 = Texto2.Text;
            ComparaCadenas();
        }
    }
}
