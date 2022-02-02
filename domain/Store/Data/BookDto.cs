using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class BookDto
    {
        public string Title { get; set; }

        public string Isbn { get; set; }

        public string Author { get; set; }

        public int ID { get; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
