
using System;
using System.Collections.Generic;

namespace AvSBookStore
{
    public class OrderPayment   
    {
        public string UniqCode { get; }

        public string Description { get; }

        public IReadOnlyDictionary<string, string> Parameters { get; }

        public OrderPayment(string uniqCode, string description, 
            IReadOnlyDictionary<string, string> parameters)
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
            Parameters = parameters;
        }
    }
}
