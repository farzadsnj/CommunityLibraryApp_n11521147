using System;
using CommunityLibraryApp_n11521147.Models;
using CommunityLibraryApp_n11521147.Services;
using CommunityLibraryApp_n11521147.Menus;

namespace CommunityLibraryApp_n11521147
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize data collections
            var memberCollection = new MemberCollection(100);
            var movieCollection = new MovieCollection(1000);

            // Add sample member data
            memberCollection.AddMember(new Member("John", "Doe", "1234567890", "password123"));
            memberCollection.AddMember(new Member("Alice", "Smith", "9876543210", "alicepass"));

            // Add sample movie data
            movieCollection.AddMovie(new Movie("Inception", "Sci-Fi", "PG-13", 148, 5));
            movieCollection.AddMovie(new Movie("The Matrix", "Sci-Fi", "R", 136, 3));
            movieCollection.AddMovie(new Movie("Titanic", "Drama", "PG-13", 195, 2));
            movieCollection.AddMovie(new Movie("The Godfather", "Crime", "R", 175, 4));

            // Initialize services
            var memberService = new MemberService(memberCollection);
            var movieService = new MovieServices(movieCollection);
            var authenticationService = new AuthenticationService();

            // Initialize menus
            var staffMenu = new StaffMenu(movieService, memberService);
            var memberMenu = new MemberMenu(memberCollection, movieService, memberService); // Pass memberService here
            var mainMenu = new MainMenu(authenticationService, staffMenu, memberMenu);

            // Run the main menu
            mainMenu.Display();
        }
    }
}
