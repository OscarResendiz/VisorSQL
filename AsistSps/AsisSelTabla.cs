using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public partial class AsisSelTabla : Visor_sql_2015.AsistSps.AsistBaseSP
    {
        private Controladores_DB.IDataBase DB;
        public AsisSelTabla(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent(); 

        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            Formularios.FormBuscarTabla dlg = new Visor_sql_2015.Formularios.FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            TTabla.Text = dlg.Tabla;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (Visible == false)
                return;
            if (TTabla.Text.Trim() == "")
                ok = false;
            EnableSiguiente(ok);
            EnableAnterior(true);
        }

        private void BCrear_Click(object sender, EventArgs e)
        {
            CrearTablas.FormCrearTabla dlg = new Visor_sql_2015.CrearTablas.FormCrearTabla(DB);
            dlg.ShowDialog();
            TTabla.Text = dlg.NombreTabla;
        }
        public override void BSiguiente()
        {
            //agrego elnombre
            AsignaValor("Tabla", TTabla.Text);
            if (Siguiente == null)
            {
                Siguiente = new AsisNombreSP(DB);
                Siguiente.Anterior = this;
            }
            OnInstalame(Siguiente);
        }
        public override void Inicializate()
        {
            string s;
            try
            {
                s = (string )DameValor("Tabla");
            }
            catch (System.Exception)
            {
                return;
            }
            TTabla.Text = s;
        }
    }
}


