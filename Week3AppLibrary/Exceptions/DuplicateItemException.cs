using System;

namespace Week3AppLibrary.Exceptions
{
    // Custom exception thrown when duplicate library item is added
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}
