using System;
using System.Threading;
using CodeLibrary.Models;
using CodeLibrary.Services;

namespace CodeLibrary.Controllers
{
    public class LibraryController
    {
        public LibraryController()
        {
            libraryService = new LibraryService();
        }

        public bool Running { get; set; } = true;

        public LibraryService libraryService { get; set; }
        public void Run()
        {
            Console.Clear();
            while (Running)
            {
                Utils.PrintLogo();
                GetUserInput();
            }
        }
        private void GetUserInput()
        {
            System.Console.WriteLine("Type Your Selection:  Add, Read, Checkout, Return, Delete, Quit");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "add":
                    Add();
                    break;
                case "read":
                    Read();
                    break;
                case "checkout":
                    Checkout();
                    break;
                case "return":
                    Return();
                    break;
                case "delete":
                    Delete();
                    break;
                case "quit":
                    Quit();
                    break;
                default:
                    System.Console.WriteLine("InvalidSelection");
                    break;
            }
        }

        private void Add()
        {
            Console.Clear();
            System.Console.WriteLine("What book do you want to add?");
            System.Console.WriteLine("Title?");
            string title = Console.ReadLine();
            System.Console.WriteLine("Who is the Author?");
            string author = Console.ReadLine();
            System.Console.WriteLine("What is the description of the book?");
            string description = Console.ReadLine();
            string greatSuccess = libraryService.addBook(title, author, description);
            if (greatSuccess == "Great Success")
            {
                System.Console.WriteLine("Great Success! Book Added!");
            }
        }

        private void Read()
        {
            Console.Clear();
            var books = libraryService.GetBooks();
            System.Console.WriteLine(books);
            System.Console.WriteLine("Which book would you like to read? Number:");
            string toRead = Console.ReadLine();
            string description = libraryService.getDescription(toRead);
            System.Console.WriteLine(description);
        }

        private void Checkout()
        {
            Console.Clear();
            var availible = libraryService.GetActiveBooks(true);
            System.Console.WriteLine(availible);
            System.Console.WriteLine("Which book do you want to check out? Number:");
            string checkoutBook = Console.ReadLine();
            string greatSuccess = libraryService.checkout(checkoutBook);
            if (greatSuccess == "Great Success")
            {
                System.Console.WriteLine("Great Success! Book Checked Out!");
            }
        }

        private void Return()
        {
            Console.Clear();
            var returnable = libraryService.GetActiveBooks(false);
            System.Console.WriteLine(returnable);
            System.Console.WriteLine("Which book do you want to return? Number:");
            string returnBook = Console.ReadLine();
            string greatSuccess = libraryService.returnBook(returnBook);
            if (greatSuccess == "Great Success")
            {
                System.Console.WriteLine("Great Success! Book Returned!");
            }
        }

        private void Delete()
        {
            Console.Clear();
            var availible = libraryService.GetBooks();
            System.Console.WriteLine(availible);
            System.Console.WriteLine("Which book do you want to delete? Number:");
            string deleteBook = Console.ReadLine();
            string greatSuccess = libraryService.deleteBook(deleteBook);
            if (greatSuccess == "Great Success")
            {
                System.Console.WriteLine("Great Success! Book Deleted!");
            }
        }

        private void Quit()
        {
            Running = false;
        }
    }
}