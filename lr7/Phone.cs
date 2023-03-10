using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public class Phone
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CompanyId { get; set; }
        public decimal Price { get; set; }

        public Company CompanyEntity { get; set; }
    }
}
