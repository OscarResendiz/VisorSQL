using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormTrasar : FormBase
    {
        System.Collections.Generic.List<Objetos.CSysObject> Objetos;
        public event OnListaObjetosEvent OnListaObjetos;
        public event OnVerObjetoEvent OnVerObjeto;
        private string Tabla;
        Controladores_DB.IDataBase DB;
        public FormTrasar(Controladores_DB.IDataBase db, string tabla)
        {
            DB = db;
            Tabla = tabla;
            InitializeComponent();
            Text = "Trasado de "+Tabla;
        }

        private void FormTrasar_Load(object sender, EventArgs e)
        {
            Objetos = new List<Visor_sql_2015.Objetos.CSysObject>();
            TreeNode nodo = treeView1.Nodes.Add("BASE DE DATOS");
            nodo.ImageIndex = 0;
            nodo.SelectedImageIndex = 0;
            nodo.StateImageIndex = 0;
            TreeNode nodo2 = AgregaPadre(Tabla, nodo);
            nodo2.ImageIndex = 2;
            nodo2.SelectedImageIndex = 2;
            nodo2.StateImageIndex = 2;
            AgregaHijos(Tabla, nodo2);
        }
        private TreeNode AgregaPadre(string nombre, TreeNode nodo)
        {
            TreeNode ultimo = nodo;
            System.Collections.Generic.List<Objetos.CSysObject> lista;
            lista=DB.DamePadresDe(nombre);
            int  n;
            n = lista.Count;
            if(n>0)//for (i = 0; i < n; i++)
            {
                Objetos.CSysObject obj=lista[0];
                TreeNode nodo2=AgregaPadre(obj.Nombre,nodo);
                TreeNode nodo3 = nodo2.Nodes.Add(nombre);
                nodo3.ImageIndex = 1;
                nodo3.SelectedImageIndex = 1;
                nodo3.StateImageIndex = 1;
                Objetos.Add(obj);
                return nodo3;
            }
            TreeNode nodo4 = nodo.Nodes.Add(nombre);
            nodo4.ImageIndex = 1;
            nodo4.SelectedImageIndex = 1;
            nodo4.StateImageIndex = 1;
            return nodo4;

        }
        private void AgregaHijos(string nombre,TreeNode nodo)
        {
            System.Collections.Generic.List<Objetos.CSysObject> lista;
            lista = DB.DameHijosDe(nombre);
            int i, n;
            n = lista.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CSysObject obj = lista[i];
                Objetos.Add(obj);
                TreeNode nodo2 = nodo.Nodes.Add(obj.Nombre);
                nodo2.ImageIndex = 3;
                nodo2.SelectedImageIndex = 3;
                nodo2.StateImageIndex = 3;
                AgregaHijos(obj.Nombre, nodo2);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void verTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode nodo = treeView1.SelectedNode;
            if (nodo == null)
                return;
            System.Collections.Generic.List<Objetos.CSysObject> lista;
            lista = DB.BuscaObjetos(nodo.Text, Controladores_DB.TIPOOBJETO.NINGUNO);
            if (lista.Count == 0)
                return;
            Objetos.CSysObject obj = lista[0];
            if (OnVerObjeto != null)
                OnVerObjeto(obj);

        }

        private void verDiagramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnListaObjetos != null)
                OnListaObjetos(Objetos);
        }
    }
}