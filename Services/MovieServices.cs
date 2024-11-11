using CommunityLibraryApp_n11521147.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityLibraryApp_n11521147.Services
{
    public class MovieServices
    {
        private MovieCollection _movieCollection;

        public MovieServices(MovieCollection movieCollection)
        {
            _movieCollection = movieCollection;
        }

        public void AddNewMovie(string title, string genre, string classification, int duration, int copies)
        {
            var movie = new Movie
            {
                Title = title,
                Genre = genre,
                Classification = classification,
                Duration = duration,
                NumberOfCopies = copies
            };
            _movieCollection.AddMovie(movie);
            Console.WriteLine("Movie added successfully.");
        }

        public void RemoveMovie(string title)
        {
            bool result = _movieCollection.RemoveMovie(title);
            if (result)
            {
                Console.WriteLine("Movie removed successfully.");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }

        public Movie? GetMovieDetails(string title)
        {
            return _movieCollection.FindMovie(title);
        }

        public void DisplayAllMovies()
        {
            var movies = _movieCollection.GetAllMovies();
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available.");
                return;
            }

            Console.WriteLine("Movies in the library:");
            foreach (var movie in movies)
            {
                Console.WriteLine($"- {movie.Title} ({movie.NumberOfCopies} copies available)");
            }
        }
    }
}
