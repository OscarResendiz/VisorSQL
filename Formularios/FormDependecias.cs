using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public delegate void OnVerObjetoEvent(Objetos.CSysObject obj);
    public partial class FormDependecias : FormBase
    {
        bool Dependencias;
        public event OnVerObjetoEvent OnVerObjeto;
        System.Collections.Generic.List<Objetos.CSysObject> Lista;
        private string fnombre;
        Controladores_DB.IDataBase DB;
        public FormDependecias(Controladores_DB.IDataBase db, string titulo, string Nombre, bool dependencias)
        {
            Dependencias = dependencias;
            DB = db;
            InitializeComponent();
            Text = titulo;
            fnombre=Nombre;
        }

        private void FormDependecias_Load(object sender, EventArgs e)
        {
            if (Dependencias == true)
                Lista = DB.DameDependencias(fnombre);
            else
                Lista = DB.DameDependientesDe(fnombre);
            listBox1.Items.Clear();
            int i, n;
            n = Lista.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CSysObject obj=Lista[i];
                listBox1.Items.Add(obj.Nombre);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex==-1)
                return;
              Objetos.CSysObject obj=Lista[listBox1.SelectedIndex];
              if (OnVerObjeto != null)
                  OnVerObjeto(obj);
        }
    }
}