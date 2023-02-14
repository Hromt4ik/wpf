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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lr4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Phone> phones;

        public MainWindow()
        {
            phones = new List<Phone>
            {
                new Phone { Company = "Apple", Title = "iPhone 10", Price = 58000},
                new Phone { Company = "Xiaomi", Title = "Redmi Note 10S", Price = 28000},
                new Phone { Company = "Apple", Title = "iPhone 12 Pro Max Super Idol", Price = 158000},
                new Phone { Company = "Nokia", Title = "3310", Price = 800},

            };

            InitializeComponent();

            mainListBox.ItemsSource = phones;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if ((InputCompany.Text == "") || (InputTitle.Text == "") || (InputPrice.Text == ""))
            {
                MessageBox.Show("Строки не должны быть пустыми", "Ты че дурак?", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                Convert.ToDecimal(InputPrice.Text);
            }
            catch
            {
                MessageBox.Show("Иди в первый клас", "Ты число от цифры не отличаешь?", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!(Convert.ToDecimal(InputPrice.Text) > 0))
            {
                MessageBox.Show("Нельзя продавать бесплано или давать деньги вместе с телефоном!!! Ты на что жить собрался?", "Ты че внатуре дурак что-ли?", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            phones.Add(new Phone
            {
                Company = InputCompany.Text,
                Title = InputTitle.Text,
                Price = Convert.ToDecimal(InputPrice.Text),
            });



            mainListBox.ItemsSource = null;
            mainListBox.ItemsSource = phones;
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            phones.Remove(mainListBox.SelectedItem as Phone);
            mainListBox.ItemsSource = null;
            mainListBox.ItemsSource = phones;
        }
    }
}
