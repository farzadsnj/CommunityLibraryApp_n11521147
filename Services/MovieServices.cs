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
            _movieCollection = movieCollection ?? throw new ArgumentNullException(nameof(movieCollection));
        }

        public List<Movie> GetAllMovies()
        {
            return _movieCollection.GetAllMovies();
        }

        public void AddNewMovie(string title, string genre, string classification, int duration, int copies)
        {
            var movie = new Movie(title, genre, classification, duration, copies);
            _movieCollection.AddMovie(movie);
            Console.WriteLine("Movie added successfully.");
        }

        public void RemoveMovie(string title)
        {
            bool result = _movieCollection.RemoveMovie(title);
            Console.WriteLine(result ? "Movie removed successfully." : "Movie not found.");
        }

        public Movie? GetMovieDetails(string title)
        {
            return _movieCollection.FindMovie(title);
        }

        public void DisplayAllMovies()
        {
            var movies = GetAllMovies();
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
