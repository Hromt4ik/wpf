using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EditWinhdow.xaml
    /// </summary>
    public partial class EditWinhdow : Window
    {

        private const string _imageSourse = "O:\\колледж\\wpf\\lr9\\Lr4\\added_image";

        private OpenFileDialog _img;

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

            _tempPhone.Title = titleView.Text;
            _tempPhone.CompanyId = (int)companyView.SelectedValue;
            _tempPhone.Price = Convert.ToDecimal(priceView.Text);

            //hm... were there progremmer who went out  window, after coding???????
            File.Delete(_tempPhone.Image);
            _tempPhone.Image = System.IO.Path.Combine(_imageSourse, _img.SafeFileName);
            File.Copy(_img.FileName, _tempPhone.Image, true);

            //I delete somthing check because i has a lot of bugs f*** in this row:) 
            DatabaseControl.UpdatePhone(_tempPhone);
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
