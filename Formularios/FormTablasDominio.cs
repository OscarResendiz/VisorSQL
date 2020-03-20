using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormTablasDominio : FormBase
    {
        public event OnVerObjetoEvent OnVerObjeto;
        string Tabla;
        Controladores_DB.IDataBase DB;
        System.Collections.Generic.List<Objetos.CSysObject> Lista;
        //System.Collections.Generic.List<string> Lista2;
        private Objetos.CSysObject Obj;
        public FormTablasDominio(Controladores_DB.IDataBase db, System.Collections.Generic.List<Objetos.CSysObject> lista)
        {
            DB = db;
            Lista = new List<Visor_sql_2015.Objetos.CSysObject>();
            foreach (Objetos.CSysObject obj in lista)
                Lista.Add(obj);
            InitializeComponent();
            cBarraProgreso1.ValorMaximo = Lista.Count;
        }
        private bool Exiete(string s)
        {
            foreach (Objetos.CSysObject s2 in Lista)
            {
                if (s== s2.Nombre)
                    return true;
            }
            return false;
        }
        private void AgregaAlaLista(string s)
        {
            int i, n;
            n = listView1.Items.Count;
            for(i=0;i<n;i++)
            {
                string s2=listView1.Items[i].Text;
                if (s2 == s)
                {
                    return;
                }
            }
            listView1.Items.Add(s, 0);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Lista.Count == 0)
            {
                timer1.Enabled = false;
                cBarraProgreso1.Texto = "Analisis terminado";
                return;
            }
            try
            {
                cBarraProgreso1.Progreso++;
            }
            catch (System.Exception)
            {
                cBarraProgreso1.Progreso=1;
            }
            //me traigo el primer Item
            Obj=Lista[0];
            Lista.RemoveAt(0);
            if (Obj.TipoObjeto == Controladores_DB.TIPOOBJETO.TABLAX)
            {
                listView1.Items.Add(Obj.Nombre, 0);
            }
            else
            {
                cBarraProgreso1.Texto = "Extrayendo dependencias de: " + Obj.Nombre;
                System.Collections.Generic.List<Objetos.CSysObject> l;
                if (Obj.TipoObjeto == Controladores_DB.TIPOOBJETO.STOREPROCERURE)
                    l = DB.DameDependencias(Obj.Nombre);
                else
                    l = DB.DameDependientesDe(Obj.Nombre);
                foreach (Objetos.CSysObject obj in l)
                {
                    if (obj.TipoObjeto == Controladores_DB.TIPOOBJETO.TABLAX)
                    {
                        AgregaAlaLista(obj.Nombre);
                    }
                    else
                    {
                        if (Exiete(obj.Nombre) == false)
                        {
                            Lista.Add(obj);
                            cBarraProgreso1.ValorMaximo++;
                        }
                    }
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (Tabla == null)
                return;
            System.Collections.Generic.List<Objetos.CSysObject> lista;
            lista = DB.BuscaObjetos(Tabla, Controladores_DB.TIPOOBJETO.NINGUNO);
            if (lista.Count == 0)
                return;
            Objetos.CSysObject obj = lista[0];
            if (OnVerObjeto != null)
                OnVerObjeto(obj);
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                Tabla = null;
            }
            else
            {
                Tabla = item.Text;
            }
        }

        private void FormTablasDominio_Load(object sender, EventArgs e)
        {

        }
    }
}