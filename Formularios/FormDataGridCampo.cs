using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormDataGridCampo : FormBase
    {
        private DialogResult result;
        public FormDataGridCampo()
        {
            InitializeComponent();
            result = DialogResult;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            if(TDescripcion.Text.Trim()=="")
                ok=false;
            if(TTamaño.Text.Trim()=="")
                ok=false;
            BAceptar.Enabled=ok;
        }

        private void TTamaño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        public string Campo
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
        public string Descripcion
        {
            get
            {
                return TDescripcion.Text;
            }
            set
            {
                TDescripcion.Text=value;
            }
        }
        public int Tamaño
        {
            get
            {
                return int.Parse(TTamaño.Text);
            }
            set
            {
                TTamaño.Text = value.ToString();
            }
        }

        private void FormDataGridCampo_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult=result ;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
        }

    }
}