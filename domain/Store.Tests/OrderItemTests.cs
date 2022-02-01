using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    public class OrderItemTests
    {

        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                new OrderItem(1, 0m, count);
            });
        }

        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentOutOfRangeException() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
           {
               int count = -1;
               new OrderItem(1, 0m, count);
           });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_SetsCount() 
        {
            var orderItem = new OrderItem(1, 3m, 2);

            Assert.Equal(1, orderItem.BookId);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(3, orderItem.Price);
        }




    }   
}
