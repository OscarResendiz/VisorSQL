using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    public class CRelacion
    {
        public List<CCampoFK> CamposFK;
        public string TablaHija;
        public string TablaPadre;
        public bool EliminarCascada;
        public bool ActualisarCascada;
        public string Nombre;
    }
}
