using CoreLibarary.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Kusinskiy_Timophey
{
    /// <summary>
    /// Логика взаимодействия для info.xaml
    /// </summary>
    public partial class info : Window
    {
        private Dish dish;
        public info(Dish list)
        {
            InitializeComponent();
            dish = list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var stream = new MemoryStream(dish.image);
                var bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = stream;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                imageOfProduct.Source = bitmapimage;

                txtName.Text = dish.ProductName;
                txtDescription.Text = dish.Description;
                txtCost.Text = Convert.ToString(dish.Cost) + " Руб";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't view information: '{ex.Message}'", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
