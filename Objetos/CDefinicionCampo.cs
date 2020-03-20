using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.Objetos
{
   public class CDefinicionCampo
    {
        public string Nombre
        {
            get;
            set;
        }
        public string Tipo
        {
            get;
            set;
        }
        public int Longitud
        {
            get;
            set;
        }
        public bool AceptaNulos
        {
            get;
            set;
        }
        public bool ClavePrimaria
        {
            get;
            set;
        }
        public bool AutoIncremental
        {
            get;
            set;
        }
        public string ValorDefault
        {
            get;
            set;
        }
        public string ValorCalculado
        {
            get;
            set;
        }
        public bool Unico
        {
            get;
            set;
        }
    }
}
