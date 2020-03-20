using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public delegate void OnListaObjetosEvent(System.Collections.Generic.List<Objetos.CSysObject> lista);
    public partial class FormModelDominio : EditorGenerico//FormBase
    {
        public event OnListaObjetosEvent OnListaObjetosX;
        public event Formularios.OnVerObjetoEvent OnVerObjeto;
        System.Collections.Generic.List<Objetos.CSysObject> Lista;
        System.Collections.Generic.List<Objetos.CSysObject> ListaObjs2;
        Controladores_DB.IDataBase DB;
        public FormModelDominio(Controladores_DB.IDataBase db)
        {
            DB = db;
            ListaObjs2 = new List<Visor_sql_2015.Objetos.CSysObject>();
            InitializeComponent();
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ListaObjetos.Items.Clear();
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
                }
                Lista = DB.BuscaObjetos(TNombre.Text.Trim(), tipo);
                int i, n;
                n = Lista.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CSysObject obj = Lista[i];
                    ListaObjetos.Items.Add(obj);
                }
                LEncontrados.Text = "Elementos Encontrados=" + Lista.Count.ToString();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void ComboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            TNombre_TextChanged(sender, e);
        }

        private void ListaObjetos_DoubleClick(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedIndex == -1)
                return;
            Objetos.CSysObject obj = Lista[ListaObjetos.SelectedIndex];
            if (OnVerObjeto != null)
                OnVerObjeto(obj);
        }

        private void FormModelDominio_Load(object sender, EventArgs e)
        {
            ComboTipos.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ListaObjetos.SelectedIndex == -1)
                ok = false;
            BAgregar.Enabled = ok;
            ok = true;
            if (Lista2.SelectedIndex==-1)
                ok = false;
            BQuitar.Enabled = ok;
            ok=true;
            if (Lista2.Items.Count == 0)
                ok = false;
            BAnalizar.Enabled = ok;
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            //verifico si existe en la lista destido
            int i, n;
            n=ListaObjetos.SelectedIndices.Count;
            for (i = n - 1; i >= 0;i-- )
            {
                int indice=ListaObjetos.SelectedIndices[i];
                Objetos.CSysObject obj2 = (Objetos.CSysObject)ListaObjetos.Items[indice];
                foreach (Objetos.CSysObject obj in Lista2.Items)
                {
                    if (obj.Nombre == obj2.Nombre)
                    {
                        //como ya existe, no lo agrego
                        return;
                    }
                }
                Lista2.Items.Add(ListaObjetos.Items[indice]);
                ListaObjs2.Add(Lista[indice]);
                Lista.RemoveAt(indice);
                ListaObjetos.Items.RemoveAt(indice);
            }
        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            int i, n;
            n = Lista2.SelectedIndices.Count;
            for (i = n - 1; i >= 0; i--)
            {
                int indice = Lista2.SelectedIndices[i];
                Lista.Add(ListaObjs2[indice]);
                ListaObjetos.Items.Add(Lista2.Items[indice]);
                ListaObjs2.RemoveAt(indice);
                Lista2.Items.RemoveAt(indice);
            }            
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
//            Close();
        }

        private void BAnalizar_Click(object sender, EventArgs e)
        {
            if (OnListaObjetosX != null)
                OnListaObjetosX(ListaObjs2);
        }

        private void Lista2_DoubleClick(object sender, EventArgs e)
        {
            if (Lista2.SelectedIndex == -1)
                return;
            Objetos.CSysObject obj = ListaObjs2[Lista2.SelectedIndex];
            if (OnVerObjeto != null)
                OnVerObjeto(obj);
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Objetos.CSysObject obj in Lista)
            {
                if (OnVerObjeto != null)
                    OnVerObjeto(obj);
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Objetos.CSysObject obj in ListaObjs2)
            {
                if (OnVerObjeto != null)
                    OnVerObjeto(obj);
            }

        }
    }
}