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
            { "1", "Москва" },
            { "2", "Санкт-Петербург" },
        };

        private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> postamates = new Dictionary<string, IReadOnlyDictionary<string, string>>
        {
            {
                "1",
                new Dictionary<string, string>
                {
                    { "1", "Казанский вокзал" },
                    { "2", "Охотный ряд" },
                    { "3", "Савёловский рынок" },
                }
            },
            {
                "2",
                new Dictionary<string, string>
                {
                    { "4", "Московский вокзал" },
                    { "5", "Гостиный двор" },
                    { "6", "Петропавловская крепость" },
                }
            }
        };

        public string Name => "Postamate";

        public string Title => "Доставка через постаматы Киева, Харькова";

        public OrderDelivery GetDelivery(Form form) 
        {
            if (form.ServiceName != Name || !form.IsFinal) 
                throw new InvalidOperationException("Не верно передана форма!");


            var cityId = form.Fields.Single(field => field.Name == "gorod").Value;
            var cityName = cities[cityId];
            var postamateId = form.Fields.Single(field => field.Name == "postamate").Value;
            var postamateName = postamates[cityId][postamateId];

            var parameters = new Dictionary<string, string>
            {
                {nameof(cityId), cityId},
                {nameof(cityName), cityName},
                {nameof(postamateId), postamateId},
                {nameof(postamateName), postamateName},
            };

            var description = $"Город: {cityName}\nПостамат: {postamateName}";

            return new OrderDelivery(Name, description, 150m, parameters);
        }

        public Form FirstForm(Order order)
        {
            return Form.CreateFirst(Name)
                         .AddParameter("orderId", order.Id.ToString())
                         .AddField(new SelectionField("Город", "city", "1", cities));
        }

        public Form NextForm(int step, IReadOnlyDictionary<string, string> values)
        {
            if (step == 1)
            {
                if (values["gorod"] == "1")
                {
                    return Form.CreateNext(Name, 2, values)
                              .AddField(new SelectionField("Постамат", "postamate", "1", postamates["1"]));
                }

                else if (values["gorod"] == "2")
                {
                    return Form.CreateNext(Name, 2, values)
                               .AddField(new SelectionField("Постамат", "postamate", "4", postamates["2"]));
                }
                else
                    throw new InvalidOperationException("Не верная операция выбора доставки");
            }

            else if (step == 2)
            {
                return Form.CreateLast(Name, 3, values);
            }
            else
                throw new InvalidOperationException("Не верный шаг заполнения");
        }
    }
}
