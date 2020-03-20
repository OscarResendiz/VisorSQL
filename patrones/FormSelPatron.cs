using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.patrones
{
    public partial class FormSelPatron : Form
    {
        public FormSelPatron()
        {
            InitializeComponent();
        }

        private void FormSelPatron_Load(object sender, EventArgs e)
        {
            CargaPatrones();
        }
        private void CargaPatrones()
        {
            ListaPatrones.Items.Clear();
            string[] directorios;
            //se trae la lista de grupos de conexiones
            directorios = System.IO.Directory.GetFiles(DirDocumentos);
            foreach (string s in directorios)
            {
                int i, n, pos = 0;
                n = s.Length;
                for (i = 0; i < n; i++)
                {
                    if (s[i] == '\\')
                        pos = i;
                }
                ListaPatrones.Items.Add(s.Substring(pos + 1));
            }
        }
        public static string DirDocumentos
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
                s = s + "\\DOCUMENTOS";
                if (System.IO.Directory.Exists(s) == false)
                {
                    //no existe, por lo que lo creo
                    System.IO.Directory.CreateDirectory(s);
                }
                return s;
            }
        }
        public string PatronText
        {
            get
            {
                string s;
                s=(string)ListaPatrones.Items[ListaPatrones.SelectedIndex];
                TCodigo.LoadFile(DirDocumentos+"\\"+s);
                return TCodigo.Text;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ListaPatrones.SelectedIndex == -1)
                ok = false;
            BAceptar.Enabled = ok;
        }
    }
}
