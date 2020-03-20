using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Visor_sql_2015.Controladores_DB
{
    public enum DBMOTORES
    {
        SQLSERVER=0,
        MYSQL=1
    };
    public enum TIPOOBJETO
    {
        NINGUNO = 0,
        TABLAX = 1,
        VISTA = 2,
        STOREPROCERURE = 3,
        TRIGER = 4,
        FOREINGKEY = 5,
        PRIMARYKEY = 6,
        TABLASYSTEMA = 7,
        EN_CODIGO = 8,
        VISTAS_TABLAS = 9,
        CAMPOS_TABLA = 10,
        FUNCTION=11
    };

    public delegate void ProcessingQuery();
    public interface IDataBase
    {
        //propiedades de la interface
        bool EnEjecucion
        {
            get;
        }
        DataSet Results
        {
            get;
            set;
        }
        string TiempoEjecucion
        {
            get;
        }
        int TimeOut
        {
            get;
            set;
        }
        Editor.CErrorQuery MensajeError
        {
            get;
        }
        string Error
        {
            get;
            set;
        }
        string ConnectionString
        {
            get;
            set;
        }
        string BDName
        {
            get;
            set;
        }
        string Servidor
        {
            get;
            set;
        }
        string User
        {
            get;
            set;
        }
        string Password
        {
            get;
            set;
        }
        //metodos de la interface
         bool PruebaConexion();
         CNodoTabla BuscaEnTabla(string nombre);
         System.Collections.Generic.List<Objetos.CSysObject> BuscaObjetos(string nombre, TIPOOBJETO tipo);
         Objetos.CSysObject DameTablaVista(string nombre);
         System.Collections.Generic.List<Objetos.CParametro> DameCamposTabla(string nombre);
         System.Collections.Generic.List<Objetos.CParametro> DameCamposTabla(string nombre, string campo);
         string DameCodigo(string nombre);
         string CreaCodigoTabla(string nombre);
         System.Collections.Generic.List<Objetos.CParametro> DameLLavesPrimarias(string nombre);
         System.Collections.Generic.List<Objetos.CLLaveForanea> DameLLavesForaneas(string tabla);
         System.Collections.Generic.List<Objetos.CLLaveForanea> DameLLavesForaneasHijas(string tabla);
         System.Collections.Generic.List<Objetos.CCampoFK> DameCamposFK(string nombre);
         System.Collections.Generic.List<Objetos.CParametro> DameParametrosDeProcedimiento(string nombre);
         System.Collections.Generic.List<Objetos.CSysObject> DameDependencias(string Nombre);
         System.Collections.Generic.List<Objetos.CSysObject> DameDependientesDe(string Nombre);
         System.Collections.Generic.List<Objetos.CSysObject> DameHijosDe(string Nombre);
         System.Collections.Generic.List<Objetos.CSysObject> DamePadresDe(string Nombre);
         DataSet Ejecuta(string comando);
         string DaMeDescripcionTabla(string tabla);
         string DameDescripcionCampo(string tabla, string campo);
         void GusrdaDescripcionTabla(string tabla, string descripcion);
         void GuardaDescripcionCampo(string tabla, string campo, string descripcion);
         bool EsLLavePrimaria(string Tabla, string Campo);
         bool EsLLaveForanea(string tabla, string campo);
         string DameTablaForanea(string tabla, string campo);
         System.DateTime DameFechaModificacion(string nombre);
         System.Collections.Generic.List<Objetos.CCampoFK> DameLLaveForanea(string nombre);
         string DameCodigoCampoCalculado(string tabla, string campo);
         string EsIdentity(string Tabla, string Campo);
         Objetos.CIdentity DameIdentity(string Tabla, string Campo);
         Objetos.CDefault DameDefault(string Tabla, string Campo);
         string GeneraCodigoTabla(string Nombre, List<Objetos.CParametro> Campos);
         void Async_ObtenTablaQuery(string Query);
         void StopAsync();
         bool ExisteCampoTabla(string tabla, string campo);
         void Close();
         List<string> GetDataBases();
         void CargaConexion(AdministrarConexiones.FileConecction fc);
         List<string> GetServers();
         IDataBase Clona();
        //eventos
        event ProcessingQuery EndingQuery;
        event ProcessingQuery BeginningQuery;
        List<string> DameTiposDatos();
        string CreaTabla(Objetos.CDefinicionTabla tabla, bool ejecutar);
        List<Objetos.CUnico> DameUnicos(string tabla);
    }
}
