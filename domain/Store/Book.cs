using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public string Title { get; }

        public string Isbn { get; }

        public string Author { get; }

        public int ID { get; }

        public Book(int id, string isbn, string author, string titlePart) 
        {
            Title = titlePart;
            ID = id;
            Isbn = isbn;
            Author = author;
        }

        internal static bool IsIsbn(string s) 
        {
            if (s == null)
                return false;

            s = s.Replace("-", "").Replace(" ", "").ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
        }
    }
}
