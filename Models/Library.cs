using System.Collections.Generic;

namespace CodeLibrary.Models
{
    public class Library
    {
        //Constructor
        public Library(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}