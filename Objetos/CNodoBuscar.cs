using System;
using System.Collections.Generic;
using System.Text;

namespace Visor_sql_2015.Objetos
{
    class CNodoBuscar: System.Windows.Forms.TreeNode
    {
        Visor_sql_2015.Controladores_DB.TIPOOBJETO ftipo;
        public Visor_sql_2015.Controladores_DB.TIPOOBJETO Tipo
        {
            get
            {
                return ftipo;
            }
            set
            {
                ftipo = value;
                switch (ftipo)
                {
                    case Visor_sql_2015.Controladores_DB.TIPOOBJETO.NINGUNO:
                        this.ImageIndex = 0;
                        break;
                    case Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLAX:
                        this.ImageIndex = 1;
                        break;
                    case Visor_sql_2015.Controladores_DB.TIPOOBJETO.VISTA:
                        this.ImageIndex = 2;
                        break;
                    case Visor_sql_2015.Controladores_DB.TIPOOBJETO.STOREPROCERURE:
                        this.ImageIndex = 3;
                        break;
                    case Visor_sql_2015.Controladores_DB.TIPOOBJETO.TRIGER:
                        this.ImageIndex = 4;
                        break;
                    case Visor_sql_2015.Controladores_DB.TIPOOBJETO.FOREINGKEY:
                        this.ImageIndex = 5;
                        break;
                    case Visor_sql_2015.Controladores_DB.TIPOOBJETO.PRIMARYKEY:
                        this.ImageIndex = 6;
                        break;
                    case Visor_sql_2015.Controladores_DB.TIPOOBJETO.TABLASYSTEMA:
                        this.ImageIndex = 7;
                        break;
                }
                SelectedImageIndex = ImageIndex;
            }
        }
    }
}
