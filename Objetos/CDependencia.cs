using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Objetos
{
    public delegate void OnCantidadEvent(int cantidad);
    public delegate void OnFinEvent();
    public delegate bool OnBuscaEvent(Objetos.CSysObject obj);
    class CDependencia
    {
        public event OnBuscaEvent OnBusca;
        public event OnFinEvent OnBeginBusqueda;
        public event OnCantidadEvent OnCantidad;
        public event OnBuscaEvent OnIncremento;
        public event OnFinEvent OnFin;
        private int Pos;
        private int estado;
        private System.Windows.Forms.Timer timer1;
        private bool Modo;
        private TreeNode Nodo;
        Controladores_DB.IDataBase DB;
        System.Collections.Generic.List<Objetos.CDependencia> Lista;
        System.Collections.Generic.List<Objetos.CSysObject> Objetos;
        Objetos.CSysObject Objeto;
        public CDependencia(TreeNode nodo, Objetos.CSysObject objeto, Controladores_DB.IDataBase db, bool modo)
        {
            Modo = modo;
            DB = db;
            Nodo = nodo;
            Objeto = objeto;
            Lista = new List<CDependencia>();
            this.timer1 = new System.Windows.Forms.Timer();
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }
        private void LeeDependencias()
        {
            estado = 0;
            Pos = 0;
            if (Modo == true)
            {
                //cargar los que dependen de mi
                if (Objeto.TipoObjeto == Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE)
                    Objetos = DB.DameDependientesDe(Objeto.Nombre);
                else
                    Objetos = DB.DameDependencias(Objeto.Nombre);
            }
            else
            {
                //Cargar de los que dependo
                if (Objeto.TipoObjeto == Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE)
                    Objetos = DB.DameDependencias(Objeto.Nombre);
                else
                    Objetos = DB.DameDependientesDe(Objeto.Nombre);
            }
            if (OnCantidad != null)
                OnCantidad(Objetos.Count);

        }
        public void CargaDependencias()
        {
            LeeDependencias();
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Objetos.CSysObject obj = null;
            TreeNode nodo2 =null;
            CDependencia dep = null;
            switch (estado)
            {
                case 0://cargando dependencias
                    if (Pos >= Objetos.Count)
                    {
                        Pos = 0;
                        estado = 1;
                        if (OnBeginBusqueda != null)
                            BeginBusqueda();
                        return;
                    }
                    obj = Objetos[Pos];
                    nodo2 = Nodo.Nodes.Add(obj.Nombre);
                    nodo2.ImageIndex = IndexImagen(obj);
                    nodo2.SelectedImageIndex = IndexImagen(obj);
                    nodo2.StateImageIndex = IndexImagen(obj);
                    if (OnIncremento != null)
                        OnIncremento(obj);
                    Pos++;
                    break;
                case 1://buscando los que ya se avian agregado
                    if (Pos >= Objetos.Count)
                    {
                        timer1.Enabled = false;
                        //checo si se insertaron mas nodos
                        if (Lista.Count == 0)
                        {
                            //ya no hay mas, por lo que termine
                            if (OnFin != null)
                                OnFin();
                            return;
                        }
                        //me traigo el primer objeto
                        Pos = 0;
                        dep=Lista[Pos];
                        //que carge sus dependencias
                        dep.CargaDependencias();
                        return;
                    }
                    obj = Objetos[Pos];
                    if (OnBusca != null)
                    {
                        //busca si ya avia sido agregada la dependencia
                        if (OnBusca(obj) == false)
                        {
                            //no se encontro, por lo que lo agrego a la lista de insercion
                            nodo2 = Nodo.Nodes[Pos];
                            dep = new CDependencia(nodo2, obj, DB, Modo);
                            dep.OnBusca += new OnBuscaEvent(BuscaEvent);
                            dep.OnCantidad = new OnCantidadEvent(CantidadEvent);
                            dep.OnFin += new OnFinEvent(FinEvent);
                            dep.OnIncremento += new OnBuscaEvent(IncrementoEvent);
                            dep.OnBeginBusqueda = new OnFinEvent(BeginBusqueda);
                            Lista.Add(dep);
                        }
                    }
                    Pos++;
                    break;
            }

        }
        private void BeginBusqueda()
        {
            if (OnBeginBusqueda != null)
                OnBeginBusqueda();
        }
        private bool BuscaEvent(Objetos.CSysObject obj)
        {
            if (OnBusca != null)
                return OnBusca(obj);
            return true;
        }
        private void CantidadEvent(int cantidad)
        {
            if (OnCantidad != null)
                OnCantidad(cantidad);
        }
        private void FinEvent()
        {
            if (Lista.Count == 0)
            {
                //ya no hay mas, por lo que termine
                if (OnFin != null)
                    OnFin();
                return;
            }
            //me traigo el primer objeto
            Pos++;
            if (Pos >= Lista.Count)
            {
                //ya no hay mas, por lo que termine
                if (OnFin != null)
                    OnFin();
                return;
            }
            CDependencia dep = Lista[Pos];
            //que carge sus dependencias
            dep.CargaDependencias();
        }
        private bool IncrementoEvent(Objetos.CSysObject obj)
        {
            if (OnIncremento != null)
                OnIncremento(obj);
            return true;
        }
        private int IndexImagen(Objetos.CSysObject obj)
        {
            //regresa el indice de la imagen al que depende el objeto
            switch (obj.TipoObjeto)
            {
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE:
                    return 4;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX:
                    return 0;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTAS_TABLAS:
                    return 0;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLASYSTEMA:
                    return 0;
                case Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTA:
                    return 5;
            }
            return 6;
        }
    }
}
