using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visor_sql_2015.Editor
{
    public class CErrorQuery
    {
        public string msg;
        public int LineNumber;
        public override string ToString()
        {
            return msg;
        }
        public CErrorQuery()
        {
            LineNumber = 0;
        }
    }
}
