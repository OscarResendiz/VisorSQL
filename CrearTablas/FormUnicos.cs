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
    public partial class FormUnicos : Form
    {
        public FormUnicos(List<string> campos)
        {
            InitializeComponent();
            ListaUnicos.Items.Clear();
            //agrego los campos a la tabla
            foreach (string s in campos)
            {
                ListaUnicos.Items.Add(s, CheckState.Unchecked);
            }
        }
        public string Campos
        {
            get
            {
                string s = "";
                //me traigo la lista de campos
                //Recorro todos los registros
                for (int i = 0; i < ListaUnicos.CheckedItems.Count; i++)
                {
                    string campo = ListaUnicos.CheckedItems[i].ToString();
                    //lo agrego
                    if (s != "")
                    {
                        s = s + ",";
                    }
                    s = s + campo;
                }
                return s;
            }
        }
    }
}
