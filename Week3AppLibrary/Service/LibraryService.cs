using System;
using System.Collections.Generic;
using Week3AppLibrary.Interfaces;
using Week3AppLibrary.Model;
using Week3AppLibrary.Exceptions;

namespace Week3AppLibrary.Service
{
    /*
     * LibraryService acts as the service layer for the library system.
     * 
     * Responsibilities:
     * - Store all library items (Book, Magazine, Newspaper)
     * - Add items with duplicate checking
     * - Display all items polymorphically
     * 
     * Refactored for Week 4 to use ILibraryItem interface
     */
    public class LibraryService
    {
        // List to store all items using interface for polymorphism
        private List<ILibraryItem> _items = new List<ILibraryItem>();

        /*
         * AddItem method adds a new library item to the collection
         * Performs duplicate check based on:
         * - Title
         * - Publisher
         * - PublicationYear
         * - Type-specific property (Author, IssueNumber, Language)
         */
        public void AddItem(ILibraryItem newItem)
        {
            foreach (var existingItem in _items)
            {
                if (IsDuplicate(existingItem, newItem))
                {
                    throw new DuplicateItemException(
                        $"Duplicate detected: {newItem.Title} already exists."
                    );
                }
            }

            // If no duplicates, add the item
            _items.Add(newItem);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Item added successfully: {newItem.Title}");
            Console.ResetColor();
        }

        /*
         * Method to check if two items are duplicates
         * Compares common properties and type-specific property
         */
        private bool IsDuplicate(ILibraryItem existingItem, ILibraryItem newItem)
        {
            // Compare common properties first
            bool commonMatch =
                existingItem.Title == newItem.Title &&
                existingItem.Publisher == newItem.Publisher &&
                existingItem.PublicationYear == newItem.PublicationYear;

            if (!commonMatch)
                return false; // Not a duplicate if common properties differ

            // Now compare type-specific property based on type
            if (existingItem is Book existingBook && newItem is Book newBook)
                return existingBook.Author == newBook.Author;

            if (existingItem is Magazine existingMagazine && newItem is Magazine newMagazine)
                return existingMagazine.IssueNumber == newMagazine.IssueNumber;

            if (existingItem is Newspaper existingNewspaper && newItem is Newspaper newNewspaper)
                return existingNewspaper.Language == newNewspaper.Language;

            // Different types are never considered duplicates
            return false;
        }

        /*
         * DisplayAllItems prints all library items
         * Uses polymorphic DisplayInfo() method
         */
        public void DisplayAllItems()
        {
            foreach (var item in _items)
            {
                item.DisplayInfo(); // Polymorphic call
            }
        }

        /*
         * GetAllItems returns a copy of the item list
         * This prevents external modification of the internal list
         */
        public List<ILibraryItem> GetAllItems()
        {
            return new List<ILibraryItem>(_items);
        }
    }
}
