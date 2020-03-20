using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.AdministrarConexiones
{
    //clase que se encarga de administrar las conexiones de la bases de datos
    //dependiendo del motor revisa cual le corresponde. crea el objeto y lo regresa
    public class CInstanciadorDB
    {
        
        public Controladores_DB.IDataBase DameInstancia(string Directorio, string Nombre)
        {
            //cargo el archivo de la base de datos que me estan pidiendo
            Controladores_DB.IDataBase DB = null;
            FileConecction fc = new FileConecction();
            fc.Nombre = Nombre;
            fc.LoadFile(Directorio);
            //veo el motor de la base de datos que hay que instanciar
            switch (fc.Motor)
            {
                case "SQL Server":
                    DB=new Controladores_DB.MSSQLServer();
                    break;
                case "MySQL":
                    DB=new Controladores_DB.MySqlServer();
                    break;
            }
            DB.CargaConexion(fc);
            return DB;
        }
    }
}
