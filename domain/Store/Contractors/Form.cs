using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contractors
{
    public class Form
    {
        public string UniqueCode { get; }

        public int OrderId { get; }

        public int Step { get; }

        public bool IsFinal { get; }

        public IReadOnlyList<Field> Fields { get; }

        public Form(
            string uniquecode, 
            int orderId, 
            int step, 
            bool isfinal, 
            IEnumerable<Field> fields) 
        {
            if (string.IsNullOrWhiteSpace(uniquecode))
                throw new ArgumentException(nameof(uniquecode));


            if (step < 1)
                throw new ArgumentNullException(nameof(step));

            if (fields == null)
                throw new ArgumentNullException(nameof(fields));


            UniqueCode = uniquecode;
            OrderId = orderId;
            Step = step;
            IsFinal = isfinal;
            Fields = fields.ToArray();
        }

    }
}
