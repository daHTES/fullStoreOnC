using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
   public class Order
    {
        public int Id { get; }

        //private List<OrderItem> Listitems;

        public OrderItemCollection CollectionItems { get; }

        public string CellPhone { get; set; }

        public OrderDelivery Delivery { get; set; }

        public OrderPayment Payment { get; set; }

        //syntax sugar on C#
        public int TotalCount => CollectionItems.Sum(item => item.Count);

        public decimal TotalPrice => CollectionItems.Sum(item => item.Price * item.Count) 
            + (Delivery?.Amount ?? 0m);

        public Order(int id, IEnumerable<OrderItem> items)
        {
            Id = id;
            CollectionItems = new OrderItemCollection(items);

        }
            public bool ContaintsItem(int bookId) 
        {
            return CollectionItems.Any(item => item.BookId == bookId);
        }

    }
}
