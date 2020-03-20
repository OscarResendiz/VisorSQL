using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class Unico:DBObjeto
    {
        private List<CampoTabla> FCampos;
        public Unico()
        {
            FTipoObjeto = DBTIPO.UNICO;
        }
        public List<CampoTabla> Campos
        {
            get
            {
                if (FCampos == null)
                    FCampos = new List<CampoTabla>();
                return FCampos;
            }
        }
        public void AgregaCampo(CampoTabla campo)
        {
            foreach (CampoTabla obj in Campos)
            {
                if (campo.Nombre == obj.Nombre)
                    return;
            }
            Campos.Add(campo);

        }
    }
}
