using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    public class CDefinicionTabla
    {
        private List<string> FUnicos;
        private List<CDefinicionCampo> FCampos;
        private List<CDefinicionFK> FLLavesForaneas;
        public string Nombre
        {
            get;
            set;
        }
        public List<CDefinicionCampo> Campos
        {
            get
            {
                if (FCampos == null)
                    FCampos = new List<CDefinicionCampo>();
                return FCampos;
            }
        }
        public List<CDefinicionCampo> PrimaryKey
        {
            //regresa una lista con los campos que pertenecn a la llave primaria
            get
            {
                List<CDefinicionCampo> l = new List<CDefinicionCampo>();
                foreach (CDefinicionCampo campo in Campos)
                {
                    if (campo.ClavePrimaria)
                    {
                        l.Add(campo);
                    }
                }
                return l;
            }
        }
        public List<CDefinicionFK> LLavesForaneas
        {
            get
            {
                if (FLLavesForaneas == null)
                {
                    FLLavesForaneas = new List<CDefinicionFK>();
                }
                return FLLavesForaneas;
            }
        }
        public List<string> Unicos
        {
            get
            {
                if (FUnicos == null)
                {
                    FUnicos = new List<string>();
                }
                return FUnicos;
            }
        }

    }
}
