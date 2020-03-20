using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Documentador
{
    enum ESTADOS_DOCUEMNTACIO
    {
        INCATIVO=0,
        LEYENDO_TABLAS=1,
        ANALIZANDO=2,
        INICA_LECTURA=3
    }
    public partial class FormExportarDocuemntacion : Form
    {
        System.Collections.Generic.List<Objetos.CSysObject> Lista;
        Controladores_DB.IDataBase DB;
        Controladores_DB.IDataBase DB2;
        private ESTADOS_DOCUEMNTACIO Estado;
        public FormExportarDocuemntacion(Controladores_DB.IDataBase db)
        {
            DB = db;
            Estado = ESTADOS_DOCUEMNTACIO.INCATIVO;
            InitializeComponent();
    //        CargaConexiones();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ComboConexiones.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Seleccione una base de datos");
                return;
            }
            BAnalizar.Enabled = false;
            Estado = ESTADOS_DOCUEMNTACIO.INICA_LECTURA;
            TablasDocuemntadas.Items.Clear();
            ComboConexiones.Enabled = false;
            TimerDocumentar.Enabled = true;
        }

        private void FormExportarDocuemntacion_Load(object sender, EventArgs e)
        {
            CargaGrupos();
        }
        private void CargaGrupos()
        {
            ComboGrupos.Items.Clear();
            string[] directorios;
            //se trae la lista de grupos de conexiones
            directorios = System.IO.Directory.GetDirectories(DirConexiones);
            foreach (string s in directorios)
            {
                int i, n, pos = 0;
                n = s.Length;
                for (i = 0; i < n; i++)
                {
                    if (s[i] == '\\')
                        pos = i;
                }
                ComboGrupos.Items.Add(s.Substring(pos + 1));
            }
        }

        private void CargaConexiones()
        {
            ComboConexiones.Items.Clear();
            int i, n;
            string[] archivos;
            if (System.IO.Directory.Exists(DirConexiones) == false)
            {
                System.IO.Directory.CreateDirectory(DirConexiones);
            }
            archivos = System.IO.Directory.GetFiles(DirConexiones);
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                ComboConexiones.Items.Add(QuitaDirectorio(archivos[i]));
            }
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
                return s + "\\CONEXIONES";
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

        private void ComboConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboConexiones.SelectedIndex == -1)
            {
                BAnalizar.Enabled = false;
                return;
            }
            BAnalizar.Enabled = true;
            //-----------------------------------------
            string archivo = DirConexiones + "\\" +ComboGrupos.Items[ComboGrupos.SelectedIndex].ToString()+"\\"+ ComboConexiones.Items[ComboConexiones.SelectedIndex].ToString();
            if (!System.IO.File.Exists(archivo))
            {
                MessageBox.Show("No se encontro la conexion");
                return;
            }
            AdministrarConexiones.CInstanciadorDB IDB = new AdministrarConexiones.CInstanciadorDB();
            DB2=IDB.DameInstancia(DirConexiones + "\\" +ComboGrupos.Items[ComboGrupos.SelectedIndex].ToString(),ComboConexiones.Items[ComboConexiones.SelectedIndex].ToString());
            try
            {
                DB2.PruebaConexion();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                ComboConexiones.SelectedIndex = -1;
                return;
            }
            this.Text = DB2.ConnectionString;

        }

        private void TimerDocumentar_Tick(object sender, EventArgs e)
        {
            switch (Estado)
            {
                case ESTADOS_DOCUEMNTACIO.INICA_LECTURA:
                    cBarraProgreso1.Texto = "Extrayendo objetos de la base de datos";
                    Estado = ESTADOS_DOCUEMNTACIO.LEYENDO_TABLAS;
                    break;
                case ESTADOS_DOCUEMNTACIO.LEYENDO_TABLAS:
                    BuscaObjetos();
                    Estado = ESTADOS_DOCUEMNTACIO.ANALIZANDO;
                    break;
                case ESTADOS_DOCUEMNTACIO.ANALIZANDO:
                    AnalizaSiguiente();
                    break;
            }
        }
        private void BuscaObjetos()
        {
            Controladores_DB.TIPOOBJETO tipo = Controladores_DB.TIPOOBJETO.TABLAX;
            Lista = DB.BuscaObjetos("", tipo);
            cBarraProgreso1.ValorMaximo = Lista.Count;
            cBarraProgreso1.Progreso = 0;
        }
        private void AnalizaSiguiente()
        {
            if (Lista.Count == 0)
            {
                //ya se termino el analisis
                cBarraProgreso1.Texto = "Exportacion terminada";
                TimerDocumentar.Enabled = false;
                BAnalizar.Enabled = true;
                return;
            }
            Objetos.CSysObject obj=Lista[0];
            Lista.RemoveAt(0);
            cBarraProgreso1.Texto = "Analizando: "+obj.Nombre;
            cBarraProgreso1.Progreso++;
            //me traigo la docuemntacion de la tabla
            //veo si existe en la base de datos destino
            Objetos.CSysObject ObjDest;
            List<Objetos.CSysObject> l = DB2.BuscaObjetos(obj.Nombre, obj.TipoObjeto);
            if(l.Count==0)
                return;
            ObjDest = l[0];
            if (ObjDest == null)
                return;
            if (obj.Nombre.ToLower().Trim() != ObjDest.Nombre.ToLower().Trim())
                return;
            //aplico la docuemntacion
            string DescTabla = DB.DaMeDescripcionTabla(obj.Nombre);
            bool documentada = false;
            if (DescTabla.Trim() != "")
            {
                documentada = true;
                DB2.GusrdaDescripcionTabla(ObjDest.Nombre, DescTabla);
            }
            //me traigo los campos de la tabla
            System.Collections.Generic.List<Objetos.CParametro> Campos;
            Campos = DB.DameCamposTabla(obj.Nombre);
            foreach (Objetos.CParametro campo in Campos)
            {
                campo.Descripcion = DB.DameDescripcionCampo(obj.Nombre, campo.nombre);
                if (campo.Descripcion.Trim() != "")
                {
                    try
                    {
                        DB2.GuardaDescripcionCampo(ObjDest.Nombre, campo.nombre, campo.Descripcion);
                        documentada = true;
                    }
                    catch (System.Exception ex)
                    {
                        TablasDocuemntadas.Items.Add(ex.Message);
                    }
                }
            }
            if (documentada == true)
            {
                TablasDocuemntadas.Items.Add(obj.Nombre);
            }

        }

        private void ComboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargo la lista de conexiones
            ComboConexiones.Items.Clear();
            int i, n;
            string[] archivos;
            if (System.IO.Directory.Exists(DirConexionesGrupo) == false)
            {
                System.IO.Directory.CreateDirectory(DirConexionesGrupo);
            }
            archivos = System.IO.Directory.GetFiles(DirConexionesGrupo);
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                System.Windows.Forms.ToolStripMenuItem Submenu = new System.Windows.Forms.ToolStripMenuItem();
                Submenu.Text = QuitaDirectorio(archivos[i]);
                ComboConexiones.Items.Add(Submenu.Text);
            }
        }
        private string DirConexionesGrupo
        {
            get
            {
                if (Grupo == "")
                    return DirConexiones;
                return DirConexiones + "\\" + Grupo;
            }
        }
        private string Grupo
        {
            get
            {
                if (ComboGrupos.SelectedIndex == -1)
                    return "";
                return (string)ComboGrupos.Items[ComboGrupos.SelectedIndex];
            }
            set
            {
                if (ComboGrupos.Items.Count == 0)
                    CargaGrupos();
                int i, n;
                n = ComboGrupos.Items.Count;
                for (i = 0; i < n; i++)
                {
                    string s = (string)ComboGrupos.Items[i];
                    if (s == value)
                    {
                        ComboGrupos.SelectedIndex = i;
                        ComboGrupos_SelectedIndexChanged(null, null);
                        return;
                    }
                }
            }
        }
    }
}