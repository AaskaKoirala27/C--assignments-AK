// File: Service/LibraryService.cs
// Service layer: manages adding, duplicate checking, and displaying items

using System;
using System.Collections.Generic;
using Week3AppLibrary.Model;
using Week3AppLibrary.CustomException;

namespace Week3AppLibrary.Service
{
    public class LibraryService
    {
        private List<Item> _items = new List<Item>(); // stores all Books and Magazines

        // AddItem: adds a Book or Magazine
        // Throws DuplicateEntryException if item already exists
        public void AddItem(Item item)
        {
            if (item == null)
                throw new InvalidItemDataException("Cannot add a null item.");

            foreach (var existingItem in _items)
            {
                if (existingItem.Title == item.Title &&
                    existingItem.Publisher == item.Publisher &&
                    existingItem.PublicationYear == item.PublicationYear)
                {
                    throw new DuplicateEntryException(
                        $"Item already exists: Title: {item.Title}, Publisher: {item.Publisher}, Year: {item.PublicationYear}");
                }
            }

            _items.Add(item);
            Console.WriteLine($"Item added successfully: Title: {item.Title}, Publisher: {item.Publisher}, Year: {item.PublicationYear}");
        }

        // DisplayAllItems: prints info of all items
        public void DisplayAllItems()
        {
            foreach (var item in _items)
            {
                item.DisplayInfo();
            }
        }

        // GetAllItems: returns a copy of all items for external use
        public List<Item> GetAllItems()
        {
            return new List<Item>(_items);
        }
    }
}
