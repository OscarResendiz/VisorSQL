using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public enum ESTADOS_BUSQUEDA
    {
        INICIANDO_BUSUQUEDA=0,
        EXTRAYENDO_OBJETOS=1,
        ANALIZANDO=2,
        FIN=3
    };
    //creo el delgado para la comparacion de cadena
    public delegate void OnComprarCodigoEvent(string codigo1, string caption1, string codigo2, string caption2);
    public partial class FormCompararBases : FormBase
    {
        public event OnVerObjetoEvent OnVerObjeto;
        public event OnComprarCodigoEvent OnComprarCodigo;
        private ESTADOS_BUSQUEDA Estado;
        System.Collections.Generic.List<Objetos.CSysObject> Lista;
        System.Collections.Generic.List<Objetos.CDiferenciaObjeto> Diferencias;

        Controladores_DB.IDataBase DB;
        Controladores_DB.IDataBase DB2;
        public FormCompararBases(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
        }

        private void FormCompararBases_Load(object sender, EventArgs e)
        {
            CargaGrupos();
            ComboTipos.SelectedIndex = 0;
        }
        private void CargaConexiones()
        {
            ComboConexiones.Items.Clear();
            int i, n;
            string[] archivos;
            if (System.IO.Directory.Exists(DirConexiones) == false)
            {
                System.IO.Directory.CreateDirectory(DirConexiones);
            }
            archivos = System.IO.Directory.GetFiles(DirConexiones);
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                ComboConexiones.Items.Add(QuitaDirectorio(archivos[i]));
            }
        }
        public string DirConexiones
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
                return s + "\\CONEXIONES";
            }
        }
        private string QuitaDirectorio(string nombre)
        {
            string s = "";
            int i, n;
            n = nombre.Length;
            for (i = 0; i < n; i++)
            {
                if (nombre[i] == '\\')
                    s = "";
                else
                    s = s + nombre[i];
            }
            return s;
        }

        private void ComboConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboConexiones.SelectedIndex == -1)
                return;
            //-----------------------------------------
            string archivo = DirConexiones + "\\" + ComboGrupos.Items[ComboGrupos.SelectedIndex].ToString() + "\\" + ComboConexiones.Items[ComboConexiones.SelectedIndex].ToString();
            if (!System.IO.File.Exists(archivo))
            {
                MessageBox.Show("No se encontro la conexion");
                return;
            }
            AdministrarConexiones.CInstanciadorDB IDB = new AdministrarConexiones.CInstanciadorDB();
            DB2 = IDB.DameInstancia(DirConexiones + "\\" + ComboGrupos.Items[ComboGrupos.SelectedIndex].ToString(), ComboConexiones.Items[ComboConexiones.SelectedIndex].ToString());
            try
            {
                DB2.PruebaConexion();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                ComboConexiones.SelectedIndex = -1;
                return;
            }
            this.Text = DB2.ConnectionString;
        }
        private void BuscaObjetos()
        {
            Controladores_DB.TIPOOBJETO tipo = Controladores_DB.TIPOOBJETO.NINGUNO;
            switch (ComboTipos.SelectedIndex)
            {
                case 0:
                    tipo = Controladores_DB.TIPOOBJETO.NINGUNO;
                    break;
                case 1:
                    tipo = Controladores_DB.TIPOOBJETO.TABLAX;
                    break;
                case 2:
                    tipo = Controladores_DB.TIPOOBJETO.VISTA;
                    break;
                case 3:
                    tipo = Controladores_DB.TIPOOBJETO.STOREPROCERURE;
                    break;
                case 4:
                    tipo = Controladores_DB.TIPOOBJETO.EN_CODIGO;
                    break;
            }
            Lista = DB.BuscaObjetos("", tipo);
            if(Lista.Count>0)
                cBarraProgreso1.ValorMaximo = Lista.Count;
            cBarraProgreso1.Progreso = 0;
            //int i, n;
            //n = 
            //////for (i = 0; i < n; i++)
            //////{
            //////    Objetos.CSysObject obj = Lista[i];
            //////    ListaObjetos.Items.Add(obj.Nombre);
            //////}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Estado)
            {
                case ESTADOS_BUSQUEDA.INICIANDO_BUSUQUEDA:
                    cBarraProgreso1.Texto = "Extrayendo objetos de la base de datos";
                    Estado = ESTADOS_BUSQUEDA.EXTRAYENDO_OBJETOS;
                    break;
                case ESTADOS_BUSQUEDA.EXTRAYENDO_OBJETOS:
                    BuscaObjetos();
                    Estado = ESTADOS_BUSQUEDA.ANALIZANDO;
                    break;
                case ESTADOS_BUSQUEDA.ANALIZANDO:
                    AnalizaObjeto();
                    break;
                case ESTADOS_BUSQUEDA.FIN:
                    timer1.Enabled = false;
                    ComboConexiones.Enabled = true;
                    ComboGrupos.Enabled = true;
                    ComboTipos.Enabled = true;
                    ComboVer.Enabled = true;
                    button2.Enabled = true;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ComboConexiones.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Seleccione una base de datos");
                return;
            }
            ListaObjetos.Items.Clear();
            button2.Enabled = false;
            ComboConexiones.Enabled = false;
            ComboGrupos.Enabled = false;
            ComboTipos.Enabled = false;
            ComboVer.Enabled = false;
            label3.Text = "Objetos con diferencias";
            textBox1.Text = "";
            Diferencias = new List<Visor_sql_2015.Objetos.CDiferenciaObjeto>();
            Estado = ESTADOS_BUSQUEDA.INICIANDO_BUSUQUEDA;
            timer1.Enabled = true;

        }
        private void AnalizaObjeto()
        {
            //se trae el primer objeto de la lista y lo busca en la base de datos
            //externa.
            /* 
             * primero revisa que exista. SI no existe lo agrega a la lista
             * si existe, revisa si es un sp o una vista o una tabla
             * Si es un Sp o una vista, se tare el codigo de las dos bases
             * y los compara y si son diferentes lo agrega a la lita
             * si es una tabla checa los campos y si aguno es diferente lo agrea
             * si es una llave foranea, checa si tienen las mismas tablas y campos
             * si no coinciden, lo agrega a la lista
             * si es una llave primaria checa si son los mismos campos
             */
            if (Lista.Count == 0)
            {
                cBarraProgreso1.Texto = "Analisis terminado";
                Estado = ESTADOS_BUSQUEDA.FIN;
                return;
            }
            //me traigo el primer objeto de la lista
            Objetos.CSysObject obj = Lista[0];
            Lista.RemoveAt(0);
            System.Collections.Generic.List<Objetos.CSysObject> l;
            l = DB2.BuscaObjetos(obj.Nombre, obj.TipoObjeto);
            cBarraProgreso1.Progreso++;
            cBarraProgreso1.Texto="Analizando "+obj.Nombre;
            if (l.Count == 0)
            {
                //no lo encontro, por lo que lo agrego a la lista
                AgregaDiferencia(obj, "No se encontró en la base de datos",1);
                return;
            }
            Objetos.CSysObject obj2=l[0];
            if(obj2.Nombre!=obj.Nombre)
            {
                //no lo encontro, por lo que lo agrego a la lista
                AgregaDiferencia(obj, "No se encontró en la base de datos",1);
                return;
            }
            switch (obj.TipoObjeto)
            {
                case Controladores_DB.TIPOOBJETO.TABLAX:
                    ComparaTablas(obj,obj2);
                    break;
                case Controladores_DB.TIPOOBJETO.STOREPROCERURE:
                    ComparaCodigo(obj,obj2);
                    break;
                case Controladores_DB.TIPOOBJETO.VISTA:
                    ComparaCodigo(obj,obj2);
                    break;
                case Controladores_DB.TIPOOBJETO.TRIGER:
                    ComparaCodigo(obj,obj2);
                    break;
                case Controladores_DB.TIPOOBJETO.PRIMARYKEY:
                    ComparaLLavesPrimarias(obj, obj2);
                    break;
                case Controladores_DB.TIPOOBJETO.FOREINGKEY:
                    ComparaLLavesForaneas(obj, obj2);
                    break;
            }
        }
        private void ComparaTablas(Objetos.CSysObject obj,Objetos.CSysObject obj2)
        {
            //compara los campos de una tabla
            System.Collections.Generic.List<Objetos.CParametro> l1;
            System.Collections.Generic.List<Objetos.CParametro> l2;
            l1 = DB.DameCamposTabla(obj.Nombre);
            l2 = DB2.DameCamposTabla(obj.Nombre);
            if (l1.Count != l2.Count)
            {
                //son diferentes
                AgregaDiferencia(obj, "La cantidad de campos no coinciden " + l1.Count + "->" + l2.Count,2);
                if (l2.Count > l1.Count)
                {
                    //faltan campos en la tabla origen, asi que a buscarlos
                    foreach (Objetos.CParametro c2 in l2)
                    {
                        bool encontrado = false;
                        foreach (Objetos.CParametro c1 in l1)
                        {
                            if (c1.nombre.ToLower().Trim() != c2.nombre.ToLower().Trim())
                            {
                                //que se salte al siguiente campo
                                continue;
                            }
                            encontrado = true;
                        }
                        if (encontrado == false)
                        {
                            AgregaDiferencia(obj, "Falta el campo "+c2.nombre+" en la tabla origen",1);
                        }
                    }
                }
                //return;
            }
            int  n;
            n = l2.Count;
            //comparo campo por campo
            foreach(Objetos.CParametro c1 in l1)
            {
                //primero veo si el campo existe en la otra tabla
                bool encontrado = false;
                foreach (Objetos.CParametro c2 in l2)
                {
                    //comparo los campos
                    if (c1.nombre.ToLower().Trim() != c2.nombre.ToLower().Trim())
                    {
                        //que se salte al siguiente campo
                        continue;
                    }
                    encontrado = true;//lo marco como encontrado
                    if (c1.tipo != c2.tipo)
                    {
                        //son diferentes
                        AgregaDiferencia(obj, "Los tipos del campo " + c1.nombre.Trim() + " no coinciden " + c1.tipo.Trim() + " " + c2.tipo.Trim(),2);
                        //return;
                    }
                    if (c1.Logitud != c2.Logitud)
                    {
                        //son diferentes
                        AgregaDiferencia(obj, "La longitud del campo " + c1.nombre.Trim() + " no coincide " + c1.Logitud.ToString() + " " + c2.Logitud.ToString(),2);
                        //return;
                    }
                    if (c1.NULOS.ToLower().Trim() != c2.NULOS.ToLower().Trim())
                    {
                        //son diferentes
                        AgregaDiferencia(obj, "La propiedad de aceptar nulos no coinciden " + c1.nombre.Trim() + " " + c1.NULOS.Trim() + " " + c2.NULOS.Trim(),2);
                        //return;
                    }
                    if (c1.collation != c2.collation)
                    {
                        //son diferentes
                        AgregaDiferencia(obj, "La configuración regional de los campos no coincide " + c1.nombre.Trim() + " " + c1.collation.Trim() + " " + c2.collation.Trim(),2);
                    }
                    //checo su propiedad de identidad                   
                    Objetos.CIdentity id1, id2;
                    id1 = DB.DameIdentity(obj.Nombre, c1.nombre);
                    id2 = DB2.DameIdentity(obj.Nombre, c2.nombre);
                    if (id1.EsIdentidad != id2.EsIdentidad)
                    {
                        AgregaDiferencia(obj, "La propiedad identity no coinciden " + id1.EsIdentidad.ToString() + " " + id2.EsIdentidad.ToString()+" campo "+c1.nombre,2);
                    }
                    else if (id1.EsIdentidad == true)
                    {
                        //si son identidad, ahora chehco sus propiedades
                        if (id1.incremento != id2.incremento)
                        {
                            AgregaDiferencia(obj, "En la propiedad identity no coinciden los imcrementos " + id1.incremento.ToString() + " " + id2.incremento.ToString() + " campo " + c1.nombre,2);
                        }
                        if (id1.inicio != id2.inicio)
                        {
                            AgregaDiferencia(obj, "En la propiedad identity no coinciden los inicios " + id1.inicio.ToString() + " " + id2.inicio.ToString() + " campo " + c1.nombre,2);
                        }
                    }
                    //veo si es un campo que tiene valores por default
                    Objetos.CDefault df1, df2;
                    df1 = DB.DameDefault(obj.Nombre, c1.nombre);
                    df2 = DB.DameDefault(obj.Nombre, c2.nombre);
                    if (df1.EsDeafult != df2.EsDeafult)
                    {
                        AgregaDiferencia(obj, "En el campo " + c1.nombre + " la propiedad default no coinciden " + df1.EsDeafult.ToString() + ", " + df2.EsDeafult.ToString(),2);
                    }
                    else
                    {
                        if (df1.Valor != df1.Valor)
                        {
                            AgregaDiferencia(obj, "En el campo " + c1.nombre + " la propiedad default no coinciden " + df1.Valor + ", " + df2.Valor,2);
                        }
                    }
                }
                if (encontrado == false)
                {
                    //no se encontro en la tabla
                    AgregaDiferencia(obj, "El campo " + c1.nombre.Trim() + " no existe en la tabla destino ",1);
                }
            }
            //ahora reviso las claves primarias
           l1=DB.DameLLavesPrimarias(obj.Nombre);
           l2 = DB2.DameLLavesPrimarias(obj2.Nombre);
           if (l1.Count != l2.Count)
           {
               //son diferentes
               AgregaDiferencia(obj, "No coinciden la cantidad de campos de llaves primarias",2);
               return;
           }
       }
        private void ComparaCodigo(Objetos.CSysObject obj, Objetos.CSysObject obj2)
        {
            //son SPs o vistas o trigers
            string s1,s2;
            s1 = DB.DameCodigo(obj.Nombre).ToUpper().Trim().Replace("\r\n", "\n");
            s2 = DB2.DameCodigo(obj.Nombre).ToUpper().Trim().Replace("\r\n", "\n");
            if (s1 != s2)
            {
                AgregaDiferencia(obj, "El código fuente es diferente",2);
            }
        }
        private void ComparaLLavesPrimarias(Objetos.CSysObject obj, Objetos.CSysObject obj2)
        {
        }
        private void AgregaDiferencia(Objetos.CSysObject obj, string descripcion,int tipo)
        {
            bool agregar = false;
            switch (ComboVer.SelectedIndex)
            {
                case 0:// todos
                    agregar = true;
                    break;
                case 1: //nuevos
                    if (tipo == 1)
                        agregar = true;
                    break;
                case 2: //con diferencias
                    if (tipo == 2)
                        agregar = true;
                    break;
                default:
                    agregar = true; //no definido
                    break;
            }
            if (agregar)
            {
                Objetos.CDiferenciaObjeto dobj = new Visor_sql_2015.Objetos.CDiferenciaObjeto();
                dobj.obj = obj;
                dobj.Descripcion = descripcion;
                Diferencias.Add(dobj);
                ListaObjetos.Items.Add(obj.Nombre);
                label3.Text = "Objetos con diferencias: " + ListaObjetos.Items.Count;
            }
        }
        private void ListaObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedIndex == -1)
            {
                textBox1.Text = "";
                return;
            }
            textBox1.Text = DB.DameFechaModificacion(Diferencias[ListaObjetos.SelectedIndex].obj.Nombre).ToString();
            textBox1.Text = textBox1.Text +"\r\n"+Diferencias[ListaObjetos.SelectedIndex].Descripcion;

        }

        private void ListaObjetos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListaObjetos.SelectedIndex == -1)
                return;
            if (OnVerObjeto != null)
                OnVerObjeto(Diferencias[ListaObjetos.SelectedIndex].obj);
        }
        private void ComparaLLavesForaneas(Objetos.CSysObject obj, Objetos.CSysObject obj2)
        {
            System.Collections.Generic.List<Objetos.CCampoFK> l1, l2;
            l1 = DB.DameLLaveForanea(obj.Nombre);
            l2 = DB2.DameLLaveForanea(obj2.Nombre);
            if (l1.Count != l2.Count)
            {
                AgregaDiferencia(obj, "El numero de campos de la llave foránea no coinciden",2);
                return;
            }
            int i, n;
            n = l2.Count;
            //comparo campo por campo
            for (i = 0; i < n; i++)
            {
                Objetos.CCampoFK c1, c2;
                c1 = l1[i];
                c2 = l2[i];
                //comparo si las tablas coinciden
                if (c1.maestra != c2.maestra)
                {
                    AgregaDiferencia(obj, "Las tablas con clave primaria no coinciden",2);
                    return;
                }
                if(c1.hija!=c2.hija)
                {
                    AgregaDiferencia(obj, "Las tablas con clave externa no coinciden",2);
                    return;
                }
                if (c1.columnahija != c2.columnahija)
                {
                    AgregaDiferencia(obj, "Las columnas de clave externa no coinciden",2);
                    return;
                }
                if (c1.columnaMaestra!= c2.columnaMaestra)
                {
                    AgregaDiferencia(obj, "Las columnas de clave primaria no coinciden",2);
                    return;
                }
            }
        }

        private void ComboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public override void Guardar()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            System.IO.TextWriter sw;
            sw = System.IO.File.CreateText(saveFileDialog1.FileName);
            foreach (Objetos.CSysObject obj in Lista)
            {
                sw.WriteLine(obj.Nombre);
            }
            sw.Close();
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Objetos.CDiferenciaObjeto obj in Diferencias)
            {
                if (OnVerObjeto != null)
                    OnVerObjeto(obj.obj);
            }

        }
        private void CargaGrupos()
        {
            ComboGrupos.Items.Clear();
            string[] directorios;
            //se trae la lista de grupos de conexiones
            directorios = System.IO.Directory.GetDirectories(DirConexiones);
            foreach (string s in directorios)
            {
                int i, n, pos = 0;
                n = s.Length;
                for (i = 0; i < n; i++)
                {
                    if (s[i] == '\\')
                        pos = i;
                }
                ComboGrupos.Items.Add(s.Substring(pos + 1));
            }
        }

        private void ComboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargo la lista de conexiones
            ComboConexiones.Items.Clear();
            int i, n;
            string[] archivos;
            if (System.IO.Directory.Exists(DirConexionesGrupo) == false)
            {
                System.IO.Directory.CreateDirectory(DirConexionesGrupo);
            }
            archivos = System.IO.Directory.GetFiles(DirConexionesGrupo);
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                System.Windows.Forms.ToolStripMenuItem Submenu = new System.Windows.Forms.ToolStripMenuItem();
                Submenu.Text = QuitaDirectorio(archivos[i]);
                ComboConexiones.Items.Add(Submenu.Text);
            }

        }
        private string DirConexionesGrupo
        {
            get
            {
                if (Grupo == "")
                    return DirConexiones;
                return DirConexiones + "\\" + Grupo;
            }
        }
        private string Grupo
        {
            get
            {
                if (ComboGrupos.SelectedIndex == -1)
                    return "";
                return (string)ComboGrupos.Items[ComboGrupos.SelectedIndex];
            }
            set
            {
                if (ComboGrupos.Items.Count == 0)
                    CargaGrupos();
                int i, n;
                n = ComboGrupos.Items.Count;
                for (i = 0; i < n; i++)
                {
                    string s = (string)ComboGrupos.Items[i];
                    if (s == value)
                    {
                        ComboGrupos.SelectedIndex = i;
                        ComboGrupos_SelectedIndexChanged(null, null);
                        return;
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comprarCadenasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedIndex == -1)
                return;
            // muestro las diferedncias en el odigo
            //me traigo el objeto que tiene las diferencias
            Objetos.CDiferenciaObjeto objdif=null;
            objdif=Diferencias[ListaObjetos.SelectedIndex ];
            //si es procedimiento almacenado, funcion o vita puedo hacer la comparacion de codigo
            Objetos.CSysObject obj=(Objetos.CSysObject )objdif.obj;
            if(obj.TipoObjeto!= Controladores_DB.TIPOOBJETO.STOREPROCERURE &&obj.TipoObjeto!= Controladores_DB.TIPOOBJETO.VISTA)
            {
                //como no es soprtado el tipo de objeto, no hago nada
                return;
            }
            // ahora veo el tipo de diferencia que es.
            if (!objdif.Descripcion.Contains("El código fuente es diferente"))
            {
                // no es diferencia de codigo.
                // no hago nada
                return;
            }
            //ahora si me traigo el codigo de ambas bases
            string s1=DB.DameCodigo(obj.Nombre);
            string s2 = DB2.DameCodigo(obj.Nombre); 
            //ahora si los paso al comparador de cadenas para que los muestre
            if (OnComprarCodigo!=null)
            {

                OnComprarCodigo(s1, "Local", s2, ComboConexiones.Text);
            }
        }

        private void crearScripDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i,n;
            System.IO.StreamWriter sw=null;
            if(saveFileDialog1.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
                return;
            //creo el archivo
            try
            {
                sw=System.IO.File.CreateText(saveFileDialog1.FileName);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }

            //recorro los objetos
            n = ListaObjetos.Items.Count;
            for (i = 0; i < n; i++)
            {
                Objetos.CDiferenciaObjeto objdif = null;
                objdif = Diferencias[i];
                string s = DB.DameCodigo(objdif.obj.Nombre);
                sw.WriteLine(s);
                sw.WriteLine("go");
            }
            sw.Close();
            MessageBox.Show("Se guardo el archivo");
        }
    }
}
