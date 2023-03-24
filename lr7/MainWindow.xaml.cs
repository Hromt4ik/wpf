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
 
        //Phone tempPhone;

        public MainWindow()
        {
            InitializeComponent();
            mainDataGridView.ItemsSource = DatabaseControl.GetPhonesForView();
            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow win = new AddWindow();
            win.Owner = this;
            win.ShowDialog();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Phone p = mainDataGridView.SelectedItem as Phone;
            if(p != null)
            {
                EditWinhdow win = new EditWinhdow(p);
                win.Owner = this;
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseControl.DelPhone(mainDataGridView.SelectedItem as Phone);
            mainDataGridView.ItemsSource = null;
            mainDataGridView.ItemsSource = DatabaseControl.GetPhonesForView();
        }

        public void RefreshTable()
        {
            mainDataGridView.ItemsSource = null;
            mainDataGridView.ItemsSource = DatabaseControl.GetPhonesForView();
        }

        

        //private void AddButton_Click(object sender, RoutedEventArgs e)
        //{

        //    if (Check())
        //    {
        //        DatabaseControl.AddPhone(new Phone
        //        {
        //            Title = InputTitle.Text,
        //            CompanyId = (companyViewInput.SelectedItem as Company).Id,
        //            Price = Convert.ToDecimal(InputPrice.Text),
        //        });

        //        mainListBox.ItemsSource = null;
        //        mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
        //        InputTitle.Text = String.Empty;
        //        companyViewInput.Text = String.Empty;
        //        InputPrice.Text = String.Empty;
        //    }


        //}

        //private void DelButton_Click(object sender, RoutedEventArgs e)
        //{

        //    DatabaseControl.DelPhone(mainListBox.SelectedItem as Phone);
        //    mainListBox.ItemsSource = null;
        //    mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
        //    InputTitle.Text = String.Empty;
        //    companyViewInput.Text = String.Empty;
        //    InputPrice.Text = String.Empty;
        //}

        //private void editButton_Click(object sender, RoutedEventArgs e)
        //{
        //    tempPhone = mainListBox.SelectedItem as Phone;
        //    if (tempPhone != null)
        //    {
        //        InputTitle.Text = tempPhone.Title;
        //        companyViewInput.SelectedIndex = tempPhone.CompanyId - 1;
        //        InputPrice.Text = tempPhone.Price.ToString();

        //        mainListBox.IsEnabled = false;
        //        addButton.IsEnabled = false;
        //        DelButton.IsEnabled = false;
        //        editButton.IsEnabled = false;

        //        saveEditButtonView.Visibility = Visibility.Visible;
        //        cancelEditButtonView.Visibility = Visibility.Visible;
        //    }


        //}
        //private void EndEditing()
        //{
        //    InputTitle.Text = String.Empty;
        //    companyViewInput.Text = String.Empty;
        //    InputPrice.Text = String.Empty;

        //    mainListBox.IsEnabled = true;
        //    addButton.IsEnabled = true;
        //    DelButton.IsEnabled = true;
        //    editButton.IsEnabled = true;

        //    saveEditButtonView.Visibility = Visibility.Hidden;
        //    cancelEditButtonView.Visibility = Visibility.Hidden;
        //}

        //private void saveEditButtonView_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Check())
        //    {
        //        tempPhone.CompanyId = (companyViewInput.SelectedItem as Company).Id;
        //        tempPhone.Title = InputTitle.Text;
        //        tempPhone.Price = Convert.ToDecimal(InputPrice.Text);
        //        DatabaseControl.UpdatePhone(tempPhone);


        //        mainListBox.ItemsSource = null;
        //        mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
        //        InputTitle.Text = String.Empty;
        //        companyViewInput.Text = String.Empty;
        //        InputPrice.Text = String.Empty;
        //    }

        //    EndEditing();
        //}

        //private void cancelEditButtonView_Click(object sender, RoutedEventArgs e)
        //{
        //    EndEditing();
        //}
    }
}
