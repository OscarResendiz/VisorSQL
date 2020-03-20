using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormVerTodasLasDependencias : FormBase
     {
        Visor_sql_2015.Objetos.CSysObject ObjetoPrincipal;
        System.Collections.Generic.List<Objetos.CSysObject> Agregados;
        public event OnVerObjetoEvent OnVerObjeto;
        private string Tabla;
        Controladores_DB.IDataBase DB;
        public FormVerTodasLasDependencias(Controladores_DB.IDataBase db, string tabla)
        {
            DB = db;
            Tabla = tabla;
            InitializeComponent();
            Text = "Dependencias de "+Tabla;
            label1.Text = tabla;
            label2.Text = tabla;
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

        private void FormVerTodasLasDependencias_Load(object sender, EventArgs e)
        {
            RBDependende.Checked = true;
        }
        private int IndexImagen(Objetos.CSysObject obj)
        {
            //regresa el indice de la imagen al que depende el objeto
            switch (obj.TipoObjeto )
            {
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE:
                    return 4;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX:
                    return 0;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLASYSTEMA:
                    return 0;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTA:
                    return 5;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTAS_TABLAS:
                    return 0;
            }
            return 6;
        }
        private bool Busca(Objetos.CSysObject obj2)
        {
            int i, n;
            n = Agregados.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CSysObject obj = Agregados[i];
                if (obj.Nombre == obj2.Nombre)
                    return true;
            }
            Agregados.Add(obj2);
            return false;
        }

        private void RBDependende_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void MuestraDependenciasAnterior()
        {
            Agregados = new List<Visor_sql_2015.Objetos.CSysObject>();
            List<Visor_sql_2015.Objetos.CSysObject> l = DB.BuscaObjetos(Tabla, Controladores_DB.TIPOOBJETO.NINGUNO);
            ObjetoPrincipal = l[0];
            treeView1.Nodes.Clear();
            TreeNode nodo = treeView1.Nodes.Add(Tabla);
            nodo.ImageIndex = IndexImagen(ObjetoPrincipal);
            nodo.SelectedImageIndex = IndexImagen(ObjetoPrincipal);
            nodo.StateImageIndex = IndexImagen(ObjetoPrincipal);
            Agregados.Add(ObjetoPrincipal);
            AgregaDependencias(ObjetoPrincipal, nodo);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Progreso.ValorMaximo = 1;
            Progreso.Progreso = 0;
            MuestraDependencias();
//            Progreso.ValorMaximo = 1;
//            Progreso.Progreso = 0;
        }
        private void AgregaDependencias(Objetos.CSysObject Objeto, TreeNode nodo)
        {
            Progreso.Texto = "cargando dependencias de: " + Objeto.Nombre;
            System.Collections.Generic.List<Objetos.CSysObject> lista;
            //si es un SP, y es el objeto principal, muestro sus dependendias
            if (RBDependende.Checked == true)
            {
                if (Objeto.TipoObjeto == Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE)
                    lista = DB.DameDependientesDe(Objeto.Nombre);
                else
                    lista = DB.DameDependencias(Objeto.Nombre);
            }
            else
            {
                if (Objeto.TipoObjeto == Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE)
                    lista = DB.DameDependencias(Objeto.Nombre);
                else
                    lista = DB.DameDependientesDe(Objeto.Nombre);
            }
            int i, n;
            n = lista.Count;
            Progreso.ValorMaximo = Progreso.ValorMaximo + n;
            for (i = 0; i < n; i++)
            {
                Objetos.CSysObject obj = lista[i];
                TreeNode nodo2 = nodo.Nodes.Add(obj.Nombre);
                nodo2.Tag = obj;
                nodo2.ImageIndex = IndexImagen(obj);
                nodo2.SelectedImageIndex = IndexImagen(obj);
                nodo2.StateImageIndex = IndexImagen(obj);
            }
            for (i = 0; i < n; i++)
            {
                Progreso.Progreso++;
                Invalidate();
                Objetos.CSysObject obj = lista[i];
                if (Busca(obj) == false)
                {
                    TreeNode nodo2 = nodo.Nodes[i];
                    AgregaDependencias(obj, nodo2);
                }
            }
        }
        private void MuestraDependencias()
        {
            Agregados = new List<Visor_sql_2015.Objetos.CSysObject>();
            List<Visor_sql_2015.Objetos.CSysObject> l = DB.BuscaObjetos(Tabla, Controladores_DB.TIPOOBJETO.NINGUNO);
            ObjetoPrincipal = l[0];
            treeView1.Nodes.Clear();
            TreeNode nodo = treeView1.Nodes.Add(Tabla);
            nodo.ImageIndex = IndexImagen(ObjetoPrincipal);
            nodo.SelectedImageIndex = IndexImagen(ObjetoPrincipal);
            nodo.StateImageIndex = IndexImagen(ObjetoPrincipal);
            Agregados.Add(ObjetoPrincipal);
            Objetos.CDependencia dep = new Visor_sql_2015.Objetos.CDependencia(nodo, ObjetoPrincipal, DB, RBDependende.Checked);
            dep.OnBusca += new Visor_sql_2015.Objetos.OnBuscaEvent(BuscaEvent);
            dep.OnCantidad += new Visor_sql_2015.Objetos.OnCantidadEvent(CantidadEvent);
            dep.OnFin += new Visor_sql_2015.Objetos.OnFinEvent(FinEvent);
            dep.OnIncremento += new Visor_sql_2015.Objetos.OnBuscaEvent(IncrementoEvent);
            dep.OnBeginBusqueda += new Visor_sql_2015.Objetos.OnFinEvent(BeginBusqueda);
            dep.CargaDependencias();
            //agrego los eventos que requiero
        }
        private bool BuscaEvent(Objetos.CSysObject obj)
        {
            Progreso.Texto = "Buscando: " + obj.Nombre;
            Progreso.Progreso++;
            return Busca(obj);
        }
        private void CantidadEvent(int cantidad)
        {
            if (cantidad > 0)
            {
                Progreso.ValorMaximo = cantidad;// Progreso.ValorMaximo + cantidad;
                Progreso.Progreso = 0;
            }
        }
        private void FinEvent()
        {
            Progreso.Texto = "Carga Terminada";
            Progreso.Progreso = Progreso.ValorMaximo;

        }
        private bool IncrementoEvent(Objetos.CSysObject obj)
        {
            Progreso.Texto = "Cargando: "+obj.Nombre;
            Progreso.Progreso++;
            return true;
        }
        private void BeginBusqueda()
        {
            Progreso.Progreso = 0;
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode c;
            c=treeView1.GetNodeAt(e.X, e.Y);
            if (c == null)
                return;
            treeView1.SelectedNode = c;
        }
    }
}