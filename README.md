# C--assignments-AK

# Week 4 Library Management System

## Project Overview

This is a **console-based Library Management System** developed in C#. It allows users to manage **Books, Magazines, and Newspapers** in a single system.

The system demonstrates **core object-oriented programming concepts** including:

* **Interface**
* **Abstract class**
* **Inheritance**
* **Encapsulation**
* **Polymorphism**
* **Custom exceptions**

### Key functionalities

* Add new library items (Books, Magazines, Newspapers) with **input validation**
* Detect **duplicate items** using both common and type-specific properties
* Display all library items with **colored console output**
* Maintain a **modular and extensible design**

---

## Folder Structure

```
Week4AppLibrary/
│
├── Program.cs                  # Main console UI
│
├── Interfaces/
│   └── ILibraryItem.cs         # Interface defining library item structure
│
├── Abstract/
│   └── LibraryItemBase.cs      # Abstract base class implementing ILibraryItem with validation
│
├── Models/
│   ├── Book.cs                 # Book class with Author property
│   ├── Magazine.cs             # Magazine class with IssueNumber property
│   └── Newspaper.cs            # Newspaper class with Language property
│
├── Services/
│   └── LibraryService.cs       # Handles adding, duplicate checking, and displaying items
│
└── Exceptions/
    ├── DuplicateItemException.cs
    └── InvalidItemDataException.cs
```

---

## OOP Concepts Implemented

1. **Interface (`ILibraryItem`)**

   * Defines the contract for all library items: `Title`, `Publisher`, `PublicationYear`, and `DisplayInfo()`
   * Ensures all library items follow the same structure

2. **Abstract Class (`LibraryItemBase`)**

   * Implements `ILibraryItem`
   * Provides centralized **validation** for common properties
   * Declares `DisplayInfo()` as abstract for polymorphic behavior

3. **Inheritance**

   * `Book`, `Magazine`, and `Newspaper` inherit from `LibraryItemBase`
   * Each class adds its own specific property (`Author`, `IssueNumber`, `Language`)

4. **Polymorphism**

   * `DisplayInfo()` method is called through base type references (`LibraryItemBase` or `ILibraryItem`)
   * Ensures correct behavior based on actual object type

5. **Encapsulation**

   * All class fields are private or protected
   * Public properties are used with validation in setters

6. **Custom Exceptions**

   * `InvalidItemDataException` for invalid inputs
   * `DuplicateItemException` for duplicate items

---

## How to Run

1. Clone or download the repository.
2. Open the project folder in your terminal.
3. Build the project using:

```
dotnet build
```

4. Run the project using:

```
dotnet run
```

5. Follow the console menu to add or display Books, Magazines, and Newspapers.

### Menu Options

1. Add Book
2. Add Magazine
3. Add Newspaper
4. Display All Items
5. Exit

---

## Notes

* Preloaded items include 5 Books, 3 Magazines, and 1 Newspaper.
* Console output uses **colors** to differentiate item types.
* Duplicate items are not allowed; the system will throw a `DuplicateItemException` if a duplicate is entered.
* All properties are validated; invalid input will throw `InvalidItemDataException`.
* Designed to be modular and extensible for future item types or storage enhancements.
