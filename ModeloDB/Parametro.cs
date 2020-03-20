using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class Parametro : DBObjeto
    {
        public Parametro()
        {
            FTipoObjeto = DBTIPO.PARAMETRO;
        }
        public int Longitud
        {
            get;
            set;
        }
        public string Tipo
        {
            get;
            set;
        }
        public DBObjeto Padre
        {
            get;
            set;
        }
    }
}
