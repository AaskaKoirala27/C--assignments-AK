using System;
using Week3AppLibrary.Model;
using Week3AppLibrary.Service;
using Week3AppLibrary.Exceptions;

namespace Week3AppLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryService libraryService = new LibraryService();

            SeedLibraryData(libraryService);

            bool exit = false;

            while (!exit)
            {
                Console.ResetColor();
                Console.WriteLine("\n===== Library Management System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Magazine");
                Console.WriteLine("3. Add Newspaper");
                Console.WriteLine("4. Display All Items");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": AddBook(libraryService); break;
                        case "2": AddMagazine(libraryService); break;
                        case "3": AddNewspaper(libraryService); break;
                        case "4": DisplayItems(libraryService); break;
                        case "5": exit = true; Console.WriteLine("Exiting..."); break;
                        default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (InvalidItemDataException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Data: " + ex.Message);
                }
                catch (DuplicateItemException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Duplicate Entry: " + ex.Message);
                }
            }
        }

        static void SeedLibraryData(LibraryService service)
        {
            try
            {
                // Books
                service.AddItem(new Book("The Great Gatsby", "Scribner", 1925, "F. Scott Fitzgerald"));
                service.AddItem(new Book("Harry Potter and the Sorcerer's Stone", "Bloomsbury", 1997, "J.K. Rowling"));
                service.AddItem(new Book("To Kill a Mockingbird", "J.B. Lippincott", 1960, "Harper Lee"));
                service.AddItem(new Book("Nineteen Eighty-Four", "Secker & Warburg", 1949, "George Orwell"));
                service.AddItem(new Book("Pride and Prejudice", "T. Egerton", 1813, "Jane Austen"));

                // Magazines
                service.AddItem(new Magazine("National Geographic", "National Geographic Society", 2021, 5));
                service.AddItem(new Magazine("Time Magazine", "Time Inc.", 2022, 12));
                service.AddItem(new Magazine("Scientific American", "Springer Nature", 2023, 8));

                // Newspaper
                service.AddItem(new Newspaper("The New York Times", "NYT Company", 2023, "English"));
            }
            catch { }
        }

        static void AddBook(LibraryService service)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Add New Book ---");
            Console.Write("Enter Title: "); string title = Console.ReadLine();
            Console.Write("Enter Publisher: "); string publisher = Console.ReadLine();
            Console.Write("Enter Publication Year: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Enter Author: "); string author = Console.ReadLine();
            service.AddItem(new Book(title, publisher, year, author));
        }

        static void AddMagazine(LibraryService service)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- Add New Magazine ---");
            Console.Write("Enter Title: "); string title = Console.ReadLine();
            Console.Write("Enter Publisher: "); string publisher = Console.ReadLine();
            Console.Write("Enter Publication Year: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Enter Issue Number: "); int issue = int.Parse(Console.ReadLine());
            service.AddItem(new Magazine(title, publisher, year, issue));
        }

        static void AddNewspaper(LibraryService service)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- Add New Newspaper ---");
            Console.Write("Enter Title: "); string title = Console.ReadLine();
            Console.Write("Enter Publisher: "); string publisher = Console.ReadLine();
            Console.Write("Enter Publication Year: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Enter Language: "); string language = Console.ReadLine();
            service.AddItem(new Newspaper(title, publisher, year, language));
        }

        static void DisplayItems(LibraryService service)
        {
            Console.ResetColor();
            Console.WriteLine("\n===== Library Items =====");
            foreach (var item in service.GetAllItems())
            {
                if (item is Book) Console.ForegroundColor = ConsoleColor.Cyan;
                else if (item is Magazine) Console.ForegroundColor = ConsoleColor.Yellow;
                else if (item is Newspaper) Console.ForegroundColor = ConsoleColor.Green;
                item.DisplayInfo();
            }
            Console.ResetColor();
            Console.WriteLine("=========================");
        }
    }
}
