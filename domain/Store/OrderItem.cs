﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderItem
    {
        public int BookId { get; }

        private int count;

        public int Count 
        {
            get { return count; }
            set 
            {
                ValidateCount(value);

                count = value;
            }
        }

        public decimal Price { get; }

        public OrderItem(int bookId, int count, decimal price) 
        {
            ValidateCount(count);
            BookId = bookId;
            Count = count;
            Price = price;
        }

        private static void ValidateCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Количество не может быть меньше нуля!");
        }
    }
}
