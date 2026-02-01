using System;
using Week3AppLibrary.Interfaces;
using Week3AppLibrary.Exceptions;

namespace Week3AppLibrary.Model
{
    /*
     * Abstract base class LibraryItemBase
     * Implements ILibraryItem interface
     * 
     * - Cannot be instantiated directly
     * - Provides validation for common properties
     * - Child classes must override DisplayInfo()
     */
    public abstract class LibraryItemBase : ILibraryItem
    {
        protected string _title;
        protected string _publisher;
        protected int _publicationYear;

        // Default constructor
        protected LibraryItemBase() { }

        // Parameterized constructor
        protected LibraryItemBase(string title, string publisher, int publicationYear)
        {
            Title = title;
            Publisher = publisher;
            PublicationYear = publicationYear;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new InvalidItemDataException(
                        "Title must be at least 5 characters long."
                    );
                }
                _title = value;
            }
        }

        public string Publisher
        {
            get { return _publisher; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidItemDataException(
                        "Publisher cannot be empty."
                    );
                }
                _publisher = value;
            }
        }

        public int PublicationYear
        {
            get { return _publicationYear; }
            set
            {
                if (value < 1000 || value > DateTime.Now.Year)
                {
                    throw new InvalidItemDataException(
                        "Publication year is invalid."
                    );
                }
                _publicationYear = value;
            }
        }

        // Abstract method to display item details
        public abstract void DisplayInfo();
    }
}
