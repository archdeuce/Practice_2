using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
    
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
