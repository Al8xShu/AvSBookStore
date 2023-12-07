using System;
using System.Collections.Generic;

namespace AvSBookStore
{
    public class OrderDelivery
    {
        public string UniqCode { get; }

        public string Description { get; }

        public decimal Amount { get; }

        public IReadOnlyDictionary<string, string> Parameters { get; }

        public OrderDelivery(string uniqCode, string description, 
            decimal amount, IReadOnlyDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(nameof(uniqCode)))
            {
                throw new ArgumentException(nameof(uniqCode));
            }

            if (string.IsNullOrWhiteSpace(nameof(description)))
            {
                throw new ArgumentException(nameof(description));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            UniqCode = uniqCode;
            Description = description;
            Amount = amount;
            Parameters = parameters;
        }
    }
}
