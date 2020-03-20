using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.CrearTablas
{
    public delegate void OnCodigoEvent(string s);
    public partial class FormEditorTabla : Form
    {
        public event OnCodigoEvent OnCodigo;
        List<string> TiposDato;
        Controladores_DB.IDataBase DB;
        private string TablaActual;
        private DataTable Campos
        {
            get
            {
                return DSTabla.Tables["Campos"];
            }
        }
        public FormEditorTabla(Controladores_DB.IDataBase db)
        {
            DB = db;
            //me traigo la lista de tipos de datos que soporta el motor
            InitializeComponent();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BBuscarTabla_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Objetos.CSysObject> Lista;
            //limpio la lista de tablas
            ListaTablas.Nodes.Clear();
            TablaActual = "";
            // y tambien la de los camnpos hijos
            ListaCampos.Nodes.Clear();
            //hago la busqueda
            Lista = DB.BuscaObjetos(TBuscarTabla.Text.Trim(), Controladores_DB.TIPOOBJETO.TABLAX);
            //lleno la lista de tablas encontradas
            foreach (Objetos.CSysObject obj in Lista)
            {
                TreeNode nodo = new TreeNode(obj.Nombre);
                nodo.Tag = obj;
                ListaTablas.Nodes.Add(nodo);
            }
        }

        private void ListaTablas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TablaActual = e.Node.Text;
            //ahora me traigo los campos de la tabla
            List<Objetos.CParametro> Campos;
            Campos = DB.DameCamposTabla(TablaActual);
            //lleno la lista de campos
            ListaCampos.Nodes.Clear();
            foreach (Objetos.CParametro obj in Campos)
            {
                TreeNode nodo = new TreeNode(obj.nombre);
                nodo.Tag = obj;
                //selecciono el icono que le corresponde
                //hay 4 posobilidades
                //1. que sea un campo normal
                //2. que dea un campo con llave foranea
                //3. que sea un campo con llave primaria
                //4. que sea un campo con llave primaria y foranea
                //veo si el campo tiene llave primaria
                obj.LLaveForanea = DB.EsLLaveForanea(TablaActual, obj.nombre);
                if (obj.LLavePrimaria && obj.LLaveForanea)
                {
                    nodo.ImageIndex = 4;
                    nodo.SelectedImageIndex = 4;
                }
                else if (obj.LLavePrimaria)
                {
                    nodo.ImageIndex = 3;
                    nodo.SelectedImageIndex = 3;
                }
                else if (obj.LLaveForanea)
                {
                    nodo.ImageIndex = 2;
                    nodo.SelectedImageIndex = 2;
                }
                else
                {
                    nodo.ImageIndex = 1;
                    nodo.SelectedImageIndex = 1;
                }
                ListaCampos.Nodes.Add(nodo);
            }
        }

        private void FormEditorTabla_Load(object sender, EventArgs e)
        {
            //llleno la lista de tipos de datos soportados por el motor
            TiposDato = DB.DameTiposDatos();
            foreach (string s in TiposDato)
            {
                DataRow dr = DSTabla.Tables["Tipos"].NewRow();
                dr["Nombre"] = s;
                DSTabla.Tables["Tipos"].Rows.Add(dr);
            }
        }

        private void ListaCampos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode nodo;
            if (!e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                return;
            nodo = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //ya tengo el nodo ahora me traigo los datos del campo que contiene
            //ahora me traigo los campos de la tabla
            List<Objetos.CParametro> Campos;
            Campos = DB.DameCamposTabla(TablaActual);
            //lleno la lista de campos
            foreach (Objetos.CParametro obj in Campos)
            {
                if (obj.nombre == nodo.Text)
                {
                    //ya lo encontré ahora lo agrego a la lista
                    if (AgregaCampoExtra(obj) == false)
                        return;
                    
                }
            }
            nodo.Remove();
        }
        private bool ExisteCampoTabla(string campo)
        {
            foreach (DataRow dr in Campos.Rows)
            {
                if (dr["Nombre"].ToString().ToUpper().Trim() == campo.ToUpper().Trim())
                    return true;
            }
            return false;
        }
        private void AgregaCampo(Objetos.CParametro campo)
        {
            DataRow dr = null;
            dr = Campos.NewRow();
            dr["Nombre"] = campo.nombre;
            dr["Tipo"] = campo.tipo;
            dr["PK"] = false;
            if (campo.NULOS!=null && campo.NULOS.ToUpper().Trim() == "NO")
                dr["Nulos"] = false;
            else
                dr["Nulos"] = true;
            dr["AutoIncremental"] = campo.AutoIncremental;
            dr["Longitud"] = campo.Logitud;
            //dr["ValorDeafult"]=campo.Default;
            //dr["ValorCalculado"]=campo;
            Campos.Rows.Add(dr);
        }
        private bool AgregaCampoExtra(Objetos.CParametro campo)
        {
            string fk = "";
            //agrega el campo a la tabla
            //checo si el campo es una llabe primaria
            if (campo.LLavePrimaria)
            {
                //aqui hay de dos. 
                //1. Se agrega el campo solamente
                //2. Se agregan todos los campos que pertenecen a la llave primaria y se crea la relacion
                FormFK dlg = new FormFK();
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return false; //cancelo
                //me traigo la respuesta
                if (dlg.Respuesta == 1)
                {
                    //solamente hay que agregar el campo
                    if (ExisteCampoTabla(campo.nombre))
                    {
                        MessageBox.Show("El campo ya existe en la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    AgregaCampo(campo);
                    return true;
                }
                else
                {
                    //hay que agregar la relacion entre tablas
                    //me traigo los campos que son llabe primaria de la tabla
                    List<Objetos.CParametro> pks=                    DB.DameLLavesPrimarias(TablaActual);
                    //verifico que no existan en la tabla nueva
                    //creo el nombre de la nueva relacion
                    fk = "FK_"+TNombreTabla.Text + "_" + TablaActual;
                    AgregaFK(fk, TablaActual, TNombreTabla.Text);
                    foreach (Objetos.CParametro obj in pks)
                    {
                        if (!ExisteCampoTabla(obj.nombre))
                        {
                            AgregaCampo(obj);
                        }
                        //agrego la relacion
                        AgregaDetalleFK(fk, obj.nombre, obj.nombre);
                    }
                    MuestraFks();
                    //ahora hay que crear la relacion con la tabla padre
                    return true;
                }
            }
            //primero verifico que no exista el campo en la tabla
            if (ExisteCampoTabla(campo.nombre))
            {
                MessageBox.Show("El campo ya existe en la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //como no es llave primaria, simplemente hay que agregarlo
            AgregaCampo(campo);
            return true;
        }
        private void AgregaFK(string nombre, string TablaPadre, string TablaHija)
        {
            DataTable dt = DSTabla.Tables["Relaciones"];
            DataRow dr = dt.NewRow();
            dr["Nombre"]=nombre;
            dr["TablaPadre"]=TablaPadre;
            dr["TablaHija"] = TablaHija;
            dt.Rows.Add(dr);
        }
        private void AgregaDetalleFK(string Nombre, string ColumnaPadre, string ColumnaHija)
        {
            DataTable dt = DSTabla.Tables["RelacionDetalle"];
            DataRow dr = dt.NewRow();
            dr["Nombre"] = Nombre;
            dr["ColumnaPadre"] = ColumnaPadre;
            dr["ColumnaHija"] = ColumnaHija;
            dt.Rows.Add(dr);
        }
        private void TBuscarTabla_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BBuscarTabla_Click(null,null);
            }
        }

        private void ListaFK_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valida())
                {
                    GenerarTabla(true);
                    Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Valida()
        {
            if (TNombreTabla.Text.Trim() == "")
            {
                MessageBox.Show("falta el nombre de la tabla", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private string GenerarTabla(bool ejecutar)
        {
           
            Objetos.CDefinicionTabla tabla = new Objetos.CDefinicionTabla();
            tabla.Nombre = TNombreTabla.Text.Trim();
            //ahora agrego los campos
            DataTable campos = DSTabla.Tables["Campos"];
            DataTable Fks = DSTabla.Tables["Relaciones"];
            DataTable DetallesFK = DSTabla.Tables["RelacionDetalle"];
            foreach (DataRow dr in campos.Rows)
            {
                Objetos.CDefinicionCampo obj = new Objetos.CDefinicionCampo();
                obj.Nombre=dr["Nombre"].ToString();
                obj.Tipo = dr["Tipo"].ToString();
                if(dr["PK"].ToString().Trim()!="")
                    obj.ClavePrimaria =bool.Parse( dr["PK"].ToString());
                if (dr["Nulos"].ToString().Trim()!="")
                    obj.AceptaNulos = bool.Parse(dr["Nulos"].ToString());
                if (dr["AutoIncremental"].ToString().Trim()!="")
                    obj.AutoIncremental = bool.Parse(dr["AutoIncremental"].ToString());
                if (dr["Longitud"].ToString().Trim()!="")
                    obj.Longitud = int.Parse(dr["Longitud"].ToString());
                obj.ValorDefault = dr["ValorDeafult"].ToString();
                obj.ValorCalculado = dr["ValorCalculado"].ToString();
                if (dr["Unico"].ToString().Trim() != "")
                    obj.Unico = bool.Parse(dr["Unico"].ToString());
                tabla.Campos.Add(obj);
                if (obj.ClavePrimaria)
                {
                    tabla.PrimaryKey.Add(obj);
                }
            }
            //ahora agrego las llaves foraneas
            foreach (DataRow fk in Fks.Rows)
            {
                Objetos.CDefinicionFK obj = new Objetos.CDefinicionFK();
                obj.Nombre = fk["Nombre"].ToString();
                obj.TablaPadre = fk["TablaPadre"].ToString();
                obj.TablaHija = fk["TablaHija"].ToString();
                //ahora agrego el detalle
                foreach (DataRow detalle in DetallesFK.Rows)
                {
                    if (detalle["Nombre"].ToString() == obj.Nombre)
                    {
                        Objetos.CDefinicionDetalleFK obj2 = new Objetos.CDefinicionDetalleFK();
                        obj2.CampoPadre = detalle["ColumnaPadre"].ToString();
                        obj2.CampoHijo = detalle["ColumnaHija"].ToString();
                        obj.Campos.Add(obj2);
                    }
                }
                tabla.LLavesForaneas.Add(obj);
            }
            //agrego los valores unicos
            DataTable unicos = DSTabla.Tables["CamposUnicos"];
            foreach (DataRow dru in unicos.Rows)
            {
                tabla.Unicos.Add(dru["Campos"].ToString());
            }
            return DB.CreaTabla(tabla, ejecutar);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string s;
            try
            {
                if (Valida())
                {
                    s = GenerarTabla(false);
                    if (OnCodigo != null)
                        OnCodigo(s);
                    Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cambiarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //verifico si hay alguna liga seleccionada
            if (ListaFK.SelectedNode==null)
            {
                MessageBox.Show("seleccione primero alguna liga","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //me traigo el nombre de la liga
            string nombre = ListaFK.SelectedNode.Text;
            ListaFK.SelectedNode.BeginEdit();
            //pido que se cambie el nombre
        }

        private void ListaFK_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string fk = e.Node.Text;
            DataTable dt = DSTabla.Tables["RelacionDetalle"];
            var l = from myrown in dt.AsEnumerable()
                    where myrown.Field<String>("Nombre") == fk
                    select new
                    {
                        Nombre = myrown.Field<String>("Nombre")
                        ,
                        ColumnaPadre = myrown.Field<String>("ColumnaPadre")
                        ,
                        ColumnaHija = myrown.Field<String>("ColumnaHija")
                    };
            // MessageBox.Show(l.Count().ToString());
            DGVCamposFK.DataSource = l.ToList();
            //            DGVCamposFK.DataBind();

        }
        private void MuestraFks()
        {
            ListaFK.Nodes.Clear();
            DataTable Fks = DSTabla.Tables["Relaciones"];
            foreach (DataRow dr in Fks.Rows)
            {
                TreeNode n = new TreeNode();
                n.Text = dr["Nombre"].ToString();
                ListaFK.Nodes.Add(n);
            }
        }

        private void ListaFK_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string ViejoNombre;
            string NuevoNombre;
            ViejoNombre = e.Node.Text;
            NuevoNombre = e.Label;
            if (NuevoNombre == null || ValidaNombre(NuevoNombre) == false)
            {
                MessageBox.Show("Nombre invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
                return;
            }
            //me traigo el registro que hay que cambiar
            DataTable Fks = DSTabla.Tables["Relaciones"];
            foreach (DataRow dr in Fks.Rows)
            {
                if (dr["Nombre"].ToString() == ViejoNombre)
                {
                    dr["Nombre"] = NuevoNombre;
                    dr.AcceptChanges();
                    MuestraFks();
                    return;
                }
            }
        }
        private bool ValidaNombre(string nombre)
        {
            if (nombre.Trim() == "")
                return false;
            if (nombre.Contains(' '))
                return false;
            if (nombre.Contains('.'))
                return false;
            if (nombre.Contains('+'))
                return false;
            if (nombre.Contains(','))
                return false;
            return true;
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre=ListaFK.SelectedNode.Text;
            if (MessageBox.Show("Eliminar la llave foranea: " + nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            //me traigo el registro que hay que cambiar
            DataTable Fks = DSTabla.Tables["Relaciones"];
            foreach (DataRow dr in Fks.Rows)
            {
                if (dr["Nombre"].ToString() == nombre)
                {
                    dr.Delete();
                    //dr.AcceptChanges();
                    MuestraFks();
                    return;
                }
            }

        }

        private void BagregarUnicos_Click(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            DataTable dt;
            //me traigo la lista de campos que pertenecen a la tabla
            dt = DSTabla.Tables["Campos"];
            //recorro los campos
            foreach (DataRow dr in dt.Rows)
            {
                l.Add(dr["Nombre"].ToString());
            }
            FormUnicos dlg = new FormUnicos(l);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            //agrego la relacion
            DataTable dt2 = DSTabla.Tables["CamposUnicos"];
            DataRow dr2 = dt2.NewRow();
            dr2["Campos"] = dlg.Campos;
            dt2.Rows.Add(dr2);
        }

        private void BQuitarUnicos_Click(object sender, EventArgs e)
        {
            if (ListaUnicos.SelectedIndex == -1)
                return;
            //me traigo la tabla
            DataTable dt2 = DSTabla.Tables["CamposUnicos"];
            dt2.Rows.RemoveAt(ListaUnicos.SelectedIndex);
            dt2.AcceptChanges();
        }
    }
}
