﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AvSBookStore.Contractors
{
    public interface IPaymentService
    {
        string Name { get; }

        string Title { get; }

        Form FirstForm(Order order);

        Form NextForm(int step, IReadOnlyDictionary<string, string> values);

        OrderPayment GetPayment(Form form);
    }
}
