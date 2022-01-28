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

        private List<OrderItem> Listitems;

        public IReadOnlyCollection<OrderItem> CollectionItems 
        {
            get { return Listitems; }
        }

        public int TotalCount 
        {
            get { return Listitems.Sum(item => item.Count); }
        }


        public decimal TotalPrice 
        {
            get { return Listitems.Sum(item => item.Price * item.Count); }
        }

        public Order(int id, IEnumerable<OrderItem> items) 
        {
            if (items == null)
                throw new ArgumentOutOfRangeException(nameof(items));


            Id = id;
            this.Listitems = new List<OrderItem>(items);
        }

        public void AddItem(Book book, int count) 
        {
            if (book == null)
                throw new ArgumentOutOfRangeException(nameof(book));

            var item = Listitems.SingleOrDefault(tempitem => tempitem.BookId == book.ID);

            if (item == null)
            {
                Listitems.Add(new OrderItem(book.ID, count, book.Price));
            }
            else 
            {
                Listitems.Remove(item);
                Listitems.Add(new OrderItem(book.ID, item.Count + count, book.Price));

            }

        }


    }
}
