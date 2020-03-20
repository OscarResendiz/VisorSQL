using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    public class CDefinicionFK
    {
        private List<CDefinicionDetalleFK> FCampos;
        public string Nombre
        {
            get;
            set;
        }
        public string TablaPadre
        {
            get;
            set;
        }
        public string TablaHija
        {
            get;
            set;
        }
        public List<CDefinicionDetalleFK> Campos
        {
            get {
                if (FCampos == null)
                    FCampos = new List<CDefinicionDetalleFK>();
                return FCampos;
            }
        }
    }
}
