using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.ModeloDB
{
    public class CampoTabla:Parametro
    {
        public CampoTabla()
        {
            FTipoObjeto = DBTIPO.CAMPO_TABLA;
            LLavePrimaria = false;
            AceptaNulos = true;
            AutoIncremental = false;
            ValorDefault = "";
            ValorCalculado = "";
            Unico = false;
            Location = "";
        }
        public bool LLavePrimaria
        {
            get;
            set;
        }
        public bool AceptaNulos
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
        public string Location
        {
            get;
            set;
        }
    }
}
