using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    public class CTablaVariable
    {
        public string Nombre;
        public List<string> Campos;
       public  CTablaVariable()
        {
            Campos = new List<string>();
        }
        public void Add(string campo)
        {
            Campos.Add(campo);
        }
    }
}
