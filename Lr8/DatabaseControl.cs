using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public static class DatabaseControl
    {
        public static List<Phone> GetPhonesForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Phone.Include(p => p.CompanyEntity).ToList();
            }
        }

        public static List<Company> GetCompanyForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Company.Include(p => p.PhoneEntites).ToList();
            }
        }

        public static void AddPhone(Phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Phone.Add(phone);
                ctx.SaveChanges();
            }
        }
        public static void DelPhone(Phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Phone.Remove(phone);
                ctx.SaveChanges();
            }
        }

        public static void UpdatePhone(Phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                Phone _phone = ctx.Phone.FirstOrDefault(p => p.Id == phone.Id);

                if (_phone == null)
                {
                    return;
                }

                _phone.Title = phone.Title;
                _phone.Price = phone.Price;
                _phone.CompanyId = phone.CompanyId;

                ctx.SaveChanges();
            }
        }
    }
}
