﻿using Bakery_app.DB;
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
    
    public partial class ProductList : Window
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
        public ProductList()
        {
            InitializeComponent();
            GetListProduct();
            
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

        private void BtnExitProduct_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnOptionAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminPanelWindow adminPanel = new AdminPanelWindow();       
            adminPanel.Show();
            this.Close();

        }
    }
}
