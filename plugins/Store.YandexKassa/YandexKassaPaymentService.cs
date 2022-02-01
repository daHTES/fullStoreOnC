using Store.Contractors;
using Store.Web.Contractors;
using System.Collections.Generic;

namespace Store.YandexKassa
{
    public class YandexKassaPaymentService : IPaymentServices, IWebContractorService
    {
        public string UniqueCode => "YandexKassa";

        public string Title => "Яндекс Касса - Система оплаты банковской картой";

        public string GetUri => "/YandexKassa/Home";




        public Form CreateForm(Order order)
        {
            return new Form(UniqueCode, order.Id, 1, true, new Field[0]);
        }



        public OrderPayment GetPayment(Form form)
        {
            return new OrderPayment(UniqueCode, "Оплата картой", new Dictionary<string, string>());
        }




        public Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> value)
        {
            return new Form(UniqueCode, orderId, 2, true, new Field[0]);
        }
    }
}
