using Bakery_app.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = ContextDB.Product.ToList();


            products = products.Where(i => i.ProdName.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            // поиск, сортировка, фильтрация

            LvProduct.ItemsSource = products;
        }
        public ProductList()
        {
            InitializeComponent();
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProductList editProductList = new EditProductList();
            editProductList.Show(); 
            
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProductList editProductList = new EditProductList();
            editProductList.ShowDialog();

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListProduct();
        }
    }
}
