using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CommunityLibraryApp_n11521147.Models;
using CommunityLibraryApp_n11521147.Services;

namespace CommunityLibraryApp_n11521147.Menus
{
    public class MemberMenu
    {
        public MemberCollection MemberCollection { get; }
        private readonly MovieServices _movieService;
        private readonly MemberService _memberService;

        public MemberMenu(MemberCollection memberCollection, MovieServices movieService, MemberService memberService)
        {
            MemberCollection = memberCollection ?? throw new ArgumentNullException(nameof(memberCollection));
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            _memberService = memberService ?? throw new ArgumentNullException(nameof(memberService));
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

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Movie title cannot be empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            var movie = _movieService.GetMovieDetails(title);
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
            Console.Write("Enter your first name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string? lastName = Console.ReadLine();

            var member = _memberService.FindMemberByName(firstName ?? "", lastName ?? "");
            if (member == null)
            {
                Console.WriteLine("Member not found. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter the title of the movie to borrow: ");
            string? movieTitle = Console.ReadLine();
            var movie = _movieService.GetMovieDetails(movieTitle ?? "");

            if (movie == null)
            {
                Console.WriteLine("Movie not found. Press any key to continue.");
            }
            else if (movie.NumberOfCopies <= 0)
            {
                Console.WriteLine("No copies available. Press any key to continue.");
            }
            else
            {
                member.BorrowedMovies.Add(movie.Title);
                movie.NumberOfCopies--;
                movie.TimesRented++; // Increment rental count for top rented movies
                Console.WriteLine("Movie borrowed successfully. Press any key to continue.");
            }

            Console.ReadKey();
        }

        private void ReturnMovie()
        {
            Console.Write("Enter your first name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string? lastName = Console.ReadLine();

            var member = _memberService.FindMemberByName(firstName ?? "", lastName ?? "");
            if (member == null)
            {
                Console.WriteLine("Member not found. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter the title of the movie to return: ");
            string? movieTitle = Console.ReadLine();
            if (member.BorrowedMovies.Remove(movieTitle ?? ""))
            {
                var movie = _movieService.GetMovieDetails(movieTitle ?? "");
                if (movie != null)
                {
                    movie.NumberOfCopies++;
                    Console.WriteLine("Movie returned successfully. Press any key to continue.");
                }
            }
            else
            {
                Console.WriteLine("You did not borrow this movie. Press any key to continue.");
            }

            Console.ReadKey();
        }

        private void ListBorrowingMovies()
        {
            Console.Write("Enter your first name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string? lastName = Console.ReadLine();

            var member = _memberService.FindMemberByName(firstName ?? "", lastName ?? "");
            if (member == null)
            {
                Console.WriteLine("Member not found. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            _memberService.ListBorrowedMovies(member);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void DisplayTop3Movies()
        {
            var allMovies = _movieService.GetAllMovies();
            var topMovies = allMovies
                .OrderByDescending(m => m.TimesRented)
                .Take(3)
                .ToList();

            Console.WriteLine("Top 3 Most Rented Movies:");
            foreach (var movie in topMovies)
            {
                Console.WriteLine($"{movie.Title} - Rented {movie.TimesRented} times");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
