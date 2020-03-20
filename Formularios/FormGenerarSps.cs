using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2005.Formularios
{
    /// <summary>
    /// Summary description for FormNombre.
    /// </summary>
    public delegate void OnFormNombreCodigoEvent(string nombre,string Codigo);
    public class FormGenerarSps : FormBase
    {
        public event OnFormNombreCodigoEvent OnCodigo;
        int Modo;
        Controladores_DB.MSSQLServer DB;
        string NombreTabla;
        System.Collections.Generic.List<Objetos.CParametro> Campos,Parametros,LLaves;
        System.Collections.Generic.List<Objetos.CLLaveForanea>Foraneas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox ComboParametros;
        private System.Windows.Forms.ListBox ComboCampos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox ComboLLave;
        private System.Windows.Forms.CheckBox CHAuto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox ComboForanes;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.IContainer components;

        public FormGenerarSps(Controladores_DB.MSSQLServer db, string nombreTabla, int modo)
        {
            Modo = modo;
            DB = db;
            NombreTabla = nombreTabla;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboCampos = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ComboParametros = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CHAuto = new System.Windows.Forms.CheckBox();
            this.ComboLLave = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ComboForanes = new System.Windows.Forms.CheckedListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "SPAD_Agregar";
            // 
            // BAceptar
            // 
            this.BAceptar.Location = new System.Drawing.Point(432, 8);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(75, 23);
            this.BAceptar.TabIndex = 2;
            this.BAceptar.Text = "Generar";
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(432, 40);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 3;
            this.BCancelar.Text = "Cerrar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboCampos);
            this.groupBox1.Location = new System.Drawing.Point(8, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 248);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos de la tabla";
            // 
            // ComboCampos
            // 
            this.ComboCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboCampos.Location = new System.Drawing.Point(3, 16);
            this.ComboCampos.Name = "ComboCampos";
            this.ComboCampos.Size = new System.Drawing.Size(194, 225);
            this.ComboCampos.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComboParametros);
            this.groupBox2.Location = new System.Drawing.Point(296, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 232);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros del SP";
            // 
            // ComboParametros
            // 
            this.ComboParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboParametros.Location = new System.Drawing.Point(3, 16);
            this.ComboParametros.Name = "ComboParametros";
            this.ComboParametros.Size = new System.Drawing.Size(194, 212);
            this.ComboParametros.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = ">";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(216, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = ">>";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(216, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "<";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(216, 200);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "<<";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CHAuto);
            this.groupBox3.Controls.Add(this.ComboLLave);
            this.groupBox3.Location = new System.Drawing.Point(8, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 232);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LLave primaria";
            // 
            // CHAuto
            // 
            this.CHAuto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CHAuto.Location = new System.Drawing.Point(3, 205);
            this.CHAuto.Name = "CHAuto";
            this.CHAuto.Size = new System.Drawing.Size(242, 24);
            this.CHAuto.TabIndex = 1;
            this.CHAuto.Text = "Obtener llave automaticamente";
            // 
            // ComboLLave
            // 
            this.ComboLLave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboLLave.Location = new System.Drawing.Point(3, 16);
            this.ComboLLave.Name = "ComboLLave";
            this.ComboLLave.Size = new System.Drawing.Size(242, 212);
            this.ComboLLave.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ComboForanes);
            this.groupBox4.Location = new System.Drawing.Point(264, 312);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 232);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Validar LLaves Foraneas";
            // 
            // ComboForanes
            // 
            this.ComboForanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboForanes.Location = new System.Drawing.Point(3, 16);
            this.ComboForanes.Name = "ComboForanes";
            this.ComboForanes.Size = new System.Drawing.Size(226, 199);
            this.ComboForanes.TabIndex = 0;
            this.ComboForanes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ComboForanes_ItemCheck);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.Items.AddRange(new object[] {
            "Altas",
            "Bajas",
            "Cambios",
            "Lectura"});
            this.comboBox1.Location = new System.Drawing.Point(248, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(248, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tipo";
            // 
            // FormGenerarSps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(514, 544);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGenerarSps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear SP para Agregar";
            this.Load += new System.EventHandler(this.FormNombre_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void FormNombre_Load(object sender, System.EventArgs e)
        {
            comboBox1.SelectedIndex = Modo;
            switch (Modo)
            {
                case 0:
                    this.Nombre = "SPAD_Agregar" + this.NombreTabla.Trim();
                    MuestraLavesForaneas();
                    break;
                case 1:
                    this.Nombre = "SPAD_Eliminar" + this.NombreTabla.Trim();
                    MuestraLavesForaneasHjas();
                    break;
                case 2:
                    this.Nombre = "SPAD_Actualizar" + this.NombreTabla.Trim();
                    MuestraLavesForaneas();
                    break;
                case 3:
                    this.Nombre = "SPAD_Dame" + this.NombreTabla.Trim();
                    MuestraLavesForaneas();
                    break;

            }
            Campos = DB.DameCamposTabla(this.NombreTabla);
            MuestraCampos();
            MuestraPK();

        }
        public string Nombre
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
            }
        }
        private void MuestraCampos()
        {
            //acrgo los campos de la tabla
            int i, n;
            Objetos.CParametro Parametro = null;
            ComboCampos.Items.Clear();
            n = Campos.Count;
            for (i = 0; i < n; i++)
            {
                Parametro = Campos[i];
                ComboCampos.Items.Add(Parametro.nombre);
            }
            if (Parametros == null)
                Parametros = new List<Visor_sql_2005.Objetos.CParametro>();
            ComboParametros.Items.Clear();
            n = Parametros.Count;
            for (i = 0; i < n; i++)
            {
                Parametro = Parametros[i];
                ComboParametros.Items.Add(Parametro.nombre);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Objetos.CParametro Parametro = this.Campos[ComboCampos.SelectedIndex];
            Campos.RemoveAt(ComboCampos.SelectedIndex);
            ComboCampos.Items.RemoveAt(ComboCampos.SelectedIndex);
            Parametros.Add(Parametro);
            ComboParametros.Items.Add(Parametro.nombre);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            int i, n;
            n = Campos.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro Parametro = this.Campos[i];
                Parametros.Add(Parametro);
                ComboParametros.Items.Add(Parametro.nombre);
            }
            Campos.Clear();
            ComboCampos.Items.Clear();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Objetos.CParametro Parametro = this.Parametros[ComboParametros.SelectedIndex];
            Parametros.RemoveAt(ComboParametros.SelectedIndex);
            ComboParametros.Items.RemoveAt(ComboParametros.SelectedIndex);
            Campos.Add(Parametro);
            ComboCampos.Items.Add(Parametro.nombre);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            int i, n;
            n = Parametros.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro Parametro = this.Parametros[i];
                Campos.Add(Parametro);
                ComboCampos.Items.Add(Parametro.nombre);
            }
            Parametros.Clear();
            ComboParametros.Items.Clear();

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            bool ok = true;
            if (textBox1.Text.Trim() == "")
                ok = false;
            switch (Modo)
            {
                case 0://agregar
                    if (ComboCampos.SelectedIndex == -1)
                        button1.Enabled = false;
                    else
                        button1.Enabled = true;
                    if (ComboParametros.SelectedIndex == -1)
                        button3.Enabled = false;
                    else
                        button3.Enabled = true;
                    if (ComboParametros.Items.Count == 0)
                        ok = false;
                    this.BAceptar.Enabled = ok;
                    if (ComboLLave.Items.Count != 1)
                        this.EnableDatosLLave = false;
                    else
                        EnableDatosLLave = true;
                    break;
                case 1: //Eliminar
                    groupBox1.Enabled = false;
                    groupBox4.Enabled = true;
                    CHAuto.Enabled = false;
                    break;
                case 2://agregar
                    if (ComboCampos.SelectedIndex == -1)
                        button1.Enabled = false;
                    else
                        button1.Enabled = true;
                    if (ComboParametros.SelectedIndex == -1)
                        button3.Enabled = false;
                    else
                        button3.Enabled = true;
                    if (ComboParametros.Items.Count == 0)
                        ok = false;
                    this.BAceptar.Enabled = ok;
                    this.EnableDatosLLave = false;
                    break;
                case 3:
                    groupBox4.Enabled = false;
                    if (ComboCampos.SelectedIndex == -1)
                        button1.Enabled = false;
                    else
                        button1.Enabled = true;
                    if (ComboParametros.SelectedIndex == -1)
                        button3.Enabled = false;
                    else
                        button3.Enabled = true;
                    this.BAceptar.Enabled = ok;
                    this.EnableDatosLLave = false;
                    break;
            }
        }
        private void MuestraPK()
        {
            LLaves = DB.DameLLavesPrimarias(this.NombreTabla);
            int i, n;
            n = this.LLaves.Count;
            ComboLLave.Items.Clear();
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro Parametro =LLaves[i];
                ComboLLave.Items.Add(Parametro.nombre);
            }

        }

        private bool EnableDatosLLave
        {
            set
            {
                CHAuto.Enabled = value;
            }
        }
        private void MuestraLavesForaneas()
        {
            ComboForanes.Items.Clear();
            Foraneas = DB.DameLLavesForaneas(this.NombreTabla);
            int i, n;
            n = Foraneas.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CLLaveForanea fk = Foraneas[i];
                ComboForanes.Items.Add(fk.name);
            }
        }
        private void MuestraLavesForaneasHjas()
        {
            ComboForanes.Items.Clear();
            Foraneas = DB.DameLLavesForaneasHijas(this.NombreTabla);
            int i, n;
            n = Foraneas.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CLLaveForanea fk = Foraneas[i];
                ComboForanes.Items.Add(fk.name);
            }
        }

        private void BAceptar_Click(object sender, System.EventArgs e)
        {
            switch (Modo)
            {
                case 0://crear
                    Crear();
                    break;
                case 1:
                    Eliminar();
                    break;
                case 2:
                    Actualizar();
                    break;
                case 3:
                    Dame();
                    break;
            }
            Close();
        }
        private void Crear()
        {
            Objetos.CParametro llave = null;
            System.Collections.Generic.List<Objetos.CParametro> campos;
            campos = DB.DameCamposTabla(this.NombreTabla);
            int i, n;
            string s = "create procedure " + Nombre + "(";
            n = this.Parametros.Count;
            //agrego los campos de la tabla (todos)
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                    s = s + ",";
                Objetos.CParametro Parametro = Parametros[i];
                s = s + "@" + Parametro.nombre + " " + Parametro.TipoSP;
            }
            s = s + ") as\r\n";
            s = s + "begin\r\n";
            s = s + "\t--procedimiento almacenado que agrega un registro a la tabla " + NombreTabla + " \r\n";
            if (CHAuto.Checked == true)
            {
                llave = this.LLaves[0];
                //hay que obtener la llave de forma automatica
                //esto solo aplica cuado el campo es numerico
                s = s + "\tdeclare @" + llave.nombre + " " + llave.TipoSP + " --variable para obtener la llave automaticamente\r\n";
                s = s + "\tif exists( select * from " + this.NombreTabla.Trim() + ")\r\n";
                s = s + "\tbegin\r\n";
                s = s + "\t\t select @" + llave.nombre + "=max(" + llave.nombre + ")+1 from " + this.NombreTabla + " --obtengo un consecutivo\r\n";
                s = s + "\tend\r\n";
                s = s + "\telse\r\n";
                s = s + "\tbegin\r\n";
                s = s + "\t\t select @" + llave.nombre + "=0 --es el primer registro, por lo que empieza en cero\r\n";
                s = s + "\tend\r\n";
            }
            if (ComboForanes.CheckedItems.Count > 0)
            {
                //hay llaves foraneas, por lo que checo si hay que comprobar la integridad
                System.Collections.Generic.List<Objetos.CLLaveForanea> Fks = new System.Collections.Generic.List<Objetos.CLLaveForanea>();
                n = ComboForanes.CheckedIndices.Count;
                for (i = 0; i < n; i++)
                {
                    //creo la lista de llaves foraneas que hay que checar
                    Fks.Add(Foraneas[ComboForanes.CheckedIndices[i]]);
                }
                n = Fks.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CLLaveForanea fk = Fks[i];
                    System.Collections.Generic.List<Objetos.CCampoFK> lista = DB.DameCamposFK(fk.id);
                    int j, k;
                    k = lista.Count;
                    Objetos.CCampoFK cfk = null;
                    if (fk.Comentarios.Trim() != "")
                        s = s + "\t--" + fk.Comentarios + "\r\n";

                    for (j = 0; j < k; j++)
                    {
                        cfk = lista[j];
                        if (j == 0)
                            s = s + "\tif not exists( select * from " + cfk.maestra + " where " + cfk.columnaMaestra + "=@" + cfk.columnahija;
                        else
                            s = s + " and " + cfk.columnaMaestra + "=@" + cfk.columnahija; ;
                    }
                    s = s + ")\r\n";
                    s = s + "\tbegin\r\n";
                    s = s + "\t\t--no se ncontro el campo de la llave foranea \r\n";
                    s = s + "\t\t--por lo que genero una ecepcion \r\n";
                    s = s + "\t\tRAISERROR ('" + fk.Mensage + "', 16, 1) \r\n";
                    s = s + "\t\treturn \r\n";
                    s = s + "\tend\r\n";
                }
            }
            s = s + "\t --agregar el codigo adicional aqui\r\n";
            s = s + "\tinsert into " + NombreTabla + "(";
            n = Parametros.Count;
            if (CHAuto.Checked == true)
            {
                s = s + llave.nombre;
                if (n > 0)
                    s = s + ",";
            }
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                    s = s + ",";
                Objetos.CParametro Parametro = Parametros[i];
                s = s + Parametro.nombre;
            }
            s = s + ")\r\n";
            s = s + "\tvalues(";
            if (CHAuto.Checked == true)
            {
                s = s + "@"+llave.nombre;
                if (n > 0)
                    s = s + ",";
            }
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                    s = s + ",";
                Objetos.CParametro Parametro = Parametros[i];
                s = s + "@" + Parametro.nombre;
            }
            s = s + ")\r\n";
            s = s + "end\r\n";
            if (OnCodigo != null)
                OnCodigo(textBox1.Text,s);
        }
        private void Eliminar()
        {
            string s = "create procedure " + this.Nombre + "(";
            //obtengo los parametros
            System.Collections.Generic.List<Objetos.CParametro> llaves = DB.DameLLavesPrimarias(this.NombreTabla);
            int i, n = llaves.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro pa = llaves[i];
                if (i > 0)
                    s = s + ",";
                s = s + "@" + pa.nombre + " " + pa.TipoSP;
            }
            s = s + ") as\r\n";
            s = s + "begin\r\n";
            s = s + "\t--procedimiento almacenado que borra un registro de la tabla " + this.NombreTabla + " \r\n";
            //------------------------------------------------------------------------
            if (ComboForanes.CheckedItems.Count > 0)
            {
                //hay llaves foraneas, por lo que checo si hay que comprobar la integridad
                System.Collections.Generic.List<Objetos.CLLaveForanea> Fks = new System.Collections.Generic.List<Objetos.CLLaveForanea>();
                n = ComboForanes.CheckedIndices.Count;
                for (i = 0; i < n; i++)
                {
                    //creo la lista de llaves foraneas que hay que checar
                    Fks.Add(Foraneas[ComboForanes.CheckedIndices[i]]);
                }
                n = Fks.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CLLaveForanea fk = Fks[i];
                    System.Collections.Generic.List<Objetos.CCampoFK> lista = DB.DameCamposFK(fk.id);
                    int j, k;
                    k = lista.Count;
                    Objetos.CCampoFK cfk = null;
                    if (fk.Eliminar == false)
                    {
                        for (j = 0; j < k; j++)
                        {
                            cfk = lista[j];
                            if (j == 0)
                            {
                                if (fk.Comentarios.Trim() == "")
                                    s = s + "\t--Verifico la existencia de registros en la tabla " + cfk.hija + "\r\n";
                                else
                                    s = s + "\t--" + fk.Comentarios + "\r\n";
                                s = s + "\tif exists( select * from " + cfk.hija + " where " + cfk.columnaMaestra + "=@" + cfk.columnahija;
                            }
                            else
                                s = s + " and " + cfk.columnaMaestra + "=@" + cfk.columnahija; ;
                        }
                        s = s + ")\r\n";
                        s = s + "\tbegin\r\n";
                        s = s + "\t\t--Genero un error \r\n";
                        s = s + "\t\tRAISERROR (\'" + fk.Mensage + "\', 16, 1) \r\n";
                        s = s + "\t\treturn \r\n";
                        s = s + "\tend\r\n";
                    }
                    else
                    {
                        // hay que eliniar la tabla hija
                        for (j = 0; j < k; j++)
                        {
                            cfk = lista[j];
                            if (j == 0)
                            {
                                if (fk.Comentarios.Trim() == "")
                                    s = s + "\t--Elimino la tabla " + cfk.hija + "\r\n";
                                else
                                    s = s + "\t--" + fk.Comentarios + "\r\n";

                                s = s + "\tdelete  " + cfk.hija + " where " + cfk.columnaMaestra + "=@" + cfk.columnahija;
                            }
                            else
                                s = s + " and " + cfk.columnaMaestra + "=@" + cfk.columnahija;
                        }
                        s = s + "\r\n";
                    }
                }
            }
            //--------------------------------------------------------------------------------
            s = s + "\t-- agregar el codigo para las comprobaciones adicionales aqui\r\n";
            s = s + "\t-- Elimino la tbala " + NombreTabla + " \r\n";
            s = s + "\tdelete " + NombreTabla + " where ";
            n = llaves.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro pa = llaves[i];
                if (i > 0)
                    s = s + " and ";
                s = s + pa.nombre + "=@" + pa.nombre;
            }
            s = s + "\r\nend\r\n";
            if (OnCodigo != null)
                OnCodigo(textBox1.Text, s);
        }
        private void Actualizar()
        {
            System.Collections.Generic.List<Objetos.CParametro> campos;
            campos = DB.DameCamposTabla(this.NombreTabla);
            System.Collections.Generic.List<Objetos.CParametro> llaves = DB.DameLLavesPrimarias(this.NombreTabla);
            int i, n;
            //genero la lista de parametros
            System.Collections.Generic.List<Objetos.CParametro> camposParametro = new List<Visor_sql_2005.Objetos.CParametro>();
            //lo primero que agrego, son los campos llave que requiero
            foreach (Objetos.CParametro p in llaves)
            {
                camposParametro.Add(p);
            }
            //ahora agrego los demas campos que me dio el usuario
            foreach (Objetos.CParametro p2 in Parametros)
            {
                //checo si esta en la lista de parametros
                bool esta = false;
                foreach (Objetos.CParametro p3 in camposParametro)
                {
                    if (p3.nombre == p2.nombre)
                    {
                        esta = true;
                        break;
                    }
                }
                if(esta==false)
                    camposParametro.Add(p2);
            }

            string s = "create procedure " + Nombre + "(";
            n = camposParametro.Count;
            //agrego los campos de la tabla (todos)
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                    s = s + ",";
                Objetos.CParametro Parametro = camposParametro[i];
                s = s + "@" + Parametro.nombre + " " + Parametro.TipoSP;
            }
            s = s + ") as\r\n";
            s = s + "begin\r\n";
            s = s + "\t--procedimiento almacenado que modifica un registro a la tabla " + NombreTabla + " \r\n";
            if (ComboForanes.CheckedItems.Count > 0)
            {
                //hay llaves foraneas, por lo que checo si hay que comprobar la integridad
                System.Collections.Generic.List<Objetos.CLLaveForanea> Fks = new System.Collections.Generic.List<Objetos.CLLaveForanea>();
                n = ComboForanes.CheckedIndices.Count;
                for (i = 0; i < n; i++)
                {
                    //creo la lista de llaves foraneas que hay que checar
                    Fks.Add(Foraneas[ComboForanes.CheckedIndices[i]]);
                }
                n = Fks.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CLLaveForanea fk = Fks[i];
                    System.Collections.Generic.List<Objetos.CCampoFK> lista = DB.DameCamposFK(fk.id);
                    int j, k;
                    k = lista.Count;
                    Objetos.CCampoFK cfk = null;
                    if (fk.Comentarios.Trim() != "")
                        s = s + "\t--" + fk.Comentarios + "\r\n";
                    for (j = 0; j < k; j++)
                    {
                        cfk = lista[j];
                        if (j == 0)
                            s = s + "\tif not exists( select * from " + cfk.maestra + " where " + cfk.columnaMaestra + "=@" + cfk.columnahija;
                        else
                            s = s + " and " + cfk.columnaMaestra + "=@" + cfk.columnahija; ;
                    }
                    s = s + ")\r\n";
                    s = s + "\tbegin\r\n";
                    s = s + "\t\t--no se ncontro el campo de la llave foranea \r\n";
                    s = s + "\t\t--por lo que genero una ecepcion \r\n";
                    s = s + "\t\tRAISERROR ('" + fk.Mensage + "', 16, 1) \r\n";
                    s = s + "\t\treturn \r\n";
                    s = s + "\tend\r\n";
                }
            }
            s = s + "\t --agregar el codigo adicional aqui\r\n";
            s = s + "\tupdate  " + NombreTabla + " set ";
            n = Parametros.Count;
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                    s = s + ",";
                Objetos.CParametro Parametro = Parametros[i];
                s = s + Parametro.nombre + "=@" + Parametro.nombre;
            }
            s = s + " where ";
            n = LLaves.Count;
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                    s = s + " and ";
                Objetos.CParametro llave = this.LLaves[i];
                s = s + llave.nombre + "=@" + llave.nombre;
            }
            s = s + "\r\nend\r\n";
            if (OnCodigo != null)
                OnCodigo(textBox1.Text, s);
        }
        private void Dame()
        {
            System.Collections.Generic.List<Objetos.CParametro> campos;
            campos = DB.DameCamposTabla(this.NombreTabla);
            int i, n;
            string s = "create procedure " + Nombre;
            n = this.Parametros.Count;
            if (n > 0)
                s = s + "(";
            //agrego los campos de la tabla (todos)
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                    s = s + ",";
                Objetos.CParametro Parametro = Parametros[i];
                s = s + "@" + Parametro.nombre + " " + Parametro.TipoSP;
            }
            if (n > 0)
                s = s + ") as\r\n";
            else
                s = s + " as\r\n";
            s = s + "begin\r\n";
            s = s + "\t--procedimiento almacenado que obtiene datos de la tabla " + NombreTabla + " \r\n";
            s = s + "\t --agregar el codigo adicional aqui\r\n";
            s = s + "\tselect * from " + NombreTabla;
            n = this.Parametros.Count;
            if (n > 0)
                s = s + " where ";
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                    s = s + " and ";
                Objetos.CParametro Parametro = Parametros[i];
                s = s + Parametro.nombre + "=@" + Parametro.nombre;
            }
            s = s + "\r\nend\r\n";
            if (OnCodigo != null)
                OnCodigo(textBox1.Text, s);
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Modo = comboBox1.SelectedIndex;
            switch (Modo)
            {
                case 0:
                    this.Nombre = "SPAD_Agregar" + this.NombreTabla.Trim();
                    break;
                case 1:
                    this.Nombre = "SPAD_Eliminar" + this.NombreTabla.Trim();
                    break;
                case 2:
                    this.Nombre = "SPAD_Actualizar" + this.NombreTabla.Trim();
                    break;
                case 3:
                    this.Nombre = "SPAD_Dame" + this.NombreTabla.Trim();
                    break;

            }
        }


        private void ComboForanes_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            if (e.Index == -1)
                return;

            if (e.NewValue == System.Windows.Forms.CheckState.Checked)
            {
                Objetos.CLLaveForanea fk;
                fk = this.Foraneas[e.Index];
                FormAccion dlg = new FormAccion(Modo); 
                dlg.Eliminar = fk.Eliminar;
                dlg.Comentarios = fk.Comentarios;
                System.Collections.Generic.List<Objetos.CCampoFK> lista = DB.DameCamposFK(fk.id);
                Objetos.CCampoFK cfk = lista[0];
                if (this.Modo == 1)
                    dlg.Tabla = cfk.hija;
                else
                    dlg.Tabla = cfk.maestra;
                dlg.Mensaje = fk.Mensage;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.NewValue = System.Windows.Forms.CheckState.Unchecked;
                    return;
                }
                fk.Eliminar = dlg.Eliminar;
                fk.Mensage = dlg.Mensaje;
                fk.Comentarios = dlg.Comentarios;
            }
        }
    }
}
