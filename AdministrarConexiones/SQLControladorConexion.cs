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
    public partial class SQLControladorConexion : IControladorConexion
    {
        Controladores_DB.MSSQLServer DB;
        public SQLControladorConexion()
        {
            DB = new Controladores_DB.MSSQLServer();
            InitializeComponent();
            ComboAutentication.SelectedIndex = 0;
        }
        public override string ToString()
        {
            return "SQL Server";
        }
        private void ComboServidores_DropDown(object sender, EventArgs e)
        {
            //hay que buscar los servidores de sql que esten al alcance
            Cursor = Cursors.WaitCursor;
            List<string> servidores = DB.GetServers();
            ComboServidores.Items.Clear();
            foreach (string s in servidores)
            {
                ComboServidores.Items.Add(s);
            }
            Cursor = Cursors.Default;

        }

        private void ComboAutentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboAutentication.SelectedIndex)
            {
                case 0:
                        //es autenticacion de windows
                    TUsuario.Enabled = false;
                    TPassword.Enabled = false;
                    CHContraseña.Enabled = false;
                    label5.Enabled = false;
                    label4.Enabled = false;
                    break;
                case 1:
                    //es autenticacion de sql
                    TUsuario.Enabled = true;
                    TPassword.Enabled = true;
                    CHContraseña.Enabled = true;
                    label5.Enabled = true;
                    label4.Enabled = true;
                    break;
            }
        }

        private void ComboBases_DropDown(object sender, EventArgs e)
        {
            //hay que traer la lista de bases de datos que hay en el servidor
            Cursor = Cursors.WaitCursor;
            DB.Servidor = ComboServidores.Text;
            DB.User = TUsuario.Text;
            DB.Password = TPassword.Text;
            if (ComboAutentication.SelectedIndex == 0)
                DB.AutenticacionWindows = true;
            else
                DB.AutenticacionWindows = false;
            ComboBases.Items.Clear();
            try
            {
                List<string> bases = DB.GetDataBases();
                foreach (string s in bases)
                {
                    ComboBases.Items.Add(s);
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor = Cursors.Default;
        }
        public override void GuardaDatos(FileConecction fc)
        {
            fc.Base = ComboBases.Text;
            fc.Motor = this.ToString();
            fc.Password = TPassword.Text;
            fc.SalvePassword = CHContraseña.Checked;
            fc.Servidor = ComboServidores.Text;
            fc.Usuario = TUsuario.Text;
            if (ComboAutentication.SelectedIndex == 0)
                fc.WindowsAutentication = true;
            else
                fc.WindowsAutentication = false;
        }
        public override bool ValidaDatos()
        {
            bool ok = true;
            if (ComboServidores.Text.Trim() == "")
                ok = false;
            if (ComboAutentication.SelectedIndex == -1)
                ok = false;
            if (ComboAutentication.SelectedIndex == 1)
            {
                if (TUsuario.Text.Trim() == "")
                    ok = false;
                if (TPassword.Text.Trim() == "")
                    ok = false;
            }
            if (ComboBases.Text.Trim() == "")
                ok = false;
            return ok;
        }
        public override void CargaDatos(FileConecction fc)
        {
            //extraigo los datos
            ComboBases.Text = fc.Base;
            //fc.Motor = this.ToString();
            TPassword.Text = fc.Password;
            CHContraseña.Checked = fc.SalvePassword;
            ComboServidores.Text = fc.Servidor;
            TUsuario.Text = fc.Usuario;
            if(fc.WindowsAutentication )
                ComboAutentication.SelectedIndex = 0;
            else
                ComboAutentication.SelectedIndex = 1;
        }

    }
}
