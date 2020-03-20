using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2005.Formularios
{
    public partial class FormCodigoX : FormBase
    {
        System.Windows.Forms.DataGrid dataGrid1;
        Controladores_DB.MSSQLServer DB;

        public FormCodigoX(Controladores_DB.MSSQLServer db,string Nombre, string Codigo)
        {
            DB = db;
            InitializeComponent();
            TNombre.Text = Nombre;
            Text = Nombre;
            TCodigo.Text = Codigo;
            cTextColor1.AnalizaTexto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGrid1.DataSource = null;
                dataGrid1.TableStyles.Clear();
                DataSet ds;
                if(TCodigo.SelectedText.Trim()=="")
                    ds = DB.Ejecuta(TCodigo.Text);
                else
                    ds = DB.Ejecuta(TCodigo.SelectedText);
                dataGrid1.DataSource = ds;
                dataGrid1.TabIndex = 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCodigo_Load(object sender, EventArgs e)
        {
            dataGrid1 = new System.Windows.Forms.DataGrid();
            dataGrid1.DataMember = "";
            dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            dataGrid1.Location = new System.Drawing.Point(0, 48);
            dataGrid1.Name = "dataGrid1";
            dataGrid1.ReadOnly = true;
            dataGrid1.Size = new System.Drawing.Size(464, 360);
            dataGrid1.TabIndex = 0;
            dataGrid1.Parent = splitContainer1.Panel2;

        }
        public override void Guardar()
        {
            saveFileDialog1.FileName = TNombre.Text + ".txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText(saveFileDialog1.FileName);
            sw.WriteLine(TCodigo.Text);
            sw.Close();
        }
    }
}