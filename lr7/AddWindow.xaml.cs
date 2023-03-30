using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            companyView.ItemsSource = DatabaseControl.GetCompanyForView();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Phone _tempPhone = new Phone();

            try
            {
                if (Check.CheckEmpty(companyView.SelectedValue, Convert.ToDecimal(priceView.Text), titleView.Text))
                {
                    _tempPhone.Title = titleView.Text;
                    _tempPhone.CompanyId = (int)companyView.SelectedValue;
                    _tempPhone.Price = Convert.ToDecimal(priceView.Text);
                }

                if (Check.check(_tempPhone))
                {
                    DatabaseControl.AddPhone(new Phone
                    {
                        Title = titleView.Text,
                        CompanyId = (int)companyView.SelectedValue,
                        Price = Convert.ToDecimal(priceView.Text)
                    });

                    (this.Owner as MainWindow).RefreshTable();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Неверный формат дынных", "Ошибка при вводе", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}