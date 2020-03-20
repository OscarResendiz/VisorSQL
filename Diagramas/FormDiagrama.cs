using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Diagramas
{
    public partial class FormDiagrama : Form
    {
        public event Formularios.OnCodigoEvent OnCodigo;
        public event Formularios.OnCodigoEvent OnDependencias;
        public event Formularios.OnCodigoEvent OnTrasar;
        public event Formularios.OnDocuemntarEvent OnDocuemntar;
        public event Formularios.OnCodigoEvent OnEjecuta;
        System.Collections.Generic.List<Objetos.CSysObject> Lista;
        List<string> ListaTablas;
        private List<CTabla> Tablas;
        private CTabla TablaActiva;
        private Controladores_DB.IDataBase DB;
        private Point PMouse;
        private bool BMouseDown;
        private Graphics GraficoBuffer;
        Bitmap ImgBuffer;
        private Objetos.CSysObject Obj;
        //Graphics Grafico;
        public FormDiagrama(Controladores_DB.IDataBase db, System.Collections.Generic.List<Objetos.CSysObject> lista)//List<string> l)
        {
               Lista = new List<Visor_sql_2015.Objetos.CSysObject>();
            foreach (Objetos.CSysObject obj in lista)
                Lista.Add(obj);
            //---------------------------------------------------
            Tablas = new List<CTabla>();
            DB = db;
            ListaTablas = new List<string>();
            InitializeComponent();
            cBarraProgreso1.ValorMaximo = Lista.Count;
        }   

        private void FormDiagrama_Load(object sender, EventArgs e)
        {
            Diseñador.Left = 0;
            Diseñador.Top = 0;
            WindowState = FormWindowState.Maximized;
        }
        private void MuestraTabla(string nombre)
        {
            Graphics gp = Diseñador.CreateGraphics();
            CTabla t = new CTabla(DB, nombre,gp);
            //Diseñador.MouseClick += new MouseEventHandler(t.Diseñador_MouseClick);
            t.OnCodigo += new Visor_sql_2015.Formularios.OnCodigoEvent(OnCodigoE);
            t.OnDependencias += new Visor_sql_2015.Formularios.OnCodigoEvent(OnDependenciasE);
            t.OnTrasar += new Visor_sql_2015.Formularios.OnCodigoEvent(OnTrasarE);
            t.OnDocuemntar += new Visor_sql_2015.Formularios.OnDocuemntarEvent(OnDocuemntarE);
            t.OnEjecuta += new Visor_sql_2015.Formularios.OnCodigoEvent(OnEjecutaE);
            Tablas.Add(t);
        }
        private void Dibuja()
        {
            CalculaTamaño();
            Graphics gp = Diseñador.CreateGraphics();
            ImgBuffer = new Bitmap((Diseñador.Width*2), (Diseñador.Height*2));
            GraficoBuffer = Graphics.FromImage(ImgBuffer);
            GraficoBuffer.FillRectangle(Brushes.White, 0, 0, Diseñador.Width, Diseñador.Height);
            foreach (CTabla t in Tablas)
            {
                    t.ConectaHijos(GraficoBuffer, Brushes.Black);
            }
            foreach (CTabla t in Tablas)
            {
                t.Pintate(GraficoBuffer);
            }
            if (TablaActiva != null)
            {
                TablaActiva.Pintate(GraficoBuffer);
            }
            gp.DrawImage(ImgBuffer, Diseñador.Left, Diseñador.Top);
        }
        private void Diseñador_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = Diseñador.CreateGraphics();
            if (ImgBuffer == null)
                return;
            gp.DrawImage(ImgBuffer, Diseñador.Left, Diseñador.Top);
        }

        private void Diseñador_MouseDown(object sender, MouseEventArgs e)
        {

            PMouse = new Point(e.X + panel1.HorizontalScroll.Value, e.Y + panel1.VerticalScroll.Value);
            BMouseDown=true;
            TablaActiva = null;
            //ahora checo si el raton esta posado sobre una de las tablas
            foreach(CTabla obj in Tablas)
            {
                if(obj.EstaDentroElMouse(PMouse)==true)
                {
                    //el raton esta dentro del area de la tabla
                    TablaActiva=obj;
                }
            }
        }


        private void Diseñador_MouseUp(object sender, MouseEventArgs e)
        {
            if (TablaActiva != null)
            {
                if (BMouseDown == true)
                {
                    Dibuja();
                }
            }
            BMouseDown = false;
            TablaActiva = null;
        }
        private void CalculaTamaño()
        {
            Point P = new Point(0, 0);
            foreach (CTabla obj in Tablas)
            {
                if (obj.EndPoint.X > P.X)
                    P.X = obj.EndPoint.X;
                if (obj.EndPoint.Y > P.Y)
                    P.Y = obj.EndPoint.Y;
            }
                Diseñador.Width = P.X+100;
                Diseñador.Height = P.Y+100;
    }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Lista.Count == 0)
            {
                timer1.Enabled = false;
                cBarraProgreso1.Texto = "Analisis terminado";
                foreach (string s in ListaTablas)
                {
                    MuestraTabla(s);
                }
                COrdenadorTablas ot = new COrdenadorTablas(Tablas);
                ot.Ordena();
                Dibuja();
                return;
            }
            try
            {
                cBarraProgreso1.Progreso++;
            }
            catch (System.Exception)
            {
                cBarraProgreso1.Progreso = 1;
            }
            //me traigo el primer Item
            Obj = Lista[0];
            Lista.RemoveAt(0);
            if (Obj.TipoObjeto == Controladores_DB.TIPOOBJETO.TABLAX)
            {
                ListaTablas.Add(Obj.Nombre);
            }
            else
            {
                cBarraProgreso1.Texto = "Extrayendo dependencias de: " + Obj.Nombre;
                System.Collections.Generic.List<Objetos.CSysObject> l;
                if (Obj.TipoObjeto == Controladores_DB.TIPOOBJETO.STOREPROCERURE)
                    l = DB.DameDependencias(Obj.Nombre);
                else
                    l = DB.DameDependientesDe(Obj.Nombre);
                foreach (Objetos.CSysObject obj in l)
                {
                    if (obj.TipoObjeto == Controladores_DB.TIPOOBJETO.TABLAX)
                    {
                        AgregaAlaLista(obj.Nombre);
                    }
                    else
                    {
                        if (Exiete(obj.Nombre) == false)
                        {
                            Lista.Add(obj);
                            cBarraProgreso1.ValorMaximo++;
                        }
                    }
                }
            }

        }
        private void AgregaAlaLista(string s)
        {
            int i, n;
            n = ListaTablas.Count;
            for (i = 0; i < n; i++)
            {
                string s2 = ListaTablas[i];
                if (s2 == s)
                {
                    return;
                }
            }
            ListaTablas.Add(s);
        }
        private bool Exiete(string s)
        {
            foreach (Objetos.CSysObject s2 in Lista)
            {
                if (s == s2.Nombre)
                    return true;
            }
            return false;
        }

        private void Diseñador_MouseMove(object sender, MouseEventArgs e)
        {
            if (BMouseDown == false)
                return;
            if (TablaActiva == null)
                return;
            //como no se ha soltado el raton y se movio, hay que mover la tabla
            Point d = new Point();
            d.X = e.X + panel1.HorizontalScroll.Value - PMouse.X;
            d.Y = e.Y + panel1.VerticalScroll.Value - PMouse.Y;
            TablaActiva.Despintate(GraficoBuffer);
            TablaActiva.X = TablaActiva.X + d.X;
            TablaActiva.Y = TablaActiva.Y + d.Y;
            PMouse.X = e.X + panel1.HorizontalScroll.Value;
            PMouse.Y = e.Y + panel1.VerticalScroll.Value;
            TablaActiva.Repintate(GraficoBuffer);
            Diseñador_Paint(null, null);
        }

        public void OnCodigoE(string Nombre, string Codigo)
        {
            if (OnCodigo != null)
                OnCodigo(Nombre, Codigo);
        }
        public void OnDependenciasE(string Nombre, string Codigo)
        {
            if (OnDependencias != null)
                OnDependencias(Nombre, Codigo);
        }
        public void OnTrasarE(string Nombre, string Codigo)
        {
            if (OnTrasar != null)
                OnTrasar(Nombre, Codigo);
        }
        public void OnDocuemntarE(Formularios.FormDocumentar dlg)
        {
            if (OnDocuemntar != null)
            {
                //Formularios.FormDocumentar dlg = new Formularios.FormDocumentar(Tabla, DB);
                OnDocuemntar(dlg);
            }
        }
        public void OnEjecutaE(string Nombre, string Codigo)
        {
            if (OnEjecuta != null)
                OnEjecuta(Nombre, Codigo);
        }
    }
}