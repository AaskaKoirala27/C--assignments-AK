// File: Model/Book.cs
// Represents a Book, which is a type of Item
// Adds Author property with validation and overrides DisplayInfo

using System;
using Week3AppLibrary.CustomException;

namespace Week3AppLibrary.Model
{
    public class Book : Item
    {
        private string _author = string.Empty; // private field for Author

        // ---------- Constructors ----------
        public Book() : base() { }

        public Book(string title, string publisher, int publicationYear, string author)
            : base(title, publisher, publicationYear)
        {
            Author = author; // validation occurs in property
        }

        // ---------- Author Property ----------
        // 1. Cannot be null/empty
        // 2. Minimum length 5
        // 3. Starts with capital
        public string Author
        {
            get => _author;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Author cannot be null or empty.");

                string trimmed = value.Trim();

                if (trimmed.Length < 5)
                    throw new InvalidItemDataException("Author must be at least 5 characters long.");

                char firstAlpha = '\0';
                foreach (char c in trimmed)
                {
                    if (char.IsLetter(c))
                    {
                        firstAlpha = c;
                        break;
                    }
                }

                if (firstAlpha == '\0' || !char.IsUpper(firstAlpha))
                    throw new InvalidItemDataException("Author must start with a capital letter.");

                _author = trimmed;
            }
        }

        // ---------- Display Info ----------
        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}, Author: {Author}");
        }
    }
}
