using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class ProcedimientoAlmacenado : ObjetoCodigoFuente
    {
        protected List<Parametro> FParametros;
        public ProcedimientoAlmacenado()
        {
            FTipoObjeto = DBTIPO.PROCEDIIENTO_ALMACENADO;
        }
        public List<Parametro> Parametros
        {
            get
            {
                if (FParametros == null)
                    FParametros = new List<Parametro>();
                return FParametros;
            }
        }
        public void AgregaParametro(Parametro obj)
        {
            foreach(Parametro p in Parametros)
            {
                if (p.Nombre == obj.Nombre)
                {
                    return;
                }
            }
            Parametros.Add(obj);
        }
    }
}
