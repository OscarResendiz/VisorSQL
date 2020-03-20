using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using System.Data;

namespace Visor_sql_2008
{
    public interface IDataBase
    {
        string ConnectionString { get; set; }
        bool Busy { get; }
        bool FullyLoaded { get; }
        DateTime LoadTime
        {
            get;
            set;
        }

        void Initialize();
        void Refresh();
        void FullInitialize();

        System.Data.SqlClient.SqlConnection Conexion { get; }

        //List<IDataBaseChild> Tables {get; set;}
        //List<IDataBaseChild> Views { get; set; }
        //List<IDataBaseChild> Sps { get; set; }

        //List<IDataBaseChild> FilterByType(FilteringTypeValues Type);

        //void LoadChilds(IConector Conector);
    }
}
