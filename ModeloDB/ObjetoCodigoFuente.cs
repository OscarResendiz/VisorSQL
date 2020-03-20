using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class ObjetoCodigoFuente:DBObjeto
    {
        public ObjetoCodigoFuente()
        {
            CodigoFuente = "";
        }
        public string CodigoFuente
        {
            get;
            set;
        }
    }
}
