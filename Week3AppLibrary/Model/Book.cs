using System;
using Week3AppLibrary.Exceptions;

namespace Week3AppLibrary.Model
{
    /*
     * Book class inherits from LibraryItemBase
     * Adds Author property and overrides DisplayInfo()
     */
    public class Book : LibraryItemBase
    {
        private string _author;

        public Book() { }

        public Book(string title, string publisher, int publicationYear, string author)
            : base(title, publisher, publicationYear)
        {
            Author = author;
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new InvalidItemDataException("Author must be at least 5 characters long.");
                _author = value;
            }
        }

        public override void DisplayInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----- Book -----");
            Console.ResetColor();
            Console.WriteLine($"Title           : {Title}");
            Console.WriteLine($"Author          : {Author}");
            Console.WriteLine($"Publisher       : {Publisher}");
            Console.WriteLine($"PublicationYear : {PublicationYear}");
            Console.WriteLine();
        }
    }
}
