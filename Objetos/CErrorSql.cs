using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2005.Objetos
{
    class CErrorSql
    {
        public string Mensage;
        public int linea;
        public override string ToString()
        {
            return Mensage;
        }
    }
}
