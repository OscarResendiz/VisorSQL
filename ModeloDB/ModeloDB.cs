using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class ModeloDB
    {
        //clase que enbuelve el trabajo con la base de datos y 
        //pone a disposicion los objetos que la componen
        private List<Tabala> Tablas;
        private List<LLAveForanea> LLavesForaneas;
        private List<Vista> Vistas;
        private List<ProcedimientoAlmacenado> ProcedimientosAlmacenados;
        private List<Funcion> Funciones;
        private Controladores_DB.IDataBase MotorDB
        {
            get;
            set;
        }
        public ModeloDB(Controladores_DB.IDataBase db)
        {
            MotorDB = db;
        }
        private void CargaCamposTabla(Tabala t)
        {
            List<Objetos.CParametro> l = MotorDB.DameCamposTabla(t.Nombre);
            foreach (Objetos.CParametro obj in l)
            {
                CampoTabla ct = new CampoTabla();
                ct.Nombre = obj.nombre;
                ct.AceptaNulos = bool.Parse(obj.NULOS);
                ct.AutoIncremental = obj.AutoIncremental;
                ct.LLavePrimaria = obj.FLLavePrimaria;
                ct.Longitud = obj.Logitud;
                ct.Padre = t;
                ct.Tipo = obj.tipo;
                ct.ValorCalculado = MotorDB.DameCodigoCampoCalculado(t.Nombre, ct.Nombre);
                ct.ValorDefault = obj.Default;
                t.AgregaCampo(ct);
            }
        }
        private Tabala DameTabla(string nombre)
        {
            foreach (Tabala t in Tablas)
            {
                if (t.Nombre == nombre)
                    return t;
            }
            return null;
        }
        private void AgregaLLaveForanea(Objetos.CLLaveForanea obj)
        {
            //verifico si no existe
            foreach (LLAveForanea fk in LLavesForaneas)
            {
                if (fk.Nombre == obj.name)
                {
                    //ya esta ingresado
                    return;
                }
            }
            //como no esta lo agrego
            LLAveForanea fk2 = new LLAveForanea();
            fk2.Nombre = obj.name;
            //me traigo los campos de la llave
            List<Objetos.CCampoFK> campos = MotorDB.DameCamposFK(fk2.Nombre);
            //agrego los campos
            bool primero = true;
            foreach (Objetos.CCampoFK c in campos)
            {
                if (primero)
                {
                    //como es el primer registro, me traigo las tablas
                    fk2.TablaHija = DameTabla(c.hija);
                    fk2.TablaPadre = DameTabla(c.maestra);
                    primero = false;
                }
                DetalleFK detalle = new DetalleFK();
                detalle.CampoHijo = fk2.TablaHija.DameCampo(c.columnahija);
                detalle.CampoPadre = fk2.TablaPadre.DameCampo(c.columnaMaestra);
                fk2.AgregaDetalle(detalle);
            }
            //agrego la relacion a la tabla
            fk2.TablaHija.AgregaLlaveForanea(fk2);
        }
        private void CargaLLavesForaneas()
        {
            LLavesForaneas = new List<LLAveForanea>();
            //recoroo todas las tablas y me traigo las llaves foranbeas de cada una
            foreach (Tabala obj in Tablas)
            {
                List<Objetos.CLLaveForanea> l = MotorDB.DameLLavesForaneas(obj.Nombre);
                //ahora recorro cada llave y la  agrego a la lista
                foreach (Objetos.CLLaveForanea fk in l)
                {
                    //agrego la llave a la lista general
                    AgregaLLaveForanea(fk);
                }
            }
        }
        private void CargaTablas()
        {
            Tablas = new List<Tabala>();
            List<Objetos.CSysObject> l = MotorDB.BuscaObjetos("", Controladores_DB.TIPOOBJETO.TABLAX);
            foreach (Objetos.CSysObject obj in l)
            {
                Tabala t = new Tabala();
                t.Nombre = obj.Nombre;
                //me traigo los campos de la tabla
                CargaCamposTabla(t);
                //me traigo las llaves foraneas
                CargaLLavesForaneas();
                //me traigo los campos que son unicos
                CargaUnicos(t);
            }
        }
        private void CargaUnicos(Tabala t)
        {
            List<Objetos.CUnico> l = MotorDB.DameUnicos(t.Nombre);
            foreach (Objetos.CUnico obj in l)
            {
                Unico unico = new Unico();
                unico.Nombre = obj.Nombre;
                foreach (string scampo in obj.Campos)
                {
                    CampoTabla campo = t.DameCampo(scampo);
                    unico.AgregaCampo(campo);
                }
                t.AgregaUnico(unico);
            }
        }
        private void CargaVistas()
        {
            //se encarga de extraer todas las vistas
            List<Objetos.CSysObject> l = MotorDB.BuscaObjetos("", Controladores_DB.TIPOOBJETO.VISTA);
            foreach (Objetos.CSysObject obj in l)
            {
                Vista v = new Vista();
                v.Nombre = obj.Nombre;
                //me traigo los campos de la vista
                List<Objetos.CParametro> l2 = MotorDB.DameCamposTabla(obj.Nombre);
                foreach (Objetos.CParametro p in l2)
                {
                    Parametro p2 = new Parametro();
                    p2.Longitud = p.Logitud;
                    p2.Nombre = p.nombre;
                    p2.Tipo = p.tipo;
                    v.AgregaCampo(p2);
                }
                v.CodigoFuente = MotorDB.DameCodigo(v.Nombre);
                Vistas.Add(v);
            }
        }
        private void CargaProcedimientosAlmacenados()
        {
            List<Objetos.CSysObject> l = MotorDB.BuscaObjetos("", Controladores_DB.TIPOOBJETO.STOREPROCERURE);
            foreach (Objetos.CSysObject obj in l)
            {
                ProcedimientoAlmacenado p = new ProcedimientoAlmacenado();
                p.CodigoFuente = MotorDB.DameCodigo(obj.Nombre);
                p.Nombre = obj.Nombre;
                List<Objetos.CParametro> l2 = MotorDB.DameParametrosDeProcedimiento(p.Nombre);
                foreach (Objetos.CParametro obj2 in l2)
                {
                    Parametro p2 = new Parametro();
                    p2.Longitud = obj2.Logitud;
                    p2.Nombre = obj.Nombre;
                    p2.Tipo = obj2.tipo;
                    p.AgregaParametro(p2);
                }
                ProcedimientosAlmacenados.Add(p);
            }
        }
        private void CargaFunciones()
        {
            List<Objetos.CSysObject> l = MotorDB.BuscaObjetos("", Controladores_DB.TIPOOBJETO.FUNCTION);
            foreach (Objetos.CSysObject obj in l)
            {
                Funcion p = new Funcion();
                p.CodigoFuente = MotorDB.DameCodigo(obj.Nombre);
                p.Nombre = obj.Nombre;
                List<Objetos.CParametro> l2 = MotorDB.DameParametrosDeProcedimiento(p.Nombre);
                foreach (Objetos.CParametro obj2 in l2)
                {
                    Parametro p2 = new Parametro();
                    p2.Longitud = obj2.Logitud;
                    p2.Nombre = obj.Nombre;
                    p2.Tipo = obj2.tipo;
                    p.AgregaParametro(p2);
                }
                Funciones.Add(p);
            }
        }
        private void CargaModelo()
        {
            //se encarga de extraer todos los objetos de la base de datos y los carga en las
            //listas correspondientes
            //me traigo todas las tablas
            CargaTablas();
            //ahora cargo las llaves foraneas
            CargaLLavesForaneas();
            //me traigo las vistas
            CargaVistas();
            //me traigo los procedimientos almacenados
            CargaProcedimientosAlmacenados();
            //me traigo las funciones
            CargaFunciones();
            //me traigo los triggers
        }
        private void cargaTriggres()
        {
           List<Objetos.CSysObject> l = MotorDB.BuscaObjetos("", Controladores_DB.TIPOOBJETO.TRIGER);
           foreach (Objetos.CSysObject obj in l)
           {
               Trigger t = new Trigger();
               t.CodigoFuente = MotorDB.DameCodigo(obj.Nombre);
               t.Nombre = obj.Nombre;
               //t.
           }
        }
    }
}
