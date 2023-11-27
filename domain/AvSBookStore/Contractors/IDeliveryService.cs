﻿using System.Collections.Generic;

namespace AvSBookStore.Contractors
{
    public interface IDeliveryService   
    {
        string UniqCode { get; }

        string Title { get; }

        Form CreateForm(Order order);

        Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> values);

        OrderDelivery GetDelivery(Form form);
    }
}
