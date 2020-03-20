using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormFK : FormBase
    {
        Controladores_DB.IDataBase DB;
        public FormFK(Controladores_DB.IDataBase db, string nombre)
        {
            DB = db;
            InitializeComponent();
            Text = nombre;
        }

        private void FormFK_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Objetos.CCampoFK> lista;
            lista=DB.DameLLaveForanea(Text);
            foreach (Objetos.CCampoFK obj in lista)
            {
                TTablaPrimaria.Text = obj.maestra;
                TTablaExterna.Text = obj.hija;
                CamposPrimaria.Items.Add(obj.columnaMaestra);
                CamposExternos.Items.Add(obj.columnahija);
            }
        }
    }
}