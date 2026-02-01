using System;

namespace Week3AppLibrary.Interfaces
{
    /*
     * ILibraryItem is an INTERFACE.
     * 
     * An interface only declares WHAT a class must have,
     * not HOW it is implemented.
     * 
     * Any class that implements this interface must:
     *  - Have Title, Publisher, PublicationYear
     *  - Have a method to display item details
     */

    public interface ILibraryItem
    {
        // Property to store the title of the item
        // Example: "The Great Gatsby"
        string Title { get; set; }

        // Property to store the publisher name
        // Example: "Scribner"
        string Publisher { get; set; }

        // Property to store the year of publication
        // Example: 1925
        int PublicationYear { get; set; }

        /*
         * Method that forces every library item
         * to define how its details are displayed.
         * 
         * Book and Magazine will display differently,
         * but BOTH must have this method.
         */
        void DisplayInfo();
    }
}
