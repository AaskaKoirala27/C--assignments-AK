using System;
using Week3AppLibrary.Exceptions;

namespace Week3AppLibrary.Model
{
    /*
     * Magazine is another CHILD class of LibraryItemBase.
     * 
     * - Inherits all common item properties
     * - Adds IssueNumber as its own unique attribute
     * - Overrides DisplayInfo() method
     */

    public class Magazine : LibraryItemBase
    {
        // Private field to store issue number
        private int _issueNumber;

        /*
         * Default constructor
         */
        public Magazine()
        {
        }

        /*
         * Parameterized constructor
         * 
         * Calls base class constructor to initialize
         * common item fields
         */
        public Magazine(string title, string publisher, int publicationYear, int issueNumber)
            : base(title, publisher, publicationYear)
        {
            IssueNumber = issueNumber;
        }

        /*
         * Public property for IssueNumber
         * 
         * Ensures issue number is valid
         */
        public int IssueNumber
        {
            get { return _issueNumber; }
            set
            {
                // Validation rule:
                // Issue number must be positive
                if (value <= 0)
                {
                    throw new InvalidItemDataException(
                        "Issue number must be a positive number."
                    );
                }

                _issueNumber = value;
            }
        }

        /*
         * Override of abstract DisplayInfo method
         * 
         * Provides Magazine-specific output format
         */
        public override void DisplayInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----- Magazine -----");
            Console.ResetColor();

            Console.WriteLine($"Title           : {Title}");
            Console.WriteLine($"Issue Number    : {IssueNumber}");
            Console.WriteLine($"Publisher       : {Publisher}");
            Console.WriteLine($"PublicationYear : {PublicationYear}");
            Console.WriteLine();
        }
    }
}
