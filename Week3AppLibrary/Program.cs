using System;
using Week3AppLibrary.Model;      // Access Book, Magazine, Newspaper classes
using Week3AppLibrary.Service;    // Access LibraryService class
using Week3AppLibrary.Exceptions; // Access custom exceptions: InvalidItemDataException, DuplicateItemException

namespace Week3AppLibrary
{
    /*
     * Main program class for the Library Management System.
     * Handles user interaction, menu navigation, and calls the service layer.
     */
    class Program
    {
        // Entry point of the program
        static void Main(string[] args)
        {
            // Create an instance of the LibraryService which manages all items
            LibraryService libraryService = new LibraryService();

            // Preload some books, magazines, and newspapers into the library
            SeedLibraryData(libraryService);

            // Flag to control the main menu loop
            bool exit = false;

            // Main menu loop
            while (!exit)
            {
                Console.ResetColor(); // Reset console colors before displaying menu
                Console.WriteLine("\n===== Library Management System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Magazine");
                Console.WriteLine("3. Add Newspaper");
                Console.WriteLine("4. Display All Items");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine(); // Read user input

                try
                {
                    // Handle menu selection
                    switch (choice)
                    {
                        case "1": AddBook(libraryService); break;       // Call method to add a Book
                        case "2": AddMagazine(libraryService); break;   // Call method to add a Magazine
                        case "3": AddNewspaper(libraryService); break;  // Call method to add a Newspaper
                        case "4": DisplayItems(libraryService); break;  // Display all library items
                        case "5": exit = true; Console.WriteLine("Exiting..."); break; // Exit program
                        default: 
                            // Invalid menu choice
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice."); 
                            break;
                    }
                }
                // Handle exceptions for invalid input data
                catch (InvalidItemDataException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Data: " + ex.Message);
                }
                // Handle exceptions for duplicate items
                catch (DuplicateItemException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Duplicate Entry: " + ex.Message);
                }
            }
        }

        /*
         * Method to preload default items into the library.
         * Demonstrates preloading and avoids starting with an empty library.
         */
        static void SeedLibraryData(LibraryService service)
        {
            try
            {
                // Add Books with all properties (Title, Publisher, Year, Author)
                service.AddItem(new Book("The Great Gatsby", "Scribner", 1925, "F. Scott Fitzgerald"));
                service.AddItem(new Book("Harry Potter and the Sorcerer's Stone", "Bloomsbury", 1997, "J.K. Rowling"));
                service.AddItem(new Book("To Kill a Mockingbird", "J.B. Lippincott", 1960, "Harper Lee"));
                service.AddItem(new Book("Nineteen Eighty-Four", "Secker & Warburg", 1949, "George Orwell"));
                service.AddItem(new Book("Pride and Prejudice", "T. Egerton", 1813, "Jane Austen"));

                // Add Magazines with Title, Publisher, Year, IssueNumber
                service.AddItem(new Magazine("National Geographic", "National Geographic Society", 2021, 5));
                service.AddItem(new Magazine("Time Magazine", "Time Inc.", 2022, 12));
                service.AddItem(new Magazine("Scientific American", "Springer Nature", 2023, 8));

                // Add a Newspaper with Title, Publisher, Year, Language
                service.AddItem(new Newspaper("The New York Times", "NYT Company", 2023, "English"));
            }
            catch
            {
                // Ignore any errors if duplicates occur while seeding
            }
        }

        /*
         * Method to add a new Book.
         * Prompts user for input and validates through Book constructor.
         */
        static void AddBook(LibraryService service)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Color for Book
            Console.WriteLine("\n--- Add New Book ---");

            Console.Write("Enter Title: "); string title = Console.ReadLine();
            Console.Write("Enter Publisher: "); string publisher = Console.ReadLine();
            Console.Write("Enter Publication Year: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Enter Author: "); string author = Console.ReadLine();

            // Create Book object and add it to the library
            service.AddItem(new Book(title, publisher, year, author));
        }

        /*
         * Method to add a new Magazine.
         * Prompts user for input and validates through Magazine constructor.
         */
        static void AddMagazine(LibraryService service)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Color for Magazine
            Console.WriteLine("\n--- Add New Magazine ---");

            Console.Write("Enter Title: "); string title = Console.ReadLine();
            Console.Write("Enter Publisher: "); string publisher = Console.ReadLine();
            Console.Write("Enter Publication Year: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Enter Issue Number: "); int issue = int.Parse(Console.ReadLine());

            // Create Magazine object and add it to the library
            service.AddItem(new Magazine(title, publisher, year, issue));
        }

        /*
         * Method to add a new Newspaper.
         * Prompts user for input and validates through Newspaper constructor.
         */
        static void AddNewspaper(LibraryService service)
        {
            Console.ForegroundColor = ConsoleColor.Green; // Color for Newspaper
            Console.WriteLine("\n--- Add New Newspaper ---");

            Console.Write("Enter Title: "); string title = Console.ReadLine();
            Console.Write("Enter Publisher: "); string publisher = Console.ReadLine();
            Console.Write("Enter Publication Year: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Enter Language: "); string language = Console.ReadLine();

            // Create Newspaper object and add it to the library
            service.AddItem(new Newspaper(title, publisher, year, language));
        }

        /*
         * Method to display all library items.
         * Iterates over the list in the service layer and calls each item's DisplayInfo method.
         * Colors the output based on item type for easy visual distinction.
         */
        static void DisplayItems(LibraryService service)
        {
            Console.ResetColor();
            Console.WriteLine("\n===== Library Items =====");

            foreach (var item in service.GetAllItems())
            {
                // Set console color based on item type
                if (item is Book) Console.ForegroundColor = ConsoleColor.Cyan;
                else if (item is Magazine) Console.ForegroundColor = ConsoleColor.Yellow;
                else if (item is Newspaper) Console.ForegroundColor = ConsoleColor.Green;

                // Polymorphic call: the correct DisplayInfo() is called depending on actual type
                item.DisplayInfo();
            }

            // Reset console color after displaying all items
            Console.ResetColor();
            Console.WriteLine("=========================");
        }
    }
}
