using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lr4
{
    /// <summary>
    /// Логика взаимодействия для EditWinhdow.xaml
    /// </summary>
    public partial class EditWinhdow : Window
    {
        Phone _tempPhone = new Phone();
        public EditWinhdow(Phone phone)
        {
            InitializeComponent();
            _tempPhone = phone;
            companyView.ItemsSource = DatabaseControl.GetCompanyForView();
            titleView.Text = phone.Title;
            companyView.SelectedValue = phone.CompanyEntity.Id;
            priceView.Text = phone.Price.ToString();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Check.CheckEmpty(companyView.SelectedValue, Convert.ToDecimal(priceView.Text), titleView.Text))
                {
                    _tempPhone.Title = titleView.Text;
                    _tempPhone.CompanyId = (int)companyView.SelectedValue;
                    _tempPhone.Price = Convert.ToDecimal(priceView.Text);
                    if (Check.check(_tempPhone))
                    {
                        DatabaseControl.UpdatePhone(_tempPhone);
                        (this.Owner as MainWindow).RefreshTable();
                        this.Close();
                    }
                }
            }


            catch
            {
                MessageBox.Show("Неверный формат дынных", "Ошибка при вводе", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }
    }
}
