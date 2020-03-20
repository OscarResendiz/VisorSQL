using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class Tabala: DBObjeto
    {
        private List<LLAveForanea> FLLavesForaneas;
        private List<CampoTabla> FCampos;
        private List<Restriccion> FRestricciones;
        private List<Trigger> FDisparadores;
        private List<Unico> FUnicos;
        public Tabala()
        {
            FTipoObjeto = DBTIPO.TABLA;
            NombreLLavePrimaria = "";
            EsDeSistema = false;
        }
        public string NombreLLavePrimaria
        {
            get;
            set;
        }
        public bool EsDeSistema
        {
            get;
            set;
        }
        public List<LLAveForanea> LLavesForaneas
        {
            get
            {
                if (FLLavesForaneas == null)
                    FLLavesForaneas = new List<LLAveForanea>();
                return FLLavesForaneas;
            }
        }
        public List<CampoTabla> Campos
        {
            get
            {
                if (FCampos == null)
                    FCampos = new List<CampoTabla>();
                return FCampos;
            }
        }
        public List<Restriccion> Restricciones
        {
            get
            {
                if (FRestricciones == null)
                    FRestricciones = new List<Restriccion>();
                return FRestricciones;
            }
        }
        public List<Trigger> Disparadores
        {
            get
            {
                if (FDisparadores == null)
                    FDisparadores = new List<Trigger>();
                return FDisparadores;
            }
        }
        public List<Unico> Unicos
        {
            get
            {
                if (FUnicos == null)
                    FUnicos = new List<Unico>();
                return FUnicos;
            }
        }
        public void AgregaCampo(CampoTabla campo)
        {
            //reviso que no se repita
            foreach (CampoTabla obj in Campos)
            {
                if (obj.Nombre == campo.Nombre)
                {
                    return;
                }
            }
            Campos.Add(campo);
        }
        public CampoTabla DameCampo(string nombre)
        {
            foreach (CampoTabla obj in Campos)
            {
                if (obj.Nombre == nombre)
                {
                    return obj;
                }
            }
            //no contiene el campo buscado
            throw new Exception("No existe el campo");
        }
        public void AgregaLlaveForanea(LLAveForanea obj)
        {
            foreach (LLAveForanea fk in LLavesForaneas)
            {
                if (fk.Nombre == obj.Nombre)
                {
                    return;
                }
            }
            LLavesForaneas.Add(obj);
        }
        public void AgregaUnico(Unico obj)
        {
            if (obj.Campos.Count == 1)
            {
                obj.Campos[0].Unico = true;
            }
            //lo agrego a la lista
            foreach (Unico u in Unicos)
            {
                if (u.Nombre == obj.Nombre)
                {
                    return;
                }
            }
            Unicos.Add(obj);
        }
    }
}
