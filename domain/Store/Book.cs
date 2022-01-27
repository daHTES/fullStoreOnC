using System;

namespace Store
{
    public class Book
    {
        public string Title { get; }
        public int ID { get; }




        public Book(int id, string titlePart) 
        {
            Title = titlePart;
            ID = id;
        }
    }
}
