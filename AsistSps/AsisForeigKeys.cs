using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public partial class AsisForeigKeys : Visor_sql_2015.AsistSps.AsistBaseSP
    {
        private string Tabla;
        private Controladores_DB.IDataBase DB;
        public AsisForeigKeys(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
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
            Objetos.CLLaveForanea obj = (Objetos.CLLaveForanea)ListaParametros.Items[ListaParametros.SelectedIndex];
            string modo = (string)DameValor("Tipo");
            if (modo == "Escritura" || modo == "Update")
            {
                FormForeigKey dlg = new FormForeigKey(DB);
                dlg.Nombre = obj.name;
                dlg.GenerarExcepcion = obj.GenerarExcepcion;
                dlg.Docuemntacion = obj.Comentarios;
                dlg.Excepcion = obj.Mensage;
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                obj.name = dlg.Nombre;
                obj.GenerarExcepcion = dlg.GenerarExcepcion;
                obj.Comentarios = dlg.Docuemntacion;
                obj.Mensage = dlg.Excepcion;
            }
            if (modo == "Delete")
            {
                FormPropFkDelete dlg2 = new FormPropFkDelete(DB, obj);
                if (dlg2.ShowDialog() == DialogResult.Cancel)
                    return;
            }
        }
        public override void BSiguiente()
        {
            string modo = (string)DameValor("Tipo");
            if (modo == "Escritura")
            {
                if (Siguiente == null)
                {
                    Siguiente = new AsisGenLLave(DB);
                    Siguiente.Anterior = this;
                }
                //guardo mi informacion
            }
            if (modo == "Update")
            {
                if (Siguiente == null)
                {
                    Siguiente = new AsisResUpdate(DB);
                    Siguiente.Anterior = this;
                }
            }
            if (modo == "Delete")
            {
                if (Siguiente == null)
                {
                    Siguiente = new AsisResDelete(DB);
                    Siguiente.Anterior = this;
                }
            }
            List<Objetos.CLLaveForanea> lista = new List<Visor_sql_2015.Objetos.CLLaveForanea>();
            foreach (Objetos.CLLaveForanea obj in ListaParametros.Items)
            {
                lista.Add(obj);
            }
            AsignaValor("AsisForeigKeys", lista);
            OnInstalame(Siguiente);
        }
        public override void Inicializate()
        {
            string modo = (string)DameValor("Tipo");
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

            //me traigo la lista llaves foraneas de la tabla
            List<Objetos.CLLaveForanea> campos =null;
            if(modo =="Delete")
                campos = DB.DameLLavesForaneasHijas(Tabla);
            else
                campos = DB.DameLLavesForaneas(Tabla);
            //List<Objetos.CParametro> lista = (List<Objetos.CParametro>)DameValor("ListaParametros");
            foreach (Objetos.CLLaveForanea obj in campos)
            {
                ListaCampos.Items.Add(obj);
            }
        }
    }
}

