using Store.Contractors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Web.Controllers
{
    public class PostamateDeliveryService : IDeliveryService
    {
        private static IReadOnlyDictionary<string, string> cities = new Dictionary<string, string>
        {
            {"1", "Киев" },
            {"2", "Харьков" },
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
            };

        public string UniqueCode => "Postamate";

        public string Title => "Доставка через постаматы Киева, Одессы, Харькова";

        public OrderDelivery GetDelivery(Form form) 
        {
            if (form.UniqueCode != UniqueCode || form.IsFinal) 
                throw new ArgumentException("Не верно передана форма!");


            var cityId = form.Fields.Single(field => field.Name == "city").Value;
            var cityName = cities[cityId];
            var postamateId = form.Fields.Single(field => field.Name == "postamate").Value;
            var postamateName = postmates[cityId][postamateId];

            var parameters = new Dictionary<string, string>
            {
                {nameof(cityId), cityId},
                {nameof(cityName), cityName},
                {nameof(postamateId), postamateId},
                {nameof(postamateName), postamateName}
            };

            var description = $"Город: {cityName}\nПостамат: {postamateName}";

            return new OrderDelivery(UniqueCode, description, 150m, parameters);
        }

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

        public Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> value)
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
