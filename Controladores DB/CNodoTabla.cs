using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2015.Controladores_DB
{
    public class CNodoTabla
    {
        private CNodoTabla Izquierdo;
        private CNodoTabla Derecho;
        public  string Tabla;
        public System.Collections.Generic.List<Objetos.CParametro> Campos;
        public void AddTabla(String tabla, System.Collections.Generic.List<Objetos.CParametro> campos)
        {
            if (Tabla == tabla)
            {
                //esta repetida, por lo que no hao nada
                return;
            }
            //veo si lo inserto a la izquierda o a la derecha
            if (Tabla.CompareTo(tabla) > 0)
            {
                //lo inserto a la derecha
                if (Derecho == null)
                {
                    Derecho = new CNodoTabla();
                    Derecho.Tabla = tabla;
                    Derecho.Campos = campos;
                    return;
                }
                Derecho.AddTabla(tabla, campos);
                return;
            }
            //va a la izquierda
            if (Izquierdo == null)
            {
                Izquierdo = new CNodoTabla();
                Izquierdo.Tabla = tabla;
                Izquierdo.Campos = campos;
                return;
            }
            Izquierdo.AddTabla(tabla, campos);
        }
        public CNodoTabla BuscaTabla(string tabla)
        {
            if (Tabla.ToLower().Trim() == tabla.ToLower().Trim())
            {
                //soy yo, por lo que me auto regreso
                return this;
            }
            if (Tabla.CompareTo(tabla) > 0)
            {
                //lo inserto a la derecha
                if (Derecho == null)
                    return null;
                return Derecho.BuscaTabla(tabla);
            }
            if (Izquierdo == null)
                return null;
            return Izquierdo.BuscaTabla(tabla);
        }
        public void Clear()
        {
            if (Derecho != null)
                Derecho.Clear();
            Derecho = null;
            if (Izquierdo != null)
                Izquierdo.Clear();
            Izquierdo = null;
            //GC.Collect();
        }
    }
}
