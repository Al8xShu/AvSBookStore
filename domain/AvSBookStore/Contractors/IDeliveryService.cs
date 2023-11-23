using System;
using System.Collections.Generic;
using System.Text;

namespace AvSBookStore.Contractors
{
    public interface IDeliveryService
    {
        string UniqCode { get; }

        string Title { get; }

        Form FirstForm(Order order);

        Form NextForm(int step, IReadOnlyDictionary<string, string> values);

    }
}
