using System;

namespace Week3AppLibrary.Exceptions
{
    // Custom exception thrown when invalid data is entered
    public class InvalidItemDataException : Exception
    {
        public InvalidItemDataException(string message) : base(message) { }
    }
}
