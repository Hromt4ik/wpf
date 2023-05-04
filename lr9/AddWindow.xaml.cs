using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Lr4
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private string _imageSourse = Environment.CurrentDirectory + "\\added_image";

        private OpenFileDialog _img;

        public AddWindow()
        {
            InitializeComponent();
            companyView.ItemsSource = DatabaseControl.GetCompanyForView();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath;

            if (_img != null)
            {
                filePath = System.IO.Path.Combine(_imageSourse, _img.SafeFileName);
                File.Copy(_img.FileName, filePath, true);
            }else{
                filePath = "../Image/No_image.png";
            }


            DatabaseControl.AddPhone(new Phone
            {
                Title = titleView.Text,
                CompanyId = (int)companyView.SelectedValue,
                Price = Convert.ToDecimal(priceView.Text),
                Image = filePath,
                Definition = definitionBox.Text,
            });

            (this.Owner as MainWindow).RefreshTable();
            this.Close();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.jpg, *.png)|*.jpg;*.png;*.JPG;*.PNG;";
            if (openFileDialog.ShowDialog() == true)
            {
                _img = openFileDialog;
            }
        }

    }
}