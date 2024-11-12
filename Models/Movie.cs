using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityLibraryApp_n11521147.Models
{
    public class Movie
    {
        // Properties
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Classification { get; set; }
        public int Duration { get; set; }
        public int NumberOfCopies { get; set; }
        public int TimesRented { get; set; } // Property to track the number of times the movie is rented

        // Constructor
        public Movie(string title, string genre, string classification, int duration, int numberOfCopies)
        {
            Title = title;
            Genre = genre;
            Classification = classification;
            Duration = duration;
            NumberOfCopies = numberOfCopies;
            TimesRented = 0; // Initialize TimesRented to 0
        }

        // Method to display movie information
        public void DisplayMovieInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Classification: {Classification}");
            Console.WriteLine($"Duration: {Duration} minutes");
            Console.WriteLine($"Copies Available: {NumberOfCopies}");
            Console.WriteLine($"Times Rented: {TimesRented}");
        }
    }
}
