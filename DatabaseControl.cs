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
        public static List<phone> GetPhonesForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.phone.Include(p => p.CompanyEntity).ToList();
            }
        }

        public static List<company> GetCompanyForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.company.Include(p => p.PhoneEntites).ToList();
            }
        }

        public static void AddPhone(phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.phone.Add(phone);
                ctx.SaveChanges();
            }
        }
        public static void DelPhone(phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.phone.Remove(phone);
                ctx.SaveChanges();
            }
        }

        public static void UpdatePhone(phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                phone _phone = ctx.phone.FirstOrDefault(p => p.id == phone.id);

                if (_phone == null)
                {
                    return;
                }

                _phone.title = phone.title;
                _phone.price = phone.price;
                _phone.companyid = phone.companyid;

                ctx.SaveChanges();
            }
        }
    }
}
