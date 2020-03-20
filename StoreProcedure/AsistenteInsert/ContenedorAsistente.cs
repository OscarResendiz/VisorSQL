using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.StoreProcedure.AsistenteInsert
{
    public delegate void DelegateSetVentanaEvent(ContenedorAsistente obj);
    public partial class ContenedorAsistente : UserControl
    {
        public System.Windows.Forms.Button BSiguiente
        {
            get;
            set;
        }
        public System.Windows.Forms.Button Banterior
        {
            get;
            set;
        }
        public System.Windows.Forms.Button Bcancelar
        {
            get;
            set;
        }

        public event DelegateSetVentanaEvent SetVentanaEvent;
        private ContenedorAsistente Siguiente, Anterior;
        public ContenedorAsistente()
        {
            InitializeComponent();
        }
        public virtual void OnSiguiente()
        {
            //estos hay que sobre escribirlos
            if (Siguiente != null)
                SetVentana(Siguiente);
        }
        public virtual void OnAnterior()
        {
            //este hay que sobre escribirlo
            if (Anterior != null)
                SetVentana(Anterior);
        }
        public virtual void OnCancelar()
        {
            //este hay que sobre escribirlo
        }
        protected void SetVentana(ContenedorAsistente obj)
        {
            if (SetVentanaEvent != null)
                SetVentanaEvent(obj);
        }
        protected bool EnableAnterior
        {
            get
            {
                return Banterior.Enabled;
            }
            set
            {
                Banterior.Enabled = value;
            }
        }
        protected bool EnableSiguiente
        {
            get
            {
                return BSiguiente.Enabled;
            }
            set
            {
                BSiguiente.Enabled = value;
            }
        }
        protected bool EnableCancelar
        {
            get
            {
                return Bcancelar.Enabled;
            }
            set
            {
                Bcancelar.Enabled = value;
            }
        }

    }
}
