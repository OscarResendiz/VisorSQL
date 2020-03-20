using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public delegate void OnNoDatosEvent();
    public partial class AsisSelCampos : AsisBase
    {
        public event OnNoDatosEvent OnNoDatos;
        private string Nombre;
        Controladores_DB.IDataBase DB;
        public System.Collections.Generic.List<Objetos.CParametro> CamposRegresar;
        private System.Collections.Generic.List<Objetos.CParametro> CamposTabla=null;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox ListaRegreso;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Button BVerClase;
        private System.ComponentModel.IContainer components = null;

        public AsisSelCampos(Controladores_DB.IDataBase db, string nombre)
        {
            InitializeComponent();
            DB = db;
            Nombre = nombre;
            try
            {
                MuestraCampos();
                timer1.Enabled = true;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                timer1.Enabled = true;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BVerClase = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ListaRegreso = new System.Windows.Forms.ListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // LTitulo
            // 
            this.LTitulo.Size = new System.Drawing.Size(688, 40);
            this.LTitulo.Text = "SELECCIÓN DE CAMPOS";
            // 
            // BVerClase
            // 
            this.BVerClase.Location = new System.Drawing.Point(316, 19);
            this.BVerClase.Name = "BVerClase";
            this.BVerClase.Size = new System.Drawing.Size(133, 23);
            this.BVerClase.TabIndex = 5;
            this.BVerClase.Text = "Ver codigo de la clase";
            this.BVerClase.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ListaRegreso);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(688, 464);
            this.panel4.TabIndex = 8;
            // 
            // ListaRegreso
            // 
            this.ListaRegreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaRegreso.Location = new System.Drawing.Point(0, 56);
            this.ListaRegreso.Name = "ListaRegreso";
            this.ListaRegreso.Size = new System.Drawing.Size(688, 407);
            this.ListaRegreso.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.BVerClase);
            this.panel7.Controls.Add(this.TNombre);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(688, 56);
            this.panel7.TabIndex = 2;
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(121, 21);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(189, 20);
            this.TNombre.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nombre de la clase";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AsisSelCampos
            // 
            this.Controls.Add(this.panel4);
            this.Name = "AsisSelCampos";
            this.Size = new System.Drawing.Size(688, 504);
            this.Load += new System.EventHandler(this.AsisSelCampos_Load);
            this.Controls.SetChildIndex(this.LTitulo, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void AsisSelCampos_Load(object sender, System.EventArgs e)
        {
            if (ListaRegreso.Items.Count==0)
                if (OnNoDatos!=null)
                    OnNoDatos();
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (ListaRegreso.Items.Count == 0)
            {
                if (OnNoDatos != null)
                    OnNoDatos();
                timer1.Enabled = false;
            }
            bool ok = true;
            if (this.Visible == false)
                return;
            if (TNombre.Text.Trim() == "")
                ok = false;
            this.EnableSiguiente = ok;
            BVerClase.Enabled = ok;
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            int i, n;
            n = CamposTabla.Count;
            if (CamposRegresar == null)
                CamposRegresar = new System.Collections.Generic.List<Objetos.CParametro>();
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro Parametro = CamposTabla[i];
                CamposRegresar.Add(Parametro);
                ListaRegreso.Items.Add(Parametro.nombre);
            }
            CamposTabla.Clear();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            CamposRegresar.RemoveAt(ListaRegreso.SelectedIndex);
            ListaRegreso.Items.RemoveAt(ListaRegreso.SelectedIndex);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            CamposRegresar.Clear();
            ListaRegreso.Items.Clear();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            FormParametroManual dlg = new FormParametroManual();
            dlg.OnDatoManual += new OnDatoManualEvent(OnDatoManual);
            dlg.ShowDialog();
        }

        public string Clase
        {
            get
            {
                return TNombre.Text.Trim();
            }
        }
        private void OnDatoManual(string nombre, string tipo)
        {
            if (CamposRegresar == null)
                CamposRegresar = new List<Visor_sql_2015.Objetos.CParametro>();
            foreach (string s in ListaRegreso.Items)
            {
                if (s == nombre)
                    return;
            }
            Objetos.CParametro Parametro = new Objetos.CParametro();
            Parametro.nombre = nombre;
            Parametro.TipoNet = tipo;
            CamposRegresar.Add(Parametro);
            ListaRegreso.Items.Add(nombre);
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            FormVerClase dlg = new FormVerClase();
            if (CamposRegresar == null)
                CamposRegresar = new List<Visor_sql_2015.Objetos.CParametro>();
            dlg.CreaCodigoTabla(TNombre.Text, CamposRegresar);
            dlg.ShowDialog();
        }
        private void MuestraCampos()
        {
            int j, k;
            System.Data.SqlClient.SqlCommand SqlCommand1;
            SqlCommand1 = new System.Data.SqlClient.SqlCommand();
            SqlCommand1.CommandText = Nombre;
            SqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand1.Connection = new System.Data.SqlClient.SqlConnection(DB.ConnectionString);
            SqlCommand1.Connection.Open();
            System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(SqlCommand1);
            System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
            sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            sqlDataAdapter1.SelectCommand = SqlCommand1;
            DataSet ds = new DataSet("aaa");
            try
            {
                sqlDataAdapter1.GetFillParameters();
                sqlDataAdapter1.FillSchema(ds, SchemaType.Source, "aaa");
                k = ds.Tables.Count;
                for (j = 0; j < k; j++)
                {
                    System.Data.DataTable t = ds.Tables[j];
                    int i, n;
                    n = t.Columns.Count;
                    Objetos.CConvertidor cv = new Objetos.CConvertidor();
                    for (i = 0; i < n; i++)
                    {
                        System.Data.DataColumn c = t.Columns[i];
                        string TipoNet = cv.DameTipo(c.DataType.ToString());
                        OnDatoManual(c.Caption, TipoNet);
                    }
                }
            }
            catch (Exception ex)
            {
                SqlCommand1.Connection.Close();
                throw new Exception(ex.Message);
            }
            SqlCommand1.Connection.Close();
        }
    }
}

