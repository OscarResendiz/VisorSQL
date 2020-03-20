using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public partial class AsisSelParametros : Visor_sql_2015.AsistSps.AsistBaseSP
    {
        private string Tabla;

        private Controladores_DB.IDataBase DB;
        public AsisSelParametros(Controladores_DB.IDataBase db)
        {
            DB = db;
            Tabla = "";
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible == false)
                return;
            bool ok = true;
            string tipo = (string)DameValor("Tipo");
            if (tipo != "Lectura")
            {
                if (ListaParametros.Items.Count == 0)
                    ok = false;
            }
            if (CHExcepcion.Checked == true)
            {
                if (TExcepcion.Text.Trim() == "")
                    ok = false;
            }
            EnableAnterior(true);
            EnableSiguiente(ok);
            ok = true;
            if (ListaCampos.SelectedIndices.Count == 0)
                ok = false;
            BAgregar.Enabled = ok;
            ok = true;
            if (ListaParametros.SelectedIndices.Count == 0)
                ok = false;
            if (tipo == "Delete")
                ok = false;
            BQuitar.Enabled = ok;
            TExcepcion.Enabled = CHExcepcion.Checked;
            TComentarios.Enabled = CHExcepcion.Checked;
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            int i, n, pos;
            n = ListaCampos.SelectedIndices.Count;
            //agrego los campos ala lista de parametros
            for (i = 0; i < n; i++)
            {
                pos = ListaCampos.SelectedIndices[i];
                ListaParametros.Items.Add(ListaCampos.Items[pos]);
            }
            //elimino la lista de campos seleccionados
            for (i = n - 1; i >= 0; i--)
            {
                pos = ListaCampos.SelectedIndices[i];
                ListaCampos.Items.RemoveAt(pos);
            }
        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            int i, n, pos;
            n = ListaParametros.SelectedIndices.Count;
            //agrego los campos ala lista de parametros
            for (i = 0; i < n; i++)
            {
                pos = ListaParametros.SelectedIndices[i];
                ListaCampos.Items.Add(ListaParametros.Items[pos]);
            }
            //elimino la lista de campos seleccionados
            for (i = n - 1; i >= 0; i--)
            {
                pos = ListaParametros.SelectedIndices[i];
                ListaParametros.Items.RemoveAt(pos);
            }

        }

        private void ListaParametros_DoubleClick(object sender, EventArgs e)
        {
            if (ListaParametros.SelectedIndex == -1)
                return;
            Objetos.CParametro obj = (Objetos.CParametro)ListaParametros.Items[ListaParametros.SelectedIndex];
            string tipo = (string)DameValor("Tipo");
            if (tipo == "Lectura")
            {
                FormPropParametro dlg = new FormPropParametro();
                dlg.Nombre = obj.nombre;
                dlg.Tipo = obj.tipo;
                dlg.Filtro = obj.Filtro;
                dlg.Comentario = obj.Descripcion;
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                obj.Filtro = dlg.Filtro;
                obj.Descripcion = dlg.Comentario;
            }
            else if (tipo == "Escritura" || tipo == "Update")
            {
                FormPropParametro2 dlg = new FormPropParametro2();
                dlg.Nombre = obj.nombre;
                dlg.Tipo = obj.tipo;
                dlg.NoRepetibles = obj.ValidarUnicidad;
                dlg.Comentario = obj.Descripcion;
                dlg.Vacios = obj.Vacios;
                dlg.ExcepcionNoRepetibles = obj.ExcepcionNoRepetibles;
                dlg.ExcepcionVacios = obj.ExcepcionVacios;
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                obj.Descripcion = dlg.Comentario;
                obj.ValidarUnicidad = dlg.NoRepetibles;
                obj.Descripcion = dlg.Comentario;
                obj.Vacios = dlg.Vacios;
                obj.ExcepcionNoRepetibles = dlg.ExcepcionNoRepetibles;
                obj.ExcepcionVacios = dlg.ExcepcionVacios;
            }
        }
        public override void BSiguiente()
        {
            string tipo = (string)DameValor("Tipo");
            if (Siguiente == null)
            {
                if (tipo == "Lectura")
                {
                    Siguiente = new AsisSelCampos(DB);
                }
                else if (tipo == "Escritura" || tipo == "Update")
                {
                    Siguiente = new AsisSelValFijos(DB);
                }
                else if (tipo == "Delete")
                {
                    Siguiente = new AsisForeigKeys(DB);
                }
                Siguiente.Anterior = this;
            }
            //guardo mis datos
            List<Objetos.CParametro> lista = new List<Visor_sql_2015.Objetos.CParametro>();
            foreach (Objetos.CParametro obj in ListaParametros.Items)
            {
                lista.Add(obj);
            }
            AsignaValor("ListaParametros", lista);
            AsignaValor("CHExcepcionParametros", CHExcepcion.Checked);
            AsignaValor("ExcepcionParametros", TExcepcion.Text);
            AsignaValor("ComentariosParametros", TComentarios.Text);
            OnInstalame(Siguiente);
        }
        public override void Inicializate()
        {
            string tipo = (string)DameValor("Tipo");
            if (tipo == "Lectura")
            {
                CHExcepcion.Visible = true;
                label3.Visible = true;
                TExcepcion.Visible = true;
                label5.Visible = true;
                TComentarios.Visible = true;
            }
            else
            {
                CHExcepcion.Visible = false;
                label3.Visible = false;
                TExcepcion.Visible = false;
                label5.Visible = false;
                TComentarios.Visible = false;
            }

            string tabla = (string)DameValor("Tabla");
            if (Tabla == tabla)
            {
                //no nececito actualizar nada
                return;
            }
            Tabla = tabla;
            //cambio el nombre de la tabla, por lo que actualizo mis listas
            ListaCampos.Items.Clear();
            ListaParametros.Items.Clear();
            //me traigo la lista de campos de la tabla
            List<Objetos.CParametro> campos = DB.DameCamposTabla(Tabla);
            foreach (Objetos.CParametro obj in campos)
            {
                if (obj.LLavePrimaria == true && (tipo=="Update"||tipo=="Delete"))
                    ListaParametros.Items.Add(obj);
                else
                    ListaCampos.Items.Add(obj);
            }
            if (tipo == "Delete")
            {
                //es de borrado, por loque desactivo unos botones
                ListaCampos.Enabled = false;
                //ListaParametros.Enabled = false;
                //ListaParametros.ContextMenu = null;
            }

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNuevoCampo dlg = new FormNuevoCampo(DB);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            ListaParametros.Items.Add(dlg.Parametro);
        }

        private void ListaCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DlstPropiedades.Items.Clear();
            if (ListaCampos.SelectedIndex == -1)
                return;
            string tabla = (string)DameValor("Tabla");
            Objetos.CParametro obj;
            obj = (Objetos.CParametro)ListaCampos.Items[ListaCampos.SelectedIndex];
            DlstPropiedades.Items.Add("nombre="+obj.nombre);
            DlstPropiedades.Items.Add("Tipo="+obj.tipo);
            DlstPropiedades.Items.Add("Longitud="+obj.Logitud.ToString());
            DlstPropiedades.Items.Add("Identidad=" + DB.EsIdentity(tabla, obj.nombre));
            TxtDocumentacion.Rtf = DB.DameDescripcionCampo(tabla, obj.nombre);
            //DlstPropiedades.Items.Add("");
            //DlstPropiedades.Items.Add("");
        }
    }
}

