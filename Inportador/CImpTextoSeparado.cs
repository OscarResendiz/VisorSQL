using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Inportador
{

    public partial class CImpTextoSeparado : CImpBase//UserControl//
    {
        private int Nlineas;
        System.IO.TextReader rt = null;
        int ncampos;
        private  System.Collections.Generic.List<System.Collections.Generic.List<string>> Datos;
        protected Controladores_DB.IDataBase DB;
        public CImpTextoSeparado(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
        }
        private bool CalculaTamaño()
        {
            Nlineas = 0;
            try
            {
                //abro el archivo
                rt = System.IO.File.OpenText(TArchivo.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            //leo la primer linea del archivo y veo cuantos campos requiero para hacer la importacion
            while (rt.Peek() > 0)
            {
                string s = rt.ReadLine();
                Nlineas++;
            }
            rt.Close();
            return true;
        }
        public override void Importar()
        {
            cBarraProgreso1.Texto = "Calculando el tamaño del archivo";
            if (CalculaTamaño() == false)
                return;
            try
            {
                //abro el archivo
                rt = System.IO.File.OpenText(TArchivo.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return;
            }
            cBarraProgreso1.ValorMaximo = Nlineas;
            cBarraProgreso1.Progreso = 0;
            //leo la primer linea del archivo y veo cuantos campos requiero para hacer la importacion
            //string s;
            ncampos = 0;
            TImportar.Enabled = true;
        }
        private bool  CreaTabla()
        {
            TErrores.Text = "";
            //creo un scrip para crear una tabla con el numero de campos que requiere para subir el archivo
            //primero calculo el numero mayor de campos que va a tener la tabla
            CalculaCampos();
            //ya tengo el numero de campos, asi que creo el scrip
            string s = "create table " + TTabla.Text + "(";
            //agrego los campos
            int i;
            for (i = 0; i < ncampos; i++)
            {
                if (i > 0)
                    s = s + ",";
                s = s + "Campo" + i.ToString() + " varchar(500)";
            }
            s = s + ")";
            try
            {
                //TErrores.Text = TErrores.Text + s + "\r\n";
                DB.Ejecuta(s);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;

        }
        private char Separador
        {
            get
            {
                if (CHTabuladores.Checked == true)
                {
                    return '\t';
                }
                return TSeparador.Text[0];
            }
        }
        private void CalculaCampos()
        {
            //recorro la linea para ver cuantos campos hay
            int i, n;
            n = Datos.Count;
            ncampos = 0;
            for (i = 0; i < n; i++)
            {
                if (Datos[i].Count > ncampos)
                    ncampos = Datos[i].Count;
            }
        }
        private void AgregaLiea(string s)
        {
            System.Collections.Generic.List<string> lista=new List<string>();
            string dato="";
            int i, n;
            n = s.Length;
            ncampos = 0;
            for (i = 0; i < n; i++)
            {
                if (s[i] == Separador)
                {
                    lista.Add(dato);
                    dato="";
                }
                else if(s[i]!='\'')
                    dato=dato+s[i];
            }
            if(dato!="")
                    lista.Add(dato);
                if (Datos == null)
                    Datos = new List<List<string>>();
                Datos.Add(lista);
        }
        private void InsertaDatos()
        {
            //recorro los datos y los voy insertando uno por uno

            int i, n;
            n = Datos.Count;
            for (i = 0; i < n; i++)
            {
                InsertaRegistro(Datos[i]);
            }
        }
        private void InsertaRegistro(List<string> l)
        {
            int i, n;
            //genero el scrip de insercion
            string s = "Insert into "+TTabla.Text+"(";
            string campos = "";
            string datos = "";
            n = l.Count;
            for (i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    campos = campos + ",";
                    datos = datos + ",";
                }
                campos=campos+"Campo"+i.ToString();
                datos = datos + "\'"+l[i]+"\'";
            }
            s = s + campos + ") values(" + datos + ")";
            try
            {
                //TErrores.Text = TErrores.Text + s + "\r\n";
                DB.Ejecuta(s);
            }
            catch (System.Exception ex)
            {
                TErrores.Text = TErrores.Text + ex.Message + "\r\n";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok=true;
            if (TArchivo.Text.Trim() == "")
                ok = false;
            if (TSeparador.Text.Trim() == "")
                ok = false;
            if (TTabla.Text.Trim() == "")
                ok = false;
             ActivarImportar(ok);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            TArchivo.Text = openFileDialog1.FileName;
        }

        private void TImportar_Tick(object sender, EventArgs e)
        {
            if (rt.Peek() > 0)
            {
                int rxs=1000/TImportar.Interval;
                int segundos=(cBarraProgreso1.ValorMaximo-cBarraProgreso1.Progreso)/rxs;
                int minutos=segundos/60;
                segundos=segundos-(minutos*60);
                cBarraProgreso1.Texto =cBarraProgreso1.Progreso.ToString()+"/"+cBarraProgreso1.ValorMaximo.ToString()+" Lineas leidas del archivo Tiempo estimado="+minutos.ToString()+" minutos y "+segundos.ToString()+" Segundos  ";
                cBarraProgreso1.Progreso++;
                string s = rt.ReadLine();
                AgregaLiea(s);
            }
            else
            {
                rt.Close();
                TImportar.Enabled = false;
                //ahora reviso el numero de registros                
                if (CreaTabla() == false)
                    return;
//                InsertaDatos();
                cBarraProgreso1.Texto = "Subiendo registros";   
                cBarraProgreso1.Progreso=0;
                cBarraProgreso1.ValorMaximo = Datos.Count;
                TimeSubirRegistros.Enabled = true;
            }

        }

        private void TimeSubirRegistros_Tick(object sender, EventArgs e)
        {
            if (cBarraProgreso1.ValorMaximo <= cBarraProgreso1.Progreso)
            {
                cBarraProgreso1.Texto = "Carga Terminada";
                TimeSubirRegistros.Enabled = false;
                return;
            }
            cBarraProgreso1.Texto = "Subiendo registros (" + cBarraProgreso1.Progreso.ToString() + "/" + cBarraProgreso1.ValorMaximo.ToString()+")";
            InsertaRegistro(Datos[cBarraProgreso1.Progreso]);
            cBarraProgreso1.Progreso++;
        }
    }
}
