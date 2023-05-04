using System;
using System.Collections.Generic;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace Lr4
{
    /// <summary>
    /// Логика взаимодействия для detail.xaml
    /// </summary>
    public partial class detail : Page
    {
        public detail(Phone _phone)
        {
            InitializeComponent();
            titlePageView.Text = _phone.Title;
            definitionPageView.Text = _phone.Definition;
            companyPageView.Text = _phone.CompanyEntity.Title;
            pricePageView.Text = _phone.Price.ToString();

            try {
                imagePageView.Source = new BitmapImage(new Uri(_phone.Image));
            } catch {
                imagePageView.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Image\\No_image.png"));
            }


        }

        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            FrameContex.MainWindowFrame.Navigate(null);
        }

    }
}
