using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }
        public virtual void Guardar()
        {
            //este codigo hay que sobre escribirlo
        }
        public virtual void ActualizaColores()
        {
            //este codigo hay que sobre escribirlo
        }
        public virtual void Abrir()
        {
            //este codigo hay que sobre escribirlo
        }
    }
}