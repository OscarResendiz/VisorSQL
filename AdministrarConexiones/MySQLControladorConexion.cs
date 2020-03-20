using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Visor_sql_2015.AdministrarConexiones
{
    public partial class MySQLControladorConexion : IControladorConexion
    {
        Controladores_DB.MySqlServer DB;
        public MySQLControladorConexion()
        {
            DB = new Controladores_DB.MySqlServer();
            InitializeComponent();
        }

        private void ComboServidores_DropDown(object sender, EventArgs e)
        {
        }

        private void ComboBases_DropDown(object sender, EventArgs e)
        {
            //hay que buscar los servidores de sql que esten al alcance
            DB.Servidor = ComboServidores.Text;
            DB.User = TUsuario.Text;
            DB.Password = TPassword.Text;
            Cursor = Cursors.WaitCursor;
            List<string> servidores = DB.GetDataBases();
            ComboBases.Items.Clear();
            foreach (string s in servidores)
            {
                ComboBases.Items.Add(s);
            }
            Cursor = Cursors.Default;

        }
        public override string ToString()
        {
            return "MySQL";
        }
        public override void GuardaDatos(FileConecction fc)
        {
            fc.Base = ComboBases.Text;
            fc.Motor = this.ToString();
            fc.Password = TPassword.Text;
            fc.Servidor = ComboServidores.Text;
            fc.Usuario = TUsuario.Text;
        }
        public override bool ValidaDatos()
        {
            bool ok = true;
            if (ComboServidores.Text.Trim() == "")
                ok = false;
            if (TUsuario.Text.Trim() == "")
                ok = false;
            if (TPassword.Text.Trim() == "")
                ok = false;
            if (ComboBases.Text.Trim() == "")
                ok = false;
            return ok;
        }
        public override void CargaDatos(FileConecction fc)
        {
            //extraigo los datos
            ComboBases.Text = fc.Base;
            TPassword.Text = fc.Password;
            ComboServidores.Text = fc.Servidor;
            TUsuario.Text = fc.Usuario;
        }
    }
}
