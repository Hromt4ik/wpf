using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lr4
{
    internal class Check
    {
        static public bool CheckEmpty(object CompanyId, decimal Price, string Title)
        {
            if ((Title == "") || (Price == 0) || (CompanyId == null))
            {
                MessageBox.Show("Строки не должны быть пустыми", "Пожалуйста будьте внимательнее", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        static public bool check(Phone _tempPhone)
        {


            string price = Convert.ToString(_tempPhone.Price);

            try
            {

                price = Convert.ToString(Math.Round(Convert.ToDecimal(price), 2));
            }
            catch
            {
                MessageBox.Show("Идите в первый класс", "Вы число от цифры не отличаете?", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            if (price.Length >= 17)
            {
                MessageBox.Show("Настолько дорого, что это число даже не влизает в базу данных", "Слишком дорого", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!(Convert.ToDecimal(price) > 0))
            {
                MessageBox.Show("Нельзя продавать бесплано или давать деньги вместе с телефоном!!! Ты на что жить собрался?", "Ты че внатуре дурак что-ли?", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}