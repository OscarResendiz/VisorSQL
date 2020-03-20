using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public enum DBTIPO
    {
        FK
        ,DETALLE_FK
        ,TABLA
        ,CAMPO_TABLA
        ,TRIGGER
        ,RESTRICCION
        ,VISTA
        ,CAMPO_VISTA
        ,PROCEDIIENTO_ALMACENADO
        ,FUNCION
        ,PARAMETRO
        ,UNICO
    }
    public class DBObjeto
    {
        protected DBTIPO FTipoObjeto;
        public string Nombre
        {
            get;
            set;
        }
        public DBTIPO TipoObjeto
        {
            get
            {
                return FTipoObjeto;
            }
        }
    }
}
