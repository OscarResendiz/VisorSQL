using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormDocumentar : EditorGenerico
    {
        private int checkPrint;
        Controladores_DB.IDataBase DB;
        public FormDocumentar(string Nombre, Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
            TNombreTabla.Text = Nombre;
            Text = "Documentación de la tabla:" + Nombre;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            //Close();
        }

        private void FormDocumentar_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Objetos.CParametro> Campos ;
            Campos = DB.DameCamposTabla(TNombreTabla.Text);
            Objetos.CParametro tabla=new Visor_sql_2015.Objetos.CParametro();
            tabla.nombre="Tabla "+TNombreTabla.Text;
            tabla.Descripcion = DB.DaMeDescripcionTabla(TNombreTabla.Text);
            ListaCampos2.Items.Add(tabla);
            foreach (Objetos.CParametro obj in Campos)
            {
                obj.Descripcion = DB.DameDescripcionCampo(TNombreTabla.Text, obj.nombre);
                obj.Modificado = false;
                ListaCampos2.Items.Add(obj);
            }
            //WindowState = FormWindowState.Maximized;
        }

        private void ListaCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListaCampos2.SelectedIndex == -1)
            {
                TNombreCampo.Text = "";
                TTipo.Text = "";
                TLongitud.Text = "";
                TDescCampo.Text = "";
                return;
            }
            Objetos.CParametro ojb=(Objetos.CParametro)ListaCampos2.Items[ListaCampos2.SelectedIndex];
            TNombreCampo.Text = ojb.nombre;
            TTipo.Text = ojb.tipo;
            TLongitud.Text = ojb.Logitud.ToString();
            try
            {
                TDescCampo.Rtf = ojb.Descripcion;
            }
            catch (System.Exception)
            {
                TDescCampo.Text = ojb.Descripcion;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void T_Click(object sender, EventArgs e)
        {
            bool inicio = true;
            foreach (Objetos.CParametro obj in ListaCampos2.Items)
            {
                if (inicio == true)
                {
                    DB.GusrdaDescripcionTabla(TNombreTabla.Text, obj.Descripcion);
                    obj.Modificado = false;
                    inicio = false;
                }
                else
                {
                    DB.GuardaDescripcionCampo(TNombreTabla.Text, obj.nombre, obj.Descripcion);
                    obj.Modificado = false;
                }
            }
            //Close();
        }

        private void TDescCampo_TextChanged(object sender, EventArgs e)
        {
            if (ListaCampos2.SelectedIndex == -1)
                return;

            Objetos.CParametro obj = (Objetos.CParametro)ListaCampos2.Items[ListaCampos2.SelectedIndex];
            if (obj.Descripcion != TDescCampo.Rtf)
            {
                obj.Descripcion = TDescCampo.Rtf;
                obj.Modificado = true;
                return;
            }
            obj.Modificado = false;
        }

        private void BFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = TDescCampo.SelectionFont;
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            TDescCampo.SelectionFont = fontDialog1.Font;
        }

        private void BColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            TDescCampo.SelectionColor = colorDialog1.Color;
        }

        private void BFondo_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            TDescCampo.SelectionBackColor = colorDialog1.Color;

        }

        private void BNegrita_Click(object sender, EventArgs e)
        {
            TDescCampo.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TDescCampo.SelectionAlignment = HorizontalAlignment.Left;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TDescCampo.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Print the content of RichTextBox. Store the last character printed.
            checkPrint = TDescCampo.Print(checkPrint, TDescCampo.TextLength, e);

            // Check for more pages
            if (checkPrint < TDescCampo.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

        }

        private void FormDocumentar_FormClosing(object sender, FormClosingEventArgs e)
        {
            //verifico si hay algun dato que este modificado
            foreach (Objetos.CParametro obj in ListaCampos2.Items)
            {
                if (obj.Modificado == true)
                {
                    DialogResult dr=MessageBox.Show("¿Desea guardar los cambios hechos a la documentación?", "Guardar", MessageBoxButtons.YesNoCancel);
                    switch (dr)
                    {
                        case DialogResult.Cancel:
                            //no hay que cerrar la ventana
                            e.Cancel = true;
                            return;
                        case DialogResult.Yes:
                            //hay que guardar los cambios antes de cerrar
                            T_Click(null, null);
                            break;
                    }
                }
            }
        }
        public void CampoSeleccionado(string campo)
        {
            //recorro el combo de campos
            int i;
            for (i = 0; i < ListaCampos2.Items.Count;i++ )
            {
                if (ListaCampos2.Items[i].ToString() == campo)
                {
                    ListaCampos2.SelectedIndex = i;
                    return;
                }
            }
        }
    }
}