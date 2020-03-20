using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2015.Inportador
{
    class CColumna
    {
        public string Nombre;
        public string Columna;
        public string x;
        public string y;
        public override string ToString()
        {
            return Columna+"-->"+Nombre;
        }
    }
}
