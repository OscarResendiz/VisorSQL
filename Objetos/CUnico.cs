using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    public class CUnico
    {
        public string Nombre;
        public string tabla;
        private List<string> FCampos;
        public List<string> Campos
        {
            get
            {
                if(FCampos==null)
                    FCampos=new List<string>();
                return FCampos;
            }
        }

    }
}
