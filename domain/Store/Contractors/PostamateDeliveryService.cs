using Store.Contractors;
using System;
using System.Collections.Generic;

namespace Store.Web.Controllers
{
    public class PostamateDeliveryService : IDeliveryService
    {
        private static Dictionary<string, string> cities = new Dictionary<string, string>
        {
            {"1", "Киев" },
            {"2", "Харьков" },
            {"3", "Одесса" }
        };
        private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> postmates
            = new Dictionary<string, IReadOnlyDictionary<string, string>>
            {

                {
                    "1",
                    new Dictionary<string, string>
                    {
                        {"1", "Поштовая площать" },
                        {"2", "Крещатик"},
                        {"3", "Левый берег"},
                    }
                },
                {
                    "2",
                    new Dictionary<string, string>
                    {
                        {"4", "Центральный вокзал" },
                        {"5", "Московское" },
                        {"6", "Индустриальный" },
                    }
                },
                {
                    "3",
                    new Dictionary<string, string>
                    {
                        {"7", "Водопад"},
                        {"8", "Потемкино"},
                        {"9", "Ватерлоу"},
                    }
                }
            };

        public string UniqueCode => "Postamate";

        public string Title => "Доставка через постаматы Киева";

        public Form CreateForm(Order order)
        {
           if (order == null)
            {
                throw new ArgumentException(nameof(order));
            }

            return new Form(UniqueCode, order.Id, 1, false, new[]
            {
               new SelectionField("Город", "city", "1", cities),
           });
        }

        public Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> value)
        {
            if (step == 1)
            {
                if (value["city"] == "1")
                {
                    return new Form(UniqueCode, orderId, 2, false, new Field[]
                    {
                        new HiddenField("Город", "city", "1"),
                        new SelectionField("Постамат", "postamate", "1", postmates["1"]),
                    });
                }

                else if (value["city"] == "2")
                {
                    return new Form(UniqueCode, orderId, 2, false, new Field[]
                    {
                        new HiddenField("Город", "city", "2"),
                        new SelectionField("Постамат", "postamate", "4", postmates["2"]),
                    });
                }
                else if (value["city"] == "3")
                {
                    return new Form(UniqueCode, orderId, 3, false, new Field[]
                    {
                        new HiddenField("Город", "city", "3"),
                        new SelectionField("Постамат", "postamate", "7", postmates["3"]),
                    });
                }
                else
                    throw new InvalidOperationException("Не верная операция выбора доставки");
            }

            else if (step == 2)
            {
                return new Form(UniqueCode, orderId, 3, true, new Field[]
                {
                    new HiddenField("Город", "city", value["city"]),
                    new HiddenField("Постамат", "postamate", value["postamate"]),
                });
            }
            else
                throw new InvalidOperationException("Не верный шаг заполнения");
        }
    }
}
