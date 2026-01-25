// File: Model/Item.cs
// This is the abstract base class for all library items.
// It contains common properties: Title, Publisher, PublicationYear
// Validation is applied in property setters to ensure data integrity.

using System;
using Week3AppLibrary.CustomException;

namespace Week3AppLibrary.Model
{
    public abstract class Item
    {
        // Private backing fields, initialized to avoid CS8618 warnings.
        private string _title = string.Empty;
        private string _publisher = string.Empty;
        private int _publicationYear;

        // ---------- Constructors ----------

        // Parameterless constructor
        protected Item() { }

        // Parameterized constructor
        protected Item(string title, string publisher, int publicationYear)
        {
            Title = title;                 // Calls property setter (validation occurs)
            Publisher = publisher;
            PublicationYear = publicationYear;
        }

        // ---------- Properties with Validation ----------

        // Title: non-null, min 5 chars, starts with capital
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Title cannot be null, empty, or whitespace.");

                string trimmed = value.Trim();

                if (trimmed.Length < 5)
                    throw new InvalidItemDataException("Title must be at least 5 characters long.");

                // First alphabetic character must be uppercase
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
                    throw new InvalidItemDataException("Title must start with a capital letter.");

                _title = trimmed;
            }
        }

        // Publisher: non-null, min 6 chars, starts with capital
        public string Publisher
        {
            get => _publisher;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Publisher cannot be null, empty, or whitespace.");

                string trimmed = value.Trim();

                if (trimmed.Length < 6)
                    throw new InvalidItemDataException("Publisher must be at least 6 characters long.");

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
                    throw new InvalidItemDataException("Publisher must start with a capital letter.");

                _publisher = trimmed;
            }
        }

        // PublicationYear: 4-digit number
        public int PublicationYear
        {
            get => _publicationYear;
            set
            {
                if (value < 1000 || value > 9999)
                    throw new InvalidItemDataException("Publication year must be a four-digit number.");

                _publicationYear = value;
            }
        }

        // ---------- Methods ----------

        // Virtual method to display basic item info
        // Can be overridden by derived classes
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}");
        }
    }
}
