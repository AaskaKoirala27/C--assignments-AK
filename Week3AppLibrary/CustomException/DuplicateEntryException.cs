// File: CustomException/DuplicateEntryException.cs
// Thrown when trying to add a duplicate Book or Magazine

using System;

namespace Week3AppLibrary.CustomException
{
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException() { }

        public DuplicateEntryException(string message) : base(message) { }

        public DuplicateEntryException(string message, Exception inner) : base(message, inner) { }
    }
}
