using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Inportador
{
    public delegate void OnActivarImportarEvent(bool ok);
    public partial class CImpBase : UserControl
    {
        public event Formularios.OnCodigoEvent OnCodigo;
        public event OnActivarImportarEvent OnActivarImportar;
        public CImpBase()
        {
            InitializeComponent();
        }
        //protected void ActivarImportar(bool ok)
        //{
        //    if (OnActivarImportar != null)
        //        OnActivarImportar(ok);
        //}
        public virtual void Importar()
        {
            //esta funcion hay que sobre escribirla
        }
        protected void ActivarImportar(bool ok)
        {
            if (OnActivarImportar != null)
                OnActivarImportar(ok);
        }
        protected void MuestraMensage(string Nombrex, string Codigox)
        {
            if (OnCodigo != null)
                OnCodigo(Nombrex, Codigox);
        }
    }
}
