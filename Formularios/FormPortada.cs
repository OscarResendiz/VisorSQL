using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class FormPortada : Form
    {
        public FormPortada()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
       //     if (Opacity == 0)
            {
                Close();
            }
         //   Opacity--;
        }

        private void componenteExpandible1_OnFin()
        {
            timer1.Enabled = true;
            //formOpacador1.Visible = false;
           // Opacity = 100;
        }

        private void FormPortada_Load(object sender, EventArgs e)
        {
            formOpacador1.Visible = true;
        }

        private void formOpacador1_OnVisible(bool visible)
        {
            if (visible == true)
            {
                timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formOpacador1.Formulario = null;
            formOpacador1.OnVisible -= new Opacador.OnVisibleEvent(formOpacador1_OnVisible);
            formOpacador1.AutoCerrar = false;
            Close();
        }
    }
}