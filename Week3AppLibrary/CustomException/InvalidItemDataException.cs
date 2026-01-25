// File: CustomException/InvalidItemDataException.cs
// Thrown when invalid data is assigned to an Item, Book, or Magazine

using System;

namespace Week3AppLibrary.CustomException
{
    public class InvalidItemDataException : Exception
    {
        public InvalidItemDataException() { }

        public InvalidItemDataException(string message) : base(message) { }

        public InvalidItemDataException(string message, Exception inner) : base(message, inner) { }
    }
}
