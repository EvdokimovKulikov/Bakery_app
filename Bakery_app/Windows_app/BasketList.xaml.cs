using Bakery_app.ClassHelper;
using Bakery_app.DB;
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
using static Bakery_app.ClassHelper.EFClass;

namespace Bakery_app.Windows_app
{
    /// <summary>
    /// Логика взаимодействия для BasketList.xaml
    /// </summary>
    public partial class BasketList : Window
    {
        public BasketList()
        {
            InitializeComponent();
            LvCartProduct.ItemsSource = CartProduct.products;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ProductListClient productListClient = new ProductListClient();
            productListClient.Show();
            this.Close();
        }

        private void BtnBuyProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var product = button.DataContext as Product;



            if (product != null)
            {
                CartProduct.products.Remove(product);

                LvCartProduct.ItemsSource = CartProduct.products;

                MessageBox.Show(product.ProdName + " Delete");
            }
          LvCartProduct.ItemsSource = CartProduct.products;

        }

        private void LvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }
    }
}
