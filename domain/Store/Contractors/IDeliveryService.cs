using System.Collections.Generic;

namespace Store.Contractors
{
    public interface IDeliveryService
    {
        string Name { get; }

        string Title { get; }

        Form FirstForm(Order oder);

        Form NextForm(int step, IReadOnlyDictionary<string, string> value);

        OrderDelivery GetDelivery(Form form);
    }
}
