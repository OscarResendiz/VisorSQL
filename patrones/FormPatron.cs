using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.patrones
{
    public partial class FormPatron : Form
    {
        private bool Modificado;
        public FormPatron(string filename)
        {
            InitializeComponent();
            if (filename != "")
            {
                TCodigo.LoadFile(DirDocumentos + "\\" + filename);
                TxtNombre.Text = filename;
                TxtNombre.ReadOnly = true;
            }
            Modificado = false;
        }
        private bool guardar()
        {
            if (TxtNombre.Text.Trim() == "")
            {
                MessageBox.Show("falta el nombre del patron");
                return false;
            }
            TCodigo.SaveFile(DirDocumentos + "\\" + TxtNombre.Text);
            return true;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Modificado == true)
            {
                if (MessageBox.Show("Desea guardar los cambios hechos", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (guardar() == false)
                    {
                        return;
                    }
                }
            }
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            guardar();
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

        private void cTextColor1_OnCambiaFoco()
        {
            TxtNombre.Focus();
            TxtNombre.SelectionLength = 0;

        }

        private void TCodigo_TextChanged(object sender, EventArgs e)
        {
            Modificado = true;
        }
    }
}
