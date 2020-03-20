using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Componentes
{
    public partial class CRelacionTabla : UserControl
    {
        private int pos;
        public List<string> Campos;
        public CRelacionTabla()
        {
            Campos = new List<string>();
            InitializeComponent();
            pos = 0;
        }
        public void Clear()
        {
            PCampos.Controls.Clear();
            pos = 0;
        }
        public void Add(string Campo)
        {
            CCampoRelacion cr = new CCampoRelacion();
            cr.Parent = PCampos;
            cr.OnDameCampos += new OnDameCamposEvent(DameCampos);
            cr.Top = pos;
            pos = pos + cr.Height;
            cr.Texto= Campo;
        }
        private void DameCampos(ref List<string> l)
        {
            foreach (string s in Campos)//
            {
                bool encontrado=false;
                foreach (CCampoRelacion c in PCampos.Controls)
                {
                    if (c.SelectedIndex != -1)
                    {
                        string s2 = (string)c.Items[c.SelectedIndex];
                        if (s2.ToLower().Trim() == s.ToLower().Trim())
                        {
                            encontrado = true;
                            break;
                        }
                    }                    
                }
                if (encontrado == false)
                {
                    l.Add(s);
                }
            }
        }
        public bool TodosAsignados
        {
            get
            {
                foreach (CCampoRelacion c in PCampos.Controls)
                {
                    if (c.SelectedIndex == -1)
                        return false;
                }
                return true;
            }
        }
        public List<Objetos.CCampoFK> Relaciones
        {
            get
            {
                List<Objetos.CCampoFK> l = new List<Visor_sql_2015.Objetos.CCampoFK>();
                foreach (CCampoRelacion c in PCampos.Controls)
                {
                    Objetos.CCampoFK obj=new Visor_sql_2015.Objetos.CCampoFK();
                    obj.columnahija=(string )c.Items[c.SelectedIndex];
                    obj.columnaMaestra = c.Texto;
                    l.Add(obj);
                }
                return l;
            }
        }
    }
}
