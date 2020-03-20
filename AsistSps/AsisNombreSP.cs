using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.AsistSps
{
    public partial class AsisNombreSP : Visor_sql_2015.AsistSps.AsistBaseSP
    {
        private Controladores_DB.IDataBase DB;

        public AsisNombreSP(Controladores_DB.IDataBase db)
        {
            DB = db;
            InitializeComponent();
            //me traigo el modo y el nombre de la tabla para proponer un nombre
            string modo =(string ) DameValor("Tipo");
            string tabla =(string ) DameValor("Tabla");
            if (modo == "Lectura")
            {
                TNombre.Text = "SPAD_Dame" + tabla;
            }
            if (modo == "Escritura")
            {
                TNombre.Text = "SPAD_Agrega" + tabla;
            }
            if (modo == "Update")
            {
                TNombre.Text = "SPAD_Actualiza" + tabla;
            }
            if (modo == "Delete")
            {
                TNombre.Text = "SPAD_Elimina" + tabla;
            }
            if (TComentario.Text.Trim() == "")
            {
                TComentario.Text = TComentario.Text + "\n Fecha de creación " + System.DateTime.Now.Date.ToString("dd/MM/yyyy"); ;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible == false)
                return;
            bool ok = true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            EnableAnterior(true);
            EnableSiguiente(ok);
        }
        public override void BSiguiente()
        {
            AsignaValor("NombreSP", TNombre.Text);
            AsignaValor("ComentarioNombreSP", TComentario.Text);
            if (Siguiente == null)
            {
                Siguiente = new AsisSelParametros(DB);
                Siguiente.Anterior = this;
            }
            OnInstalame(Siguiente);
        }

        private void agregarFechaDeCreaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TComentario.Text = TComentario.Text + "\n Fecha de creación " + System.DateTime.Now.Date.ToString("dd/MM/yyyy"); ;
        }

        private void Chk_Mayusculas_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Mayusculas.Checked == true)
            {
                //cambia a mayusculas
                TNombre.CharacterCasing = CharacterCasing.Upper;
            }
            else
                TNombre.CharacterCasing = CharacterCasing.Normal;
        }

        private void TNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

