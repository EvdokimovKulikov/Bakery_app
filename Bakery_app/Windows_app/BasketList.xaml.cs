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
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ProductListClient productListClient = new ProductListClient();
            productListClient.Show();
        }

        private void BtnBuyProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
