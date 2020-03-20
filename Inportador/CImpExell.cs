using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.OleDb;

namespace Visor_sql_2015.Inportador
{
    public partial class CImpExell : Visor_sql_2015.Inportador.CImpBase
    {
        int subidos;
        int status;
        private List<string> Comandos;
        private string Errores;
        int row;
        Controladores_DB.IDataBase DB;
        Microsoft.Office.Interop.Excel._Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlLibro;
        Microsoft.Office.Interop.Excel.Sheets xlHojas;
        Microsoft.Office.Interop.Excel._Worksheet Hoja;
        List<Microsoft.Office.Interop.Excel._Worksheet> Hojas;
        List<FilaXLS> Tabla= new List<FilaXLS>();
        public CImpExell(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
        }

        private void BBuacar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            TArchivo.Text = openFileDialog1.FileName;
            BProgreso.Texto = "Leyendo información del archivo";
            //extraigo las hojas que contiene el archivo
            string fileName = TArchivo.Text;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;
            xlLibro = xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            Hojas = new List<Microsoft.Office.Interop.Excel._Worksheet>();
            foreach (Microsoft.Office.Interop.Excel._Worksheet h in xlHojas)
            {
                hojas.Items.Add(h.Name);
                Hojas.Add(h);
            }
            //cierro el archivo de exel
        }

        private void hojas_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool nullrow = false;
            row = 0;
            Hoja = Hojas[hojas.SelectedIndex];
            //ya tengo abierto el archivo de exel
            //ahora intento estraer los registro de la hoja
            while (!nullrow)
            {
                nullrow = true;
                row++;
                FilaXLS obj = new FilaXLS();
                for (int col = 0; col <= 100; col++)
                {
                    CColumna cc = new CColumna();
                    string cell;
                    char cy = ' ';
                    char cx = ((char)(65 + col)).ToString()[0];
                    if (cx > 'Z')
                    {
                        cy = (char)(64 + (int)col / (int)26);
                        cx = (char)((int)cx - (int)'Z' + 64);
                    }
                    cell = cy.ToString().Trim() + cx.ToString();
                    cell += row;
                    try
                    {
                        cc.Columna = cell;
                        cc.x = cx.ToString();
                        cc.y = cy.ToString();
                        cell = (string)Hoja.get_Range(cell, cell).Text;
                    }
                    catch (System.Exception)
                    {
                        break;
                    }
                    if (cell != "")
                    {
                        try
                        {
                            cc.Nombre = cell;
                            ListaCamposOrigen.Items.Add(cc);
                            obj.v[col] = cell;
                            nullrow = false;
                        }
                        catch (Exception)
                        {
                            obj.v[col - 1] = "";
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                //if (!nullrow)
                //{
                //    ListaCeldas.Items.Add(cell);
                //}
                //nullrow = false;
            }
        }

        private void BAgregarOrigen_Click(object sender, EventArgs e)
        {
            if (ListaCamposOrigen.SelectedItems.Count == 0)
                return;
            int i, n;
            n = ListaCamposOrigen.SelectedItems.Count;
            for (i = 0; i < n; i++)
            {
                ListaCamposOrigen2.Items.Add(ListaCamposOrigen.SelectedItems[i]);
            }
            //loe elimino de la lista
            for (i = n - 1; i >= 0; i--)
            {
                ListaCamposOrigen.Items.Remove(ListaCamposOrigen.SelectedItems[i]);
            }
        }

        private void BSubirOrigen_Click(object sender, EventArgs e)
        {
            if (ListaCamposOrigen2.SelectedIndex <= 0)
                return;
            int si = ListaCamposOrigen2.SelectedIndex;
            Objetos.CParametro s = (Objetos.CParametro)ListaCamposOrigen2.Items[ListaCamposOrigen2.SelectedIndex];
            ListaCamposOrigen2.Items.Insert(ListaCamposOrigen2.SelectedIndex - 1, s);
            ListaCamposOrigen2.Items.RemoveAt(ListaCamposOrigen2.SelectedIndex);
            ListaCamposOrigen2.SelectedIndex = si - 1;

        }

        private void BQuitarOrigen_Click(object sender, EventArgs e)
        {
            //if (ListaCamposOrigen2.SelectedIndex == -1)
            //    return;
            //ListaCamposOrigen.Items.Add(ListaCamposOrigen2.Items[ListaCamposOrigen2.SelectedIndex]);
            //ListaCamposOrigen2.Items.RemoveAt(ListaCamposOrigen2.SelectedIndex);
            //--------------------------------------------
            if (ListaCamposOrigen2.SelectedItems.Count == 0)
                return;
            int i, n;
            n = ListaCamposOrigen2.SelectedItems.Count;
            for (i = 0; i < n; i++)
            {
                ListaCamposOrigen.Items.Add(ListaCamposOrigen2.SelectedItems[i]);
            }
            //loe elimino de la lista
            for (i = n - 1; i >= 0; i--)
            {
                ListaCamposOrigen2.Items.Remove(ListaCamposOrigen2.SelectedItems[i]);
            }

        }

        private void BBajarOrigen_Click(object sender, EventArgs e)
        {
            if (ListaCamposOrigen2.SelectedIndex >= ListaCamposOrigen2.Items.Count - 1)
                return;
            int si = ListaCamposOrigen2.SelectedIndex;
            Objetos.CParametro s = (Objetos.CParametro)ListaCamposOrigen2.Items[ListaCamposOrigen2.SelectedIndex];
            ListaCamposOrigen2.Items.Insert(ListaCamposOrigen2.SelectedIndex + 2, s);
            ListaCamposOrigen2.Items.RemoveAt(ListaCamposOrigen2.SelectedIndex);
            ListaCamposOrigen2.SelectedIndex = si + 1;

        }

        private void BSubirDestino_Click(object sender, EventArgs e)
        {
            if (ListaCamposDestino2.SelectedIndex <= 0)
                return;
            int si = ListaCamposDestino2.SelectedIndex;
            Objetos.CParametro s = (Objetos.CParametro)ListaCamposDestino2.Items[ListaCamposDestino2.SelectedIndex];
            ListaCamposDestino2.Items.Insert(ListaCamposDestino2.SelectedIndex - 1, s);
            ListaCamposDestino2.Items.RemoveAt(ListaCamposDestino2.SelectedIndex);
            ListaCamposDestino2.SelectedIndex = si - 1;

        }

        private void BAgregarDestino_Click(object sender, EventArgs e)
        {
            //if (ListaCamposDestino.SelectedIndex == -1)
            //    return;
            //ListaCamposDestino2.Items.Add(ListaCamposDestino.Items[ListaCamposDestino.SelectedIndex]);
            //ListaCamposDestino.Items.RemoveAt(ListaCamposDestino.SelectedIndex);
            ////----------------------------------------
            if (ListaCamposDestino.SelectedItems.Count == 0)
                return;
            int i, n;
            n = ListaCamposDestino.SelectedItems.Count;
            for (i = 0; i < n; i++)
            {
                ListaCamposDestino2.Items.Add(ListaCamposDestino.SelectedItems[i]);
            }
            //loe elimino de la lista
            for (i = n - 1; i >= 0; i--)
            {
                ListaCamposDestino.Items.Remove(ListaCamposDestino.SelectedItems[i]);
            }


        }

        private void BQuitarDestino_Click(object sender, EventArgs e)
        {
            //if (ListaCamposDestino2.SelectedIndex == -1)
            //    return;
            //ListaCamposDestino.Items.Add(ListaCamposDestino2.Items[ListaCamposDestino2.SelectedIndex]);
            //ListaCamposDestino2.Items.RemoveAt(ListaCamposDestino2.SelectedIndex);
            ////-----------------------------------
            if (ListaCamposDestino2.SelectedItems.Count == 0)
                return;
            int i, n;
            n = ListaCamposDestino2.SelectedItems.Count;
            for (i = 0; i < n; i++)
            {
                ListaCamposDestino.Items.Add(ListaCamposDestino2.SelectedItems[i]);
            }
            //loe elimino de la lista
            for (i = n - 1; i >= 0; i--)
            {
                ListaCamposDestino2.Items.Remove(ListaCamposDestino2.SelectedItems[i]);
            }

        }

        private void BBajarDestino_Click(object sender, EventArgs e)
        {
            if (ListaCamposDestino2.SelectedIndex >= ListaCamposDestino2.Items.Count - 1)
                return;
            int si = ListaCamposDestino2.SelectedIndex;
            Objetos.CParametro s = (Objetos.CParametro)ListaCamposDestino2.Items[ListaCamposDestino2.SelectedIndex];
            ListaCamposDestino2.Items.Insert(ListaCamposDestino2.SelectedIndex + 2, s);
            ListaCamposDestino2.Items.RemoveAt(ListaCamposDestino2.SelectedIndex);
            ListaCamposDestino2.SelectedIndex = si + 1;

        }

        private void BBUscarTablaDestino_Click(object sender, EventArgs e)
        {
            Formularios.FormBuscarTabla dlg = new Formularios.FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            ListaCamposDestino2.Items.Clear();
            ListaCamposDestino.Items.Clear();
            TTablaDestino.Text = dlg.Tabla;
            List<Objetos.CParametro> campos;
            campos = DB.DameCamposTabla(dlg.Tabla);
            foreach (Objetos.CParametro obj in campos)
            {
                ListaCamposDestino.Items.Add(obj);
            }
        }
        //private void LeerLinea()
        //{
        //    bool nullrow = true;
        //    row++;
        //    FilaXLS obj = new FilaXLS();
        //    //recorre todos los campos
        //    for (int col = 0; col < ListaCamposOrigen2.Items.Count; col++)
        //    {
        //        CColumna cc = (CColumna)ListaCamposOrigen2.Items[col];
        //        string cell;
        //        char cy = ' ';
        //        char cx = ((char)(65 + col)).ToString()[0];
        //        if (cx > 'Z')
        //        {
        //            cy = (char)(64 + (int)col / (int)26);
        //            cx = (char)((int)cx - (int)'Z' + 64);
        //        }
        //        cell = cy.ToString().Trim() + cx.ToString();
        //        cell += row;
        //        try
        //        {
        //            cc.Columna = cell;
        //            if (Hoja.get_Range(cell, cell).Text != null)
        //                cell = (string)Hoja.get_Range(cell, cell).Text;
        //            else
        //                cell = "";
        //        }
        //        catch (System.Exception)
        //        {
        //            break;
        //        }
        //        if (cell != "")
        //        {
        //            try
        //            {
        //                cc.Nombre = cell;
        //                obj.v[col] = cell;
        //                nullrow = false;
        //            }
        //            catch (Exception)
        //            {
        //                obj.v[col - 1] = "";
        //            }
        //        }
        //    }
        //    if (!nullrow)
        //    {
        //        //aqui tengo el registro de exel
        //        //ListaCeldas.Items.Add(cell);
        //        //creo el comando para subir el campo a la base de datos
        //        string s = "insert into " + TTablaDestino.Text + "(";
        //        int i, n;
        //        n = ListaCamposDestino2.Items.Count;
        //        bool primero = true;
        //        for (i = 0; i < n; i++)
        //        {
        //            if (primero == true)
        //            {
        //                primero = false;
        //            }
        //            else
        //                s = s + ",";
        //            Objetos.CParametro obj2 = (Objetos.CParametro)ListaCamposDestino2.Items[i];
        //            s = s + obj2.nombre;
        //        }
        //        s = s + ") values(";
        //        primero = true;
        //        bool hayDatos = false;
        //        for (i = 0; i < n; i++)
        //        {
        //            Objetos.CParametro obj2 = (Objetos.CParametro)ListaCamposDestino2.Items[i];
        //            if (primero == true)
        //            {
        //                primero = false;
        //            }
        //            else
        //                s = s + ",";
        //            if (obj.v[i] == null)
        //                obj.v[i] = "";
        //            if (obj.v[i].Length > obj2.Logitud)
        //            {
        //                s = s + "\'" + obj.v[i].Substring(0, obj2.Logitud).Replace('\'',' ') + "\'";
        //            }
        //            else
        //            {
        //                s = s + "\'" + obj.v[i].Replace('\'', ' ') + "\'";
        //            }
        //            if (obj.v[i] != "")
        //                hayDatos = true;
        //        }
        //        s = s + ")";
        //        if (hayDatos == false)
        //        {
        //            //timer1.Enabled = false;
        //            status = 2;
        //            row = Comandos.Count;
        //            BProgreso.Progreso = 0;
        //            BProgreso.ValorMaximo = row;
        //            xlLibro.Close(false, Missing.Value, Missing.Value);
        //            xlApp.Quit();
        //            return;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                BProgreso.Texto = Comandos.Count + " Registros leídos";//row.ToString() + " Registros leídos";
        //                Comandos.Add(s);
        //            }
        //            catch (System.Exception ex)
        //            {
        //                Errores = Errores + "\n" + ex; ;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        status = 2;
        //        row = Comandos.Count;
        //        BProgreso.Progreso = 0;
        //        BProgreso.ValorMaximo = row;
        //        xlLibro.Close(false, Missing.Value, Missing.Value);
        //        xlApp.Quit();
        //    }
        //    nullrow = false;
        //}
        private void timer1_Tick(object sender, EventArgs e)
        {
            string s="";
            if (status == 1)
            {
                BProgreso.Progreso++;
                if (BProgreso.Progreso >= BProgreso.ValorMaximo)
                    BProgreso.Progreso = 0;
                LeerLinea();
                BProgreso.Texto = " Subiendo registro " + subidos.ToString();// BProgreso.Progreso.ToString();
                subidos++;
                if (Comandos.Count <= 0)
                    return;
                s = Comandos[0];
                Comandos.RemoveAt(0);
                try
                {
                    DB.Ejecuta(s);
                }
                catch (System.Exception ex)
                {
                    Errores = Errores + "\n" + ex; ;
                }
                return;
            }
            if (Comandos.Count == 0)
            {
                TInsertar.Enabled = false;
                AcivarControles = true;
                return;
            }
            //el staus es subir registros
            BProgreso.Texto = " Subiendo registro " + BProgreso.Progreso.ToString();
            BProgreso.Progreso++;
            s = Comandos[0];
            Comandos.RemoveAt(0);
            try
            {
                DB.Ejecuta(s);
            }
            catch (System.Exception ex)
            {
                Errores = Errores + "\n" + ex; ;
            }
        }
        public override void Importar()
        {
            subidos = 0;
            AcivarControles = false;
            Errores = "";
            Comandos = new List<string>();
            status = 1;//leyendo archivo
            //iniciar la importacion de la tabla
            BProgreso.ValorMaximo = 100;
            BProgreso.Progreso = 0;
            TInsertar.Enabled = true;
        }
        private bool AcivarControles
        {
            set
            {
                //desactiva o activa los controles
                ActivarImportar(value);
//                TInsertar.Enabled = value;
//                ComboConexionesDestino.Enabled = value;
                if (value == false)
                {
//                    BBuscarTablaOrigen.Enabled = value;
                    BSubirOrigen.Enabled = value;
                    BAgregarOrigen.Enabled = value;
                    BQuitarOrigen.Enabled = value;
                    BBajarOrigen.Enabled = value;
//                    RcrearTablaDestino.Enabled = value;
//                    RSeleccionarTablaDestino.Enabled = value;
                    TTablaDestino.Enabled = value;
                    BSubirDestino.Enabled = value;
                    BAgregarDestino.Enabled = value;
                    BQuitarDestino.Enabled = value;
                    BBajarDestino.Enabled = value;
                }
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            bool ok=true;
            if (TInsertar.Enabled==true)
                ok = false;
            if (ListaCamposOrigen2.Items.Count == 0)
                ok = false;
            if (ListaCamposDestino2.Items.Count == 0)
                ok = false;
            ActivarImportar(ok);

        }
        private void LeerLinea()
        {
            bool nullrow = true;
            row++;
            FilaXLS obj = new FilaXLS();
            //creo el comando para subir el campo a la base de datos
            string s = "";
            string s1 = "insert into " + TTablaDestino.Text + "(";
            int i, n;
            n = ListaCamposDestino2.Items.Count;
            bool primero = true;
            s = s + ") values(";
            primero = true;
            bool hayDatos = false;
            //recorre todos los campos
            for (int col = 0; col < ListaCamposOrigen2.Items.Count; col++)
            {
                Objetos.CParametro obj2 = (Objetos.CParametro)ListaCamposDestino2.Items[col];
                if (primero == true)
                {
                    primero = false;
                }
                else
                {
                    s1 = s1 + ",";
                    s = s + ",";
                }
                //Objetos.CParametro obj2 = (Objetos.CParametro)ListaCamposDestino2.Items[col];
                s1 = s1 + obj2.nombre;
                //lectura del registro de excel
                CColumna cc = (CColumna)ListaCamposOrigen2.Items[col];
                string cell;
                char cy = ' ';
                char cx = ((char)(65 + col)).ToString()[0];
                if (cx > 'Z')
                {
                    cy = (char)(64 + (int)col / (int)26);
                    cx = (char)((int)cx - (int)'Z' + 64);
                }
                cell = cy.ToString().Trim() + cx.ToString();
                cell += row;
                try
                {
                    cc.Columna = cell;
                    if (Hoja.get_Range(cell, cell).Text != null)
                        cell = (string)Hoja.get_Range(cell, cell).Text;
                    else
                        cell = "";
                }
                catch (System.Exception)
                {
                    break;
                }
                if (cell != "")
                {
                    try
                    {
                        cc.Nombre = cell;
                        obj.v[col] = cell;
                        nullrow = false;
                    }
                    catch (Exception)
                    {
                        obj.v[col - 1] = "";
                    }
                }
                //termino de agregar los datos del campo de la consulta
                if (obj.v[col] == null)
                    obj.v[col] = "";
                if (obj.v[col].Length > obj2.Logitud && obj2.Logitud>=0)
                {
                    s = s + "\'" + obj.v[col].Substring(0, obj2.Logitud).Replace('\'', ' ') + "\'";
                }
                else
                {
                    s = s + "\'" + obj.v[col].Replace('\'', ' ') + "\'";
                }
                if (obj.v[col] != "")
                    hayDatos = true;
            }
            if (!nullrow)
            {
                //aqui tengo el registro de exel
                s =s1+ s + ")";
                if (hayDatos == false)
                {
                    //timer1.Enabled = false;
                    status = 2;
                    row = Comandos.Count;
                    BProgreso.Progreso = 0;
                    BProgreso.ValorMaximo = row;
                    xlLibro.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();
                    return;
                }
                else
                {
                    try
                    {
                        BProgreso.Texto = Comandos.Count + " Registros leídos";//row.ToString() + " Registros leídos";
                        Comandos.Add(s);
                    }
                    catch (System.Exception ex)
                    {
                        Errores = Errores + "\n" + ex; ;
                    }
                }
            }
            else
            {
                status = 2;
                row = Comandos.Count;
                BProgreso.Progreso = 0;
                if(row>0)
                    BProgreso.ValorMaximo = row;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
            }
            nullrow = false;
        }
    }
}

