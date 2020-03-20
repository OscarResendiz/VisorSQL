using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Visor_sql_2015.Inportador
{
    public partial class CImpTablasSql : Visor_sql_2015.Inportador.CImpBase
    {
        int records;

        private DataTable Tabla;
        private int ErroresCount;
        string Errores;
        string Sinsert;
        private bool Identidad;
        Controladores_DB.IDataBase DBOrigen;
        Controladores_DB.IDataBase DBDestino;
        List<Objetos.CParametro> CamposDestino;
        public CImpTablasSql()
        {
            InitializeComponent();
            CargaGrupos();
            DBDestino = null;
            DBOrigen = null;
        }
        private string TablaDestino
        {
            get
            {
                return  TTablaDestino.Text;
            }
        }
        private void CargaConexiones()
        {
            ComboConexionOrigen.Items.Clear();
            ComboConexionesDestino.Items.Clear();
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
                string s=QuitaDirectorio(archivos[i]);
                ComboConexionOrigen.Items.Add(s);
                ComboConexionesDestino.Items.Add(s);
            }
        }

        private void ComboConexionOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboConexionOrigen.SelectedIndex == -1)
                return;
            string archivo = DirConexiones + "\\" + ComboGrupos.Items[ComboGrupos.SelectedIndex].ToString() + "\\"+ ComboConexionOrigen.Items[ComboConexionOrigen.SelectedIndex].ToString();
            if (!System.IO.File.Exists(archivo))
            {
                MessageBox.Show("No se encontro la conexion");
                return;
            }
            AdministrarConexiones.CInstanciadorDB IDB = new AdministrarConexiones.CInstanciadorDB();
            DBOrigen= IDB.DameInstancia(DirConexiones + "\\" + ComboGrupos.Items[ComboGrupos.SelectedIndex].ToString(), ComboConexionOrigen.Items[ComboConexionOrigen.SelectedIndex].ToString());
            try
            {
                DBOrigen.PruebaConexion();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                ComboConexionOrigen.SelectedIndex = -1;
                return;
            }
        }
        private void ComboConexionesDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboConexionesDestino.SelectedIndex == -1)
                return;
            string archivo = DirConexiones + "\\" + ComboGrupos2.Items[ComboGrupos2.SelectedIndex].ToString() + "\\"+ ComboConexionesDestino.Items[ComboConexionesDestino.SelectedIndex].ToString();
            if (!System.IO.File.Exists(archivo))
            {
                MessageBox.Show("No se encontro la conexion");
                return;
            }
            AdministrarConexiones.CInstanciadorDB IDB = new AdministrarConexiones.CInstanciadorDB();
            DBDestino = IDB.DameInstancia(DirConexiones + "\\" + ComboGrupos2.Items[ComboGrupos2.SelectedIndex].ToString(),ComboConexionesDestino.Items[ComboConexionesDestino.SelectedIndex].ToString());
            try
            {
                DBDestino.PruebaConexion();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                ComboConexionesDestino.SelectedIndex = -1;
                return;
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
        private void BBuscarTablaOrigen_Click(object sender, EventArgs e)
        {
            Formularios.FormBuscarTabla dlg = new Formularios.FormBuscarTabla(DBOrigen, Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return ;
            ListaCamposOrigen.Items.Clear();
            ListaCamposOrigen2.Items.Clear();
            TTablaOrigen.Text = dlg.Tabla;
            List<Objetos.CParametro> CamposOrigen1 = DBOrigen.DameCamposTabla(dlg.Tabla);
            foreach (Objetos.CParametro obj in CamposOrigen1)
            {
                ListaCamposOrigen.Items.Add(obj);
            }
        }
        private void BBUscarTablaDestino_Click(object sender, EventArgs e)
        {
            Formularios.FormBuscarTabla dlg = new Formularios.FormBuscarTabla(DBDestino, Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return ;
            ListaCamposDestino2.Items.Clear();
            ListaCamposDestino.Items.Clear();
            TTablaDestino.Text = dlg.Tabla;
            List<Objetos.CParametro> campos;
            campos = DBDestino.DameCamposTabla(dlg.Tabla);
            foreach (Objetos.CParametro obj in campos)
            {
                ListaCamposDestino.Items.Add(obj);
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
        private void BSubirOrigen_Click(object sender, EventArgs e)
        {
            if (ListaCamposOrigen2.SelectedIndex <= 0)
                return;
            int si = ListaCamposOrigen2.SelectedIndex;
            Objetos.CParametro s = (Objetos.CParametro)ListaCamposOrigen2.Items[ListaCamposOrigen2.SelectedIndex];
            ListaCamposOrigen2.Items.Insert(ListaCamposOrigen2.SelectedIndex-1,s);
            ListaCamposOrigen2.Items.RemoveAt(ListaCamposOrigen2.SelectedIndex);
            ListaCamposOrigen2.SelectedIndex = si - 1;
        }
        private void BBajarOrigen_Click(object sender, EventArgs e)
        {
            if (ListaCamposOrigen2.SelectedIndex >= ListaCamposOrigen2.Items.Count-1)
                return;
            int si = ListaCamposOrigen2.SelectedIndex;
            Objetos.CParametro s = (Objetos.CParametro)ListaCamposOrigen2.Items[ListaCamposOrigen2.SelectedIndex];
            ListaCamposOrigen2.Items.Insert(ListaCamposOrigen2.SelectedIndex + 2, s);
            ListaCamposOrigen2.Items.RemoveAt(ListaCamposOrigen2.SelectedIndex);
            ListaCamposOrigen2.SelectedIndex = si +1;
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (ComboConexionOrigen.SelectedIndex == -1)
                ok = false;
            BBuscarTablaOrigen.Enabled = ok;
            ok = true;
            if (ListaCamposOrigen.SelectedIndex == -1)
                ok = false;
            BAgregarOrigen.Enabled = ok;
            ok = true;
            if (ListaCamposOrigen2.SelectedIndex == -1)
            {
                ok = false;
                BSubirOrigen.Enabled = false;
                BBajarOrigen.Enabled = false;
            }
            else
            {
                if (ListaCamposOrigen2.SelectedIndex == ListaCamposOrigen2.Items.Count - 1)
                {
                    BBajarOrigen.Enabled = false;
                }
                else
                {
                    BBajarOrigen.Enabled = true;
                }
                if (ListaCamposOrigen2.SelectedIndex == 0)
                {
                    BSubirOrigen.Enabled = false;
                }
                else
                {
                    BSubirOrigen.Enabled = true;
                }
            }
            BQuitarOrigen.Enabled = ok;
            ok = true;
            if (ComboConexionesDestino.SelectedIndex == -1)
                ok = false;
            RcrearTablaDestino.Enabled = ok;
            RSeleccionarTablaDestino.Enabled = ok;
            ok = false;
            if (RcrearTablaDestino.Enabled == false)
                ok = true;
            if (RcrearTablaDestino.Checked == false)
                ok = true;
            TTablaDestino.ReadOnly = ok;
            ok = true;
            if (RSeleccionarTablaDestino.Enabled == false)
                ok = false;
            if (RSeleccionarTablaDestino.Checked == false)
                ok = false;
            BBUscarTablaDestino.Enabled = ok;
            ok = true;
            if (ListaCamposDestino.SelectedIndex == -1)
                ok = false;
            BAgregarDestino.Enabled = ok;
            ok = true;
            if (ListaCamposDestino2.SelectedIndex == -1)
                ok = false;
            BQuitarDestino.Enabled = ok;
            if (ok == true)
            {
                if (ListaCamposDestino2.SelectedIndex == ListaCamposDestino2.Items.Count-1)
                {
                    BBajarDestino.Enabled = false;
                }
                else
                {
                    BBajarDestino.Enabled=true;
                }
                if (ListaCamposDestino2.SelectedIndex == 0)
                {
                    BSubirDestino.Enabled = false;
                }
                else
                {
                    BSubirDestino.Enabled = true;
                }
            }
            else
            {
                BSubirDestino.Enabled = false;
                BBajarDestino.Enabled = false;
            }
            ok = true;
            if (ListaCamposOrigen2.Items.Count == 0)
                ok = false;
            if (TTablaDestino.Text.Trim() == "")
                ok = false;
            if (RSeleccionarTablaDestino.Checked == true)
            {
                if (ListaCamposDestino2.Items.Count == 0)
                    ok = false;
            }
            ActivarImportar(ok);
        }
        private void RcrearTablaDestino_CheckedChanged(object sender, EventArgs e)
        {
            if (RcrearTablaDestino.Checked == true)
            {
                ListaCamposDestino2.Items.Clear();
                ListaCamposDestino.Items.Clear();
                TTablaDestino.Text = "";
            }
        }
        private void RSeleccionarTablaDestino_CheckedChanged(object sender, EventArgs e)
        {
            if (RSeleccionarTablaDestino.Checked == true)
            {
                TTablaDestino.Text = "";
            }
        }
        private void TTablaDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
        public override void Importar()
        {
            Worker.RunWorkerAsync();
            //ErroresCount = 0;
            //ActivarControles = false;
            //Errores = "";
            ////iniciar la importacion de la tabla
            ////primero verifica si hay que crear la tabla destino
            //if (RcrearTablaDestino.Checked == true)
            //{
            //    //hay que generar la tabla destino
            //    if (CreaTablaDestino() == false)
            //    {
            //        // no se pudo crear la tabla
            //        ActivarControles = true;
            //        return;
            //    }
            //}
            //else
            //{
            //    CamposDestino = new List<Visor_sql_2015.Objetos.CParametro>();
            //    foreach (Objetos.CParametro obj in ListaCamposDestino2.Items)
            //    {
            //        CamposDestino.Add(obj);
            //    }
            //}
            ////ahora genero los scrip para la insercion de los campos
            //GeneraScripInsercion();
        }
        #region Codigo Reemplazado
        //private bool CreaTablaDestino()
        //{
        //    cBarraProgreso1.Texto = "creando tabla " + TTablaDestino.Text;
        //    //me traigo la definicion de los campos de la tabla origen
        //    // y genero la consulta de creacion de la tabla,
        //    // pero primero checo si existe la tabla
        //    List<Objetos.CSysObject> lista = DBDestino.BuscaObjetos(TTablaDestino.Text.Trim(), Visor_sql_2015.Controladores_DB.TIPOOBJETO.NINGUNO);
        //    if(lista.Count>0)
        //    {
        //        // se encontraron objetos con nombre parecido
        //        foreach(Objetos.CSysObject obj in lista)
        //        {
        //            if (obj.Nombre.ToLower().Trim() == TTablaDestino.Text.ToLower().Trim())
        //            {
        //                System.Windows.Forms.MessageBox.Show("Ya existe la tabla destino");
        //                return false;
        //            }
        //        }
        //    }
        //    //crea un scrip para crear la tabla de la base de datos
        //    string s;
        //    s = "create table " + TTablaDestino.Text + "\r\n";
        //    s = s + "(\r\n";
        //    //defino los campos que lleva
        //    int i, n;
        //    n = ListaCamposOrigen2.Items.Count;
        //    CamposDestino = new List<Visor_sql_2015.Objetos.CParametro>();
        //    for (i = 0; i < n; i++)
        //    {
        //        Objetos.CParametro obj = (Objetos.CParametro)ListaCamposOrigen2.Items[i];
        //        CamposDestino.Add(obj);
        //        //le asigno el nombre del campo
        //        s = s + "\t";
        //        if (i > 0)
        //            s = s + ",";
        //        s = s + obj.nombre;
        //        //le asigno el tipo
        //        s = s + " " + obj.tipo;
        //        if (obj.tipo.ToLower().Trim() == "varchar" || obj.tipo.ToLower().Trim() == "char" || obj.tipo.ToLower().Trim() == "nvarchar")
        //            s = s + "(" + obj.Logitud.ToString() + ")";
        //        //verifico si es nulo o no es nulo
        //        if (obj.NULOS.ToLower().Trim() == "n")
        //            s = s + " not null";
        //        //doy un salto de linea para el siguiente campo
        //        s = s + "\r\n";
        //    }
        //    //ahora checo los constrains            
        //    System.Collections.Generic.List<Objetos.CParametro> PrimaryKeys;
        //    PrimaryKeys = DBOrigen.DameLLavesPrimarias(TTablaOrigen.Text);
        //    n = PrimaryKeys.Count;
        //    bool primero = true;
        //    if (n > 0)
        //    {
        //        string spk = "\t,constraint PK_" + TTablaDestino.Text + " primary key(";
        //        for (i = 0; i < n; i++)
        //        {
        //            bool encontrado=false;
        //            Objetos.CParametro objpk = PrimaryKeys[i];
        //            //checo si esta en la lista de campos eleccionados
        //            foreach (Objetos.CParametro objpk2 in ListaCamposOrigen2.Items)
        //            {
        //                if (objpk.nombre == objpk2.nombre)
        //                {
        //                    encontrado = true;
        //                    break;
        //                }
        //            }
        //            if (encontrado == true)
        //            {
        //                if (primero == false)
        //                    spk = spk + ",";
        //                else
        //                    primero = false;
        //                spk = spk + objpk.nombre;
        //            }
        //        }
        //        s =s+ spk + ")\r\n";
        //    }
        //    s = s + "\r\n)";
        //    try
        //    {
        //        DBDestino.Ejecuta(s);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        //se genro un error al crear la tabla
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "ERROR");
        //        return false;
        //    }
        //    return true;
        //}
        //private void GeneraScripInsercion()
        //{
        //    Identidad = false;
        //    cBarraProgreso1.Texto = "Extrayendo información de la tabla";
        //    string s = "select  ";
        //    bool primero=true;
        //    //recorro los campos de la tabla origen para generar la consulta de lectura
        //    foreach(Objetos.CParametro obj in ListaCamposOrigen2.Items)
        //    {
        //        if (primero == false)
        //            s = s + ",";
        //        else
        //            primero = false;
        //        if (obj.AutoIncremental == true)
        //            Identidad = true;
        //        s = s + obj.nombre;
        //    }
        //    s = s + " from "+TTablaOrigen.Text;
        //    if (TFiltro.Text.Trim() != "")
        //    {
        //        //hay que agregar el filtro
        //        s = s + " where " + TFiltro.Text;
        //    }
        //    //ejecuto La consulta
        //    DataSet DtS=null; 
        //    try
        //    {
        //        DtS = DBOrigen.Ejecuta(s);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //        ActivarControles = true;
        //        return;
        //    }
        //    //obtengo la tabla que me regresa
        //    Tabla = DtS.Tables[0];
        //    //genero la parte fija del insert
        //    if (Identidad == true)
        //    {
        //        try
        //        {
        //            DBDestino.Ejecuta("SET IDENTITY_INSERT " + TablaDestino + " ON ");
        //        }
        //        catch (System.Exception ex)
        //        {
        //            Errores = Errores + s + "\r\n";
        //            Errores = Errores + ex.Message + "\r\n";
        //            ErroresCount++;

        //        }
        //    }
        //    Sinsert = "insert into " + TablaDestino + "(";
        //    primero = true;
        //    foreach (Objetos.CParametro obj2 in CamposDestino)
        //    {
        //        if (primero == false)
        //            Sinsert = Sinsert + ",";
        //        else
        //            primero = false;
        //        Sinsert = Sinsert + obj2.nombre;

        //    }
        //    Sinsert = Sinsert + ") values(";
        //    //aqui modifico para pasar esta parte al timer
        //    cBarraProgreso1.ValorMaximo = Tabla.Rows.Count;
        //    cBarraProgreso1.Progreso = 0;
        //    cBarraProgreso1.Texto = "Insertando " + cBarraProgreso1.Progreso.ToString() + "/" + cBarraProgreso1.ValorMaximo;
        //    TInsertar.Enabled = true;
        //    return;
        //    //-----------------------------------------------------------------------------
        //}
        //private void TInsertar_Tick(object sender, EventArgs e)
        //{
        //    if (cBarraProgreso1.Progreso >= Tabla.Rows.Count)
        //    {
        //        if (Identidad == true)
        //        {
        //            try
        //            {
        //                DBDestino.Ejecuta("SET IDENTITY_INSERT " + TablaDestino + " OFF ");
        //            }
        //            catch (System.Exception ex)
        //            {
        //                Errores = Errores + "SET IDENTITY_INSERT " + TablaDestino + " OFF " + "\r\n";
        //                Errores = Errores + ex.Message + "\r\n";
        //                ErroresCount++;

        //            }
        //        }
        //        TInsertar.Enabled = false;
        //        cBarraProgreso1.Texto = "Carga terminada";
        //        if (Errores.Trim() != "")
        //        {
        //            MuestraMensage("Errores en la importacion", Errores + "\r\nERRORES=" + ErroresCount.ToString());
        //        }
        //        ActivarControles = true;
        //        return;
        //    }
        //    //me traigo el registro que corresponde
        //    DataRow reg = Tabla.Rows[cBarraProgreso1.Progreso];
        //    //genero el scrip de insercion por cada registro
        //    bool primero = true;
        //    string s = "";
        //    foreach (Objetos.CParametro obj4 in ListaCamposOrigen2.Items)
        //    {
        //        if (Identidad == false)
        //        {
        //            if (DBDestino.EsIdentity(TablaDestino, obj4.nombre) != "")
        //            {
        //                DBDestino.Ejecuta("SET IDENTITY_INSERT " + TablaDestino + " ON  ");
        //                Identidad = true;
        //            }
        //        }
        //        if (primero == false)
        //        {
        //            s = s + ",";
        //        }
        //        else
        //            primero = false;
        //        if (obj4.TipoNet == "string")
        //            s = s + "\'" + reg[obj4.nombre] + "\'";
        //        else if (obj4.TipoNet == "System.DateTime")
        //        {
        //            string sf = reg[obj4.nombre].ToString();
        //            if (sf != "")
        //            {
        //                System.DateTime d = System.DateTime.Parse(reg[obj4.nombre].ToString());
        //                s = s + "convert(datetime,\'" + d.ToString("dd/MM/yyyy hh:mm:ss") + "\',103)";
        //            }
        //            else
        //            {
        //                s = s + "NULL";
        //            }
        //        }
        //        else
        //        {
        //            string sx = reg[obj4.nombre].ToString();
        //            if (obj4.TipoNet == "int")
        //            {
        //                if (sx.ToUpper().Trim() == "TRUE" || sx.ToUpper().Trim() == "FALSE")
        //                {
        //                    if (sx.ToUpper().Trim() == "TRUE")
        //                        sx = "1";
        //                    else
        //                        sx = "0";
        //                }
        //                if (sx.Trim() == "")
        //                {
        //                    sx = "NULL";
        //                }
        //            }
        //            if (obj4.TipoNet == "float")
        //            {
        //                if (sx.Trim() == "")
        //                {
        //                    sx = "NULL";
        //                }
        //            }
        //                s = s + sx;
        //        }
        //    }
        //    s = Sinsert + s + ") ";
        //    try
        //    {
        //        DBDestino.Ejecuta(s);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Errores = Errores + s + "\r\n";
        //        Errores = Errores + ex.Message + "\r\n";
        //        ErroresCount++;

        //    }
        //    cBarraProgreso1.Progreso++;
        //    cBarraProgreso1.Texto = "Insertando " + cBarraProgreso1.Progreso.ToString() + "/" + cBarraProgreso1.ValorMaximo;

        //}
        #endregion
        private bool ActivarControles
        {
            set
            {
                //desactiva o activa los controles
                ActivarImportar(value);
                timer1.Enabled=value;
                ComboConexionOrigen.Enabled = value;
                ComboConexionesDestino.Enabled = value;
               // if (value == false)
                {
                    BBuscarTablaOrigen.Enabled = value;
                    BSubirOrigen.Enabled = value;
                    BAgregarOrigen.Enabled = value;
                    BQuitarOrigen.Enabled = value;
                    BBajarOrigen.Enabled = value;
                    RcrearTablaDestino.Enabled = value;
                    RSeleccionarTablaDestino.Enabled = value;
                    TTablaDestino.Enabled = value;
                    BSubirDestino.Enabled = value;
                    BAgregarDestino.Enabled = value;
                    BQuitarDestino.Enabled = value;
                    BBajarDestino.Enabled = value;
                }
            }
        }
        private void CargaGrupos()
        {
            ComboGrupos.Items.Clear();
            ComboGrupos2.Items.Clear();
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
                ComboGrupos2.Items.Add(s.Substring(pos + 1));
            }
        }
        private void ComboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargo la lista de conexiones
            ComboConexionOrigen.Items.Clear();
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
                ComboConexionOrigen.Items.Add(Submenu.Text);
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
        private void ComboGrupos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargo la lista de conexiones
            ComboConexionesDestino.Items.Clear();
            int i, n;
            string[] archivos;
            if (System.IO.Directory.Exists(DirConexionesGrupo2) == false)
            {
                System.IO.Directory.CreateDirectory(DirConexionesGrupo2);
            }
            archivos = System.IO.Directory.GetFiles(DirConexionesGrupo2);
            n = archivos.GetLength(0);
            for (i = 0; i < n; i++)
            {
                System.Windows.Forms.ToolStripMenuItem Submenu = new System.Windows.Forms.ToolStripMenuItem();
                Submenu.Text = QuitaDirectorio(archivos[i]);
                ComboConexionesDestino.Items.Add(Submenu.Text);
            }
        }
        private string DirConexionesGrupo2
        {
            get
            {
                if (Grupo == "")
                    return DirConexiones;
                return DirConexiones + "\\" + Grupo2;
            }
        }
        private string Grupo2
        {
            get
            {
                if (ComboGrupos2.SelectedIndex == -1)
                    return "";
                return (string)ComboGrupos2.Items[ComboGrupos2.SelectedIndex];
            }
            set
            {
                if (ComboGrupos2.Items.Count == 0)
                    CargaGrupos();
                int i, n;
                n = ComboGrupos2.Items.Count;
                for (i = 0; i < n; i++)
                {
                    string s = (string)ComboGrupos2.Items[i];
                    if (s == value)
                    {
                        ComboGrupos2.SelectedIndex = i;
                        ComboGrupos2_SelectedIndexChanged(null, null);
                        return;
                    }
                }
            }
        }

        private int DoAllWork()
        {
            string Sent_SQL;
            string s, SQL_Origen = "select ";
            bool reportprogress;
            SqlBulkCopy BatchCopy;
            SqlDataReader Reader;
            bool primero = true;

            Worker.ReportProgress(0, "Iniciando Proceso");
            SqlCommand CmdDest, CmdOrig;
            System.Data.SqlClient.SqlConnection con = new SqlConnection(DBDestino.ConnectionString);
            CmdDest = con.CreateCommand();
            CmdOrig = con.CreateCommand();

            CmdDest.Connection.Open();
            CmdOrig.Connection.Open();
            CmdDest.CommandTimeout = 0;
            CmdOrig.CommandTimeout = 0;


            if (RcrearTablaDestino.Checked)
            {//si se selecciona la opcion de crear tabla destino, hacer drop en la tabla si existe, y luego crear
                Worker.ReportProgress(0, "Creando Tabla Destino");
                #region Creacion de la Tabla Destino
                Sent_SQL = "if object_id('@tabla') is not null \n" +
                "	drop table @tabla \n";

                Sent_SQL = Sent_SQL.Replace("@tabla", TTablaDestino.Text);
                CmdDest.CommandText = Sent_SQL;
                CmdDest.ExecuteNonQuery();
                //crea un scrip para crear la tabla de la base de datos
                s = "create table " + TTablaDestino.Text + "\r\n";
                s = s + "(\r\n";
                //defino los campos que lleva
                int i, n;
                n = ListaCamposOrigen2.Items.Count;
                CamposDestino = new List<Visor_sql_2015.Objetos.CParametro>();
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro obj = (Objetos.CParametro)ListaCamposOrigen2.Items[i];
                    CamposDestino.Add(obj);
                    //le asigno el nombre del campo
                    s = s + "\t";
                    if (i > 0)
                        s = s + ",";
                    s = s + obj.nombre;
                    //le asigno el tipo
                    s = s + " " + obj.tipo;
                    if (obj.tipo.ToLower().Trim() == "varchar" || obj.tipo.ToLower().Trim() == "char" || obj.tipo.ToLower().Trim() == "nvarchar")
                        s = s + "(" + obj.Logitud.ToString() + ")";
                    // aplico la configuracion regional
                    if(obj.collation!="")
                        s = s + " COLLATE " + obj.collation;
                    //verifico si es nulo o no es nulo
                    if (obj.NULOS.ToLower().Trim() == "n")
                        s = s + " not null";
                    //doy un salto de linea para el siguiente campo
                    s = s + "\r\n";
                }
                //ahora checo los constrains            
                System.Collections.Generic.List<Objetos.CParametro> PrimaryKeys;
                PrimaryKeys = DBOrigen.DameLLavesPrimarias(TTablaOrigen.Text);
                CmdOrig.Connection.Open();
                n = PrimaryKeys.Count;
                primero = true;
                if (n > 0)
                {
                    string spk = "\t,constraint PK_" + TTablaDestino.Text + " primary key(";
                    for (i = 0; i < n; i++)
                    {
                        bool encontrado = false;
                        Objetos.CParametro objpk = PrimaryKeys[i];
                        //checo si esta en la lista de campos eleccionados
                        foreach (Objetos.CParametro objpk2 in ListaCamposOrigen2.Items)
                        {
                            if (objpk.nombre == objpk2.nombre)
                            {
                                encontrado = true;
                                break;
                            }
                        }
                        if (encontrado == true)
                        {
                            if (primero == false)
                                spk = spk + ",";
                            else
                                primero = false;
                            spk = spk + objpk.nombre;
                        }
                    }
                    s = s + spk + ")\r\n";
                }
                s = s + "\r\n)";
                try
                {
                    CmdDest.CommandText = s;
                    CmdDest.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    //se genro un error al crear la tabla
                    #region Cerrar Conexiones, Verificando si es que estan abiertas...
                    if (CmdDest.Connection.State == ConnectionState.Open)
                        CmdDest.Connection.Close();
                    if (CmdOrig.Connection.State == ConnectionState.Open)
                        CmdOrig.Connection.Close();
                    #endregion
                    System.Windows.Forms.MessageBox.Show(ex.Message, "ERROR");
                    return -1;
                }
                #endregion
                Worker.ReportProgress(0, "Tabla Destino Creada");
            }
            else
            {//si no existe borrar los registros en la tabla
                Worker.ReportProgress(0, "Borrando Informacion de la Tabla Destino");
                #region Borrado de registros de la tabla destino
                //Quitar las restricciones y triggers sobre la tabla antes de borrar
                CmdDest.CommandText = "ALTER TABLE [dbo].[" + TTablaDestino.Text + "] NOCHECK CONSTRAINT ALL";
                CmdDest.CommandText += " ALTER TABLE [dbo].[" + TTablaDestino.Text + "] DISABLE TRIGGER ALL";
                CmdDest.ExecuteNonQuery();

                //Borrar todos los registros de la tabla
                try
                {//primero definir si tiene llaves foraneas o no, para usar delete o truncate
                    CmdDest.CommandText = "SELECT OBJECTPROPERTY ( object_id('" + TTablaDestino.Text + "'),'TableHasForeignRef')";
                    int intref = Convert.ToInt32(CmdDest.ExecuteScalar());
                    if (intref == 1)
                        CmdDest.CommandText = "DELETE FROM " + TTablaDestino.Text;
                    else
                        CmdDest.CommandText = "TRUNCATE TABLE " + TTablaDestino.Text;
                    CmdDest.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    #region Cerrar Conexiones, Verificando si es que estan abiertas...
                    if (CmdDest.Connection.State == ConnectionState.Open)
                        CmdDest.Connection.Close();
                    if (CmdOrig.Connection.State == ConnectionState.Open)
                        CmdOrig.Connection.Close();
                    #endregion
                    MessageBox.Show(ex.Message, "Error en el Borrado de la Tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DBDestino.Close();
                    return -1;
                }
                //Reactivar las Restricciones y triggers
                CmdDest.CommandText = "ALTER TABLE [dbo].[" + TTablaDestino.Text + "] CHECK CONSTRAINT ALL";
                CmdDest.CommandText += " ALTER TABLE [dbo].[" + TTablaDestino.Text + "] ENABLE TRIGGER ALL";
                CmdDest.ExecuteNonQuery();
                #endregion
                Worker.ReportProgress(0, "Tabla Destino \"Limpia\"");
            }

            try
            {

                #region obtener el numero de registros a mover
                if (TFiltro.Text.Length > 0)
                    Sent_SQL = "select count(*) as records from " + TTablaOrigen.Text + " where " + TFiltro.Text;
                else
                    Sent_SQL = "select count(*) as records from " + TTablaOrigen.Text;

                CmdOrig.CommandText = Sent_SQL;
                records = Convert.ToInt32(CmdOrig.ExecuteScalar());
                Worker.ReportProgress(0, "Copiando Registros 0/" + records.ToString());

                //definir si el numero de registros merece actualizar la barra de progreso
                if (records > 5000)
                    reportprogress = true;
                else
                    reportprogress = false;
                #endregion

                #region Obtener los datos de origen y hacer el mapeo de Columna_Origen vs Columna_Destino
                //generar el select de los datos origen
                primero = true;
                foreach (Objetos.CParametro obj in ListaCamposOrigen2.Items)
                {
                    if (primero == false)
                        SQL_Origen += ", ";
                    else
                        primero = false;

                    if (obj.AutoIncremental == true)
                        Identidad = true;
                    SQL_Origen += obj.nombre;
                }
                SQL_Origen += " from " + TTablaOrigen.Text;
                if (TFiltro.Text.Trim() != "")
                {
                    //hay que agregar el filtro
                    SQL_Origen += " where " + TFiltro.Text;
                }
                CmdOrig.CommandText = SQL_Origen;
                Reader = CmdOrig.ExecuteReader();

                BatchCopy = new SqlBulkCopy(DBDestino.ConnectionString, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.CheckConstraints);

                //Mapear/Relacionar columnas de origen con las columnas de destino
                for (int i = 0; i < ListaCamposOrigen2.Items.Count; i++)
                {
                    Objetos.CParametro Orig, Dest;
                    Orig = (Objetos.CParametro)ListaCamposOrigen2.Items[i];
                    if (!RcrearTablaDestino.Checked)
                        Dest = (Objetos.CParametro)ListaCamposDestino2.Items[i];
                    else
                        Dest = (Objetos.CParametro)ListaCamposOrigen2.Items[i];
                    BatchCopy.ColumnMappings.Add(Orig.nombre, Dest.nombre);
                }
                #endregion

                if (reportprogress)
                {
                    BatchCopy.NotifyAfter = 5000;
                    BatchCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(BatchCopy_SqlRowsCopied);
                }

                BatchCopy.BulkCopyTimeout = 0;
                BatchCopy.DestinationTableName = TTablaDestino.Text;
                BatchCopy.WriteToServer(Reader);
                BatchCopy.Close();
                Reader.Close();


                #region Cerrar Conexiones, Verificando si es que estan abiertas...
                if (CmdDest.Connection.State == ConnectionState.Open)
                    CmdDest.Connection.Close();
                if (CmdOrig.Connection.State == ConnectionState.Open)
                    CmdOrig.Connection.Close();
                #endregion
                return 1;

            }
            catch (Exception ex)
            {
                #region Cerrar Conexiones, Verificando si es que estan abiertas...
                if (CmdDest.Connection.State == ConnectionState.Open)
                    CmdDest.Connection.Close();
                if (CmdOrig.Connection.State == ConnectionState.Open)
                    CmdOrig.Connection.Close();
                #endregion
                throw ex;
//                return -1;
            }
        }
        void BatchCopy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            cBarraProgreso1.Texto = "Insertando " + e.RowsCopied.ToString() + "/" + records.ToString();
            cBarraProgreso1.Progreso = (int)(((float)(e.RowsCopied * 100)) / ((float)records));
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int res = -1;
            if (Worker.CancellationPending)
                e.Cancel = true;
            else
            {
                try
                {
                    //Invoke(EventoMuestraProgreso, new Object[] { "Iniciando Proceso", 0 });
                    res = DoAllWork();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en Proceso de Copiado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (res < 0)
                    MessageBox.Show("Error en Importacion de Registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState.ToString() == "Iniciando Proceso")
                ActivarControles = false;

            cBarraProgreso1.Progreso = e.ProgressPercentage;
            cBarraProgreso1.Texto = e.UserState.ToString();
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ActivarControles = true;

            cBarraProgreso1.Progreso = 100;
            cBarraProgreso1.Texto = "Registros Copiados: " + records.ToString();
        }
    }
}

