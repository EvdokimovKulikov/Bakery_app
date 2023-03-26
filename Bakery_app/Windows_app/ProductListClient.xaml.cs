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
    /// Логика взаимодействия для ProductListClient.xaml
    /// </summary>
    public partial class ProductListClient : Window
    {
        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = ContextDB.Product.ToList();


            products = products.Where(i => i.ProdName.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            // поиск, сортировка, фильтрация

            var selectedIndexCmb = CmbSort.SelectedIndex;

            switch (selectedIndexCmb)
            {
                case 0:
                    products = products.OrderBy(i => i.IdProd).ToList();
                    break;

                case 1:
                    products = products.OrderBy(i => i.ProdName.ToLower()).ToList();
                    break;

                case 2:
                    products = products.OrderByDescending(i => i.ProdName.ToLower()).ToList();
                    break;

                default:
                    break;
            }


            LvProduct.ItemsSource = products;
        }
        public ProductListClient()
        {
            InitializeComponent();
            GetListProduct();
            //LvCartProduct.ItemsSource = observableCollectionProduct;
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;

            EditProductList editProductWindow = new EditProductList(product);
            editProductWindow.ShowDialog();

            GetListProduct();

        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProductList editProductList = new EditProductList();
            editProductList.ShowDialog();
            GetListProduct();

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListProduct();

        }

        private void LvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListProduct();
        }

        private void BtnDeletProduct_Click(object sender, RoutedEventArgs e)
        {
            //    var button = sender as Button;
            //    if (button == null)
            //    {
            //        return;
            //    }

            //    var product = button.DataContext as Product;

            //    if (product != null)
            //    {
            //        observableCollectionProduct.Remove(product);

            //        LvCartProduct.ItemsSource = observableCollectionProduct;

            //        MessageBox.Show(product.ProdName + " Delete");
            //    }
            MessageBox.Show("В разработке");
        }

        private void BtnBasket_Click(object sender, RoutedEventArgs e)
        {
            BasketList basketList = new BasketList();
            basketList.Show();
            this.Close();

            
        }

        private void BtnBasketProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
