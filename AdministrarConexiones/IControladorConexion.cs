using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AdministrarConexiones
{
    public partial class IControladorConexion : UserControl
    {
        public IControladorConexion()
        {
            InitializeComponent();
        }
        protected FileConecction FFileConexion;
        //propiedad que se utiliza para intercambiar informacion
        public FileConecction FileConexion
        {
            get
            {
                return FFileConexion;
            }
            set
            {
                FFileConexion = value;
            }
        }
        public override string ToString()
        {
            return "Base";
        }
        public virtual int getHeing()
        {
            return 0;
        }
        public virtual void GuardaDatos(FileConecction fc)
        {
        }
        public virtual void CargaDatos(FileConecction fc)
        {
        }
        public virtual bool ValidaDatos()
        {
            return false;
        }

    }
}
