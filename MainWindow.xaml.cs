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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lr4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<phone> phones;
        phone tempPhone;

        public MainWindow()
        {
            InitializeComponent();
            EndEditing();
            mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
            companyViewInput.ItemsSource = DatabaseControl.GetCompanyForView();
        }

        private bool Check()
        {

            if ((InputTitle.Text == "") || (InputPrice.Text == "") || (companyViewInput.SelectedItem == null))
            {
                MessageBox.Show("Строки не должны быть пустыми", "Пожалуйста будьте внимательнее", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            try
            {
                InputPrice.Text = Convert.ToString(Math.Round(Convert.ToDecimal(InputPrice.Text), 2));
            }
            catch
            {
                MessageBox.Show("Идите в первый класс", "Вы число от цифры не отличаете?", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (InputPrice.Text.Length >= 17)
            {
                MessageBox.Show("Настолько дорого, что это число даже не влизает в базу данных", "Слишком дорого", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!(Convert.ToDecimal(InputPrice.Text) > 0))
            {
                MessageBox.Show("Нельзя продавать бесплано или давать деньги вместе с телефоном!!! Ты на что жить собрался?", "Ты че внатуре дурак что-ли?", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (Check())
            {
                DatabaseControl.AddPhone(new phone
                {
                    title = InputTitle.Text,
                    companyid = (companyViewInput.SelectedItem as company).id,
                    price = Convert.ToDecimal(InputPrice.Text),
                });
                
                mainListBox.ItemsSource = null;
                mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
                InputTitle.Text = String.Empty;
                companyViewInput.Text = String.Empty;
                InputPrice.Text = String.Empty;
            }


        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            //phones.Remove();
            DatabaseControl.DelPhone(mainListBox.SelectedItem as phone);
            mainListBox.ItemsSource = null;
            mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
            InputTitle.Text = String.Empty;
            companyViewInput.Text = String.Empty;
            InputPrice.Text = String.Empty;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            tempPhone = mainListBox.SelectedItem as phone;
            if (tempPhone != null)
            {
                InputTitle.Text = tempPhone.title;
                companyViewInput.SelectedIndex = tempPhone.companyid - 1;
                InputPrice.Text = tempPhone.price.ToString();

                mainListBox.IsEnabled = false;
                addButton.IsEnabled = false;
                DelButton.IsEnabled = false;
                editButton.IsEnabled = false;

                saveEditButtonView.Visibility = Visibility.Visible;
                cancelEditButtonView.Visibility = Visibility.Visible;
            }


        }
        private void EndEditing()
        {
            InputTitle.Text = String.Empty;
            companyViewInput.Text = String.Empty;
            InputPrice.Text = String.Empty;

            mainListBox.IsEnabled = true;
            addButton.IsEnabled = true;
            DelButton.IsEnabled = true;
            editButton.IsEnabled = true;

            saveEditButtonView.Visibility = Visibility.Hidden;
            cancelEditButtonView.Visibility = Visibility.Hidden;
        }

        private void saveEditButtonView_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                tempPhone.companyid = (companyViewInput.SelectedItem as company).id;
                tempPhone.title = InputTitle.Text;
                tempPhone.price = Convert.ToDecimal(InputPrice.Text);
                DatabaseControl.UpdatePhone(tempPhone);


                mainListBox.ItemsSource = null;
                mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
                InputTitle.Text = String.Empty;
                companyViewInput.Text = String.Empty;
                InputPrice.Text = String.Empty;
            }

            EndEditing();
        }

        private void cancelEditButtonView_Click(object sender, RoutedEventArgs e)
        {
            EndEditing();
        }
    }
}
