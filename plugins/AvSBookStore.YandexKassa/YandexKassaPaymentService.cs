using AvSBookStore.Contractors;
using AvSBookStore.Web.Contractors;
using System.Collections.Generic;

namespace AvSBookStore.YandexKassa
{
    public class YandexKassaPaymentService : IPaymentService, IWebContractorService
    {
        public string UniqCode => "YandexKassa";

        public string Title => "Payment by card";

        public string GetUri => "/YandexKassa/";

        

        public Form CreateForm(Order order)
        {
            return new Form(UniqCode, order.Id, 1, true, new Field[0]);
        }

        public OrderPayment GetPayment(Form form)
        {
            return new OrderPayment(UniqCode, "Payment by card", new Dictionary<string, string>());
        }

        public Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> values)
        {
            return new Form(UniqCode, orderId, 2, true, new Field[0]);
        }
    }
}
