using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.CrearTablas
{
    public partial class FormFK : Form
    {
        public FormFK()
        {
            InitializeComponent();
        }
        public int Respuesta
        {
            get
            {
                if (RBCampo.Checked)
                    return 1;
                return 2;
            }
        }
    }
}
