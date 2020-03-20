using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Editor
{
    public delegate bool OnPuedoCerrarEvent();
    public partial class FormEditor : Formularios.FormBase
    {
        private bool Guardando;
        int Pi,Pf;
        Point PuntoAnterior;
        bool Moviendo;
        private bool cerrando;
        public event OnCerrarEvent OnCerrar;
        public event OnPuedoCerrarEvent OnPuedoCerrar;
        public event OnPuedoCerrarEvent onNuevo;
        Controladores_DB.IDataBase DB;
        public FormEditor(Controladores_DB.IDataBase db)
        {
            DB = db;
            cerrando = false;
            InitializeComponent();
            Guardando = false;
        }

        private void FormEditor_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void AgregaEditor(EditorGenerico obj, string nombre)
        {
            tabControl1.TabPages.Insert(0,nombre);
            obj.Parent = tabControl1.TabPages[0];
            tabControl1.TabPages[0].Tag = obj;
            obj.Dock = DockStyle.Fill;
            obj.Show();
            tabControl1.SelectedIndex = 0;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex==-1)
                return;
            Text=tabControl1.TabPages[tabControl1.SelectedIndex].Text;
        }

        public override void Guardar()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.Guardar();

        }
        public override void ActualizaColores()
        {
            int i, n;
            n = tabControl1.TabPages.Count;
            for (i = 0; i < n; i++)
            {
                TextEditX obj = (TextEditX)tabControl1.TabPages[i].Tag;
                obj.ActualizaColores();
            }
        }
        private void FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrando == true)
            {
                return;
            }
            if (tabControl1.TabPages.Count > 0)
            {
                //cancelo el cerrar la ventana y solo cierro la pestaña actual
                e.Cancel = true;
                TimerCerrar.Enabled = true;
                return;
            }
            if (OnCerrar != null)
                OnCerrar();
        }
        public void Cierra()
        {
            cerrando = true;
            Close();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pi = i;
                    PuntoAnterior = e.Location;
                    Moviendo = true;
                    return;
                }
            }
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moviendo == false)
                return;
            int Direccion;//-1=derecha a izquierda 1=izquieda a derecha
            //calculo la direccion del movimiento
            if (e.Location.X > PuntoAnterior.X)
            {
                //va de izquierda a derecha
                Direccion = 1;
            }
            else
            {
                Direccion = -1;
            }
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pf = i;
                    if (Pi == Pf)
                    {
                        return;
                    }
                    if (Pi < Pf)
                    {
                        //mi posicion es menor que la del raton
                        if (Direccion == -1)
                        {
                            //voy moviendome hacia abajo
                            //no hago nada
                            return;
                        }
                    }
                    else
                    {
                        //mi posicion es mayor
                        if (Direccion == 1)
                        {
                            //voy moviendome hacia arriba
                            //no hago nada
                            return;
                        }
                    }
                    TabPage p = tabControl1.TabPages[Pi];
                    TabPage p2 = new TabPage();
                    int j, k;
                    k = p.Controls.Count;
                    for (i = k - 1; i >= 0; i--)
                    {
                        p2.Controls.Add(p.Controls[0]);
                    }
                    p2.BackColor = p.BackColor;
                    p2.Text = p.Text;
                    if (Direccion == 1)
                    {
                        //hay que agregarlo mas una
                        tabControl1.TabPages.Insert(Pf + 1, p2);
                    }
                    else
                    {
                        tabControl1.TabPages.Insert(Pf, p2);
                    }
                    tabControl1.TabPages.Remove(p);
                    tabControl1.SelectedIndex = Pf;
                    Pi = Pf;
                    Moviendo = true;
                    return;
                }
            }
        }

        private void tabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            int n = tabControl1.TabPages.Count;
            for (int i = 0; i < n; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    Pf = i;
                    if (Pi == Pf)
                    {
                        Moviendo = false;
                        return;
                    }
                    TabPage p = tabControl1.TabPages[Pi];
                    tabControl1.TabPages.RemoveAt(Pi);
                    tabControl1.TabPages.Insert(Pf, p);
                    tabControl1.SelectedIndex = Pf;
                    Pi = -1;
                    Pf = -1;
                    Moviendo = false;
                    return;
                }
            }

        }
        private bool  CierraPestaña()
        {
            if (tabControl1.SelectedIndex == -1)
                tabControl1.SelectedIndex = 0;
            TextEditX obj = null;
            try
            {
                obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            }
            catch (System.Exception)
            {
                //no es un texto
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                TimerCerrar.Enabled = false;
                Guardando = false;
                return true;
            }
            if (obj != null)
            {
                if (obj.Guardado == false)
                {
                    if (Guardando == true)
                        return true;
                    Guardando = true;
                    System.Windows.Forms.DialogResult dr = MessageBox.Show("¿Desea guardar los cambios hechos al archivo: " + obj.FileName + "?", "Cerrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            obj.Guardar();
                            break;
                        case DialogResult.Cancel:
                            TimerCerrar.Enabled = false;
                            Guardando = false;
                            return false;
                    }
                }
            }
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
            TimerCerrar.Enabled = false;
            Guardando = false;
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OnPuedoCerrar != null)
            {
                if (OnPuedoCerrar() == false)
                {
                        return;
                }
            }
                CierraPestaña();
        }
        public void CanecaCerrarPestañas()
        {
            TimerCerrar.Enabled = false;
        }
        public bool  CierraPestañas()
        {
            while (tabControl1.TabPages.Count > 0)
            {
                if (CierraPestaña() == false)
                    return false;
            }
            return true;
        }
        public override void Abrir()
        {
            if (tabControl1.SelectedIndex == -1)
            {
                if (onNuevo != null)
                    onNuevo();
            }
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.Abrir();
        }
        public  void EdicionCopiar()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.EdicionCopiar();
            
        }
        public  void EdicionPegar()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.EdicionPegar();
        }
        public  void EdicionCortar()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.EdicionCortar();
        }
        public void EdicionDeshacer()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.EdicionDeshacer();
        }
        public void EdicionReHacer()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.EdicionReHacer();
        }
        public void Ejecutar()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.Ejecutar();
        }
        public void Comentar()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.Comentar();
        }
        public void DesComentar()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.DesComentar();
        }
        public virtual void FindNext(bool viaF3, bool searchBackward, string messageIfNotFound, string TextoBuscar, bool CaseSensitive, bool WholeWords)
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.FindNext(viaF3,searchBackward,messageIfNotFound,TextoBuscar,CaseSensitive,WholeWords);
        }
        public void ReemplazarSiguiente(string textoBuscar, string TextoRemplazar, bool CaseSensitive, bool WholeWords)
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.ReemplazarSiguiente(textoBuscar, TextoRemplazar, CaseSensitive, WholeWords);
        }
        public virtual void RemplazarTodo(string textoBuscar, string TextoRemplazar, bool CaseSensitive, bool WholeWords)
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.RemplazarTodo(textoBuscar, TextoRemplazar,  CaseSensitive,  WholeWords);
        }
        public void MarcarCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar)
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.MarcarCoincidencias( textoBuscar,  CaseSensitive,  WholeWords, ColorAplicar);
        }

        public  void VistaPrevia()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.VistaPrevia();
        }
        public  void ConfigurarPagina()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.ConfigurarPagina();
        }
        public  void Imprimir()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
            obj.Imprimir();
        }
        public void SetFocus()
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            try
            {
                TextEditX obj = (TextEditX)tabControl1.TabPages[tabControl1.SelectedIndex].Tag;
                obj.SetFocus();
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
    }
}