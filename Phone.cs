using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public class phone
    {
        public int id { get; set; }
        public string title { get; set; }
        public int companyid { get; set; }
        public decimal price { get; set; }

        public company CompanyEntity { get; set; }
    }
}
