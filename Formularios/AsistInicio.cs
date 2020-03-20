using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Visor_sql_2015.Formularios
{
    public partial class AsistInicio : AsisBase
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.ComponentModel.IContainer components = null;

        public AsistInicio()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CHStatic = new System.Windows.Forms.CheckBox();
            this.CHCrearSqlConnection = new System.Windows.Forms.CheckBox();
            this.CHLeerConfiguracion = new System.Windows.Forms.CheckBox();
            this.TConfiguracion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LTitulo
            // 
            this.LTitulo.Size = new System.Drawing.Size(568, 40);
            this.LTitulo.Text = "NOMBRE DEL PROCEDIMIENTO";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "textBox1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(16, 144);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(328, 24);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Agregar Codigo para crear el componente de comando";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CHStatic
            // 
            this.CHStatic.Location = new System.Drawing.Point(16, 174);
            this.CHStatic.Name = "CHStatic";
            this.CHStatic.Size = new System.Drawing.Size(328, 24);
            this.CHStatic.TabIndex = 5;
            this.CHStatic.Text = "Función estática";
            // 
            // CHCrearSqlConnection
            // 
            this.CHCrearSqlConnection.Location = new System.Drawing.Point(16, 204);
            this.CHCrearSqlConnection.Name = "CHCrearSqlConnection";
            this.CHCrearSqlConnection.Size = new System.Drawing.Size(328, 24);
            this.CHCrearSqlConnection.TabIndex = 6;
            this.CHCrearSqlConnection.Text = "Crear el SqlConnection";
            // 
            // CHLeerConfiguracion
            // 
            this.CHLeerConfiguracion.Location = new System.Drawing.Point(16, 234);
            this.CHLeerConfiguracion.Name = "CHLeerConfiguracion";
            this.CHLeerConfiguracion.Size = new System.Drawing.Size(374, 24);
            this.CHLeerConfiguracion.TabIndex = 7;
            this.CHLeerConfiguracion.Text = "Obtener la cadena de conexión desde la configuración de la pagina asp";
            this.CHLeerConfiguracion.CheckedChanged += new System.EventHandler(this.CHLeerConfiguracion_CheckedChanged);
            // 
            // TConfiguracion
            // 
            this.TConfiguracion.Location = new System.Drawing.Point(397, 234);
            this.TConfiguracion.Name = "TConfiguracion";
            this.TConfiguracion.Size = new System.Drawing.Size(139, 20);
            this.TConfiguracion.TabIndex = 8;
            // 
            // AsistInicio
            // 
            this.Controls.Add(this.TConfiguracion);
            this.Controls.Add(this.CHLeerConfiguracion);
            this.Controls.Add(this.CHCrearSqlConnection);
            this.Controls.Add(this.CHStatic);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "AsistInicio";
            this.Size = new System.Drawing.Size(568, 310);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.LTitulo, 0);
            this.Controls.SetChildIndex(this.CHStatic, 0);
            this.Controls.SetChildIndex(this.CHCrearSqlConnection, 0);
            this.Controls.SetChildIndex(this.CHLeerConfiguracion, 0);
            this.Controls.SetChildIndex(this.TConfiguracion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public override void Muestrate()
        {
            Dock = System.Windows.Forms.DockStyle.Fill;
            this.Visible = true;
            this.EnableAnterio = false;
            this.EnableSiguiente = true;
            this.EnableCancelar = true;
            Asigname(this);
            //			RNA_CheckedChanged(null,null);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //bool ok = true;
            bool BEnableSiguiente = true;
            if (Visible == false)
                return;
            if (CHCrearSqlConnection.Checked == false)
            {
                //desactivo los controles que dependen de el
                CHLeerConfiguracion.Checked = false;
                CHLeerConfiguracion.Enabled = false;
                TConfiguracion.Text = "";
                TConfiguracion.Enabled = false;
            }
            else
            {
                CHLeerConfiguracion.Enabled = true;
            }
            //verifico los siguientes componentes
            if (CHLeerConfiguracion.Checked == false)
            {
                TConfiguracion.Text = "";
                TConfiguracion.Enabled = false;
            }
            else
                TConfiguracion.Enabled = true;
            if (TConfiguracion.Enabled == true && TConfiguracion.Text.Trim()=="")
                BEnableSiguiente = false;
            //valido los componenetes
            if (textBox1.Text.Trim() == "")
                BEnableSiguiente = false;
            EnableSiguiente = BEnableSiguiente;
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private CheckBox CHStatic;
        private CheckBox CHCrearSqlConnection;
        private CheckBox CHLeerConfiguracion;
        private TextBox TConfiguracion;

        public string Nombre
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        public bool CrearComponente
        {
            get
            {
                return checkBox1.Checked;
            }
        }
        public bool Estatica
        {
            get
            {
                return CHStatic.Checked;
            }
        }
        public bool CrearSqlConnection
        {
            get
            {
                return CHCrearSqlConnection.Checked;
            }
        }
        public bool LeerConfiguracionASP
        {
            get
            {
                return CHLeerConfiguracion.Checked;
            }
        }
        public string SConnectionStrings
        {
            get
            {
                if (TConfiguracion.Text.Trim() != "")
                {
                    StreamWriter sw;
                    sw = File.CreateText("TConfiguracion.txt");
                    sw.WriteLine(TConfiguracion.Text);
                    sw.Close();
                }
                return TConfiguracion.Text;
            }
        }

        private void CHLeerConfiguracion_CheckedChanged(object sender, EventArgs e)
        {
            if (CHLeerConfiguracion.Checked == true)
            {
                //leo del archivo el ultimo dato

                if (File.Exists("TConfiguracion.txt") == false)
                {
                    return;
                }
                StreamReader sr;
                sr=File.OpenText("TConfiguracion.txt");
                TConfiguracion.Text = sr.ReadLine();
                sr.Close();
            }
        }
    }
}

