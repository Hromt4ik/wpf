using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CEO { get; set; }
        public double Capital { get; set; }

        public List<Phone> PhoneEntites { get; set; }
    }
}
