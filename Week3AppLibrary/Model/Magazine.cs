// File: Model/Magazine.cs
// Represents a Magazine, which is a type of Item
// Adds IssueNumber property with validation

using System;
using Week3AppLibrary.CustomException;

namespace Week3AppLibrary.Model
{
    public class Magazine : Item
    {
        private int _issueNumber; // private field for IssueNumber

        // ---------- Constructors ----------
        public Magazine() : base() { }

        public Magazine(string title, string publisher, int publicationYear, int issueNumber)
            : base(title, publisher, publicationYear)
        {
            IssueNumber = issueNumber; // validation occurs in property
        }

        // ---------- IssueNumber Property ----------
        // Must be positive integer
        public int IssueNumber
        {
            get => _issueNumber;
            set
            {
                if (value <= 0)
                    throw new InvalidItemDataException("Issue number must be positive.");
                _issueNumber = value;
            }
        }

        // ---------- Display Info ----------
        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}, Issue Number: {IssueNumber}");
        }
    }
}
