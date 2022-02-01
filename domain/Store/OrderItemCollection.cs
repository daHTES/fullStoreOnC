using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderItemCollection: IReadOnlyCollection<OrderItem>
    {
        private readonly List<OrderItem> items;


        public OrderItemCollection(IEnumerable<OrderItem> items) 
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            this.items = new List<OrderItem>(items);
        }

        public int Count => items.Count;

        public bool TryGet(int bookId, out OrderItem orderitem) 
        {
            var index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1) 
            {
                orderitem = null;
                return false;
            }
            orderitem = items[index];
            return true;
        }

        public OrderItem Get(int bookId) 
        {
            if (TryGet(bookId, out OrderItem orderitem))
                return orderitem;

            throw new InvalidOperationException("КНига не найдена.");
        }

        public OrderItem Add(int bookId, decimal bookPrice, int count) 
        {
            if (TryGet(bookId, out OrderItem orderitem))
                throw new InvalidOperationException("Книга уже есть такая");
            orderitem = new OrderItem(bookId, bookPrice, count);
            items.Add(orderitem);
            return orderitem;
        }

        public void Remove(int bookId) 
        {
            items.Remove(Get(bookId));
        }


        public IEnumerator<OrderItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (items as IEnumerable).GetEnumerator();
        }
    }
}
