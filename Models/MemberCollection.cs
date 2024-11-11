using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunityLibraryApp_n11521147.Models
{
    public class MovieCollection
    {
        private Dictionary<string, Movie> movieDictionary;

        // Constructor
        public MovieCollection()
        {
            movieDictionary = new Dictionary<string, Movie>();
        }

        // Add a movie to the collection
        public void AddMovie(Movie movie)
        {
            if (!movieDictionary.ContainsKey(movie.Title))
            {
                movieDictionary[movie.Title] = movie;
                Console.WriteLine("Movie added successfully.");
            }
            else
            {
                Console.WriteLine("Movie already exists in the collection.");
            }
        }

        // Remove a movie from the collection
        public bool RemoveMovie(string title)
        {
            if (movieDictionary.Remove(title))
            {
                Console.WriteLine("Movie removed successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Movie not found.");
                return false;
            }
        }

        // Find a movie in the collection
        public Movie? FindMovie(string title)
        {
            movieDictionary.TryGetValue(title, out Movie? movie);
            return movie;
        }

        // Get all movies as a list
        public List<Movie> GetAllMovies()
        {
            return movieDictionary.Values.ToList();
        }
    }
}
