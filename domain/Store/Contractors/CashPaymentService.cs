using System;
using System.Collections.Generic;

namespace Store.Contractors
{
   public class CashPaymentService : IPaymentServices
    {
        public string Name => "Cash";
        public string Title => "Оплата наличными";

        public Form FirstForm(Order order)
        {
            return Form.CreateFirst(Name)
                        .AddParameter("orderId", order.Id.ToString());
        }

        public OrderPayment GetPayment(Form form)
        {
            if (form.ServiceName != Name || !form.IsFinal)
                throw new InvalidOperationException("Неверная оплата наличными.");

            return new OrderPayment(Name, "Оплата наличными", form.Parameters);
        }

        public Form NextForm(int step, IReadOnlyDictionary<string, string> values)
        {
            if (step != 1)
                throw new InvalidOperationException("Неверный шаг оплаты.");

            return Form.CreateLast(Name, step + 1, values);
        }
    }
}
