using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public delegate void OnCloseEvent();
    public delegate void OnEnableEvent(bool Valor);
    public delegate void OnCambiaTexto(string Texto);
    public delegate void OnInstalameEvent(AsistBaseSP obj);
    public partial class AsistBaseSP : UserControl
    {
        public event OnCloseEvent OnClose;
        public event Formularios.OnCodigoSPEvent OnCodigoSP;
        public static List<CDato> Datos;
        public static void AsignaValor(string nombre, object valor)
        {
            if (Datos == null)
            {
                Datos = new List<CDato>();
            }
            foreach (CDato obj in Datos)
            {
                if (obj.Nombre == nombre)
                {
                    obj.Valor = valor;
                    return;
                }
            }
            CDato d = new CDato();
            d.Nombre = nombre;
            d.Valor = valor;
            Datos.Add(d);
        }
        public static object DameValor(string nombre)
        {
            if (Datos == null)
            {
                throw new System.Exception("No se encontro el valor "+nombre);
            }
            foreach (CDato obj in Datos)
            {
                if (obj.Nombre == nombre)
                {
                    return obj.Valor;
                }
            }
            throw new System.Exception("No se encontro el valor " + nombre);
        }
        public AsistBaseSP Siguiente, Anterior;
        #region Eventos de control de los botones
        public event OnEnableEvent OnEnableAnterior;
        public event OnEnableEvent OnEnableSiguiente;
        public event OnEnableEvent OnEnableCancelar;
        public event OnCambiaTexto OnTextoAnterior;
        public event OnCambiaTexto OnTextoSiguiente;
        public event OnCambiaTexto OnTextoCancelar;
        public event OnCambiaTexto OnTextoPrincipal;
        public event OnInstalameEvent InstalameEvent;
        #endregion
        public AsistBaseSP()
        {
            InitializeComponent();
        }
        protected void EnableAnterior(bool Valor)
        {
            if(OnEnableAnterior!=null)
                OnEnableAnterior(Valor);
        }
        protected void EnableSiguiente(bool Valor)
        {
            if(OnEnableSiguiente!=null)
                OnEnableSiguiente(Valor);
        }
        protected void EnableCancelar(bool Valor)
        {
            if(OnEnableCancelar!=null)
                OnEnableCancelar(Valor);
        }
        protected void TextoAnterior(string Texto)
        {
            if(OnTextoAnterior!=null)
                OnTextoAnterior(Texto);
        }
        protected void TextoSiguiente(string Texto)
        {
            if(OnTextoSiguiente!=null)
                OnTextoSiguiente(Texto);
        }
        protected void TextoCancelar(string Texto)
        {
            if (OnTextoCancelar != null)
                OnTextoCancelar(Texto);
        }
        protected void OnInstalame(AsistBaseSP obj)
        {
            if (InstalameEvent != null)
                InstalameEvent(obj);
        }
        protected void TextoPrincipal(string Texto)
        {
            if (OnTextoPrincipal != null)
                OnTextoPrincipal(Texto);
        }
        public virtual void BSiguiente()
        {
            //funciones virtuales que se tienen que ir remplazando en cada visor
        }
        public virtual void BAnterio()
        {
            //funciones virtuales que se tienen que ir remplazando en cada visor
            if (Anterior == null)
                return;
            OnInstalame(Anterior);
        }
        public virtual void Inicializate()
        {
            //se utiliza para quellos visores que nececiten actuaizar su informacion
        }
        public void CodigoSP(string Nombre, string Codigo)
        {
            if (OnCodigoSP != null)
                OnCodigoSP(Nombre, Codigo);
        }
        public void CloseEvent()
        {
            if (OnClose != null)
                OnClose();
        }
    }
}
