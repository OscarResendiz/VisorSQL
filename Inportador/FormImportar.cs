using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Inportador
{
    public partial class FormImportar : EditorGenerico// Form
    {
        public event Formularios.OnCodigoEvent OnCodigo;
        CImpBase Importar;
        Controladores_DB.IDataBase DB;
        public FormImportar(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                Importar.Importar();
            }
 
        }
        private void OnActivar(bool ok)
        {
            BImportar.Enabled = ok;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                //es el primer tipo
                Importar = new CImpTextoSeparado(DB);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                //es el primer tipo
                Importar = new CImpTablasSql();// CImpTextoSeparado(DB);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                //es el primer tipo
                Importar = new CImpExell(DB);// CImpTextoSeparado(DB);
            }
            Importar.Parent = panel2;
            Importar.Dock = DockStyle.Fill;
            Importar.OnActivarImportar += new OnActivarImportarEvent(OnActivar);
            Importar.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(MuestraMensage);
        }
        private void MuestraMensage(string Nombrex, string Codigox)
        {
            if (OnCodigo != null)
                OnCodigo(Nombrex, Codigox);
        }
    }
}