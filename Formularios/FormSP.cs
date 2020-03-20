using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public delegate void OnCodigoSPEvent(string Nombre, string Codigo);
    public partial class FormSPX : FormBase
    {
        private bool ControlV;
        private int ControlVI;
        private string Tabuladores;
        int RataX, RataY;
        System.Windows.Forms.ListBox TMensage;
        public event OnVerObjetoEvent OnVerObjeto;
        //bool NoCambio;
        System.Collections.Generic.List<Objetos.CRestaurar> Cambios;
        public event OnCodigoSPEvent OnCodigoSP;
        public event OnCodigoSPEvent OnDependencias;
        public event OnCodigoSPEvent OnDependientes;
        Controladores_DB.IDataBase DB;
        public FormSPX(string Nombre, Controladores_DB.IDataBase db)
        {
            Cambios = new List<Objetos.CRestaurar>();
//            NoCambio = false;
            DB = db;
            InitializeComponent();
            TNombre.Text = Nombre;
            Text = Nombre;
            CargaColor();
            cTextColor1.AgregarPalabraReservada("nvarchar");
            cTextColor1.AgregarPalabraReservada("max");
            cTextColor1.AgregarPalabraReservada("getdate");
            cTextColor1.AgregarPalabraReservada("count");
            cTextColor1.AgregarPalabraReservada("key");
            cTextColor1.AgregarPalabraReservada("namespace");
            cTextColor1.AgregarPalabraReservada("isnull");
            cTextColor1.AgregarPalabraReservada("len");
            cTextColor1.AgregarPalabraReservada("substring");
            cTextColor1.AgregarPalabraReservada("isnumeric");
            cTextColor1.AgregarPalabraReservada("rtrim");
            cTextColor1.AgregarPalabraReservada("ltrim");
            cTextColor1.AgregarPalabraReservada("sum");
            cTextColor1.AnalizaTexto();
        }

        private void FormSP_Load(object sender, EventArgs e)
        {
            //Left = 280;
            //Width = 995;
            //Height = 700;
            try
            {
                splitContainer1.SplitterDistance = Height;
            }
            catch (System.Exception)
            {
                ;
            }
            Lfecha.Text = "Fecha de modificacion: " + DB.DameFechaModificacion(TNombre.Text);
            TCodigo.Text = DB.DameCodigo(TNombre.Text);
            cTextColor1.AnalizaTexto();
            for (int i = 1; i <= 500; i++)
            {
                ComboZoom.Items.Add(i.ToString());
            }
            Zoom = TCodigo.ZoomFactor;
        }
        private float Zoom
        {
            get
            {
                int x = ComboZoom.SelectedIndex + 1;
                float f = (float)x / (float)100;
                return f;
            }
            set
            {
                if (value > 1)
                    return;
                float x = value * 100;
                ComboZoom.SelectedIndex = (int)x - 1;
            }
        }
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void generarCodigoDeCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreaCodigoProcedimiento();
        }
        private bool TipoBasico(string s)
        {
            if (s == "int")
                return true;
            if (s == "float")
                return true;
            if (s == "string")
                return true;
            return false;

        }
        private void CreaCodigoProcedimiento()
        {
            string NombreProcedimiento;
            System.Collections.Generic.List<Objetos.CParametro> CamposARegresar;
            FormProcedimiento dlg = new FormProcedimiento(DB, TNombre.Text);
            dlg.Nombre = TNombre.Text;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            NombreProcedimiento = TNombre.Text;
            if (dlg.Nombre == TNombre.Text)
                NombreProcedimiento = "SqlCommand1";
            //obtengo la lista de parametros de la funcion
            System.Collections.Generic.List<Objetos.CParametro> Parametros = DB.DameParametrosDeProcedimiento(TNombre.Text);
            string s;
            //creo la cabecera de la funcion
            s = "#region ";
            string s2 = "";
            if (dlg.Estatica == true)
                s2 = s2 + "public static " + dlg.Retorno + " " + dlg.Nombre + "(";
            else
                s2 = s2 + "public " + dlg.Retorno + " " + dlg.Nombre + "(";
            Objetos.CConvertidor conv = new Objetos.CConvertidor();
            int i, n;
            n = Parametros.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro pa = Parametros[i];
                if (i > 0)
                    s2 = s2 + ",";
                s2 = s2 + pa.DameCadena();
            }
            s2 = s2 + ")\r\n";
            s = s + s2 + s2;
            s += "{\r\n";
            if (dlg.TipoRetornoX == ENUMTipoRetorno.LISTA_GENERICA)
                s += "\t\tSystem.Collections.Generic.List<" + dlg.Clase + "> lista=new System.Collections.Generic.List<" + dlg.Clase + ">();\r\n";
            if (dlg.TipoRetornoX == ENUMTipoRetorno.LISTA)
                s += "\t\tSystem.Collections.ArrayList lista=new System.Collections.ArrayList();\r\n";
            if (dlg.TipoRetornoX == ENUMTipoRetorno.DATO)
                s += "\t\t" + dlg.Clase + " dato;\r\n";
            n = Parametros.Count;
            if (dlg.CrearSqlConnection)
            {
                s += "\t//Creando el componente de conexión\r\n";
                s += "\tSystem.Data.SqlClient.SqlConnection Conexion;";
                s += "\tConexion = new System.Data.SqlClient.SqlConnection();\r\n";
                if (dlg.LeerConfiguracionASP)
                {
                    s += "\tSystem.Configuration.ConnectionStringSettings cs = System.Configuration.ConfigurationManager.ConnectionStrings[\"" + dlg.SConnectionStrings + "\"];\r\n";
                    s += "\tConexion.ConnectionString = ConvierteCadena(cs.ConnectionString);\r\n";
                }
                else
                {
                    s += "\t//Conexion.ConnectionString =Colocar la cadena de conexion aqui\r\n";
                }
            }

            if (dlg.CrearComponente)
            {
                s += "\t//CREANDO EL PROCEDIMIENTO ALMACENADO " + TNombre.Text + "\r\n";
                s += "\r\n";
                s += "\tSystem.Data.SqlClient.SqlCommand " + NombreProcedimiento + ";\r\n";
                s += "\t" + NombreProcedimiento + "= new System.Data.SqlClient.SqlCommand();\r\n";
                s += "\t" + NombreProcedimiento + ".CommandText = \"[" + TNombre.Text + "]\";\r\n";
                s += "\t" + NombreProcedimiento + ".CommandType = System.Data.CommandType.StoredProcedure;\r\n";
                if (dlg.Estatica == true)
                    s += "\t" + NombreProcedimiento + ".Connection = Conexion;//remplzar por el componente de conexion adecuado\r\n";
                else
                    s += "\t" + NombreProcedimiento + ".Connection = this.Conexion;//remplzar por el componente de conexion adecuado\r\n";
                s += "\r\n";
                s += "\t//CREANDO PARAMETROS\r\n";
                s += "\r\n";
                s += "\t" + NombreProcedimiento + ".Parameters.Add(new System.Data.SqlClient.SqlParameter(\"@RETURN_VALUE\", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), \"\", System.Data.DataRowVersion.Current, null));\r\n";
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro pa = Parametros[i];
                    s += "\t" + NombreProcedimiento + ".Parameters.Add(new System.Data.SqlClient.SqlParameter(\"" + pa.nombre + "\"," + pa.TipoNet + "," + pa.Logitud + "));\r\n";
                }
            }
            //asigno parametros
            s += "\r\n";
            s += "\t//ASIGNANDO PARAMETROS\r\n";
            s += "\r\n";
            for (i = 0; i < n; i++)
            {
                Objetos.CParametro pa = Parametros[i];
                s += "\t" + NombreProcedimiento + ".Parameters[\"" + pa.nombre + "\"].Value=" + pa.nombreC + ";\r\n";
            }
            s += "\t" + NombreProcedimiento + ".Connection.Open();\r\n";
            s += "\ttry\r\n";
            s += "\t{\r\n";
            if (dlg.RegresaDatos == false)
            {
                s += "\t\t" + NombreProcedimiento + ".ExecuteNonQuery();\r\n";
                s += "\t}\r\n";
                s += "\tcatch(System.Exception ex)\r\n";
                s += "\t{\r\n";
                s += "\t\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "\t\tthrow new Exception(ex.Message);\r\n";
                s += "\t}\r\n";
                s += "\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "}\r\n";
                s += "#endregion\r\n";
                if (OnCodigoSP != null)
                    OnCodigoSP(TNombre.Text + " C#", s);
                return;
            }
            //regresa datos
            if (dlg.TipoRetornoX == ENUMTipoRetorno.DATO)
            {
                //hay que regresar un dato
                s += "\t\t//RECUPERANDO DATOS\r\n";
                s += "\t\tSystem.Data.SqlClient.SqlDataReader dr;\r\n";
                s += "\t\tdr=" + NombreProcedimiento + ".ExecuteReader();\r\n";
                s += "\t\tdr.Read();\r\n";
                if (TipoBasico(dlg.Clase) == false)
                    s += "\t\tdato=new " + dlg.Clase + "();\r\n";
                CamposARegresar = dlg.CamposRegresar;
                n = CamposARegresar.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro par = CamposARegresar[i];
                    if (par.TipoNet == "int")
                    {
                        s += "\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\tdato." + par.nombre + "=int.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        else
                            s += "\t\t\tdato=int.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s = s + "\t\telse\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\tdato." + par.nombre + "=0;\r\n";
                        else
                            s += "\t\t\tdato=0;\r\n";
                    }
                    else if (par.TipoNet == "System.DateTime")
                    {
                        s += "\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\tdato." + par.nombre + "=System.DateTime.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        else
                            s += "\t\t\tdato=System.DateTime.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\telse\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\tdato." + par.nombre + "=System.DateTime.Now.Date;\r\n";
                        else
                            s += "\t\t\tdato=System.DateTime.Now.Date;\r\n";
                    }
                    if (par.TipoNet == "float")
                    {
                        s += "\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\t\tdato." + par.nombre + "=float.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        else
                            s += "\t\t\tdato=float.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\telse\r\n";
                        s += "\t\t\tdato." + par.nombre + "=0;\r\n";
                    }
                    if (par.TipoNet == "string")
                    {
                        if (TipoBasico(dlg.Clase) == false)
                            s += "\t\tdato." + par.nombre + "=dr[\"" + par.nombre + "\"].ToString();\r\n";
                        else
                            s += "\t\tdato=dr[\"" + par.nombre + "\"].ToString();\r\n";
                    }
                }
                s += "\t}\r\n";
                s += "\tcatch(System.Exception ex)\r\n";
                s += "\t{\r\n";
                s += "\t\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "\t\tthrow new Exception(ex.Message);\r\n";
                s += "\t}\r\n";
                s += "\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "\treturn dato;\r\n";
                s += "}\r\n";
                s += "#endregion\r\n";
                if (OnCodigoSP != null)
                    OnCodigoSP(TNombre.Text + " C#", s);
                return;
            }
            if (dlg.TipoRetornoX == ENUMTipoRetorno.LISTA || dlg.TipoRetornoX == ENUMTipoRetorno.LISTA_GENERICA)
            {
                //hay que regresar un dato
                s += "\t\t//RECUPERANDO DATOS\r\n";
                s += "\t\tSystem.Data.SqlClient.SqlDataReader dr;\r\n";
                s += "\t\tdr=" + NombreProcedimiento + ".ExecuteReader();\r\n";
                s += "\t\twhile(dr.Read())\r\n";
                s += "\t\t{\r\n";
                s += "\t\t\t" + dlg.Clase + " dato=new " + dlg.Clase + "();\r\n";
                CamposARegresar = dlg.CamposRegresar;
                n = CamposARegresar.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro par = CamposARegresar[i];
                    if (par.TipoNet == "int")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=int.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=0;\r\n";
                    }
                    else if (par.TipoNet == "System.DateTime")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=System.DateTime.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=System.DateTime.Now.Date;\r\n";
                    }
                    if (par.TipoNet == "float")
                    {
                        s += "\t\t\tif(dr[\"" + par.nombre + "\"].ToString().Trim()!=\"\")\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=float.Parse(dr[\"" + par.nombre + "\"].ToString());\r\n";
                        s += "\t\t\telse\r\n";
                        s += "\t\t\t\tdato." + par.nombre + "=0;\r\n";
                    }
                    if (par.TipoNet == "string")
                    {
                        s += "\t\t\tdato." + par.nombre + "=dr[\"" + par.nombre + "\"].ToString();\r\n";
                    }
                }
                s += "\t\t\tlista.Add(dato);\r\n";
                s += "\t\t}\r\n";
                s += "\t}\r\n";
                s += "\tcatch(System.Exception ex)\r\n";
                s += "\t{\r\n";
                s += "\t\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "\t\tthrow new Exception(ex.Message);\r\n";
                s += "\t}\r\n";
                s += "\t" + NombreProcedimiento + ".Connection.Close();\r\n";
                s += "\treturn lista;\r\n";
                s += "}\r\n";
                s += "#endregion\r\n";
                if (OnCodigoSP != null)
                    OnCodigoSP(TNombre.Text + " C#", s);
                return;
            }
            s += "\t\tSystem.Data.SqlClient.SqlDataReader dr;\r\n";
            s += "\t\tdr=" + NombreProcedimiento + ".ExecuteReader();\r\n";
            s += "\t\twhile(dr.Read())\r\n";
            s += "\t\t{\r\n";
            s += "\t\t\t//agregar el codigo para leer los datos aqui\r\n";
            s += "\t\t\t//=dr[\"\"].ToString();\r\n";
            s += "\t\t}\r\n";
            s += "\t}\r\n";
            s += "\tcatch(System.Exception ex)\r\n";
            s += "\t{\r\n";
            s += "\t\t" + NombreProcedimiento + ".Connection.Close();\r\n";
            s += "\t\tthrow new Exception(ex.Message);\r\n";
            s += "\t}\r\n";
            s += "\t" + NombreProcedimiento + ".Connection.Close();\r\n";
            s += "}\r\n";
            s += "#endregion\r\n";
            if (OnCodigoSP != null)
                OnCodigoSP(TNombre.Text + " C#", s);
        }

        private void verDependenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnDependencias != null)
                OnDependencias("Dependencia de " + TNombre.Text, TNombre.Text);
        }

        private void verDependientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnDependientes != null)
                OnDependientes("Dependientes de " + TNombre.Text, TNombre.Text);
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int x = TCodigo.SelectionStart + TCodigo.SelectionLength;
            if (TCodigo.Find(toolStripTextBox1.Text, x, RichTextBoxFinds.None) == -1)
            {
                MessageBox.Show("No se encontro el elemento " + toolStripTextBox1.Text);
                TCodigo.SelectionStart = 0;
                TCodigo.SelectionLength = 0;
            }
        }
        private void BucaCampoTabla(KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                contextMenuStrip1.Items.Clear();
                List<Objetos.CAlias> Alias = new List<Visor_sql_2015.Objetos.CAlias>(); ;
                List<AnalizadorLexico.CLexema> Lexemas;
                //cargo todos los lexemas del codigo en la lista
                Lexemas = new List<AnalizadorLexico.CLexema>();
                cAnaLex1.Texto = TCodigo.Text;
                AnalizadorLexico.CLexema lex = null;
                AnalizadorLexico.CLexema lex2 = null;
                do
                {
                    lex = cAnaLex1.DameItem();
                    if (lex != null)
                    {
                        Lexemas.Add(lex);
                        //checo si es un alias
                        if (lex.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                        {
                            if (lex2 != null)
                            {
                                if (lex2.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                                {
                                    //veo si es una tabla
                                    Controladores_DB.CNodoTabla nt1;
                                    nt1 = DB.BuscaEnTabla(lex2.cadena);
                                    if (nt1 != null)
                                    {
                                        //encontre un alias
                                        Objetos.CAlias al = new Visor_sql_2015.Objetos.CAlias();
                                        al.Item = lex;
                                        al.tabla = nt1;
                                        Alias.Add(al);
                                    }
                                }
                            }
                            lex2 = lex;
                        }
                    }
                }
                while (lex != null);
                //ta tego todos los lexemas en memosria;
                //ahora busco el que esta justo antes del punto
                int posPunto = TCodigo.SelectionStart;
                int i, n, px = -1;
                n = Lexemas.Count;
                for (i = 0; i < n; i++)
                {
                    lex = Lexemas[i];
                    if (posPunto >= lex.Pos && posPunto <= lex.Pos + lex.cadena.Length)
                    {
                        //ya tengo la posicion del punto que escribieron
                        px = i;
                        break;
                    }
                }
                //ahora me traigo el lexema que esta atras del punto
                if (px == -1)
                    return;
                lex = Lexemas[px];
                //puede ser que es el nombre de una tabla
                Controladores_DB.CNodoTabla nt;
                if (lex.Tipo != AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                {
                    //no es un identificador, por lo que puerde ser un numero
                    //asi que no hago nada
                    return;
                }
                nt = DB.BuscaEnTabla(lex.cadena);
                if (nt != null)
                {
                    //es el nombre de una tabla, ai que cargo sus campos para mostrarlos
                    foreach (Objetos.CParametro campo in nt.Campos)
                    {
                        ToolStripItem nodo;
                        nodo = contextMenuStrip1.Items.Add(campo.nombre);
                        nodo.Tag = campo.tipo + "(" + campo.Logitud + ") NULL=" + campo.NULOS;
                        nodo.Click += new EventHandler(OnMenu_Click);
                    }
                    MuestraOpciones();
                    return;
                }
                //no es una tabla, porlo que veo si es un alias
                //busco todos loa alias que encuentre en el docuemnto
                foreach (Objetos.CAlias al2 in Alias)
                {
                    if (al2.Item.cadena.ToLower().Trim() == lex.cadena.ToLower().Trim())
                    {
                        //encontre el alias que le corresponde
                        foreach (Objetos.CParametro campo in al2.tabla.Campos)
                        {
                            ToolStripItem nodo;
                            nodo = contextMenuStrip1.Items.Add(campo.nombre);
                            nodo.Tag = campo.tipo + "(" + campo.Logitud + ") NULL=" + campo.NULOS;
                            nodo.Click += new EventHandler(OnMenu_Click);
                        }
                        MuestraOpciones();
                        return;
                    }
                }
            }
            TCodigo.ContextMenuStrip = null;
        }
        private void TCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            if (e.KeyChar == ' ')
            {
              VerificaEspacio(e);
              return;
            }
            if (e.KeyChar == '.')
            {
                BucaCampoTabla(e);
                return;
            }
            if ((int)e.KeyChar == 2)
            {
                //fue contro + t
                int n = TCodigo.SelectionStart - 1;
                int SelectionStart = TCodigo.SelectionStart;
                string s = TCodigo.Text;
                //me regreso hasta encontrar un separador
                while (n > 0 && s[n] != ' ' && s[n] != '\t' && s[n] != '\r' && s[n] != '\n')
                    n--;
                n++;
                //ya tengo la posicion del texo,ahora me traigo la cadena
                string s2 = "";
                while (n < TCodigo.SelectionStart)
                {
                    s2 = s2 + s[n];
                    n++;
                }
                //eso quiere decir que quiere la lista de tablas
                List<Objetos.CSysObject> tablas;
                if (s2 == "")
                    return;
                tablas = DB.BuscaObjetos(s2, Visor_sql_2015.Controladores_DB.TIPOOBJETO.NINGUNO);
                foreach (Objetos.CSysObject obj in tablas)
                {
                    ToolStripItem nodo;
                    nodo = contextMenuStrip1.Items.Add(obj.Nombre);
                    nodo.Click += new EventHandler(OnMenu_Click2);
                }
                TCodigo.SelectionStart = TCodigo.SelectionStart - s2.Length;
                TCodigo.SelectionLength = s2.Length;
                if (contextMenuStrip1.Items.Count > 0)
                    MuestraOpciones();
                else
                    VerificaClaves(s2);

                return;
            }
            if (e.KeyChar == '@')
            {
                MuestraVariables();
            }
        }
        private void MuestraOpciones()
        {
            TCodigo.ContextMenuStrip = contextMenuStrip1;
            Point p = TCodigo.GetPositionFromCharIndex(TCodigo.SelectionStart);
            contextMenuStrip1.Show(TCodigo, p);
        }
        private void OnMenu_Click(object sender, EventArgs e)
        {
            int x = TCodigo.SelectionStart;
            ToolStripMenuItem m = (ToolStripMenuItem)sender;

            TCodigo.SelectedText = m.Text;
            //TCodigo.SelectionStart = x + m.Text.Length;
            cTextColor1.AnalizaTexto();
        }
        private void OnMenu_Click2(object sender, EventArgs e)
        {
            int x = TCodigo.SelectionStart;
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            TCodigo.SelectedText = m.Text;
            cTextColor1.AnalizaTexto();
        }


        private void ComboZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TCodigo.ZoomFactor = float.Parse(ComboZoom.Text) / 100;
            }
            catch (System.Exception)
            {
                return;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lfecha.Text = TCodigo.SelectionIndent.ToString() + "." + TCodigo.Bounds.Bottom.ToString();
            bool ok = true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            toolStripButton1.Enabled = ok;
            toolStripButton6.Enabled = ok;
            //calculo la posicion del cursor
            int i, p, n = 0;
            p = 0;
            n = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
            for (i = 0; i < n; i++)
            {
                p = p + TCodigo.Lines[i].Length + 1;
            }
            p = TCodigo.SelectionStart - p;
            LX.Text = "X=" + p.ToString();
            LY.Text = "Y=" + n.ToString();
        }
        public string Codigo
        {
            get
            {
                return TCodigo.Text;
            }
            set
            {
                TCodigo.Text = value;
                cTextColor1.AnalizaTexto();
            }
        }
        public override void Guardar()
        {
            saveFileDialog1.FileName = TNombre.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            TCodigo.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
        }
        private void MuestraVariables()
        {
            contextMenuStrip1.Items.Clear();
            List<AnalizadorLexico.CLexema> Lexemas;
            //cargo todos los lexemas del codigo en la lista
            Lexemas = new List<AnalizadorLexico.CLexema>();
            cAnaLex1.Texto = TCodigo.Text;
            AnalizadorLexico.CLexema lex = null;
            do
            {
                lex = cAnaLex1.DameItem();
                if (lex != null)
                {
                    //checo si es un alias
                    if (lex.Tipo == AnalizadorLexico.TIPO_LEX.VARIABLE)
                    {
                        ToolStripItem nodo;
                        //checo si no se repite
                        int i, n;
                        n = contextMenuStrip1.Items.Count;
                        bool encontrado = false;
                        for (i = 0; i < n; i++)
                        {
                            if (contextMenuStrip1.Items[i].Text == lex.cadena)
                            {
                                encontrado = true;
                                break;
                            }
                        }
                        if (encontrado == false)
                        {
                            nodo = contextMenuStrip1.Items.Add(lex.cadena);
                            nodo.Click += new EventHandler(OnMenu_Click3);
                        }
                    }
                }
            }
            while (lex != null);
            MuestraOpciones();
            TCodigo.ContextMenuStrip = null;
        }
        private void OnMenu_Click3(object sender, EventArgs e)
        {
            int x = TCodigo.SelectionStart;
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            TCodigo.SelectedText = m.Text.Substring(1);
            cTextColor1.AnalizaLinea(TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart));
        }
        private void OnMenuRAISERROR_Click(object sender, EventArgs e)
        {
            int x = TCodigo.SelectionStart;
            int pos = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
            ToolStripMenuItem m = (ToolStripMenuItem)sender;

            TCodigo.SelectedText = "RAISERROR(\'mensage de error\', 16, 1)\r\n" + Tabuladores + "return";
            //TCodigo.SelectionStart = x + m.Text.Length;
            cTextColor1.AnalizaLinea(pos);
            cTextColor1.AnalizaLinea(pos+1);
        }
        private void CargaColor()
        {

            string archivo = DirColor + "\\Color";
            if (!System.IO.File.Exists(archivo))
            {
                return;
            }
            System.IO.StreamReader rt;
            rt = System.IO.File.OpenText(archivo);
            cTextColor1.BackColor = DameColor(rt).Color;
            cTextColor1.ColorCadena = DameColor(rt).Color;
            cTextColor1.ColorComentario = DameColor(rt).Color;
            cTextColor1.ColorIdentificador = DameColor(rt).Color;
            cTextColor1.ColorNumero = DameColor(rt).Color;
            cTextColor1.ColorOtro = DameColor(rt).Color;
            cTextColor1.ColorPalabraRserevada = DameColor(rt).Color;
            cTextColor1.ColorSimbolo = DameColor(rt).Color;
            cTextColor1.ColorVariable = DameColor(rt).Color;
            rt.Close();

        }
        public string DirColor
        {
            get
            {
                string s, dir = Application.ExecutablePath;
                int i, n;
                n = dir.Length;
                for (i = n - 1; i > 0; i--)
                {
                    if (dir[i] == '\\')
                        break;
                }
                s = dir.Substring(0, i);
                return s + "\\Color";
            }
        }
        private System.Drawing.Pen DameColor(System.IO.StreamReader rt)
        {
            int r, g, b;
            string s;
            s = rt.ReadLine();
            r = int.Parse(s);
            s = rt.ReadLine();
            g = int.Parse(s);
            s = rt.ReadLine();
            b = int.Parse(s);
            System.Drawing.Pen p;
            p = new System.Drawing.Pen(System.Drawing.Color.FromArgb(r, g, b));
            return p;
        }
        public override void ActualizaColores()
        {
            //este codigo hay que sobre escribirlo
            CargaColor();
            cTextColor1.AnalizaTexto();
        }


        private void cTextColor1_OnCambiaFoco()
        {
            TNombre.Focus();
            TNombre.SelectionLength = 0;
        }

        private void TCodigo_TextChanged(object sender, EventArgs e)
        {
            //if (NoCambio == true)
             //   return;
            if (Cambios.Count == 0)
            {
                Objetos.CRestaurar r = new Visor_sql_2015.Objetos.CRestaurar();
                r.cadena = TCodigo.Text;
                r.SelectionLength = TCodigo.SelectionLength;
                r.SelectionStart = TCodigo.SelectionStart;
                Cambios.Add(r);
            }
            else
            {
                if (Cambios[Cambios.Count - 1].cadena != TCodigo.Text)
                {
                    Objetos.CRestaurar r = new Visor_sql_2015.Objetos.CRestaurar();
                    r.cadena = TCodigo.Text;
                    r.SelectionLength = TCodigo.SelectionLength;
                    r.SelectionStart = TCodigo.SelectionStart;
                    Cambios.Add(r);
                }
                //else
                //    NoCambio = true;
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //me traigo el texto al que le dieron click
            int pos = TCodigo.GetCharIndexFromPosition(new Point(RataX, RataY));
            int posi;
            string s = TCodigo.Text;
            //me voy hacia a tras hasta encontrar un separador
            while (pos >= 0 && s[pos] != ' ' && s[pos] != '\t' && s[pos] != '\r' && s[pos] != '\n')
                pos--;
            posi = pos;
            pos++;
            while (pos < s.Length && s[pos] != ' ' && s[pos] != '\t' && s[pos] != '\r' && s[pos] != '\n' && s[pos] != '(' && s[pos] != '+' && s[pos] != '-' && s[pos] != '*')
                pos++;
            string s2 = s.Substring(posi, pos - posi);
            s2 = s2.Trim();
            //ahora me voy hacia delante hasta encontrar un separador
            if (s2 == "")
                return;
            System.Collections.Generic.List<Objetos.CSysObject> l;
            l = DB.BuscaObjetos(s2, Visor_sql_2015.Controladores_DB.TIPOOBJETO.NINGUNO);
            if (l.Count == 0)
                return;
            Objetos.CSysObject obj = l[0];
            if (obj.Nombre.ToLower().Trim() != s2.ToLower().Trim())
                return;
            if (OnVerObjeto != null)
                OnVerObjeto(obj);
        }

        private void TCodigo_MouseDown(object sender, MouseEventArgs e)
        {
            TCodigo.ContextMenuStrip = contextMenuStrip2;
            RataX = e.X;
            RataY = e.Y;

        }
        public void Ejecuta(string s)
        {
            TCodigo.Text = s;
            cTextColor1.AnalizaTexto();
            button1_Click(null, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainer1.Panel2.Controls.Clear();
                DataSet ds;
                if (TCodigo.SelectedText.Trim() == "")
                    ds = DB.Ejecuta(TCodigo.Text);
                else
                    ds = DB.Ejecuta(TCodigo.SelectedText);
                int i, n;
                n = ds.Tables.Count;
                if (n == 0)
                {
                    MuestraError("COMANDOS EJECUTADOS CON EXITO");
                    return;
                }
                for (i = 0; i < n; i++)
                {
                    System.Windows.Forms.DataGrid dataGrid1;
                    dataGrid1 = new System.Windows.Forms.DataGrid();
                    dataGrid1.DataMember = "";
                    if (i == n - 1)
                        dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                    else
                        dataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
                    dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
                    dataGrid1.Name = "dataGrid1";
                    dataGrid1.ReadOnly = true;
                    dataGrid1.Height = 150;
                    dataGrid1.DataSource = ds.Tables[i];
                    splitContainer1.Panel2.Controls.Add(dataGrid1);
                    if (i < n - 1)
                    {
                        System.Windows.Forms.Splitter splitter = new Splitter();
                        splitter.Dock = System.Windows.Forms.DockStyle.Top;
                        splitter.Size = new System.Drawing.Size(splitContainer1.Panel2.Width, 3);
                        splitter.Location = new System.Drawing.Point(splitContainer1.Panel2.Width, dataGrid1.Top + dataGrid1.Height + 10);
                        splitContainer1.Panel2.Controls.Add(splitter);
                    }
                }
                splitContainer1.SplitterDistance = Height / 2;
                n = splitContainer1.Panel2.Controls.Count;
                for (i = n - 1; i >= 0; i--)
                {
                    splitContainer1.Panel2.Controls[i].SendToBack();
                }
                return;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                splitContainer1.Panel2.Controls.Clear();
                TMensage = new ListBox();// System.Windows.Forms.RichTextBox();
                TMensage.Parent = splitContainer1.Panel2;
                TMensage.Dock = System.Windows.Forms.DockStyle.Fill;
                TMensage.DoubleClick += new System.EventHandler(ListaErrores_DoubleClick);
                splitContainer1.SplitterDistance = Height / 2;
                //TMensage.Text = "";
                int i, n;
                n = ex.Errors.Count;
                for (i = 0; i < n; i++)
                {
                    TMensage.Items.Add(ex.Errors[i]);
                }
                return;
            }
//            MuestraError("COMANDOS EJECUTADOS CON EXITO");
        }
        private void MuestraError(string s)
        {
            splitContainer1.Panel2.Controls.Clear();
            TMensage = new ListBox();
            TMensage.Parent = splitContainer1.Panel2;
            TMensage.Dock = System.Windows.Forms.DockStyle.Fill;
            TMensage.Items.Add(s);
            splitContainer1.SplitterDistance = Height / 2;
        }
        private void ListaErrores_DoubleClick(object sender, EventArgs e)
        {
            if (TMensage.SelectedIndex == -1)
                return;
            System.Data.SqlClient.SqlError ex = (System.Data.SqlClient.SqlError)TMensage.Items[TMensage.SelectedIndex];
            int pos = TCodigo.GetFirstCharIndexFromLine(ex.LineNumber - 1);
            int i, n;
            n = TCodigo.Text.Length;
            for (i = pos; i < n; i++)
            {
                if (TCodigo.Text[i] == '\n' || TCodigo.Text[i] == '\r')
                    break;
            }
            TCodigo.Focus();
            TCodigo.SelectionStart = pos;
            TCodigo.SelectionLength = i - pos;
        }
        public override void Abrir()
        {
            openFileDialog1.FileName = TNombre.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            TCodigo.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            cTextColor1.AnalizaTexto();
        }
        private void TCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                toolStripButton4_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.F7)
            {
                toolStripButton5_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.Right && e.Shift == true && e.Control == true)
            {
                e.Handled = true;
                int posf = TCodigo.SelectionStart + TCodigo.SelectionLength;
                //filtro LostFocus espacios enum blanco
                int blacos = 0;
                while (TCodigo.Text[posf] == ' ' || TCodigo.Text[posf] == '\r' || TCodigo.Text[posf] == '\n' || TCodigo.Text[posf] == '\t')
                {
                    blacos++;
                    posf++;
                }
                //me traigo el siguiente item del texto
                cAnaLex1.Texto = TCodigo.Text.Substring(posf);
                AnalizadorLexico.CLexema lex;
                lex=cAnaLex1.DameItem();
                if (lex == null)
                    return;
                TCodigo.SelectionLength = TCodigo.SelectionLength + lex.cadena.Length+blacos;
            }
            ControlV = (e.KeyCode == Keys.V && e.Modifiers == Keys.Control);
            if (ControlV == true)
            {
                ControlVI = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
            }
            //{
            //    VerificaEspacio(e);
            //    return;
            //}
            #region Tratamiento del enter
            if (e.KeyCode == Keys.Enter)
            {
                if (TCodigo.Text == "")
                    return;
                e.Handled = true;
                //me traigo la posicion de la linea en la que estoy
                int si = TCodigo.SelectionStart;
                //ahora me regreso hasta encontrar un enter o el inicio de liena
                int pos = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
                string s = TCodigo.Lines[pos];
                Tabuladores = "\r";
                //cuento el numero de tabuladores
                int i, n;
                n = s.Length;
                for (i = 0; i < n; i++)
                {
                    if (s[i] != '\t' && s[i] != ' ')
                    {
                        break;
                    }
                    Tabuladores = Tabuladores + s[i];
                }
                string s2 = "";
                for (; i < n; i++)
                {
                    //me traigo la primer palabra wue encuentre
                    if (s[i] == '\t' || s[i] == ' ')
                    {
                        break;
                    }
                    else
                        s2 = s2 + s[i];
                }
                if (s2.ToLower().Trim() == "begin")
                {
                    string s3 = Tabuladores + "\t";
                    si = si + s3.Length;
                    Tabuladores = s3 + "\t" + Tabuladores + "end";
                    TCodigo.SelectedText = Tabuladores;
                    TCodigo.SelectionStart = si;
                    return;
                }
                TCodigo.SelectedText = Tabuladores;
                return;
            }
            #endregion

            if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
            {

                e.Handled = true;
                if (Cambios.Count <= 1)
                    return;
//                NoCambio = true;
                TNombre.Focus();
                TNombre.SelectionLength = 0;
                Cambios.RemoveAt(Cambios.Count - 1);
                TCodigo.Text= Cambios[Cambios.Count - 1].cadena;
                TCodigo.SelectionLength = Cambios[Cambios.Count - 1].SelectionLength;
                TCodigo.SelectionStart = Cambios[Cambios.Count - 1].SelectionStart;
                cTextColor1.AnalizaTexto();
                TCodigo.Focus();
                //                NoCambio = false;
            }
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                e.Handled = true;
                splitContainer1.SplitterDistance = Height;
            }
        }
        private bool VerificaClaves(string s)
        {
            if (s.ToLower().Trim() == "raise")
            {
                //es autocompletar
                ToolStripItem nodo;
                nodo = contextMenuStrip1.Items.Add("RAISERROR");
                nodo.Click += new EventHandler(OnMenuRAISERROR_Click);
                MuestraOpciones();
                int pos = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
                string s2 = TCodigo.Lines[pos];
                Tabuladores = "";
                //cuento el numero de tabuladores
                int i, n;
                n = s2.Length;
                for (i = 0; i < n; i++)
                {
                    if (s2[i] != '\t' && s2[i] != ' ')
                    {
                        break;
                    }
                    Tabuladores = Tabuladores + s2[i];
                }
                cTextColor1.AnalizaLinea(pos);
                cTextColor1.AnalizaLinea(pos+1);
                return true;
            }
            if (s.ToLower().Trim() == "insert")
            {
                //es autocompletar un insert
                Formularios.FormBuscarTabla dlg = new FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTAS_TABLAS);
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                //obtengo la poicion del insert
                //-------------------------------------------------------------------------------------
                //string sx = "insert";
                //ahora me regreso hasta encontrar un enter o el inicio de liena
                int pos = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
                string s2 = TCodigo.Lines[pos];
                Tabuladores = "";
                //cuento el numero de tabuladores
                int i, n;
                n = s2.Length;
                for (i = 0; i < n; i++)
                {
                    if (s2[i] != '\t' && s2[i] != ' ')
                    {
                        break;
                    }
                    Tabuladores = Tabuladores + s2[i];
                }
                //--------------------------------------------------------------------
                TCodigo.SelectedText = dlg.DameInsert(Tabuladores, "insert ");
                return true;
            }
            if (s.ToLower().Trim() == "exec")
            {
                //es autocompletar un insert
                Formularios.FormBuscarTabla dlg = new FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE);
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                TCodigo.SelectedText = dlg.DameSP("exec ");
                return true;
            }
            return false;
        }
        private void VerificaEspacio(KeyPressEventArgs e)
        {
            int si = TCodigo.SelectionStart;
            Tabuladores = DameTabuladores(si);
            string s = DameItemAnterior(si);
            VerificaClaves2(s,e);

        }
        private bool VerificaClaves2(string s, KeyPressEventArgs e)
        {
            if (s.ToLower().Trim() == "insert")
            {
                //es autocompletar un insert
                Formularios.FormBuscarTabla dlg = new FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                //obtengo la poicion del insert
                //-------------------------------------------------------------------------------------
                //string sx = " ";
                //ahora me regreso hasta encontrar un enter o el inicio de liena
                int pos = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
                string s2 = TCodigo.Lines[pos];
                Tabuladores = "";
                //cuento el numero de tabuladores
                int i, n;
                n = s2.Length;
                for (i = 0; i < n; i++)
                {
                    if (s2[i] != '\t' && s2[i] != ' ')
                    {
                        break;
                    }
                    Tabuladores = Tabuladores + s2[i];
                }
                //--------------------------------------------------------------------
                TCodigo.SelectedText =" "+ dlg.DameInsert(Tabuladores, "");
                cTextColor1.AnalizaLinea(pos);
                cTextColor1.AnalizaLinea(pos+1);
                return true;
            }
            if (s.ToLower().Trim() == "exec")
            {
                //es autocompletar un insert
                Formularios.FormBuscarTabla dlg = new FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE);
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                TCodigo.SelectedText =" "+ dlg.DameSP("");
                cTextColor1.AnalizaLinea(TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart));
                return true;
            }
            if (s.ToLower().Trim() == "like")
            {
                e.Handled = true;
                //es autocompletar un insert
                int ss = TCodigo.SelectionStart;
                TCodigo.SelectedText = " \'%%\'";
                TCodigo.SelectionStart =  ss+ 3;
                cTextColor1.AnalizaLinea(TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart));
                return true;
            }
            if (s.ToLower().Trim() == "from" || s.ToLower().Trim() == "update" || s.ToLower().Trim() == "delete")
            {
                Formularios.FormBuscarTabla dlg = null;
                if (s.ToLower().Trim() == "from")
                {
                    dlg = new FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTAS_TABLAS);
                }
                if (s.ToLower().Trim() == "update" || s.ToLower().Trim() == "delete")
                {
                    dlg = new FormBuscarTabla(DB, Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
                }
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return false;
                e.Handled = true;
                Objetos.CSysObject obj = dlg.DameObjeto();
                TCodigo.SelectedText = " "+obj.Nombre;
                cTextColor1.AnalizaLinea(TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart));
                return true;
            }
            return false;
        }
        private string DameTabuladores(int linea)
        {
            //ahora me regreso hasta encontrar un enter o el inicio de liena
            int pos = TCodigo.GetLineFromCharIndex(linea);
            string s;
            if (pos > 0)
                s = TCodigo.Lines[pos];
            else
                s = TCodigo.Text;

            string  Tabuladores1 = "\r";
            //cuento el numero de tabuladores
            int i, n;
            n = s.Length;
            for (i = 0; i < n; i++)
            {
                if (s[i] != '\t' && s[i] != ' ')
                {
                    break;
                }
                Tabuladores1 = Tabuladores1 + s[i];
            }
            return Tabuladores1;
        }
        private string DameItemAnterior(int posicion)
        {
            List<Objetos.CAlias> Alias = new List<Visor_sql_2015.Objetos.CAlias>(); ;
            List<AnalizadorLexico.CLexema> Lexemas;
            //cargo todos los lexemas del codigo en la lista
            Lexemas = new List<AnalizadorLexico.CLexema>();
            int linea=TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
            cAnaLex1.Texto = TCodigo.Lines[linea];
            AnalizadorLexico.CLexema lex = null;
            AnalizadorLexico.CLexema lex2 = null;
            do
            {
                lex = cAnaLex1.DameItem();
                if (lex != null)
                {
                    Lexemas.Add(lex);
                    //checo si es un alias
                    if (lex.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                    {
                        if (lex2 != null)
                        {
                            if (lex2.Tipo == AnalizadorLexico.TIPO_LEX.IDENTIFICADOR)
                            {
                                //veo si es una tabla
                                Controladores_DB.CNodoTabla nt1;
                                nt1 = DB.BuscaEnTabla(lex2.cadena);
                                if (nt1 != null)
                                {
                                    //encontre un alias
                                    Objetos.CAlias al = new Visor_sql_2015.Objetos.CAlias();
                                    al.Item = lex;
                                    al.tabla = nt1;
                                    Alias.Add(al);
                                }
                            }
                        }
                        lex2 = lex;
                    }
                }
            }
            while (lex != null);
            //ta tego todos los lexemas en memosria;
            //ahora busco el que esta justo antes del punto

            int posPunto = posicion - TCodigo.GetFirstCharIndexFromLine(linea);
            int i, n, px = -1;
            n = Lexemas.Count;
            for (i = 0; i < n; i++)
            {
                lex = Lexemas[i];
                if (posPunto >= lex.Pos && posPunto <= lex.Pos + lex.cadena.Length)
                {
                    //ya tengo la posicion del punto que escribieron
                    px = i;
                    break;
                }
            }
            //ahora me traigo el lexema que esta atras del punto
            if (px == -1)
                return "";
            lex = Lexemas[px];
            return lex.cadena;
        }

        private void convertirAMayúsculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int li, lf;
            //obtengo la linea donde inicia la seleccion
            li = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
            //obtengo la linea en la que termina la seleccion
            lf = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart+TCodigo.SelectionLength);
            //le hago la convercion
            TCodigo.SelectedText = TCodigo.SelectedText.ToUpper();
            //analizo las lineas
            for (int i = li; i <= lf; i++)
            {
                cTextColor1.AnalizaLinea(i);
            }
        }

        private void convertirAMinúsculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int li, lf;
            //obtengo la linea donde inicia la seleccion
            li = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
            //obtengo la linea en la que termina la seleccion
            lf = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart + TCodigo.SelectionLength);
            //le hago la convercion
            TCodigo.SelectedText = TCodigo.SelectedText.ToLower();
            //analizo las lineas
            for (int i = li; i <= lf; i++)
            {
                cTextColor1.AnalizaLinea(i);
            }
        }
        private void TCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                button1_Click(null, null);
            }
            if (e.KeyCode == Keys.F3)
            {
                if (TCodigo.SelectedText.Trim() == "")
                {
                    //no hay nada escrito, entonces veo si tengo texto seleccionado
                    if (toolStripTextBox1.Text.Trim() == "")
                    {
                        return;
                    }
                }
                else
                {
                    toolStripTextBox1.Text = TCodigo.SelectedText;
                }
                toolStripButton3_Click(null, null);
            }
            if (ControlV == true)
            {
                int controlf = TCodigo.GetLineFromCharIndex(TCodigo.SelectionStart);
                e.Handled = true;
                for (int i = ControlVI; i <= controlf; i++)
                {
                    cTextColor1.AnalizaLinea(i);

                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //comenta el dodigo seleccionado
            int posi, posf;
            posi = TCodigo.SelectionStart;
            posf = posi + TCodigo.SelectionLength;
            int li, lf;
            li = TCodigo.GetLineFromCharIndex(posi);
            lf = TCodigo.GetLineFromCharIndex(posf);
            int pl;
            pl = TCodigo.GetFirstCharIndexFromLine(li);
            for (int i = li; i <= lf; i++)
            {
                if (li == i && pl != posi)
                {
                    TCodigo.Text = TCodigo.Text.Insert(posi, "--");
                }
                else
                {
                    int l = TCodigo.GetFirstCharIndexFromLine(i);
                    TCodigo.Text=TCodigo.Text.Insert(l, "--");
                }
            }
            TCodigo.SelectionLength = 0;
            TCodigo.SelectionStart = posi;
            cTextColor1.AnalizaTexto();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //comenta el dodigo seleccionado
            int posi, posf;
            posi = TCodigo.SelectionStart;
            posf = posi + TCodigo.SelectionLength;
            int li, lf;
            li = TCodigo.GetLineFromCharIndex(posi);
            lf = TCodigo.GetLineFromCharIndex(posf);
            int pl;
            pl = TCodigo.GetFirstCharIndexFromLine(li);
            for (int i = li; i <= lf; i++)
            {
               int l = TCodigo.GetFirstCharIndexFromLine(i);
               if (TCodigo.Text[l] == '-' && TCodigo.Text[l+1]=='-')
               {
                   TCodigo.Text=TCodigo.Text.Remove(l, 2);
               }
            }
            TCodigo.SelectionLength = 0;
            TCodigo.SelectionStart = posi;
            cTextColor1.AnalizaTexto();
        }
    }
}