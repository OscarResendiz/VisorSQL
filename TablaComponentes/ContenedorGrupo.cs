using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.TablaComponentes
{
    public partial class ContenedorGrupo : Panel
    {
        public ContenedorGrupo()
        {
            InitializeComponent();
        }
        public string Tutulo
        {
            get
            {
                return LTitulo.Text;
            }
            set
            {
                LTitulo.Text = value;
            }
        }
    }
}
