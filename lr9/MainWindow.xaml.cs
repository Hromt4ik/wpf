using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
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
            FrameContex.MainWindowFrame = mainFrame;

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
            if (p != null)
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

            File.Delete((mainDataGridView.SelectedItem as Phone).Image);
            DatabaseControl.DelPhone(mainDataGridView.SelectedItem as Phone);

            mainDataGridView.ItemsSource = null;
            mainDataGridView.ItemsSource = DatabaseControl.GetPhonesForView();
        }

        public void RefreshTable()
        {
            mainDataGridView.ItemsSource = null;
            mainDataGridView.ItemsSource = DatabaseControl.GetPhonesForView();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Phone phone = mainDataGridView.SelectedItem as Phone;
            if (phone != null)
            {
                FrameContex.MainWindowFrame.Navigate(new detail(phone));
            }

        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Phone phone = mainDataGridView.SelectedItem as Phone;
            if (phone != null)
            {
                FrameContex.MainWindowFrame.Navigate(new detail(phone));
            }
        }
    }
    public static class FrameContex
    {

        public static Frame MainWindowFrame { get; set; }

    }
}