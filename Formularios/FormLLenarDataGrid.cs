using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
	/// <summary>
	/// Summary description for FormLLenarDataGrid.
	/// </summary>
    public partial class FormLLenarDataGrid :EditorGenerico// FormBase
	{
        public event OnCodigoEvent OnCodigo;
        Controladores_DB.IDataBase DB;
		private string FTexto="";
        private System.Collections.Generic.List<Objetos.CParametro> Campos;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TFuncion;
		private System.Windows.Forms.Button BCerrar;
		private System.Windows.Forms.Button BGenerar;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton CheckPublico;
		private System.Windows.Forms.RadioButton CheckPrivado;
		private System.Windows.Forms.RadioButton CheckProtejido;
        private System.Windows.Forms.ListBox ListaCampos;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TLista;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TObjeto;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox TDataGrid;
		private System.Windows.Forms.CheckBox CheckOnPaint;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TOnPaint;

        public FormLLenarDataGrid(Controladores_DB.IDataBase db)
		{
            DB = db;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            if (Campos == null)
                Campos = new System.Collections.Generic.List<Objetos.CParametro>();
            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLLenarDataGrid));
            this.ListaCampos = new System.Windows.Forms.ListBox();
            this.MenuCampos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lLenarDesdeUnSpOTablaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TOnPaint = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CheckOnPaint = new System.Windows.Forms.CheckBox();
            this.TDataGrid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TObjeto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TLista = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckProtejido = new System.Windows.Forms.RadioButton();
            this.CheckPrivado = new System.Windows.Forms.RadioButton();
            this.CheckPublico = new System.Windows.Forms.RadioButton();
            this.BGenerar = new System.Windows.Forms.Button();
            this.BCerrar = new System.Windows.Forms.Button();
            this.TFuncion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MenuCampos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // ListaCampos
            // 
            this.ListaCampos.ContextMenuStrip = this.MenuCampos;
            this.ListaCampos.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListaCampos.Location = new System.Drawing.Point(0, 200);
            this.ListaCampos.Name = "ListaCampos";
            this.ListaCampos.Size = new System.Drawing.Size(108, 238);
            this.ListaCampos.TabIndex = 0;
            this.ListaCampos.DoubleClick += new System.EventHandler(this.ListaCampos_DoubleClick);
            // 
            // MenuCampos
            // 
            this.MenuCampos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.subirToolStripMenuItem,
            this.bajarToolStripMenuItem,
            this.lLenarDesdeUnSpOTablaToolStripMenuItem});
            this.MenuCampos.Name = "MenuCampos";
            this.MenuCampos.Size = new System.Drawing.Size(166, 136);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // subirToolStripMenuItem
            // 
            this.subirToolStripMenuItem.Name = "subirToolStripMenuItem";
            this.subirToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.subirToolStripMenuItem.Text = "Subir";
            this.subirToolStripMenuItem.Click += new System.EventHandler(this.subirToolStripMenuItem_Click);
            // 
            // bajarToolStripMenuItem
            // 
            this.bajarToolStripMenuItem.Name = "bajarToolStripMenuItem";
            this.bajarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.bajarToolStripMenuItem.Text = "Bajar";
            this.bajarToolStripMenuItem.Click += new System.EventHandler(this.bajarToolStripMenuItem_Click);
            // 
            // lLenarDesdeUnSpOTablaToolStripMenuItem
            // 
            this.lLenarDesdeUnSpOTablaToolStripMenuItem.Name = "lLenarDesdeUnSpOTablaToolStripMenuItem";
            this.lLenarDesdeUnSpOTablaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.lLenarDesdeUnSpOTablaToolStripMenuItem.Text = "Llenar desde un Sp";
            this.lLenarDesdeUnSpOTablaToolStripMenuItem.Click += new System.EventHandler(this.lLenarDesdeUnSpOTablaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TOnPaint);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.CheckOnPaint);
            this.panel1.Controls.Add(this.TDataGrid);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TObjeto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TLista);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.BGenerar);
            this.panel1.Controls.Add(this.BCerrar);
            this.panel1.Controls.Add(this.TFuncion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 200);
            this.panel1.TabIndex = 5;
            // 
            // TOnPaint
            // 
            this.TOnPaint.Location = new System.Drawing.Point(96, 168);
            this.TOnPaint.Name = "TOnPaint";
            this.TOnPaint.Size = new System.Drawing.Size(192, 20);
            this.TOnPaint.TabIndex = 18;
            this.TOnPaint.Text = "PaintRow";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "Evento OnPaint";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(336, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "PaintRowEventArgs";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(152, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "CustomDataGridTextBoxColumn";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CheckOnPaint
            // 
            this.CheckOnPaint.Location = new System.Drawing.Point(8, 136);
            this.CheckOnPaint.Name = "CheckOnPaint";
            this.CheckOnPaint.Size = new System.Drawing.Size(296, 24);
            this.CheckOnPaint.TabIndex = 14;
            this.CheckOnPaint.Text = "Generar Evento OnPaint";
            this.CheckOnPaint.CheckedChanged += new System.EventHandler(this.CheckOnPaint_CheckedChanged);
            // 
            // TDataGrid
            // 
            this.TDataGrid.Location = new System.Drawing.Point(120, 112);
            this.TDataGrid.Name = "TDataGrid";
            this.TDataGrid.Size = new System.Drawing.Size(192, 20);
            this.TDataGrid.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nombre del DataGrid";
            // 
            // TObjeto
            // 
            this.TObjeto.Location = new System.Drawing.Point(56, 88);
            this.TObjeto.Name = "TObjeto";
            this.TObjeto.Size = new System.Drawing.Size(256, 20);
            this.TObjeto.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Objeto";
            // 
            // TLista
            // 
            this.TLista.Location = new System.Drawing.Point(280, 8);
            this.TLista.Name = "TLista";
            this.TLista.Size = new System.Drawing.Size(100, 20);
            this.TLista.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(248, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lista";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckProtejido);
            this.groupBox1.Controls.Add(this.CheckPrivado);
            this.groupBox1.Controls.Add(this.CheckPublico);
            this.groupBox1.Location = new System.Drawing.Point(8, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 48);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seguridad";
            // 
            // CheckProtejido
            // 
            this.CheckProtejido.Location = new System.Drawing.Point(88, 16);
            this.CheckProtejido.Name = "CheckProtejido";
            this.CheckProtejido.Size = new System.Drawing.Size(104, 24);
            this.CheckProtejido.TabIndex = 2;
            this.CheckProtejido.Text = "Protected";
            // 
            // CheckPrivado
            // 
            this.CheckPrivado.Checked = true;
            this.CheckPrivado.Location = new System.Drawing.Point(8, 16);
            this.CheckPrivado.Name = "CheckPrivado";
            this.CheckPrivado.Size = new System.Drawing.Size(104, 24);
            this.CheckPrivado.TabIndex = 1;
            this.CheckPrivado.TabStop = true;
            this.CheckPrivado.Text = "Private";
            // 
            // CheckPublico
            // 
            this.CheckPublico.Location = new System.Drawing.Point(200, 16);
            this.CheckPublico.Name = "CheckPublico";
            this.CheckPublico.Size = new System.Drawing.Size(104, 24);
            this.CheckPublico.TabIndex = 0;
            this.CheckPublico.Text = "Public";
            // 
            // BGenerar
            // 
            this.BGenerar.Image = ((System.Drawing.Image)(resources.GetObject("BGenerar.Image")));
            this.BGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BGenerar.Location = new System.Drawing.Point(404, 8);
            this.BGenerar.Name = "BGenerar";
            this.BGenerar.Size = new System.Drawing.Size(87, 34);
            this.BGenerar.TabIndex = 6;
            this.BGenerar.Text = "Generar";
            this.BGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BGenerar.Click += new System.EventHandler(this.BGenerar_Click);
            // 
            // BCerrar
            // 
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(404, 61);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(86, 34);
            this.BCerrar.TabIndex = 5;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.Visible = false;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // TFuncion
            // 
            this.TFuncion.Location = new System.Drawing.Point(112, 8);
            this.TFuncion.Name = "TFuncion";
            this.TFuncion.Size = new System.Drawing.Size(128, 20);
            this.TFuncion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la funcion";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(108, 200);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(394, 238);
            this.dataGrid1.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormLLenarDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ListaCampos);
            this.Controls.Add(this.panel1);
            this.Name = "FormLLenarDataGrid";
            this.Size = new System.Drawing.Size(502, 438);
            this.MenuCampos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		private string Seguridad
		{
			get
			{
				string s="";
				if(this.CheckPrivado.Checked==true)
					s="private ";
				if(this.CheckProtejido.Checked==true)
					s="protected ";
				if(this.CheckPublico.Checked==true)
					s="public ";
				return s;
				
			}
		}
		private void BGenerar_Click(object sender, System.EventArgs e)
		{
			//genera el codido del data grd
			string s;
			int i,n;
			s=Seguridad+"void "+this.TFuncion.Text+"()\r\n";
			s=s+"{\r\n";
			s=s+"\tDataSet ds = new DataSet();\r\n";
			s=s+"\tDataTable dt = new DataTable(\"Tabla\");\r\n";
			s=s+"\t//Creando las columnas y agregando los items a la tabla\r\n";
			n=Campos.Count;
			for(i=0;i<n;i++)
			{
				Objetos.CParametro parametro=Campos[i];
				s=s+"\tDataColumn dc"+parametro.tipo+"= new DataColumn(\""+parametro.tipo+"\");\r\n";
			}
			s=s+"\t//Asignando los campos ala tabla\r\n";
			for(i=0;i<n;i++)
			{
                Objetos.CParametro parametro = Campos[i];
				s=s+"\tdt.Columns.Add(dc"+parametro.tipo+");\r\n";
			}
			s=s+"\t//agregarndo la tabla al data set\r\n";
			s=s+"\tds.Tables.Add(dt);\r\n";
			s=s+"\t//llenando la tabla con datos\r\n";
			s=s+"\tint i,n;\r\n";
			s=s+"\tn="+this.TLista.Text+".Count;\r\n";
			s=s+"\tfor(i=0;i< n;i++)\r\n";
			s=s+"\t{\r\n";
			s=s+"\t\t"+this.TObjeto.Text+" dato=("+this.TObjeto.Text+")"+this.TLista.Text+"[i];\r\n";
			s=s+"\t\tDataRow drRow = dt.NewRow();\r\n";
			for(i=0;i<n;i++)
			{
                Objetos.CParametro parametro = Campos[i];
				s=s+"\t\tdrRow[\""+parametro.tipo+"\"]=dato."+parametro.tipo+";\r\n";
			}
			
			s=s+"\t\tdt.Rows.Add(drRow);\r\n";
			s=s+"\t}\r\n";
			s=s+"\t"+TDataGrid.Text+".DataSource = ds.Tables[0];\r\n";
			s=s+"\tDataGridTableStyle ts = new DataGridTableStyle();\r\n";
			s=s+"\tts.AllowSorting=false;\r\n";
			s=s+"\tts.MappingName =\"Tabla\";\r\n";
			s=s+"\t//creando las columnas que se van a ver\r\n";
			for(i=0;i<n;i++)
			{
                Objetos.CParametro parametro = Campos[i];
				s=s+"\t//------------------"+parametro.nombre+"---------------------------------------- \r\n";
				if(CheckOnPaint.Checked==true)
				{
					s=s+"\tCustomDataGridTextBoxColumn "+parametro.tipo+"= new CustomDataGridTextBoxColumn();\r\n";
					s=s+"\t"+parametro.tipo+".PaintRow+=new DPaintRow("+TOnPaint.Text+");//evento para onpaint\r\n";
				}
				else
					s=s+"\tDataGridColumnStyle "+parametro.tipo+"= new DataGridTextBoxColumn();\r\n";
				s=s+"\t"+parametro.tipo+".MappingName = \""+parametro.tipo+"\";\r\n";
				s=s+"\t"+parametro.tipo+".HeaderText = \""+parametro.nombre+"\";\r\n";
				int tam=parametro.Logitud;
				s=s+"\t"+parametro.tipo+".Width="+tam.ToString()+";\r\n";
				s=s+"\t"+parametro.tipo+".ReadOnly=true;\r\n";
				s=s+"\tts.GridColumnStyles.Add("+parametro.tipo+");\r\n";
			}
			s=s+"\t//finalizando la creacion del data grid\r\n";
			s=s+"\tts.MappingName =\"Tabla\";\r\n";
			s=s+"\t"+TDataGrid.Text+".TableStyles.Clear();\r\n";
			s=s+"\t"+TDataGrid.Text+".TableStyles.Add(ts);\r\n";
			s=s+"\t"+TDataGrid.Text+".AllowSorting=false;\r\n";
			s=s+"} \r\n";
			if(CheckOnPaint.Checked==true)
			{
				s=s+"//evento para on paint\r\n";
				s=s+"private void "+TOnPaint.Text+"(PaintRowEventArgs args )\r\n";
				s=s+"{\r\n";
				s=s+"\t//poner el codigo para cambiar el color aqui\r\n";
				s=s+"\t//ejemplo\r\n";
				s=s+"\targs.BackColor=Brushes.GreenYellow;//todo es verde con amarillo\r\n";
				s=s+"}\r\n";
			}
            if (OnCodigo != null)
                OnCodigo("" , s);
            //FormVerClase dlg = new FormVerClase();
            //dlg.Texto=s;
            //dlg.ShowDialog();
		}
		private void BCerrar_Click(object sender, System.EventArgs e)
		{
//			Close();
		}
		private void CheckOnPaint_CheckedChanged(object sender, System.EventArgs e)
		{
			button1.Enabled=CheckOnPaint.Checked;
			button2.Enabled=CheckOnPaint.Checked;
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			FormVerClase dlg=new FormVerClase();
			dlg.Texto=CustomDataGridTextBoxColumn;
			dlg.ShowDialog();
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			FormVerClase dlg=new FormVerClase();
			dlg.Texto=this.PaintRowEventArgs;
			dlg.ShowDialog();		
		}
        private ContextMenuStrip MenuCampos;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem subirToolStripMenuItem;
        private ToolStripMenuItem bajarToolStripMenuItem;
        private IContainer components;
	
		public string Texto
		{
			get
			{
				return this.FTexto;
			}
		}
		private string CustomDataGridTextBoxColumn
		{
			get
			{
				string s="\r\n";
				s=s+"using System;\r\n";
				s=s+"using System.Drawing;\r\n";
				s=s+"using System.Collections;\r\n";
				s=s+"using System.ComponentModel;\r\n";
				s=s+"using System.Windows.Forms;\r\n";
				s=s+"using System.Data;\r\n";
				s=s+"namespace CustomDataGrid //cambiarlo por el namespace de la aplicacion\r\n";
				s=s+"{\r\n";
				s=s+"\t/// <summary>\r\n";
				s=s+"\t/// Summary description for CustomDataGridTextBoxColumn.\r\n";
				s=s+"\t/// </summary>\r\n";
				s=s+"\tpublic delegate void DPaintRow(PaintRowEventArgs args );\r\n";
				s=s+"\tpublic class CustomDataGridTextBoxColumn:System.Windows.Forms.DataGridTextBoxColumn\r\n";
				s=s+"\t{\r\n";
				s=s+"\t\tpublic event DPaintRow PaintRow;\r\n";
				s=s+"\t\t \r\n";
				s=s+"\t\tpublic CustomDataGridTextBoxColumn() \r\n";
				s=s+"\t\t{ \r\n";
				s=s+"\t\t\t// \r\n";
				s=s+"\t\t\t// TODO: Add constructor logic here \r\n";
				s=s+"\t\t\t// \r\n";
				s=s+"\t\t}\r\n";
				s=s+"\t\tprotected override void Paint(Graphics g ,Rectangle bounds,CurrencyManager source,int rowNum ,Brush backBrush ,Brush foreBrush ,bool alignToRight ) \r\n";
				s=s+"\t\t{ \r\n";
				s=s+"\t\t\tPaintRowEventArgs oArgs=new PaintRowEventArgs(); \r\n";
				s=s+"\t\t\toArgs.RowNumber = rowNum; \r\n";
				s=s+"\t\t\tif(PaintRow!=null) \r\n";
				s=s+"\t\t\t\tPaintRow(oArgs); \r\n";
				s=s+"\t\t\tif(oArgs.BackColor!=null) \r\n";
				s=s+"\t\t\t\tbackBrush = oArgs.BackColor; \r\n";
				s=s+"\t\t\tif(oArgs.ForeColor!=null) \r\n";
				s=s+"\t\t\t\tforeBrush = oArgs.ForeColor; \r\n";
				s=s+"\t\t\toArgs =null; \r\n";
				s=s+"\t\t\tbase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight); \r\n";
				s=s+"\t\t} \r\n";
				s=s+"\t} \r\n";
				s=s+"} \r\n";
				return s;
			}
		}
		private string PaintRowEventArgs
		{
			get
			{
				string s="using System;\r\n";
				s=s+"using System.Drawing;\r\n";
				s=s+"using System.Collections;\r\n";
				s=s+"using System.ComponentModel;\r\n";
				s=s+"using System.Windows.Forms;\r\n";
				s=s+"using System.Data;\r\n";
				s=s+"namespace CustomDataGrid //cambiarlo por el namespace de la aplicacion\r\n";
				s=s+"{\r\n";
				s=s+"\t/// <summary>\r\n";
				s=s+"\t/// Summary description for PaintRowEventArgs.\r\n";
				s=s+"\t/// </summary>\r\n";
				s=s+"\t\r\n";
				s=s+"\tpublic class PaintRowEventArgs:EventArgs\r\n";
				s=s+"\t{\r\n";
				s=s+"\t\tprivate int _rowNum;\r\n";
				s=s+"\t\tprivate Brush _backColor;\r\n";
				s=s+"\t\tprivate Brush _foreColor;\r\n";
				s=s+"\t\t\r\n";
				s=s+"\t\tpublic PaintRowEventArgs()\r\n";
				s=s+"\t\t{\r\n";
				s=s+"\t\t}\r\n";
				s=s+"\t\tpublic int RowNumber\r\n";
				s=s+"\t\t{\r\n";
				s=s+"\t\t\tget \r\n";
				s=s+"\t\t\t{ \r\n";
				s=s+"\t\t\t\treturn _rowNum; \r\n";
				s=s+"\t\t\t} \r\n";
				s=s+"\t\t\tset \r\n";
				s=s+"\t\t\t{ \r\n";
				s=s+"\t\t\t\t_rowNum = value; \r\n";
				s=s+"\t\t\t} \r\n";
				s=s+"\t\t} \r\n";
				s=s+"\t\tpublic Brush BackColor \r\n";
				s=s+"\t\t{\r\n";
				s=s+"\t\t\tget\r\n";
				s=s+"\t\t\t{ \r\n";
				s=s+"\t\t\t\treturn _backColor; \r\n";
				s=s+"\t\t\t} \r\n";
				s=s+"\t\t\tset \r\n";
				s=s+"\t\t\t{ \r\n";
				s=s+"\t\t\t\t_backColor =value; \r\n";
				s=s+"\t\t\t} \r\n";
				s=s+"\t\t} \r\n";
				s=s+"\t\tpublic Brush ForeColor \r\n";
				s=s+"\t\t{ \r\n";
				s=s+"\t\t\tget \r\n";
				s=s+"\t\t\t{ \r\n";
				s=s+"\t\t\t\treturn _foreColor; \r\n";
				s=s+"\t\t\t} \r\n";
				s=s+"\t\t\tset \r\n";
				s=s+"\t\t\t{ \r\n";
				s=s+"\t\t\t\t_foreColor=value; \r\n";
				s=s+"\t\t\t} \r\n";
				s=s+"\t\t} \r\n";
				s=s+"\t} \r\n";
				s=s+"} \r\n";
				return s;
			}
		}

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataGridCampo dlg = new FormDataGridCampo();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            Objetos.CParametro parametro = new Objetos.CParametro();
            parametro.tipo =dlg.Campo;
            parametro.nombre = dlg.Descripcion;
            parametro.Logitud = dlg.Tamaño;
            this.Campos.Add(parametro);
            ListaCampos.Items.Add(parametro.tipo);
            MuestraDataGrid();

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ListaCampos.SelectedIndex == -1)
                return;
            if (MessageBox.Show("Eliminar el campo", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;
            this.Campos.RemoveAt(ListaCampos.SelectedIndex);
            ListaCampos.Items.RemoveAt(ListaCampos.SelectedIndex);
            MuestraDataGrid();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ListaCampos.SelectedIndex == -1)
                return;
            Objetos.CParametro parametro = Campos[ListaCampos.SelectedIndex];
            FormDataGridCampo dlg = new FormDataGridCampo();
            dlg.Campo=parametro.tipo ;
            dlg.Descripcion=parametro.nombre;
            dlg.Tamaño=parametro.Logitud ;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            parametro.tipo = dlg.Campo;
            parametro.nombre = dlg.Descripcion;
            parametro.Logitud = dlg.Tamaño;
            MuestraDataGrid();

        }

        private DataGrid dataGrid1;

        private void subirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ListaCampos.SelectedIndex<=0)
                return;
            int pos = ListaCampos.SelectedIndex;
            Objetos.CParametro parametro = Campos[pos];
            ListaCampos.Items.RemoveAt(pos);
            Campos.RemoveAt(pos);
            ListaCampos.Items.Insert(pos - 1, parametro.tipo);
            Campos.Insert(pos - 1, parametro);
            ListaCampos.SelectedIndex = pos - 1;
            MuestraDataGrid();

        }

        private void bajarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ListaCampos.SelectedIndex == -1 || ListaCampos.SelectedIndex >= Campos.Count-1)
                return;
            int pos = ListaCampos.SelectedIndex;
            Objetos.CParametro parametro = Campos[pos];
            ListaCampos.Items.RemoveAt(pos);
            Campos.RemoveAt(pos);
            ListaCampos.Items.Insert(pos + 1, parametro.tipo);
            Campos.Insert(pos + 1, parametro);
            ListaCampos.SelectedIndex = pos + 1;
            MuestraDataGrid();

        }

        private Timer timer1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ListaCampos.SelectedIndex == -1)
                ok = false;
            eliminarToolStripMenuItem.Enabled = ok;
            editarToolStripMenuItem.Enabled = ok;
            ok = true;
            if (this.ListaCampos.SelectedIndex <= 0)
                ok = false;
            subirToolStripMenuItem.Enabled = ok;
            ok = true;
            if (this.ListaCampos.SelectedIndex == -1 || ListaCampos.SelectedIndex >= Campos.Count - 1)
                ok = false;
            bajarToolStripMenuItem.Enabled = ok;
            ok = true;
            if (ListaCampos.Items.Count == 0)
                ok = false;
            if (TFuncion.Text.Trim() == "")
                ok = false;
            if (TLista.Text.Trim() == "")
                ok = false;
            if (TObjeto.Text.Trim() == "")
                ok = false;
            if (TDataGrid.Text.Trim() == "")
                ok = false;
            if (CheckOnPaint.Checked == true)
            {
                if (TOnPaint.Text.Trim() == "")
                    ok = false;
            }
            BGenerar.Enabled = ok;
        }
        private void MuestraDataGrid()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Tabla");
            //agregarndo la tabla al data set
            ds.Tables.Add(dt);
            //llenando la tabla con datos
            int i, n;
            n = Campos.Count;
            for (i = 0; i < n; i++)
            {
                //Creando las columnas y agregando los items a la tabla
                Objetos.CParametro dato = (Objetos.CParametro)Campos[i];
                DataColumn dctipo = new DataColumn(dato.tipo);
                dt.Columns.Add(dctipo);
            }
            dataGrid1.DataSource = ds.Tables[0];
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.AllowSorting = false;
            ts.MappingName = "Tabla";
            for (i = 0; i < n; i++)
            {
                //creando las columnas que se van a ver
                Objetos.CParametro dato = (Objetos.CParametro)Campos[i];
                DataGridColumnStyle tipo = new DataGridTextBoxColumn();
                tipo.MappingName = dato.tipo;
                tipo.HeaderText = dato.nombre;
                tipo.Width = dato.Logitud;
                tipo.ReadOnly = true;
                ts.GridColumnStyles.Add(tipo);
            }
            //finalizando la creacion del data grid
            ts.MappingName = "Tabla";
            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(ts);
            dataGrid1.AllowSorting = false;
        }
        public override void Guardar()
        {
            BGenerar_Click(null, null);
        }

        private ToolStripMenuItem lLenarDesdeUnSpOTablaToolStripMenuItem;

        private void lLenarDesdeUnSpOTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FormBuscarTabla dlg = new FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            Objetos.CSysObject obj = dlg.DameObjeto();
            int j, k;
            System.Data.SqlClient.SqlCommand SqlCommand1;
            SqlCommand1 = new System.Data.SqlClient.SqlCommand();
            SqlCommand1.CommandText = obj.Nombre;
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
                        Objetos.CParametro parametro = new Objetos.CParametro();
                        parametro.tipo = c.Caption;
                        parametro.nombre = c.Caption;
                        parametro.Logitud = c.MaxLength;
                        this.Campos.Add(parametro);
                        ListaCampos.Items.Add(parametro.tipo);

                        //string TipoNet = cv.DameTipo(c.DataType.ToString());
                        //OnDatoManual(c.Caption, TipoNet);
                    }
                }
            }
            catch (Exception ex)
            {
                SqlCommand1.Connection.Close();
                throw new Exception(ex.Message);
            }
            SqlCommand1.Connection.Close();
            MuestraDataGrid();
        }

        private void ListaCampos_DoubleClick(object sender, EventArgs e)
        {
            if (this.ListaCampos.SelectedIndex == -1)
                return;
            Objetos.CParametro parametro = Campos[ListaCampos.SelectedIndex];
            FormDataGridCampo dlg = new FormDataGridCampo();
            dlg.Campo = parametro.tipo;
            dlg.Descripcion = parametro.nombre;
            dlg.Tamaño = parametro.Logitud;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            parametro.tipo = dlg.Campo;
            parametro.nombre = dlg.Descripcion;
            parametro.Logitud = dlg.Tamaño;
            MuestraDataGrid();

        }
    }
}
