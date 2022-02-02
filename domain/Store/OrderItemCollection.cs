using Store.Data;
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
        private readonly OrderDto orderDto;
        private readonly List<OrderItem> items;

        public OrderItemCollection(OrderDto orderDto) 
        {
            if (orderDto == null)
                throw new ArgumentNullException(nameof(orderDto));
            this.orderDto = orderDto;

            items = orderDto.Items.Select(OrderItem.Mapper.Map).ToList();
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
            if (TryGet(bookId, out OrderItem orderItem))
                throw new InvalidOperationException("Книга уже есть в корзине");

            var orderItemDto = OrderItem.DtoFactory.Create(orderDto, bookId, bookPrice, count);
            orderDto.Items.Add(orderItemDto);

            orderItem = OrderItem.Mapper.Map(orderItemDto);
            items.Add(orderItem);

            return orderItem;
        }

        public void Remove(int bookId) 
        {
            var index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
                throw new InvalidOperationException("Не найдена такая книга");

            orderDto.Items.RemoveAt(index);
            items.RemoveAt(index);
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
