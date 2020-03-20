using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2015.Formularios
{
    public partial class ForEditTabla : EditorGenerico
    {
        Controladores_DB.IDataBase DB;
        string Tabla;
        public ForEditTabla(Controladores_DB.IDataBase db, string tabla)
        {
            Tabla = tabla;
            DB = db;
            InitializeComponent();
            cidGrid1.Conexion = new System.Data.SqlClient.SqlConnection(DB.ConnectionString);
            cidGrid1.Catalogo = tabla;
        }
    }
}
