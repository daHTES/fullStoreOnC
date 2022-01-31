using System;
using System.Collections.Generic;

namespace Store
{
    public class OrderDelivery
    {
        public string UniqueCode { get; }

        public string Description { get; }

        public decimal Amount { get; }

        public IReadOnlyDictionary<string, string> Parameters { get; }

        public OrderDelivery(
            string uniquecode, 
            string description, 
            decimal amount,
            IReadOnlyDictionary<string, string> parameters) 
        {
            if (string.IsNullOrWhiteSpace(uniquecode))
                throw new ArgumentException(nameof(description));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(nameof(description));

            if (parameters == null)
                throw new ArgumentException(nameof(parameters));

            UniqueCode = uniquecode;
            Description = description;
            Parameters = parameters;
            Amount = amount;
        }
    }
}
