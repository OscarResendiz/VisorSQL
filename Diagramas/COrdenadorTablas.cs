using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Visor_sql_2015.Diagramas
{
    //clase que hace el calculo de ubicaciones de las tablas
    class COrdenadorTablas
    {
        List<CTabla> Tablas;
        public COrdenadorTablas(List<CTabla> l)
        {
            Tablas = l;
            //recorro la lista para agregar el evento de busqueda de hijos
            foreach (CTabla obj in Tablas)
            {
                obj.OnBuscaHijo += new OnBuscaHijoEvent(BuscaHijos);
            }
        }
        private CTabla BuscaHijos(string nombre)
        {
            //recorro la lista de tablas para buscar el hijo
            foreach (CTabla obj in Tablas)
            {
                if (obj.Nombre == nombre)
                {
                    //ya lo encontre, por loque lo regreso
                    return obj;
                }
            }
            return null;
        }
        public void Ordena()
        {
            //recorre la lista de tablas para que busquen a sus hijos
            foreach (CTabla obj in Tablas)
            {
                obj.Ordenado = false;
                obj.CargaHijos();
            }
            //ya tengo los hijos y los padres
            //ahora hay que calcular las posiciones de las tablas
            
            System.Drawing.Point p=new System.Drawing.Point(0,0);
            foreach (CTabla obj in Tablas)
            {
                if (obj.Ordenado == false)
                {
                    p.Y = 0;
                    p=obj.CalculaPosicion(p, 0);
                }
            }
        }
    }
}
