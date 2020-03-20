using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class DetalleFK:DBObjeto
    {
        public DetalleFK()
        {
            FTipoObjeto = DBTIPO.DETALLE_FK;
        }
        public CampoTabla CampoPadre
        {
            get;
            set;
        }
        public CampoTabla CampoHijo
        {
            get;
            set;
        }
    }
}
