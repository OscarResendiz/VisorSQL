using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public partial class AsisResUpdate : Visor_sql_2015.AsistSps.AsistBaseSP
    {
        private Controladores_DB.IDataBase DB;
        private string Codigo;
        private string NombreSP;
        private List<Objetos.CParametro> Parametros;
        private List<Objetos.CParametro> ValoresFijos;
        private string ComentarioNombreSP;
        private string Tabla;
        private List<Objetos.CLLaveForanea> LLavesForaneas;
        //private Objetos.CParametro CampoLLave;
        private List<Objetos.CParametro> LLavesPrimarias;
        public AsisResUpdate(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
        }
        public override void Inicializate()
        {
            TTabla.Text = (string)DameValor("Tabla");
            TNomSP.Text = (string)DameValor("NombreSP");
            List<Objetos.CParametro> lista = (List<Visor_sql_2015.Objetos.CParametro>)DameValor("ListaParametros");
            ListaParametros.Items.Clear();
            foreach (Objetos.CParametro obj in lista)
            {
                ListaParametros.Items.Add(obj);
            }
            TextoSiguiente("Finalizar");
        }
        private void CargaDatos()
        {
            // en esta funcion se cargan los datos que los demas modulos del asistente se fueroncaprurando
            NombreSP = (string)DameValor("NombreSP");
            Parametros = (List<Objetos.CParametro>)DameValor("ListaParametros");
            ComentarioNombreSP = (string)DameValor("ComentarioNombreSP");
            Tabla = (string)DameValor("Tabla");
            ValoresFijos = (List<Objetos.CParametro>)DameValor("AsisSelValFijos");
            LLavesForaneas = (List<Objetos.CLLaveForanea>)DameValor("AsisForeigKeys");
            LLavesPrimarias = DB.DameLLavesPrimarias(Tabla);
        }
        private void Add(string s)
        {
            Codigo = Codigo + s;
        }
        private void AddLine(string s)
        {
            Add(s + "\n");
        }
        public override void BSiguiente()
        {
            //genera el codigo del SP
            bool primero;
            Codigo = "";
            CargaDatos();
            // primero genero el cabecero del SP
            Add("create procedure " + NombreSP);
            //veo si tiene parametros
            if (Parametros.Count > 0)
            {
                //genero lalista de parametros
                Add("(");
                primero = true;
                foreach (Objetos.CParametro parametro in Parametros)
                {
                    if (primero == false)
                    {
                        Add(",");
                    }
                    else
                    {
                        primero = false;
                    }
                    Add("@" + parametro.nombre + " " + parametro.TipoSP);
                }
                Add(")");
            }
            Add(" as\n");
            AddLine("begin");
            //veo si le pucieron comentarios
            //if (ComentarioNombreSP.Trim() != "")
            //{
            //    AddLine("\t--" + ComentarioNombreSP + "\n");
            //}
            string cmt = "";
            int ni, nn;
            nn = ComentarioNombreSP.Length;
            for (ni = 0; ni < nn; ni++)
            {
                if (ComentarioNombreSP[ni] == '\n' || ComentarioNombreSP[ni] == '\r')
                {
                    //se encontro un comentario
                    if (cmt.Trim() != "")
                    {
                        AddLine("\t--" + cmt.Trim());
                        cmt = "";
                    }
                }
                else
                {
                    cmt = cmt + ComentarioNombreSP[ni];
                }
            }
            if (cmt.Trim() != "")
            {
                AddLine("\t--" + cmt);
            }
            //veo si hay campos que van a tener valores fijos
            if (ValoresFijos.Count > 0)
            {
                AddLine("\t--Declaraci�n de variables que se requieren ");
                foreach (Objetos.CParametro variable in ValoresFijos)
                {
                    AddLine("\tdeclare @" + variable.nombre + " " + variable.TipoSP);
                }
            }
            //veo si le asignaron comentarios a los parametros
            if (Parametros.Count > 0)
            {
                //genero lalista de parametros
                foreach (Objetos.CParametro parametro in Parametros)
                {
                    if (parametro.Descripcion != null && parametro.Descripcion.Trim() != "")
                    {
                        Add("\t--" + parametro.nombre + " " + parametro.Descripcion + "\n");
                    }
                }
            }
            //ahora agrego validaciones a los parametros
            if (Parametros.Count > 0)
            {
                primero = true;
                foreach (Objetos.CParametro parametro in Parametros)
                {
                    if (parametro.Vacios == false)
                    {
                        if (primero == true)
                        {
                            AddLine("\t--Validando que no sean vacios");
                            primero = false;
                        }
                        AddLine("\tif(ltrim(@" + parametro.nombre + ")=\'\')");
                        AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t--" + parametro.Descripcion);
                        }
                        AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionVacios + "\', 16, 1)");
                        AddLine("\t\treturn");
                        AddLine("\tend");
                    }
                }
            }
            //ahora valido que no se repitan los campos
            if (Parametros.Count > 0)
            {
                primero = true;
                foreach (Objetos.CParametro parametro in Parametros)
                {
                    if (parametro.ValidarUnicidad == true)
                    {
                        if (primero == true)
                        {
                            AddLine("\t--Validando que no se pueden repetir");
                            primero = false;
                        }
                        AddLine("\tif exists(select * from " + Tabla + " where " + parametro.nombre + "=@" + parametro.nombre + ")");
                        AddLine("\tbegin");
                        //Version sim tiene comentarios
                        if (parametro.Descripcion.Trim() != "")
                        {

                            AddLine("\t\t--" + parametro.Descripcion);
                        }
                        AddLine("\t\tRAISERROR(\'" + parametro.ExcepcionNoRepetibles + "\', 16, 1)");
                        AddLine("\t\treturn");
                        AddLine("\tend");
                    }
                }
            }
            //ahora me traigo los valores que son fijos
            if (ValoresFijos.Count > 0)
            {
                foreach (Objetos.CParametro variable in ValoresFijos)
                {
                    if (variable.SelectedValor == true)
                    {
                        AddLine("\tselect @" + variable.nombre + "= " + variable.Valor);
                    }
                    else
                    {
                        //hay que obtenerlo desde una tabla
                        string s = "";
                        primero = true;
                        foreach (Objetos.CParametro p in variable.Filtros)
                        {
                            if (primero == true)
                            {
                                primero = false;
                            }
                            else
                            {
                                s = s + " and ";
                            }
                            s = s + p.nombre;
                            switch (p.Filtro)
                            {
                                case Visor_sql_2015.Objetos.TIPO_FILTRO.DIFERENTE:
                                    s = s + "!=";
                                    break;
                                case Visor_sql_2015.Objetos.TIPO_FILTRO.IGUAL:
                                    s = s + "=";
                                    break;
                                case Visor_sql_2015.Objetos.TIPO_FILTRO.LIKE:
                                    s = s + " like ";
                                    break;
                                case Visor_sql_2015.Objetos.TIPO_FILTRO.MAYOR_IGUAL:
                                    s = s + ">=";
                                    break;
                                case Visor_sql_2015.Objetos.TIPO_FILTRO.MAYOR_QUE:
                                    s = s + ">";
                                    break;
                                case Visor_sql_2015.Objetos.TIPO_FILTRO.MENOR_IGUAL:
                                    s = s + "<=";
                                    break;
                                case Visor_sql_2015.Objetos.TIPO_FILTRO.MENOR_QUE:
                                    s = s + "<";
                                    break;
                            }
                            s = s + p.Campo;
                        }
                        //veo los ordenamientos
                        string s2 = "";
                        primero = true;
                        foreach (Objetos.CParametro o in variable.Ordenamientos)
                        {
                            if (primero == true)
                            {
                                primero = false;
                                s2 = " order by ";
                            }
                            else
                            {
                                s2 = s2 + ",";
                            }
                            s2 = s2 + o.nombre;
                            if (o.Descendente == true)
                            {
                                s2 = s2 + " desc ";
                            }
                            else
                            {
                                s2 = s2 + " asc ";
                            }

                        }
                        AddLine("\tselect @" + variable.nombre + "=" + variable.Campo + " from " + variable.Tabla + " where " + s + s2);
                    }
                }
            }
            //ahora valido las llaves foraneas para impedir que truene
            if (LLavesForaneas.Count > 0)
            {
                AddLine("\t--Validando llaves for�neas");
                foreach (Objetos.CLLaveForanea fk in LLavesForaneas)
                {
                    //veo si tiene algun comentario
                    if (fk.Comentarios != null && fk.Comentarios.Trim() != "")
                    {
                        AddLine("\t--" + fk.Comentarios);
                    }
                    //me traigo los campos y la tabla de la llave
                    List<Objetos.CCampoFK> fks = DB.DameCamposFK(fk.name);
                    //genero elselect
                    string s = "";
                    primero = true;
                    foreach (Objetos.CCampoFK ofk in fks)
                    {
                        if (primero == true)
                        {
                            primero = false;
                        }
                        else
                        {
                            s = s + " and ";
                        }
                        s = s + ofk.columnaMaestra + "=@" + ofk.columnahija + " ";
                    }
                    AddLine("\tif not exists( select * from " + fks[0].maestra + " where " + s + ")");
                    AddLine("\tbegin");
                    if (fk.Mensage != null && fk.Mensage.Trim() != "")
                    {
                        AddLine("\t\tRAISERROR(\'" + fk.Mensage + "\', 16, 1)");
                    }
                    else
                    {
                        //no asignaron texto para la excepcion, por lo que genero uno automatico
                        AddLine("\t\tRAISERROR(\'No se encontr� la relaci�n con la tabla " + fks[0].maestra + "\', 16, 1)");
                    }
                    AddLine("\t\treturn");
                    AddLine("\tend");
                }
            }
            //ya termine de hacer todas las validaciones, por lo que procedo a hacer el insert
            List<Objetos.CParametro> lista;
            lista = new List<Visor_sql_2015.Objetos.CParametro>();
            //le agrego los parametros
            foreach (Objetos.CParametro parametro in Parametros)
            {
                lista.Add(parametro);
            }
            foreach (Objetos.CParametro parametro in ValoresFijos)
            {
                lista.Add(parametro);
            }
            AddLine("\t--Actualizando el registro");
            primero = true;
            bool primero2 = true;
            string ss = "";
            string ss2 = "";
            AddLine("\tupdate ");
            AddLine("\t\t"+ Tabla);
            AddLine("\tset " );
            foreach (Objetos.CParametro obj in lista)
            {
                if (DB.ExisteCampoTabla(Tabla, obj.nombre))
                {
                    ss = "";
                    if (obj.LLavePrimaria == false)
                    {
                        if (primero == true)
                        {
                            primero = false;
                        }
                        else
                        {
                            ss = ss + ",";
                        }
                        ss = ss + obj.nombre + "=@" + obj.nombre;
                        AddLine("\t\t" + ss);
                    }
                    else
                    {
                        //es llave primaria, por lo que lo agrego en el where
                        if (primero2 == true)
                        {
                            primero2 = false;
                        }
                        else
                        {
                            ss2 = ss2 + " and ";
                        }
                        ss2 = ss2 + obj.nombre + "=@" + obj.nombre + "\n\r\t\t";
                    }
                }
            }
            AddLine("\t where ");
            AddLine("\t\t" + ss2);
            AddLine("end");
            CodigoSP(NombreSP, Codigo);
            CloseEvent();
        }
    }
}

