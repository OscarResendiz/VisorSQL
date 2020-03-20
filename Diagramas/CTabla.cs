using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Visor_sql_2015.Diagramas
{
    public delegate CTabla OnBuscaHijoEvent(string tabla);
    public class CTabla
    {
        public event Formularios.OnCodigoEvent OnCodigo;
        public event Formularios.OnCodigoEvent OnDependencias;
        public event Formularios.OnCodigoEvent OnTrasar;
        public event Formularios.OnDocuemntarEvent OnDocuemntar;
        public event Formularios.OnCodigoEvent OnEjecuta;
        //private bool Repintando;
        public bool Ordenado;
        private Controladores_DB.IDataBase DB;
        private List<CTabla> Hijos;
        private List<CTabla> Padres;
        public event OnBuscaHijoEvent OnBuscaHijo;
        public List<Objetos.CParametro> Campos;
        public string Nombre;
        public int X, Y;
        private int DY;
        private int Ancho; //contiene el ancho del texto
        Graphics GP;
        private int NCampos;
        System.Drawing.Font Font;
        private string MaxText;
        public CTabla(Controladores_DB.IDataBase db, string nombre, Graphics gp)
        {
            GP = gp;
            DB = db;
            Nombre = nombre;
            //cargo todos mis campos de la tabla
            Campos = DB.DameCamposTabla(nombre);
            NCampos = Campos.Count;
            //inicializo algunas variables
            DY = 15; //marca la distancia entre relglon y renglon
            //calculo el ancho de la tabla
            Ancho = Nombre.Length;
            MaxText = Nombre;
            //recorro todos los campos de la tabla
            foreach (Objetos.CParametro obj in Campos)
            {
                string s = obj.nombre + ":" + obj.TipoSP;
                if (s.Length > Ancho)
                {
                    Ancho = s.Length;
                    MaxText = s;
                }
            }
            //genero el tipo de letra que voy a utilizar
            Font = new Font("Times New Roman", 9, FontStyle.Bold);
        }
        public void Pintate(Graphics gp)
        {
            GP = gp;
            MuestraNombre();
            MuestraCampos();
        }
        public bool EstaDentroElMouse(Point p)
        {
            if (p.X >= X && p.X <= EndPoint.X && p.Y >= Y && p.Y <= EndPoint.Y)
                return true;
            return false;
        }
        public void Despintate(Graphics gp)
        {
            GP = gp;
            GP.FillRectangle(Brushes.White, X, Y, Width + 2, (NCampos * DY) + DY + 2);
            ConectaHijos(gp, Brushes.White);
            //ahora desdibujo las lineas con mis padres
            if (Padres != null)
            {
                foreach (CTabla obj in Padres)
                {
                    obj.ConectaHijo(this, Brushes.White);
                }
            }
        }
        public void AsignaPadre(CTabla t)
        {
            if (Padres == null)
                Padres = new List<CTabla>();
            //busco si ya esta agregado
            foreach (CTabla obj in Padres)
            {
                if (obj.Nombre == t.Nombre)
                {
                    //ya esta
                    return;
                }
            }
            // lo agrego
            Padres.Add(t);
        }
        public void CargaHijos()
        {
            //me traigo la lista de dependencias
            Hijos = new List<CTabla>();
            List<Objetos.CSysObject> l = DB.DameDependencias(Nombre);
            //recorro la lista de hijos para ver cuales son sus hijos
            foreach (Objetos.CSysObject obj in l)
            {
                if (OnBuscaHijo != null)
                {
                    CTabla t = OnBuscaHijo(obj.Nombre);
                    if (t != null)
                    {
                        //veo si ya lo tengo
                        bool encontrado = false;
                        foreach (CTabla ta in Hijos)
                        {
                            if (ta.Nombre == t.Nombre)
                            {
                                encontrado = true;
                                break;
                            }
                        }
                        if (encontrado == false)
                        {
                            // no esta, por lo que hay que agregarlo
                            Hijos.Add(t);
                            t.AsignaPadre(this);
                        }
                    }
                }
            }
        }
        public Point CalculaPosicion(Point r, int llamado)
        {
            //llamado -1==soy hijo, 0=soy igual, 1=Soy padre
            //primero veo si tengo padres y led digo que se calculen a si mismos
            if (Ordenado == true)
            {
                //ya fui calculado, por lo que no hago nada
                Point p = EndPoint;
                return p;
            }
            if (Padres != null)
            {
                //tengo padres, por lo que hago que ellos hagan el calculo primero
                Point PP = new Point(r.X, r.Y);
                foreach (CTabla obj in Padres)
                {
                    Point px = obj.CalculaPosicion(r, 1);
                    if (px.Y > PP.Y)
                        PP.Y = px.Y;
                }
                r.Y = PP.Y;
            }
            //ahora me calculo yo
            if (Ordenado == false)
            {
                //dependiendo del modo de llamado hago mi calculo
                X = r.X + 50;
                Y = r.Y + 50;
                Ordenado = true;
            }
            //ahora que se calculen los hijos
            if (Hijos != null)
            {
                Point p = EndPoint;
                foreach (CTabla obj in Hijos)
                {
                    if (obj.Ordenado == false)
                    {
                        p.X = r.X;
                        p = obj.CalculaPosicion(p, -1);
                    }
                }
            }
            Point pf = EndPoint;
            return pf;
        }
        public Point InitPoint
        {
            get
            {
                Point p = new Point(X, Y);
                return p;
            }
        }
        public Point PuntoMedio
        {
            get
            {
                Point p = new Point(InitPoint.X + ((EndPoint.X - InitPoint.X) / 2), InitPoint.Y + ((EndPoint.Y - InitPoint.Y) / 2));
                return p;
            }
        }
        public Point EndPoint
        {
            get
            {
                Point p = new Point(X + Width + 2, Y + (NCampos * DY) + DY + 2);
                return p;
            }
        }
        public void ConectaHijos(Graphics gp, Brush b)
        {
            GP = gp;
            if (Hijos == null)
                return;
            foreach (CTabla obj in Hijos)
            {
                ConectaHijo(obj, b);
                //obj.Repintate(gp);
            }
        }
        public void Repintate(Graphics gp)
        {
            //    if (Repintando == true)
            //      return;
//            Repintando = true;
            GP = gp;
            if (Padres != null)
            {
                foreach (CTabla obj in Padres)
                {
                    obj.ConectaHijo(this, Brushes.Black);
                    //obj.Repintate(gp);
                }
            }
            ConectaHijos(gp, Brushes.Black);
            Pintate(gp);
//            Repintando = false;
        }
        public int Width
        {
            get
            {
                SizeF s = GP.MeasureString(MaxText + "HX", Font);
                //return Ancho * (int)s.Height;
                return (int)s.Width;

            }
        }
        public void ConectaHijo(CTabla hijo, Brush b)
        {
            int Distancia = 5;
            Point pmedio = new Point();
            Point ph = new Point(), pd = new Point(), ph1 = new Point(), ph2 = new Point();
            //Calculo el punto intermedio en el que hay que hacer el quiebre
            //calculo el punto de donde se va a iniciar a dibujar la linea
            //primero checo el punto con respecto a la tabla padre
            Pen p = new Pen(b, 1);
            //veo en que cuadrante esta la tabla hija con respecto a la tabla padre
            if (PuntoMedio.X >= hijo.PuntoMedio.X && PuntoMedio.Y >= hijo.PuntoMedio.Y)
            {
                //cuadrante 1
                pmedio.X = PuntoMedio.X;
                pmedio.Y = hijo.PuntoMedio.Y;
                ph.X = pmedio.X;
                ph.Y = InitPoint.Y;
                pd.X = hijo.EndPoint.X;
                pd.Y = hijo.PuntoMedio.Y;
                ph1.X = ph.X - Distancia;
                ph1.Y = ph.Y - Distancia;
                ph2.X = ph.X + Distancia;
                ph2.Y = ph.Y - Distancia;
                //veo si la tabla hija esta dentro del harea de la tabla padre
                if (hijo.PuntoMedio.Y >= InitPoint.Y && hijo.PuntoMedio.Y <= EndPoint.Y)
                {
                    //modifico los puntos
                    ph.X = InitPoint.X;
                    ph.Y = hijo.PuntoMedio.Y;
                    ph1.X = ph.X - Distancia;
                    ph1.Y = ph.Y - Distancia;
                    ph2.X = ph.X - Distancia;
                    ph2.Y = ph.Y + Distancia;
                }
            }
            if (PuntoMedio.X < hijo.PuntoMedio.X && PuntoMedio.Y >= hijo.PuntoMedio.Y)
            {
                //cuadrante 2
                pmedio.X = PuntoMedio.X;
                pmedio.Y = hijo.PuntoMedio.Y;
                ph.X = pmedio.X;
                ph.Y = InitPoint.Y;
                pd.X = hijo.InitPoint.X;
                pd.Y = hijo.PuntoMedio.Y;
                ph1.X = ph.X - Distancia;
                ph1.Y = ph.Y - Distancia;
                ph2.X = ph.X + Distancia;
                ph2.Y = ph.Y - Distancia;
                if (hijo.PuntoMedio.Y >= InitPoint.Y && hijo.PuntoMedio.Y <= EndPoint.Y)
                {
                    //modifico los puntos
                    ph.X = EndPoint.X;
                    ph.Y = hijo.PuntoMedio.Y;
                    ph1.X = ph.X + Distancia;
                    ph1.Y = ph.Y - Distancia;
                    ph2.X = ph.X + Distancia;
                    ph2.Y = ph.Y + Distancia;
                }
            }
            if (PuntoMedio.X < hijo.PuntoMedio.X && PuntoMedio.Y < hijo.PuntoMedio.Y)
            {
                //cuadrante 3
                pmedio.X = PuntoMedio.X;
                pmedio.Y = hijo.PuntoMedio.Y;
                ph.X = pmedio.X;
                ph.Y = EndPoint.Y;
                pd.X = hijo.InitPoint.X;
                pd.Y = hijo.PuntoMedio.Y;
                ph1.X = ph.X - Distancia;
                ph1.Y = ph.Y + Distancia;
                ph2.X = ph.X + Distancia;
                ph2.Y = ph.Y + Distancia;
                if (hijo.PuntoMedio.Y >= InitPoint.Y && hijo.PuntoMedio.Y <= EndPoint.Y)
                {
                    //modifico los puntos
                    ph.X = EndPoint.X;
                    ph.Y = hijo.PuntoMedio.Y;
                    ph1.X = ph.X + Distancia;
                    ph1.Y = ph.Y - Distancia;
                    ph2.X = ph.X + Distancia;
                    ph2.Y = ph.Y + Distancia;
                }
            }
            if (PuntoMedio.X >= hijo.PuntoMedio.X && PuntoMedio.Y < hijo.PuntoMedio.Y)
            {
                //cuadrante 4
                pmedio.X = PuntoMedio.X;
                pmedio.Y = hijo.PuntoMedio.Y;
                ph.X = pmedio.X;
                ph.Y = EndPoint.Y;
                pd.X = hijo.EndPoint.X;
                pd.Y = hijo.PuntoMedio.Y;
                ph1.X = ph.X - Distancia;
                ph1.Y = ph.Y + Distancia;
                ph2.X = ph.X + Distancia;
                ph2.Y = ph.Y + Distancia;
                //veo si la tabla hija esta dentro del harea de la tabla padre
                if (hijo.PuntoMedio.Y >= InitPoint.Y && hijo.PuntoMedio.Y <= EndPoint.Y)
                {
                    //modifico los puntos
                    ph.X = InitPoint.X;
                    ph.Y = hijo.PuntoMedio.Y;
                    ph1.X = ph.X - Distancia;
                    ph1.Y = ph.Y - Distancia;
                    ph2.X = ph.X - Distancia;
                    ph2.Y = ph.Y + Distancia;
                }
            }
            if (ph.X >= hijo.X && ph.X <= hijo.X + hijo.Width)
            {
                if (hijo.Y < Y)
                {
                    pmedio.Y = hijo.EndPoint.Y - 1;
                    pd.Y = hijo.EndPoint.Y - 1;

                }
                else
                {
                    pmedio.Y = hijo.InitPoint.Y;
                    pd.Y = hijo.InitPoint.Y;
                }
            }
            GP.DrawLine(p, ph, pmedio);
            GP.DrawLine(p, pd, pmedio);
            //dibujo laslineas de la felcha
            GP.DrawLine(p, ph, ph1);
            GP.DrawLine(p, ph, ph2);
            // hijo.Pintate(GP);
        }
        public int Height
        {
            get
            {
                //SizeF s = GP.MeasureString(MaxText + "HX", Font);

                return (NCampos * DY) + DY + 2;
            }
        }
        private void MuestraCampos()
        {
            //se encarga de pintar los campos de la tabla
            //primero pinto el cuadro que va a contener los campos
            Pen p = new Pen(Color.Black);
            Pen p2 = new Pen(Color.Gray);
            GP.FillRectangle(Brushes.AliceBlue, X, Y + DY + 1, Width, NCampos * DY);
            //   GP.DrawRectangle(p2, X, Y + DY, Width + 1, (NCampos * DY) + 1);
            // GP.DrawRectangle(p, X, Y + DY, Width, NCampos * DY);
            //ahora voy pintando cada campo
            int py = Y + (DY * 1);
            foreach (Objetos.CParametro obj in Campos)
            {
                Brush b;
                string s = obj.nombre + ":" + obj.TipoSP;
                if (obj.LLavePrimaria == true)
                {
                    b = Brushes.Red;
                }
                else
                {
                    b = Brushes.Black;
                }
                GP.DrawString(s, Font, b, X + 5, py);
                py = py + DY;
            }
            GP.DrawArc(p, X, Y + (NCampos * DY), DY, DY, 91, 105);
            GP.DrawArc(p, X + Width - DY, Y + (NCampos * DY), DY, DY, 360, 105);

            GP.DrawLine(p, X + (DY / 2), Y, X + Width - (DY / 2), Y);
            GP.DrawLine(p, X + (DY / 2), Y + (NCampos * DY) + DY, X + Width - (DY / 2), Y + (NCampos * DY) + DY);

            GP.DrawLine(p, X, Y + (DY / 2), X, Y + (NCampos * DY) + DY - (DY / 2));
            GP.DrawLine(p, X + Width, Y + (DY / 2), X + Width, Y + (NCampos * DY) + DY - (DY / 2));

            GP.DrawLine(p, X, Y + DY, X + Width, Y + DY);
        }
        private void MuestraNombre()
        {
            //se encarga de dibujar el nombre de la tabla
            Pen p = new Pen(Color.Black);
            Pen p2 = new Pen(Color.Gray);
            Point P1, P2, P3, P4;
            P1 = new Point(X, Y);
            P2 = new Point(X, Y + DY);
            P3 = new Point(X + Width, Y + DY);
            P4 = new Point(X, Y + DY);
            Rectangle rectangulo = new Rectangle(X, Y, Width, DY);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.LightCyan, Color.White, LinearGradientMode.Horizontal);
            GP.FillRectangle(brocha, rectangulo);

            //GP.FillRectangle(Brushes.LightCyan, X, Y, Width, DY);
            //dibujo las curbas
            GP.DrawArc(p, X, Y, DY, DY, 165, 105);
            GP.DrawArc(p, X + Width - DY, Y, DY, DY, 259, 105);

            GP.DrawString(Nombre, Font, Brushes.Black, X + 5, Y);
        }
        private void DrawClosedCurvePoint()
        {
            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.

            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 50);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints =
             {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };

            // Draw lines between original points to screen.
            //GP.DrawLines(redPen, curvePoints);

            // Draw closed curve to screen.
            GP.DrawClosedCurve(greenPen, curvePoints);
        }
        public void Diseñador_MouseClick(object sender, MouseEventArgs e,Point p)
        {
            if (e.X < InitPoint.X || e.X > EndPoint.X || e.Y < InitPoint.Y || e.Y > EndPoint.Y)
            {
                //no esta en mi area de trabajo
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                //hay que mostrar el menu
                //Point p = new Point(e.X, e.Y);
                Menu.Show((Control) sender,p);
            }
        }
        #region Control del menu
        public System.Windows.Forms.ContextMenu Menu
        {
            get
            {
                System.Windows.Forms.ContextMenu contextMenu1;
                contextMenu1 = new System.Windows.Forms.ContextMenu();
                //creando los items del menu 
                System.Windows.Forms.MenuItem MenuGenerar_clase_C;
                MenuGenerar_clase_C = new System.Windows.Forms.MenuItem();
                MenuGenerar_clase_C.Index = 0;
                MenuGenerar_clase_C.Text = "Generar clase C#";
                MenuGenerar_clase_C.Click += new System.EventHandler(MenuGenerar_clase_CClick);
                contextMenu1.MenuItems.Add(MenuGenerar_clase_C);
                System.Windows.Forms.MenuItem MenuCrear_Sp_de_altas;
                MenuCrear_Sp_de_altas = new System.Windows.Forms.MenuItem();
                MenuCrear_Sp_de_altas.Index = 1;
                MenuCrear_Sp_de_altas.Text = "Crear Sp de altas";
                MenuCrear_Sp_de_altas.Click += new System.EventHandler(MenuCrear_Sp_de_altasClick);
                contextMenu1.MenuItems.Add(MenuCrear_Sp_de_altas);
                System.Windows.Forms.MenuItem MenuCrear_SP_de_Bajas;
                MenuCrear_SP_de_Bajas = new System.Windows.Forms.MenuItem();
                MenuCrear_SP_de_Bajas.Index = 2;
                MenuCrear_SP_de_Bajas.Text = "Crear SP de Bajas";
                MenuCrear_SP_de_Bajas.Click += new System.EventHandler(MenuCrear_SP_de_BajasClick);
                contextMenu1.MenuItems.Add(MenuCrear_SP_de_Bajas);
                System.Windows.Forms.MenuItem MenuCrear_SP_para_Cambios;
                MenuCrear_SP_para_Cambios = new System.Windows.Forms.MenuItem();
                MenuCrear_SP_para_Cambios.Index = 3;
                MenuCrear_SP_para_Cambios.Text = "Crear SP para Cambios";
                MenuCrear_SP_para_Cambios.Click += new System.EventHandler(MenuCrear_SP_para_CambiosClick);
                contextMenu1.MenuItems.Add(MenuCrear_SP_para_Cambios);
                System.Windows.Forms.MenuItem MenuCrear_SP_de_Lectura;
                MenuCrear_SP_de_Lectura = new System.Windows.Forms.MenuItem();
                MenuCrear_SP_de_Lectura.Index = 4;
                MenuCrear_SP_de_Lectura.Text = "Crear SP de Lectura";
                MenuCrear_SP_de_Lectura.Click += new System.EventHandler(MenuCrear_SP_de_LecturaClick);
                contextMenu1.MenuItems.Add(MenuCrear_SP_de_Lectura);
                System.Windows.Forms.MenuItem MenuVer_dependencias;
                MenuVer_dependencias = new System.Windows.Forms.MenuItem();
                MenuVer_dependencias.Index = 5;
                MenuVer_dependencias.Text = "Ver dependencias";
                MenuVer_dependencias.Click += new System.EventHandler(MenuVer_dependenciasClick);
                contextMenu1.MenuItems.Add(MenuVer_dependencias);
                System.Windows.Forms.MenuItem MenuTrasar;
                MenuTrasar = new System.Windows.Forms.MenuItem();
                MenuTrasar.Index = 6;
                MenuTrasar.Text = "Trasar";
                MenuTrasar.Click += new System.EventHandler(MenuTrasarClick);
                contextMenu1.MenuItems.Add(MenuTrasar);
                System.Windows.Forms.MenuItem MenuVer_Reporte;
                MenuVer_Reporte = new System.Windows.Forms.MenuItem();
                MenuVer_Reporte.Index = 7;
                MenuVer_Reporte.Text = "Ver Reporte";
                contextMenu1.MenuItems.Add(MenuVer_Reporte);
                System.Windows.Forms.MenuItem MenuDocuemntar;
                MenuDocuemntar = new System.Windows.Forms.MenuItem();
                MenuDocuemntar.Index = 8;
                MenuDocuemntar.Text = "Docuemntar";
                MenuDocuemntar.Click += new System.EventHandler(MenuDocuemntarClick);
                contextMenu1.MenuItems.Add(MenuDocuemntar);
                System.Windows.Forms.MenuItem MenuVer_Codigo;
                MenuVer_Codigo = new System.Windows.Forms.MenuItem();
                MenuVer_Codigo.Index = 9;
                MenuVer_Codigo.Text = "Ver Codigo";
                MenuVer_Codigo.Click += new System.EventHandler(MenuVer_CodigoClick);
                contextMenu1.MenuItems.Add(MenuVer_Codigo);
                System.Windows.Forms.MenuItem MenuVer_contenido;
                MenuVer_contenido = new System.Windows.Forms.MenuItem();
                MenuVer_contenido.Index = 10;
                MenuVer_contenido.Text = "Ver contenido";
                MenuVer_contenido.Click += new System.EventHandler(MenuVer_contenidoClick);
                contextMenu1.MenuItems.Add(MenuVer_contenido);
                return contextMenu1;
            }
        }
        //eventos 
        private void MenuGenerar_clase_CClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Generar clase C#
            string codigo = DB.CreaCodigoTabla(Nombre);
            if (OnCodigo != null)
                OnCodigo("Clase " + Nombre, codigo);
        }
        private void MenuCrear_Sp_de_altasClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Crear Sp de altas
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 2);
            dlg.Tabla = Nombre;
            dlg.OnCodigoSP += new Formularios.OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();
        }
        private void MenuCrear_SP_de_BajasClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Crear SP de Bajas
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 4);
            dlg.Tabla = Nombre;
            dlg.OnCodigoSP += new Formularios.OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();
        }
        private void MenuCrear_SP_para_CambiosClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Crear SP para Cambios
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 3);
            dlg.Tabla = Nombre;
            dlg.OnCodigoSP += new Formularios.OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();
        }
        private void MenuCrear_SP_de_LecturaClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Crear SP de Lectura
            AsistSps.FormAsistSP dlg = new Visor_sql_2015.AsistSps.FormAsistSP(DB, 1);
            dlg.Tabla = Nombre;
            dlg.OnCodigoSP += new Formularios.OnCodigoSPEvent(GenCodigo);
            dlg.ShowDialog();
        }
        private void MenuVer_dependenciasClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Ver dependencias
            if (OnDependencias != null)
                OnDependencias("Dependencia de " + Nombre, Nombre);
        }
        private void MenuTrasarClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Trasar
            if (OnTrasar != null)
                OnTrasar(Nombre, Nombre);
        }
        private void MenuDocuemntarClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Docuemntar
            if (OnDocuemntar != null)
            {
                Formularios.FormDocumentar dlg = new Formularios.FormDocumentar(Nombre, DB);

                OnDocuemntar(dlg);
            }
        }
        private void MenuVer_CodigoClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Ver Codigo
            if (OnCodigo != null)
                OnCodigo("Codigo para crear la tabla " + Nombre, DB.GeneraCodigoTabla(Nombre,Campos));
        }
        private void MenuVer_contenidoClick(object sender, System.EventArgs e)
        {
            //Colocar el codigo aqui para Ver contenido
            if (OnEjecuta != null)
                OnEjecuta("Contenido dr la tabla" + Nombre, "select * from " + Nombre);
        }
        #endregion
        private void GenCodigo(string nombre, string codigo)
        {
            if (OnCodigo != null)
                OnCodigo(nombre, codigo);
        }
    }
}
