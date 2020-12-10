using System;
using System.Collections.Generic;
using CodeLibrary.Models;

namespace CodeLibrary.Services
{
    public class LibraryService
    {
        public LibraryService()
        {
            RyansLibrary = new Library("Ryan's Library");
            RyansLibrary.Books.Add(new Book("Guide To Monsters", "Volo", "A deep dive into the lore behind some of D&D’s most popular and iconic monsters"));
            RyansLibrary.Books.Add(new Book("Guide To Everything", "Xanathar", "The beholder Xanathar—Waterdeep’s most infamous crime lord—is known to hoard information on friend and foe alike. The beholder catalogs lore about adventurers and ponders methods to thwart them. Its twisted mind imagines that it can eventually record everything!"));
            RyansLibrary.Books.Add(new Book("Tomb of Foes", "Mordenkainen", "This tome is built on the writings of the renowned wizard from the world of Greyhawk, gathered over a lifetime of research and scholarship."));
            RyansLibrary.Books.Add(new Book("Cauldron of Everything", "Tasha", "The wizard Tasha, whose great works include the spell Tasha’s hideous laughter, has gathered bits and bobs of precious lore during her illustrious career as an adventurer."));
        }

        public Library RyansLibrary { get; set; }

        public string GetBooks()
        {
            string template = "Books : \n";
            List<Book> books = new List<Book>();
            books.AddRange(RyansLibrary.Books);
            for (int i = 0; i < books.Count; i++)
            {
                template += $"{i + 1}. {books[i]} \n";
            }
            return template;
        }

        internal string GetActiveBooks(bool available)
        {
            string template = "Books Available : \n";
            //typically will just use template and return a string
            //am doing writelintes just to show how you can change colors of text
            // System.Console.WriteLine("Books Available : \n");
            List<Book> books = new List<Book>();
            books.AddRange(RyansLibrary.Books);

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].IsAvailable == available)
                {
                    // Console.ForegroundColor = ConsoleColor.Red;
                    // System.Console.WriteLine($"{i + 1}. {books[i]} \n");
                    template += $"{i + 1}. {books[i]} \n";
                }
                // else
                // {
                //     // Console.ForegroundColor = ConsoleColor.White;
                //     // System.Console.WriteLine($"{i + 1}. {books[i]} \n");
                //     template += $"{i + 1}. {books[i]} \n";

                // }
            }
            return template;
        }

        internal string addBook(string title, string author, string description)
        {
            var newBook = new Book(title, author, description);
            RyansLibrary.Books.Add(newBook);
            return "Great Success";
        }

        internal string returnBook(string returnBook)
        {
            int index = int.Parse(returnBook) - 1;
            RyansLibrary.Books[index].IsAvailable = true;
            return "Great Success";
        }

        internal string checkout(string checkoutBook)
        {
            int index = int.Parse(checkoutBook) - 1;
            RyansLibrary.Books[index].IsAvailable = false;
            return "Great Success";
        }

        internal string getDescription(string toRead)
        {
            int index = int.Parse(toRead) - 1;
            string text = RyansLibrary.Books[index].Description;
            return text;
        }

        internal string deleteBook(string deleteBook)
        {
            int index = int.Parse(deleteBook) - 1;
            RyansLibrary.Books.RemoveAt(index);
            return "Great Success";
        }
    }
}