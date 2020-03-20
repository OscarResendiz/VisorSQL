using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class Vista: ProcedimientoAlmacenado
    {
        public Vista()
        {
            FTipoObjeto = DBTIPO.VISTA;
        }
        public List<Parametro> Campos
        {
            get
            {
                if (FParametros == null)
                    FParametros = new List<Parametro>();
                return FParametros;
            }
        }
        public void AgregaCampo(Parametro campo)
        {
            foreach (Parametro obj in Campos)
            {
                if (obj.Nombre == campo.Nombre)
                    return;
            }
            Campos.Add(campo);
        }

    }
}
