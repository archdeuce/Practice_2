using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Task_2.Models;

namespace Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.EagerLoading();
            this.LazyLoading();
            //this.ExplicitLoading();
        }

        public void EagerLoading()
        {
            using (var context = new zzaContext())
            {
                //1. Include
                var a = context.Customer.Where(c => c.FirstName == "Dorian")
                        .Include(c => c.Order)
                        .FirstOrDefault();

                //2. ThenInclude
                var b = context.Customer.Include(c => c.Order)
                  .ThenInclude(o => o.OrderItem)
                  .FirstOrDefault();
            }
        }

        public void LazyLoading()
        {
            //2) Select anonymous class with property specifying
            //    - Lazy loading


            using (var context = new zzaContext())
            {
                var stud = context.Customer.Where(s => s.FirstName == "Russell")
                            .Select(c => new
                            {
                                Customer = c,
                                Order = c.Order
                            })
                            .FirstOrDefault();
            }
        }

        public void ExplicitLoading()
        {
            //2) Select anonymous class with property specifying
            //    - Explicit loading

            using (var context = new zzaContext())
            {
                Customer customer = context.Customer.FirstOrDefault();
                context.Entry(customer).Collection(c => c.Order).Load();
            }
        }
    }
}
