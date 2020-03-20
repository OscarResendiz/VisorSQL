using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class LLAveForanea: DBObjeto
    {
        private List<DetalleFK> FCampos;
        public LLAveForanea()
        {
            FTipoObjeto = DBTIPO.FK;
        }
        public List<DetalleFK> Campos
        {
            get
            {
                if (FCampos == null)
                    FCampos = new List<DetalleFK>();
                return FCampos;
            }
        }
        public Tabala TablaPadre;
        public Tabala TablaHija;
        public void AgregaDetalle(DetalleFK obj)
        {
            //lo agrega si no existe
            foreach (DetalleFK d in Campos)
            {
                if (d.CampoHijo.Nombre == obj.CampoHijo.Nombre && d.CampoPadre.Nombre == obj.CampoPadre.Nombre)
                {
                    //ya existe;
                    return;
                }
            }
            //no existe
            Campos.Add(obj);
        }
    }
}
