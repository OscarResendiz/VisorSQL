using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2008.Reportes
{
    public partial class FormReporteTabla : Form
    {
        string Nombre;
        Controladores_DB.IDataBase DB;

        public FormReporteTabla(Controladores_DB.IDataBase db, string nombre)
        {
            Nombre = nombre;
            DB = db;
            InitializeComponent();
        }

        private void FormReporteTabla_Load(object sender, EventArgs e)
        {
            // Ejecuta la consulta a la base dados
            sqlDataAdapter1.SelectCommand.Connection = new System.Data.SqlClient.SqlConnection(DB.ConnectionString);
            sqlDataAdapter1.SelectCommand.CommandText = Comando;
            sqlDataAdapter1.Fill(dataSet11);
            // Crea el reporte
            ReporteTabla rp = new ReporteTabla();
            // Asocia el conjunto de datos con el reporte
//            rp.SetDataSource(dataSet11);
            // Asocia el reporte con el Visualizador
//            crystalReportViewer1.ReportSource = rp;

        }
        private string Comando
        {
            get
            {
                string s = "declare @nombre varchar(100)\n";
                s = s + "declare @comentarioTabla varchar(500)\n";
                s = s + "select @nombre =\'" + Nombre + "\'";
                s = s + "declare @id int\n";
                s = s + "--obtengo el ID de la tabla\n";
                s = s + "select @id =id from sysobjects where name=@nombre\n";
                s = s + "---obtengo el comentario de la tabla\n";
                s = s + "select @comentarioTabla =convert(varchar(500),value) from sys.extended_properties where major_id=@id and minor_id=0\n";
                s = s + "if @comentarioTabla is null\n";
                s = s + "\tselect @comentarioTabla=\'\'\n";
                s = s + "select \n";
                s = s + "\t@nombre as tabla,\n";
                s = s + "\t@comentarioTabla as Descripcion,\n";
                s = s + "\tc.name as campo,\n";
                s = s + "\tt.name as Tipo,\n";
                s = s + "\tcase t.name when 'varchar' then convert(varchar(5),t.length) when 'char' then convert(varchar(5),t.length) when 'nchar' then convert(varchar(5),t.length) else '' end as tamaño,\n";
                s = s + "\ta.value as comentario\n";
                s = s + "from\n";
                s = s + "\tsys.extended_properties a,\n";
                s = s + "\tsyscolumns c,\n";
                s = s + "\tsystypes t\n";
                s = s + "where \n";
                s = s + "\ta.major_id=@id \n";
                s = s + "\tand c.id=@id\n";
                s = s + "\tand c.colid*=a.minor_id\n";
                s = s + "\tand t.xtype=c.xtype\n";
                s = s + "order by\n";
                s = s + "\tminor_id\n";
                return s;
            }
        }
    }
}