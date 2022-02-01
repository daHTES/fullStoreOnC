using System;
using System.Collections.Generic;

namespace Store
{
    public class OrderPayment
    {
        public string UniqueCode { get; }

        public string Description { get; }

        public IReadOnlyDictionary<string, string> Parameters { get; }

        public OrderPayment(
            string uniquecode, 
            string description, 
            IReadOnlyDictionary<string, string> parameters) 
        {
            if (string.IsNullOrWhiteSpace(uniquecode))
                throw new ArgumentException(nameof(uniquecode));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(nameof(description));

            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            UniqueCode = uniquecode;
            Description = description;
            Parameters = parameters;
        }
    }
}
