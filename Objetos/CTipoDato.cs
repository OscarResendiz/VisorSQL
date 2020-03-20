using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    class CTipoDato
    {
        public string Nombre;
        public bool Variable; //indica que se activa o no el campo longitud
        public CTipoDato(string nombre, bool variable)
        {
            Nombre = nombre;
            Variable = variable;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
