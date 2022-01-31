using System.Collections.Generic;

namespace Store.Contractors
{
    public interface IPaymentServices
    {
        string UniqueCode { get; }

        string Title { get; }

        Form CreateForm(Order oder);

        Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> value);

        OrderPayment GetPayment(Form form);
    }
}
