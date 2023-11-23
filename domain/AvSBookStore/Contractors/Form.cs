using System;
using System.Collections.Generic;
using System.Linq;

namespace AvSBookStore.Contractors
{
    public class Form
    {
        public string UniqCode { get; }

        public int OrderId { get; }

        public int Step { get; }

        public bool IsFinal { get; }

        public IReadOnlyList<Field> Fields { get; }

        public Form(string uniqCode, int orderId, int step, bool isFinal, IEnumerable<Field> fields)
        {
            if (string.IsNullOrWhiteSpace(uniqCode))
            {
                throw new ArgumentException(nameof(uniqCode));
            }

            if (step < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(step));
            }

            if (fields == null)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            UniqCode = uniqCode;
            OrderId = orderId;
            Step = step;
            IsFinal = IsFinal;
            Fields = fields.ToArray();
        }
    }
}
