using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormBuscarTabla : Form
    {
        private DialogResult resul;
        System.Collections.Generic.List<Objetos.CSysObject> Lista;
        Controladores_DB.IDataBase DB;
        Controladores_DB.TIPOOBJETO Tipo;
        public FormBuscarTabla(Controladores_DB.IDataBase db, Controladores_DB.TIPOOBJETO tipo)
        {
            resul = DialogResult;
            DB = db;
            Tipo = tipo;
            InitializeComponent();
            animatedWaitTextBox1.Edit.KeyPress += new KeyPressEventHandler(Edit_KeyPress);
        }
        void Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (ListaObjetos.Items.Count > 0 && ListaObjetos.SelectedIndex == -1)
                {
                    ListaObjetos.SelectedIndex = 0;
                    if (ListaObjetos.Items.Count == 1)
                    {
                        DialogResult = DialogResult.OK;
                        resul = DialogResult;
                    }
                }
            }
        }
        public string Tabla
        {
            get
            {
                return (string)ListaObjetos.Items[ListaObjetos.SelectedIndex];
            }
        }
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ListaObjetos.Items.Clear();
        //        Lista = DB.BuscaObjetos(TNombre.Text.Trim(), Tipo);
        //        int i, n;
        //        n = Lista.Count;
        //        for (i = 0; i < n; i++)
        //        {
        //            Objetos.CSysObject obj = Lista[i];
        //            ListaObjetos.Items.Add(obj.Nombre);
        //        }
        //        LEncontrados.Text = "Elementos Encontrados=" + Lista.Count.ToString();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ListaObjetos.SelectedIndex == -1 && ListaObjetos.Items.Count != 0)
                ok = false;
            BAceptar.Enabled = ok;
        }
        public string DameInsert(string tabs,string sx)
        {
            //regresa la sintaxis de un insert en una tabla
            Objetos.CSysObject Tabla = Lista[ListaObjetos.SelectedIndex];
            string s = sx+"into " + Tabla.Nombre + "(";
            string s2 = "\r\n" + tabs + "values(";
            System.Collections.Generic.List<Objetos.CParametro> campos;
            campos = DB.DameCamposTabla(Tabla.Nombre);
            bool primero = true;
            foreach (Objetos.CParametro campo in campos)
            {
                if (primero == true)
                {
                    s = s + campo.nombre;
                    primero = false;
                }
                else
                {
                    s = s + "," + campo.nombre;
                    s2 = s2 + ",";
                }
            }
            s = s + ")" + s2 + ")";
            return s;
        }
        public string DameSP( string s2)
        {
            //regresa la sintaxis de una llamada a un SP
            Objetos.CSysObject Tabla = Lista[ListaObjetos.SelectedIndex];
            string s = s2 + Tabla.Nombre + " ";
            System.Collections.Generic.List<Objetos.CParametro> campos;
            campos = DB.DameParametrosDeProcedimiento(Tabla.Nombre);
            bool primero = true;
            foreach (Objetos.CParametro campo in campos)
            {
                if (primero == true)
                {
                    s = s + campo.nombre;
                    primero = false;
                }
                else
                {
                    s = s + "," + campo.nombre;
                }
            }
            return s;
        }
        public Objetos.CSysObject DameObjeto()
        {
            return Lista[ListaObjetos.SelectedIndex];
        }
        private void ListaObjetos_DoubleClick(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedIndex != -1)
            {
                DialogResult = DialogResult.OK;
                resul = DialogResult;
                Close();
                return;
            }
        }
        private void animatedWaitTextBox1_EsperaCompletada(string Texto, int Decimas)
        {
            try
            {
                ListaObjetos.Items.Clear();
                Lista = DB.BuscaObjetos(Texto.Trim(), Tipo);
                int i, n;
                n = Lista.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CSysObject obj = Lista[i];
                    ListaObjetos.Items.Add(obj.Nombre);
                }
                LEncontrados.Text = "Elementos Encontrados=" + Lista.Count.ToString();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void FormBuscarTabla_Shown(object sender, EventArgs e)
        {
            animatedWaitTextBox1.Edit.Focus();
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            resul = DialogResult;
        }
        private void formOpacador1_OnVisible(bool visible)
        {

        }

        private void FormBuscarTabla_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult=resul;
        }

    }
}
