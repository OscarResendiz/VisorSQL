using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.AdministrarConexiones
{
    public partial class FileConecction : Component
    {
        public string Nombre;
        public string Servidor;
        public string Usuario;
        public string Password;
        public bool SalvePassword;
        public bool  WindowsAutentication;
        public string Base;
        public string Motor;
        public FileConecction()
        {
            InitializeComponent();
        }

        public FileConecction(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void WriteFile(string directorio)
        {
            System.Data.DataRow dr = dataSet1.Tables["Conexion"].NewRow();
            dr["Nombre"] = Nombre;
            dr["Servidor"] = Servidor;
            dr["Usuario"] = Usuario;
            dr["Password"] = Password;
            dr["Base"] = Base;
            dr["Motor"] = Motor;
            dr["SalvePassword"] = SalvePassword;
            dr["WindowsAutentication"] = WindowsAutentication;            
            dataSet1.Tables["Conexion"].Rows.Add(dr);
            string filename = directorio + "\\" + Nombre ;
            dataSet1.WriteXml(filename);
        }
        public void LoadFile(string directorio)
        {
            string filename = directorio + "\\" + Nombre;
            dataSet1.ReadXml(filename);
            Nombre = dataSet1.Tables["Conexion"].Rows[0]["Nombre"].ToString();
            Servidor = dataSet1.Tables["Conexion"].Rows[0]["Servidor"].ToString();
            Usuario = dataSet1.Tables["Conexion"].Rows[0]["Usuario"].ToString();
            Password = dataSet1.Tables["Conexion"].Rows[0]["Password"].ToString();
            Base = dataSet1.Tables["Conexion"].Rows[0]["Base"].ToString();
            Motor = dataSet1.Tables["Conexion"].Rows[0]["Motor"].ToString();
            SalvePassword =bool.Parse( dataSet1.Tables["Conexion"].Rows[0]["SalvePassword"].ToString());
            WindowsAutentication = bool.Parse(dataSet1.Tables["Conexion"].Rows[0]["WindowsAutentication"].ToString());
        }
    }
}
