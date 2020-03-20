using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public enum TIPO_TRIGGER
    {
        INSERT
        ,UPDATE
        ,DELETE
    }
    public class Trigger:ObjetoCodigoFuente
    {
        public Trigger()
        {
            FTipoObjeto = DBTIPO.TRIGGER;
        }
        public DBObjeto Tabla
        {
            //hace referencia a la tabla a la que pertenece
            get;
            set;
        }
        public TIPO_TRIGGER TipoEvento
        {
            get;
            set;
        }
    }
}
