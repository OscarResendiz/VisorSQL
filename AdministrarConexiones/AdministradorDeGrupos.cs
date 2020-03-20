using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Visor_sql_2015.AdministrarConexiones
{
    public delegate void OnConexionGrupoEvent(string cadena,string nombre,string grupo);
    public delegate void OnGuprosModificadosEvent( string nombre);
    public partial class AdministradorDeGrupos : Form
    {
        public event OnGuprosModificadosEvent OnAddgrupo;
        public event OnGuprosModificadosEvent OnDeleteGrupo;
        public event OnConexionGrupoEvent OnConexionGrupo;
        private string GrupoActual;
        public AdministradorDeGrupos()
        {
            InitializeComponent();
            GrupoActual = "";
        }
        private void CargaGrupos()
        {
            Grupos.Items.Clear();
            string[] directorios;
            //se trae la lista de grupos de conexiones
            directorios=System.IO.Directory.GetDirectories(DirConexiones);
            foreach (string s in directorios)
            {
                int i, n,pos=0;
                n = s.Length;
                for (i = 0; i < n; i++)
                {
                    if (s[i] == '\\')
                        pos = i;
                }
                Grupos.Items.Add(s.Substring(pos+1),0);
            }
        }
        public static string DirConexiones
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
                return s + "\\CONEXIONES";
            }
        }

        private void agregarGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGrupo dlg=new FormGrupo();
            if(dlg.ShowDialog()== DialogResult.Cancel)
                return;
            if(System.IO.Directory.Exists(DirConexiones+"\\"+dlg.NombreGrupo)==true)
            {
                MessageBox.Show("Ya existe el grupo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                System.IO.Directory.CreateDirectory(DirConexiones + "\\" + dlg.NombreGrupo);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargaGrupos();
            if (OnAddgrupo != null)
                OnAddgrupo(dlg.NombreGrupo);
        }

        private void Grupos_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem obj = Grupos.GetItemAt(e.X, e.Y);
            if (obj == null)
            {
                Grupos.ContextMenuStrip = MenuGrupos;
                GrupoActual = "";
                return;
            }
            GrupoActual = obj.Text;
            Grupos.ContextMenuStrip = MenuGrupo;
        }

        private void AdministradorDeGrupos_Load(object sender, EventArgs e)
        {
            CargaGrupos();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el grupo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            string s = GrupoActual;
            //checo si no esta vacio
            string[] archivos;
            archivos = System.IO.Directory.GetFiles(DirConexiones + "\\" + GrupoActual);
            if (archivos.GetLength(0) > 0)
            {
                if (MessageBox.Show("El grupo contiene conexiones. ¿Desea eliminarlas también?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                foreach (string sf in archivos)
                {
                    System.IO.File.Delete(sf);
                }

            }
            System.IO.Directory.Delete(DirConexiones + "\\" + GrupoActual);
            CargaGrupos();
            if (OnDeleteGrupo != null)
                OnDeleteGrupo(s);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminConexiones dlg = new FormAdminConexiones();
            dlg.OnConectar += new OnConectarEvent(OnConexion);
            dlg.Grupo = GrupoActual;
            dlg.ShowDialog();
        }

        private void Grupos_DoubleClick(object sender, EventArgs e)
        {
            if (GrupoActual == "")
                return;
            FormAdminConexiones dlg = new FormAdminConexiones();
            dlg.OnConectar += new OnConectarEvent(OnConexion);
            dlg.Grupo = GrupoActual;
            dlg.ShowDialog();
        }
        private void OnConexion(string cadena, string nombre)
        {
            if (OnConexionGrupo != null)
                OnConexionGrupo(cadena, nombre, GrupoActual);
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
