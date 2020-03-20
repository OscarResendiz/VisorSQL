using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AdministrarConexiones
{
    public delegate void OnConectarEvent(string ConextionString, string nombre);
    public partial class FormAdminConexiones :Formularios.FormBase
    {
        public string Grupo;
        public event OnConectarEvent OnConectar;
        public FormAdminConexiones()
        {
            Grupo = "";
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormConexion dlg = new FormConexion(Grupo);
            dlg.ShowDialog();
            CargaConexiones();
        }

        private void FormAdminConexiones_Load(object sender, EventArgs e)
        {
            CargaConexiones();
        }
        private void CargaConexiones()
        {
            int i, n;
            string[] archivos;
            ListaConexiones.Items.Clear();
            archivos = System.IO.Directory.GetFiles(DirConexiones);
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                string s = archivos[i];
                ListaConexiones.Items.Add(QuitaDirectorio(s));
            }
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
        public string DirConexiones
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
                if(Grupo=="")
                    return s + "\\CONEXIONES";
                return s + "\\CONEXIONES\\" + Grupo;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ListaConexiones.SelectedIndex == -1)
                ok = false;
            BConectar.Enabled = ok;
            BEliminar.Enabled = ok;
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ELIMINAR CONEXION?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;
            string s=(string)ListaConexiones.Items[ListaConexiones.SelectedIndex];
            System.IO.File.Delete(DirConexiones+"\\"+s);
            CargaConexiones();
        }

        private void BConectar_Click(object sender, EventArgs e)
        {
            string s = (string)ListaConexiones.Items[ListaConexiones.SelectedIndex];
            string NombreArchivo=s;
            string archivo=DirConexiones+"\\"+NombreArchivo;
            if (!System.IO.File.Exists(archivo))
            {
                MessageBox.Show("No se encontro la conexion");
                return;
            }
//            System.IO.StreamReader rt;
  //          rt = System.IO.File.OpenText(archivo);
            s = "";// rt.ReadLine();
//            rt.Close();
            if (OnConectar != null)
            {
                try
                {
                    OnConectar(s, NombreArchivo);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void ListaConexiones_DoubleClick(object sender, EventArgs e)
        {
            if (ListaConexiones.SelectedIndex == -1)
                return;
            string s = (string)ListaConexiones.Items[ListaConexiones.SelectedIndex];
            string NombreArchivo = s;
            string archivo = DirConexiones + "\\" + NombreArchivo;
            if (!System.IO.File.Exists(archivo))
            {
                MessageBox.Show("No se encontro la conexion");
                return;
            }

//            System.IO.StreamReader rt;
  //          rt = System.IO.File.OpenText(archivo);
    //        s = rt.ReadLine();
      //      rt.Close();
            FormConexion dlg = new FormConexion(Grupo);
            dlg.Nombre=NombreArchivo;
            dlg.ConnectionString=s;
            dlg.ShowDialog();
            CargaConexiones();
        }

    }
}