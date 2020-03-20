using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Editor
{
    public partial class FormVerError : Form
    {
        public FormVerError(string err)
        {
            InitializeComponent();
            textBox1.Text = err;
        }
    }
}