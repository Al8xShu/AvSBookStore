using System.Collections.Generic;

namespace AvSBookStore.Contractors
{
    public interface IPaymentService
    {
        string UniqCode { get; }

        string Title { get; }

        Form CreateForm(Order order);

        Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> values);

        OrderPayment GetPayment(Form form);
    }
}
