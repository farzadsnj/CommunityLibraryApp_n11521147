using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityLibraryApp_n11521147.Models
{
    public class MovieCollection
    {
        private class MovieNode
        {
            public string Key { get; set; } = string.Empty; // Default non-null value to avoid CS8618
            public Movie Value { get; set; } = new Movie("Untitled", "Unknown", "G", 0, 0); // Default to a new instance
            public MovieNode? Next { get; set; }
        }

        private MovieNode?[] movies; // Allow the array to store null values
        private int capacity;

        // Constructor
        public MovieCollection(int size)
        {
            movies = new MovieNode?[size]; // Allow the array to store null values
            capacity = size;
        }

        // Hash function
        private int GetHash(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash = (hash * 31 + c) % capacity;
            }
            return hash;
        }

        // Add a movie
        public void AddMovie(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie)); // Added null check
            int index = GetHash(movie.Title);
            MovieNode newNode = new MovieNode { Key = movie.Title, Value = movie, Next = movies[index] };
            movies[index] = newNode;
        }

        // Find a movie by title
        public Movie? FindMovie(string title)
        {
            if (string.IsNullOrEmpty(title)) return null; // Check for null or empty title

            int index = GetHash(title);
            MovieNode? current = movies[index];

            while (current != null)
            {
                if (current.Key == title)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        // Remove a movie by title
        public bool RemoveMovie(string title)
        {
            if (string.IsNullOrEmpty(title)) return false; // Check for null or empty title

            int index = GetHash(title);
            MovieNode? current = movies[index];
            MovieNode? prev = null;

            while (current != null)
            {
                if (current.Key == title)
                {
                    if (prev == null)
                    {
                        movies[index] = current.Next; // This line assigns `null` safely to the array
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    return true;
                }
                prev = current;
                current = current.Next;
            }
            return false;
        }

        // Get all movies
        public List<Movie> GetAllMovies()
        {
            var allMovies = new List<Movie>();
            foreach (var movieNode in movies)
            {
                var current = movieNode;
                while (current != null)
                {
                    allMovies.Add(current.Value);
                    current = current.Next;
                }
            }
            return allMovies;
        }
    }
}
