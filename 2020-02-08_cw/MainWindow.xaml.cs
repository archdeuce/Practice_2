using _2020_02_08_cw.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2020_02_08_cw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            using (var context = new zzaContext())
            {
                //var product = context.Product.Find(15);
                //product.Name = "testProduct";
                //context.SaveChanges();

                //var newProduct = new Product()
                //{
                //    Name = "myPizza",
                //    Type = "myType"
                //};

                //context.Add(newProduct);

                var newProduct2 = context.Product.Find(0);

                newProduct2.Name = "myPizza2";

                context.Update(newProduct2);
                context.SaveChanges();
            }
        }
    }
}
