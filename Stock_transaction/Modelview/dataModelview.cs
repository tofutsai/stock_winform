using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_transaction.Modelview
{
    class dataModelview
    {
        public class stockData
        {
            public string stat { get; set; }
            public string date { get; set; }
            public string title { get; set; }
            public List<string> fields9 { get; set; }
            public List<List<string>> data9 { get; set; }
            public List<string> notes { get; set; }
        }


    }
    
}
