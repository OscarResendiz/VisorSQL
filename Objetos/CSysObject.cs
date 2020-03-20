using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using System.Windows.Forms;


namespace Visor_sql_2015.Objetos
{
    public class CSysObject 
    {
        #region Datos Originales
        public string Nombre;
        public Controladores_DB.TIPOOBJETO TipoObjeto;
        public override string ToString()
        {
            return Nombre;
        }
        #endregion

    }
}
