using System;
using Week3AppLibrary.Model;
using Week3AppLibrary.Service;
using Week3AppLibrary.CustomException;

namespace Week3AppLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create service layer
            LibraryService libraryService = new LibraryService();

            // PRELOAD DEFAULT DATA (5 Books + 3 Magazines)
            SeedLibraryData(libraryService);

            bool exit = false;

            while (!exit)
            {
                Console.ResetColor();
                Console.WriteLine("\n===== Library Management System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Magazine");
                Console.WriteLine("3. Display All Items");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddBook(libraryService);
                            break;

                        case "2":
                            AddMagazine(libraryService);
                            break;

                        case "3":
                            DisplayItems(libraryService);
                            break;

                        case "4":
                            exit = true;
                            Console.WriteLine("Exiting application...");
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please select 1–4.");
                            break;
                    }
                }
                catch (InvalidItemDataException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Data: " + ex.Message);
                }
                catch (DuplicateEntryException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Duplicate Entry: " + ex.Message);
                }
            }
        }

        // ---------- PRELOAD DATA METHOD ----------
        // This method adds default books and magazines
        // so that option 3 always displays items
        static void SeedLibraryData(LibraryService service)
        {
            try
            {
                service.AddItem(new Book("The Great Gatsby", "Scribner", 1925, "F. Scott Fitzgerald"));
                service.AddItem(new Book("Harry Potter and the Sorcerer's Stone", "Bloomsbury", 1997, "J.K. Rowling"));
                service.AddItem(new Book("To Kill a Mockingbird", "J.B. Lippincott", 1960, "Harper Lee"));
                service.AddItem(new Book("Nineteen Eighty-Four", "Secker & Warburg", 1949, "George Orwell"));
                service.AddItem(new Book("Pride and Prejudice", "T. Egerton", 1813, "Jane Austen"));

                service.AddItem(new Magazine("National Geographic", "National Geographic Society", 2021, 5));
                service.AddItem(new Magazine("Time Magazine", "Time Inc.", 2022, 12));
                service.AddItem(new Magazine("Scientific American", "Springer Nature", 2023, 8));
            }
            catch
            {
                // Ignore duplicates if method runs again accidentally
            }
        }

        // ---------- ADD BOOK ----------
        static void AddBook(LibraryService service)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- Add New Book ---");

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Publisher: ");
            string publisher = Console.ReadLine();

            Console.Write("Enter Publication Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            Book book = new Book(title, publisher, year, author);
            service.AddItem(book);

            Console.WriteLine("Book added successfully!");
        }

        // ---------- ADD MAGAZINE ----------
        static void AddMagazine(LibraryService service)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Add New Magazine ---");

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Publisher: ");
            string publisher = Console.ReadLine();

            Console.Write("Enter Publication Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter Issue Number: ");
            int issueNumber = int.Parse(Console.ReadLine());

            Magazine magazine = new Magazine(title, publisher, year, issueNumber);
            service.AddItem(magazine);

            Console.WriteLine("Magazine added successfully!");
        }

        // ---------- DISPLAY ITEMS ----------
        static void DisplayItems(LibraryService service)
        {
            Console.ResetColor();
            Console.WriteLine("\n===== Library Items =====");

            foreach (var item in service.GetAllItems())
            {
                if (item is Book)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (item is Magazine)
                    Console.ForegroundColor = ConsoleColor.Cyan;

                item.DisplayInfo();
            }

            Console.ResetColor();
            Console.WriteLine("=========================");
        }
    }
}
