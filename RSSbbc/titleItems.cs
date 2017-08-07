using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSbbc
{
    class titleItems
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public IList<Items> items { get; set; }
    }
}
