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
        public string Definition { get; set; } = "Круто";
        public string Image { get; set; } = "C:\\Users\\student\\Downloads\\Lr6\\Lr4\\Lr4\\Image\\no_image.png";
        public Company CompanyEntity { get; set; }
    }
}
