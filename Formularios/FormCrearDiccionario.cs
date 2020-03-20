using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Visor_sql_2015.Formularios
{
    public partial class FormCrearDiccionario : FormBase
    {
        //System.Collections.Generic.List<Objetos.CSysObject> Lista;
        Controladores_DB.IDataBase DB;
        public FormCrearDiccionario(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
        }
        private void MuestraTablas()
        {
            try
            {
                ListaObjetos.Items.Clear();
                Controladores_DB.TIPOOBJETO tipo = Controladores_DB.TIPOOBJETO.VISTAS_TABLAS;
               List<Objetos.CSysObject>  Lista = DB.BuscaObjetos(TNombre.Text, tipo);
                foreach(Objetos.CSysObject obj in Lista)
                {
                    bool encontrado=false;
                    foreach(Objetos.CSysObject obj2 in ListaObjetosDestino.Items)
                    {
                        if(obj.Nombre==obj2.Nombre)
                        {
                            encontrado=true;
                            break;
                        }
                    }
                    if(encontrado==false)
                    {
                        ListaObjetos.Items.Add(obj);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void BAgregarTodo_Click(object sender, EventArgs e)
        {
            foreach(Objetos.CSysObject obj in ListaObjetos.Items)
            {
                bool encontado=false;
                foreach(Objetos.CSysObject obj2 in ListaObjetosDestino.Items)
                {
                    if(obj.Nombre==obj2.Nombre)
                    {
                        encontado=true;
                        break;
                    }
                }
                if(encontado==false)
                    ListaObjetosDestino.Items.Add(obj);
            }
            ListaObjetos.Items.Clear();
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedIndex == -1)
                return;
            ListaObjetosDestino.Items.Add(ListaObjetos.Items[ListaObjetos.SelectedIndex]);
            ListaObjetos.Items.RemoveAt(ListaObjetos.SelectedIndex);
        }

        private void BQuitarTodo_Click(object sender, EventArgs e)
        {
            int i, n;
            n = ListaObjetosDestino.Items.Count;
            for (i = 0; i < n; i++)
            {
                ListaObjetos.Items.Add(ListaObjetosDestino.Items[i]);
            }
            ListaObjetosDestino.Items.Clear();
        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            if (ListaObjetosDestino.SelectedIndex == -1)
                return;
            ListaObjetos.Items.Add(ListaObjetosDestino.Items[ListaObjetosDestino.SelectedIndex]);
            ListaObjetosDestino.Items.RemoveAt(ListaObjetosDestino.SelectedIndex);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok=true;
            if (ListaObjetos.Items.Count == 0)
                ok=false;
                BAgregarTodo.Enabled = ok;
            ok = true;
            if (ListaObjetos.SelectedIndex == -1)
                ok = false;
            BAgregar.Enabled = ok;
            ok = true;
            if (ListaObjetosDestino.Items.Count == 0)
                ok = false;
            BQuitarTodo.Enabled = ok;
            ok = true;
            if (ListaObjetosDestino.SelectedIndex == -1)
                ok = false;
            BQuitar.Enabled = ok;
            ok = true;
            if(TArchivo.Text.Trim()=="")
                ok=false;
            if (ListaObjetosDestino.Items.Count == 0)
                ok = false;
            BCrear.Enabled = ok;
       }

        private void FormCrearDiccionario_Load(object sender, EventArgs e)
        {
            MuestraTablas();
        }

        private void BNavegar_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            TArchivo.Text = saveFileDialog1.FileName;
        }

        private void BCrear_Click(object sender, EventArgs e)
        {
            int[] data = new int[] { 12, 123, 3, 7 };

            string strConnnectionOle = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            @"Data Source=" + TArchivo.Text + ";" +
            @"Extended Properties=" + '"' + "Excel 8.0;HDR=NO" + '"';
            OleDbConnection oleConn = new OleDbConnection(strConnnectionOle);
            oleConn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = oleConn;
            //creo la primer hoja que es la que contiene las tablas de la base de datos
            cmd.CommandText = "create table TABLAS(Tablas char(10))";
            cmd.ExecuteNonQuery();
            //recorro la lista de tablas y las voy agregando una por una 
            int i, n;
            n = ListaObjetosDestino.Items.Count;
            for (i = 0; i < n; i++)
            {
                string tabla=ListaObjetosDestino.Items[i].ToString();
                cmd.CommandText = "UPDATE [TABLAS$A" + (i + 1).ToString() + ":A" + (i + 1).ToString() + "] SET F1=" + "\'"+tabla+"\'";
                cmd.ExecuteNonQuery();
                //obtengo la descripcion de la tabla
                string s = DB.DaMeDescripcionTabla(tabla);
                cmd.CommandText = "UPDATE [TABLAS$B" + (i + 1).ToString() + ":B" + (i + 1).ToString() + "] SET F1=" + "\'" + s + "\'";
                cmd.ExecuteNonQuery();
            }
            //ahora recorro cada una de las tablas para crear su hoja de especificacines
            for (i = 0; i < n; i++)
            {
                string tabla = ListaObjetosDestino.Items[i].ToString();
                    CreaHojaTabla(cmd, tabla);
            }
            oleConn.Close();
            System.Windows.Forms.MessageBox.Show("El archivo se ha creado satisfactoriamente");

        }
        private void CreaHojaTabla(OleDbCommand cmd, string tabla)
        {
            string tabla2="";
            if (tabla.Length > 30)
                tabla2=tabla.Substring(0, 30);
            else
                tabla2=tabla;
            cmd.CommandText = "create table " + tabla2 + "(Nombre char(10))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE [" + tabla2 + "$A1:A1] SET F1=" + "\'Nombre del campo \'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE [" + tabla2 + "$B1:B1] SET F1=" + "\'Tipo \'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE [" + tabla2 + "$C1:C1] SET F1=" + "\'Longitud\'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE [" + tabla2 + "$D1:D1] SET F1=" + "\'Acepta nulos \'";
            cmd.ExecuteNonQuery();
            //me traigo los campos de la tabla
            System.Collections.Generic.List<Objetos.CParametro> Campos = DB.DameCamposTabla(tabla);
            int i, n;
            n = Campos.Count;
            for (i = 0; i < n; i++)
            {
                int pos=i+2;
                //agrego los datos de los campos
                Objetos.CParametro obj=Campos[i];
                cmd.CommandText = "UPDATE [" + tabla2 + "$A" + pos.ToString() + ":A" + pos.ToString() + "] SET F1=" + "\'" + obj.nombre + "\'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE [" + tabla2 + "$B"+pos.ToString()+":B"+pos.ToString()+"] SET F1=" + "\'"+obj.tipo+" \'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE [" + tabla2 + "$C" + pos.ToString() + ":C" + pos.ToString() + "] SET F1=" + "\'" + obj.Logitud+ " \'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE [" + tabla2 + "$D" + pos.ToString() + ":D" + pos.ToString() + "] SET F1=" + "\'" + obj.NULOS + " \'";
                cmd.ExecuteNonQuery();
            }
        }
        public override void Guardar()
        {
            BCrear_Click(null, null);
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            MuestraTablas();
        }
    }
}