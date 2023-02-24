using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public class company
    {
        public int id { get; set; }
        public string title { get; set; }
        public string ceo { get; set; }
        public double capital { get; set; }

        public List<phone> PhoneEntites { get; set; }
    }
}
