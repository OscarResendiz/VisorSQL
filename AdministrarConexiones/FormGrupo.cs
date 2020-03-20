using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AdministrarConexiones
{
    public partial class FormGrupo : Form
    {
        private DialogResult res;
        public FormGrupo()
        {
            InitializeComponent();
            res = DialogResult;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok=true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            BAceptar.Enabled = ok;
        }
        public string NombreGrupo
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text = value;
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            res = DialogResult.OK;

        }

        private void FormGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = res;
        }
    }
}
