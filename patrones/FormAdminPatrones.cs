using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.patrones
{
    public partial class FormAdminPatrones : Form
    {
        public FormAdminPatrones()
        {
            InitializeComponent();
        }
        private void CargaPatrones()
        {
            Grupos.Items.Clear();
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
                Grupos.Items.Add(s.Substring(pos + 1), 0);
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
                return s ;
            }
        }

        private void FormAdminPatrones_Load(object sender, EventArgs e)
        {
            CargaPatrones();

        }

        private void agregarGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPatron dlg = new FormPatron("");
            dlg.ShowDialog();
            CargaPatrones();
        }

        private void Grupos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //editar
            if (Grupos.SelectedIndices.Count == 0)
                return;
            FormPatron dlg = new FormPatron(Grupos.SelectedItems[0].Text);
            dlg.ShowDialog();
            CargaPatrones();
        }

        private void Grupos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            if (Grupos.SelectedIndices.Count == 0)
                return;
            if (MessageBox.Show("¿Desea eliminar los patrones elegidos?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach(ListViewItem itm in Grupos.SelectedItems)
                {
                        System.IO.File.Delete(DirDocumentos + "\\" + itm.Text);
                }
            }
            CargaPatrones();
            
        }
    }
}
