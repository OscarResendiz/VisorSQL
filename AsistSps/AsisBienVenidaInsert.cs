using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public partial class AsisBienVenidaInsert : Visor_sql_2015.AsistSps.AsistBaseSP
    {
        Controladores_DB.IDataBase DB;
        public AsisBienVenidaInsert(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
            EnableAnterior(false);
            EnableSiguiente(true);
            AsignaValor("Tipo", "Escritura");
        }
        public override void BSiguiente()
        {
            if (Siguiente == null)
            {
                Siguiente = new AsisSelTabla(DB);
                Siguiente.Anterior = this;
            }
            OnInstalame(Siguiente);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible == false)
                return;
            EnableSiguiente(true);
            EnableAnterior(false);
        }
        public string NombreTabla
        {
            set
            {
                AsignaValor("Tabla", value);
            }
        }
    }
}

