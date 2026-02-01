using System;
using Week3AppLibrary.Exceptions;
namespace Week3AppLibrary.Model
{
    /*
     * Newspaper is a CHILD class of LibraryItemBase.
     * 
     * - It represents newspapers in the library system
     * - It inherits Title, Publisher, PublicationYear from LibraryItemBase
     * - It adds its own unique property: Language
     * - It MUST override DisplayInfo() method
     */

    public class Newspaper : LibraryItemBase
    {
        // Private field to store newspaper language
        private string _language;

        /*
         * Default constructor
         * 
         * Allows object creation without immediate data assignment
         */
        public Newspaper()
        {
        }

        /*
         * Parameterized constructor
         * 
         * - Calls base Item constructor for common fields
         * - Applies validation through property setters
         */
        public Newspaper(string title, string publisher, int publicationYear, string language)
            : base(title, publisher, publicationYear)
        {
            Language = language;
        }

        /*
         * Public property for Language
         * 
         * Validation rules:
         * - Cannot be null or empty
         * - Must be at least 3 characters long
         */
        public string Language
        {
            get { return _language; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new InvalidItemDataException(
                        "Language must be at least 3 characters long."
                    );
                }

                _language = value;
            }
        }

        /*
         * Override of DisplayInfo()
         * 
         * This method demonstrates polymorphism.
         * Even when accessed as Item, the correct
         * Newspaper display logic will run.
         */
        public override void DisplayInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----- Newspaper -----");
            Console.ResetColor();

            Console.WriteLine($"Title           : {Title}");
            Console.WriteLine($"Language        : {Language}");
            Console.WriteLine($"Publisher       : {Publisher}");
            Console.WriteLine($"PublicationYear : {PublicationYear}");
            Console.WriteLine();
        }
    }
}
