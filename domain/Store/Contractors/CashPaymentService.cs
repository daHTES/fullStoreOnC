using System;
using System.Collections.Generic;

namespace Store.Contractors
{
   public class CashPaymentService : IPaymentServices
    {
        public string UniqueCode => "Cash";
        public string Title => "Оплата наличными";

        public Form CreateForm(Order order)
        {
            return new Form(UniqueCode, order.Id, 1, false, new Field[0]);
        }

        public OrderPayment GetPayment(Form form)
        {
            if (form.UniqueCode != UniqueCode || !form.IsFinal)
                throw new InvalidOperationException("Не верная форма оплаты");
            return new OrderPayment(UniqueCode, "Оплата Наличными", new Dictionary<string, string>());
        }

        public Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> value)
        {
            if (step != 1)
                throw new InvalidOperationException("Не верная форма для выбора оплаты наличиными!");

            return new Form(UniqueCode, orderId, 2, true, new Field[0]);
        }
    }
}
