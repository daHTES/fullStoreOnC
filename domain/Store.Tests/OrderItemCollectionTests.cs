﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Store.Tests
{
   public class OrderItemCollectionTests
    {
        [Fact]
        public void Get_WithExistingItem_ReturnsItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            var orderItem = order.CollectionItems.Get(1);

            Assert.Equal(3, orderItem.Count);
        }

        [Fact]
        public void Get_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.CollectionItems.Get(100);
            });
        }

        [Fact]
        public void Add_WithExistingItem_ThrowInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.CollectionItems.Add(1, 10m, 10);
            });
        }

        [Fact]
        public void Add_WithNewItem_SetsCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            order.CollectionItems.Add(4, 30m, 10);

            Assert.Equal(10, order.CollectionItems.Get(4).Count);
        }

        [Fact]
        public void Remove_WithExistingItem_RemovesItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            order.CollectionItems.Remove(1);

            Assert.Collection(order.CollectionItems,
                              item => Assert.Equal(2, item.BookId));
        }

        [Fact]
        public void Remove_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.CollectionItems.Remove(100);
            });
        }
    }
}

