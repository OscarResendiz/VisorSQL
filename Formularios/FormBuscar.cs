using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormBuscar : FormBase
    {
        public event OnVerObjetoEvent OnVerObjeto;
        System.Collections.Generic.List<Objetos.CSysObject> Lista;
        Controladores_DB.IDataBase DB;
        public FormBuscar(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
        }

        private void FormBuscar_Load(object sender, EventArgs e)
        {
            ComboTipos.SelectedIndex = 0;
        }

        //private void TNombre_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ListaObjetos.Nodes.Clear();
        //        Controladores_DB.TIPOOBJETO tipo = Controladores_DB.TIPOOBJETO.NINGUNO;
        //        switch (ComboTipos.SelectedIndex)
        //        {
        //            case 0:
        //                tipo = Controladores_DB.TIPOOBJETO.NINGUNO;
        //                break;
        //            case 1:
        //                tipo = Controladores_DB.TIPOOBJETO.TABLAX;
        //                break;
        //            case 2:
        //                tipo = Controladores_DB.TIPOOBJETO.VISTA;
        //                break;
        //            case 3:
        //                tipo = Controladores_DB.TIPOOBJETO.STOREPROCERURE;
        //                break;
        //            case 4:
        //                tipo = Controladores_DB.TIPOOBJETO.EN_CODIGO;
        //                break;
        //            case 5:
        //                tipo = Controladores_DB.TIPOOBJETO.VISTAS_TABLAS;
        //                break;
        //            case 6:
        //                tipo = Visor_sql_2015.Controladores_DB.TIPOOBJETO.CAMPOS_TABLA;
        //                break;
        //        }
        //        Lista = DB.BuscaObjetos(TNombre.Text.Trim(), tipo);
        //        int i, n;
        //        n = Lista.Count;
        //        for (i = 0; i < n; i++)
        //        {
        //            Objetos.CSysObject obj = Lista[i];
        //            Objetos.CNodoBuscar nodo=new Objetos.CNodoBuscar();
        //            nodo.Text=obj.Nombre;
        //            nodo.Tipo=obj.Tipo;
        //            nodo.Tag = obj;
        //            ListaObjetos.Nodes.Add(nodo);
        //        }
        //        LEncontrados.Text = "Elementos Encontrados=" + Lista.Count.ToString();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }
        //}

        private void ComboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            animatedWaitTextBox1_EsperaCompletada(animatedWaitTextBox1.Text, 0);
        }
        public Objetos.CSysObject Objeto
        {
            get
            {
                Objetos.CNodoBuscar nodo=(Objetos.CNodoBuscar)ListaObjetos.SelectedNode;
                Objetos.CSysObject obj = (Objetos.CSysObject)nodo.Tag;
                return obj ;
            }
        }

        private void ListaObjetos_DoubleClick(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode ==null)
                return;
            Objetos.CNodoBuscar nodo = (Objetos.CNodoBuscar)ListaObjetos.SelectedNode;
            Objetos.CSysObject obj = (Objetos.CSysObject)nodo.Tag;
            if (OnVerObjeto != null)
                OnVerObjeto(obj);

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListaObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public override void Guardar()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText(saveFileDialog1.FileName);
            foreach(Objetos.CSysObject obj in Lista)
            {
                sw.WriteLine(obj.Nombre);
            }
            sw.Close();
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Objetos.CSysObject obj in Lista)
            {
                if (OnVerObjeto != null)
                    OnVerObjeto(obj);
            }

        }

        private void FormBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void animatedWaitTextBox1_EsperaCompletada(string Texto, int Decimas)
        {
            try
            {
                ListaObjetos.Nodes.Clear();
                Controladores_DB.TIPOOBJETO tipo = Controladores_DB.TIPOOBJETO.NINGUNO;
                switch (ComboTipos.SelectedIndex)
                {
                    case 0:
                        tipo = Controladores_DB.TIPOOBJETO.NINGUNO;
                        break;
                    case 1:
                        tipo = Controladores_DB.TIPOOBJETO.TABLAX;
                        break;
                    case 2:
                        tipo = Controladores_DB.TIPOOBJETO.VISTA;
                        break;
                    case 3:
                        tipo = Controladores_DB.TIPOOBJETO.STOREPROCERURE;
                        break;
                    case 4:
                        tipo = Controladores_DB.TIPOOBJETO.EN_CODIGO;
                        break;
                    case 5:
                        tipo = Controladores_DB.TIPOOBJETO.VISTAS_TABLAS;
                        break;
                    case 6:
                        tipo = Visor_sql_2015.Controladores_DB.TIPOOBJETO.CAMPOS_TABLA;
                        break;
                }
                Lista = DB.BuscaObjetos(Texto.Trim(), tipo);
                int i, n;
                n = Lista.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CSysObject obj = Lista[i];
                    Objetos.CNodoBuscar nodo = new Objetos.CNodoBuscar();
                    nodo.Text = obj.Nombre;
                    nodo.Tipo = obj.TipoObjeto;
                    nodo.Tag = obj;
                    ListaObjetos.Nodes.Add(nodo);
                }
                LEncontrados.Text = "Elementos Encontrados=" + Lista.Count.ToString();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}