using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bakery_app.ClassHelper.EFClass;
using Bakery_app.DB;
using System.Collections.ObjectModel;

namespace Bakery_app.ClassHelper
{
    internal class CartProduct
    {
        public static List<Product> products = new List<Product>();
        public static ObservableCollection<Product> observableCollectionProduct = new ObservableCollection<Product>(ClassHelper.CartProduct.products);

    }
}
