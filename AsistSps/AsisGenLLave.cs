using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public partial class AsisGenLLave : Visor_sql_2015.AsistSps.AsistBaseSP
    {
        List<Objetos.CParametro> LLaves;
        Controladores_DB.IDataBase DB;
        private string Tabla;
        public AsisGenLLave(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
        }
        public override void Inicializate()
        {
            string tabla = (string)DameValor("Tabla");
            //if (Tabla == tabla)
            //{
            //    //no nececito actualizar nada
            //    return;
            //}
            Tabla = tabla;
            //me traiog los campos de la llave primaria
            LLaves = DB.DameLLavesPrimarias(Tabla);
            //si no tiene llaves desactivo el checbox
            if (LLaves.Count == 0)
            {
                CHGenLLave.Enabled = false;
                CHGenLLave.Checked = false;
                return;
            }
            //ahora me traigo los parametros para ver si alguna llave esta dentro de ellos
            List<Objetos.CParametro> parametros;
            parametros = (List<Objetos.CParametro>)DameValor("ListaParametros");
            List<Objetos.CParametro> libres = new List<Visor_sql_2015.Objetos.CParametro>();
            foreach (Objetos.CParametro llave in LLaves)
            {
                bool encontrado = false;
                foreach (Objetos.CParametro parametro in parametros)
                {
                    if (llave.nombre == parametro.nombre)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    libres.Add(llave);
                }
            }
            // si no me quedo ninguna,desactivo el chec
            if (libres.Count == 1)
            {
                CHGenLLave.Enabled = true;
                CHGenLLave.Checked = true;
                AsignaValor("CampoLLave", libres[0]);
                return;
            }
            CHGenLLave.Enabled = false;
            CHGenLLave.Checked = false;
        }
        public override void BSiguiente()
        {
            string tipo = (string)DameValor("Tipo");
            if (Siguiente == null)
            {
                Siguiente = new AsisResInsert(DB);
                Siguiente.Anterior = this;
            }
            //guardo mis datos
            AsignaValor("AsisGenLLave", CHGenLLave.Checked);
            OnInstalame(Siguiente);
        }
    }
}

