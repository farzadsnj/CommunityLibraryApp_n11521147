using System;
using CommunityLibraryApp_n11521147.Models;
using CommunityLibraryApp_n11521147.Services;
using CommunityLibraryApp_n11521147.Utils;

namespace CommunityLibraryApp_n11521147.Menus
{
    public class MemberMenu
    {
        public MemberCollection MemberCollection { get; }
        private readonly MovieServices _movieService;

        public MemberMenu(MemberCollection memberCollection, MovieServices movieService)
        {
            MemberCollection = memberCollection ?? throw new ArgumentNullException(nameof(memberCollection));
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Member Menu");
                Console.WriteLine("1. Browse all the movies");
                Console.WriteLine("2. Display information about a movie");
                Console.WriteLine("3. Borrow a movie DVD");
                Console.WriteLine("4. Return a movie DVD");
                Console.WriteLine("5. List current borrowing movies");
                Console.WriteLine("6. Display the top 3 movies rented by the members");
                Console.WriteLine("0. Return to main menu");
                Console.Write("Enter your choice ==> ");

                string? choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        BrowseMovies();
                        break;
                    case "2":
                        DisplayMovieInfo();
                        break;
                    case "3":
                        BorrowMovie();
                        break;
                    case "4":
                        ReturnMovie();
                        break;
                    case "5":
                        ListBorrowingMovies();
                        break;
                    case "6":
                        DisplayTop3Movies();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void BrowseMovies()
        {
            _movieService.DisplayAllMovies();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void DisplayMovieInfo()
        {
            Console.Write("Enter the title of the movie: ");
            string? title = Console.ReadLine();

            if (!InputValidation.IsValidString(title, "Movie title"))
            {
                Console.ReadKey();
                return;
            }

            var movie = _movieService.GetMovieDetails(title!);
            if (movie != null)
            {
                movie.DisplayMovieInfo();
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void BorrowMovie()
        {
            // Implement borrowing logic
            Console.WriteLine("Feature under development. Press any key to continue.");
            Console.ReadKey();
        }

        private void ReturnMovie()
        {
            // Implement return logic
            Console.WriteLine("Feature under development. Press any key to continue.");
            Console.ReadKey();
        }

        private void ListBorrowingMovies()
        {
            // Implement logic to list borrowed movies for the authenticated member
            Console.WriteLine("Feature under development. Press any key to continue.");
            Console.ReadKey();
        }

        private void DisplayTop3Movies()
        {
            // Implement logic to display top 3 most frequently rented movies
            Console.WriteLine("Feature under development. Press any key to continue.");
            Console.ReadKey();
        }
    }
}
