using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    public class CIdentity
    {
        public int inicio, incremento;
        public bool EsIdentidad;
        public CIdentity()
        {
            inicio = 0;
            incremento = 0;
            EsIdentidad = false;
        }
    }
}
