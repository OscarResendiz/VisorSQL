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
    public partial class OpcionBoton : UserControl
    {
        public OpcionBoton()
        {
            InitializeComponent();
        }
        public Button Boton
        {
            get
            {
                return button1;
            }
            set
            {
                button1 = value;
            }
        }
        public string Texto
        {
            get
            {
                return LTexto.Text;
            }
            set
            {
                LTexto.Text = value;
            }
        }
        public event System.EventHandler ButtonClick;
        private void button1_Click(object sender, EventArgs e) 
        {
            if (ButtonClick != null)
                ButtonClick(sender, e);
        }
        public Image Imagen
        {
            get
            {
                return button1.Image;
            }
            set
            {
                button1.Image = value;
            }
        }

    }
}
