using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AdministrarConexiones
{
    public partial class FormConexion :Formularios.FormBase
    {
        private List<IControladorConexion> Motores;
        private string Grupo;
        IControladorConexion ControladorActual = null;
        public FormConexion(string grupo)
        {
            Grupo = grupo;
            Motores = new List<IControladorConexion>();
            InitializeComponent();
        }

        private void BConexion_Click(object sender, EventArgs e)
        {
            dialogConecSQL20051.ConnectionString = TConexion.Text;
            if (dialogConecSQL20051.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            TConexion.Text=dialogConecSQL20051.ConnectionString;
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
                if (Grupo == "")
                    return s + "\\CONEXIONES";
                return s + "\\CONEXIONES\\" + Grupo;
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (ControladorActual == null)
            {
                return;
            }
            if (System.IO.Directory.Exists(DirConexiones) == false)
            {
                //crea el directorio
                System.IO.Directory.CreateDirectory(DirConexiones);
            }
            FileConecction fc = new FileConecction();
            fc.Nombre = TNombre.Text;
            ControladorActual.GuardaDatos(fc);
            fc.WriteFile(this.DirConexiones);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            if (ControladorActual == null)
            {
                ok = false;
            }
            else
            {
                if (ControladorActual.ValidaDatos() == false)
                    ok = false;
            }
            BAceptar.Enabled = ok;
        }
        private void SeleccionaControlador(string con)
        {
            CargaMotores();
            int i, n;
            n = ComboMotor.Items.Count;
            for (i = 0; i < n; i++)
            {
                string s = ComboMotor.Items[i].ToString();
                if (s == con)
                {
                    ComboMotor.SelectedIndex = i;
                    ControladorActual=Motores[i];
                    return;
                }
            }
        }
        public string ConnectionString
        {
            get
            {
                return TConexion.Text;
            }
            set
            {
                TConexion.Text = value;
            }
        }

        private void FormConexion_Load(object sender, EventArgs e)
        {
            CargaMotores();
        }
        private void AddMotor(IControladorConexion obj)
        {
            ComboMotor.Items.Add(obj.ToString());
            Motores.Add(obj);
        }
        private void CargaMotores()
        {
            if (ComboMotor.Items.Count > 0)
            {
                return;
            }
            //se trae la lista de motores instalados en el sistema
            AddMotor(new SQLControladorConexion());
            AddMotor(new MySQLControladorConexion());
            
        }

        private void ComboMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboMotor.SelectedIndex == -1)
                return;
            IControladorConexion obj = Motores[ComboMotor.SelectedIndex];
            Contenedor.Controls.Clear();
            Height = obj.Height + panel2.Height + panel1.Height;
            obj.Parent = Contenedor;
            obj.Visible = true;
            ControladorActual = obj;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {

        }
        public string Nombre
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text = value;
                //hay que cargar el archivo
                FileConecction fc = new FileConecction();
                fc.Nombre = value;
                fc.LoadFile(DirConexiones);
                //Activo el controlador
                SeleccionaControlador(fc.Motor);
                if (ControladorActual != null)
                {
                    ControladorActual.CargaDatos(fc);
                }
            }
        }
    }
}