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

        public int TotalCount => Listitems.Sum(item => item.Count);
        public decimal TotalPrice => Listitems.Sum(item => item.Price * item.Count);

        public Order(int id, IEnumerable<OrderItem> items) 
        {
            if (items == null)
                throw new ArgumentOutOfRangeException(nameof(items));


            Id = id;
            this.Listitems = new List<OrderItem>(items);
        }

        public OrderItem GetItem(int bookId) 
        {
            int index = Listitems.FindIndex(item => item.BookId == bookId);
            if (index == -1)
               ThrowBookException("Книга не найдена", bookId);

            return Listitems[index];
        }

        public bool ContaintsItem(int bookId) 
        {
            return CollectionItems.Any(item => item.BookId == bookId);
        }


        public void AddOrUpdateItem(Book book, int count) 
        {
            if (book == null)
                throw new ArgumentOutOfRangeException(nameof(book));

            var index = Listitems.FindIndex(tempitem => tempitem.BookId == book.ID);

            if (index == -1)
            {
                Listitems.Add(new OrderItem(book.ID, count, book.Price));
            }
            else 
            {
                Listitems[index].Count += count;
            }
        }

       //public void AddBook(Book book) 
       // {
       //     if (book == null)
       //         throw new ArgumentNullException(nameof(book));

       //     AddOrUpdateItem(book, 1);
       // }

       // public void RemoveBook(Book book) 
       // {
       //     if (book == null)
       //         throw new ArgumentNullException(nameof(book));
            
       //     AddOrUpdateItem(book, -1);
       // }


        public void RemoveItem(int bookid) 
        {

            int index = Listitems.FindIndex(item => item.BookId == bookid);

            if (index == -1)
                ThrowBookException("В корзине не такого заказа", bookid);

            Listitems.RemoveAt(index);
        }

        private void ThrowBookException(string msg, int bookId) 
        {
            var errormsg = new InvalidOperationException(msg);

            errormsg.Data["Id"] = bookId;


            throw errormsg;
        }





    }
}
