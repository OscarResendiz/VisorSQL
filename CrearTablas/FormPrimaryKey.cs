using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.CrearTablas
{
    public partial class FormPrimaryKey : Form
    {
        public FormPrimaryKey(List<Objetos.CParametro>l)
        {
            InitializeComponent();
            foreach (Objetos.CParametro obj in l)
            {
                Campos.Items.Add(obj, obj.LLavePrimaria);
            }
        }
        public bool EsLLave(int pos)
        {
            int i,n;
            n=Campos.CheckedIndices.Count;
            for (i = 0; i < n; i++)
            {

                if (Campos.CheckedIndices[i] == pos)
                    return true;
            }
            return false;
        }
    }
}