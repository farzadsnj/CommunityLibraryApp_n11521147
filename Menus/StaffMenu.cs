using CommunityLibraryApp_n11521147.Services;
using CommunityLibraryApp_n11521147.Utils;
using System;

namespace CommunityLibraryApp_n11521147.Menus
{
    public class StaffMenu
    {
        private readonly MovieServices _movieService;
        private readonly MemberService _memberService;

        public StaffMenu(MovieServices movieService, MemberService memberService)
        {
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            _memberService = memberService ?? throw new ArgumentNullException(nameof(memberService));
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Staff Menu");
                Console.WriteLine("1. Add DVDs of a new movie to the system");
                Console.WriteLine("2. Add new DVDs of an existing movie to the system");
                Console.WriteLine("3. Remove a DVD from the system");
                Console.WriteLine("4. Register a new member to the system");
                Console.WriteLine("5. Remove a registered member from the system");
                Console.WriteLine("6. Find a member's contact phone number");
                Console.WriteLine("7. Find members currently renting a particular movie");
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
                        AddNewMovie();
                        break;
                    case "2":
                        AddDVDsToExistingMovie();
                        break;
                    case "3":
                        RemoveMovie();
                        break;
                    case "4":
                        RegisterMember();
                        break;
                    case "5":
                        RemoveMember();
                        break;
                    case "6":
                        FindMemberPhoneNumber();
                        break;
                    case "7":
                        FindMembersRentingMovie();
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

        private void AddNewMovie()
        {
            Console.Write("Enter movie title: ");
            string? title = Console.ReadLine();
            if (!InputValidation.IsValidString(title, "Movie title"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter genre: ");
            string? genre = Console.ReadLine();
            if (!InputValidation.IsValidString(genre, "Genre"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter classification: ");
            string? classification = Console.ReadLine();
            if (!InputValidation.IsValidString(classification, "Classification"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter duration (in minutes): ");
            if (!int.TryParse(Console.ReadLine(), out int duration))
            {
                Console.WriteLine("Invalid duration. Please enter a valid number.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter number of copies: ");
            if (!int.TryParse(Console.ReadLine(), out int copies))
            {
                Console.WriteLine("Invalid number of copies. Please enter a valid number.");
                Console.ReadKey();
                return;
            }

            _movieService.AddNewMovie(title!, genre!, classification!, duration, copies);
            Console.WriteLine("Movie added successfully. Press any key to continue.");
            Console.ReadKey();
        }

        private void AddDVDsToExistingMovie()
        {
            Console.Write("Enter the movie title to add more DVDs: ");
            string? title = Console.ReadLine();
            if (!InputValidation.IsValidString(title, "Movie title"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter number of copies to add: ");
            if (!int.TryParse(Console.ReadLine(), out int copies))
            {
                Console.WriteLine("Invalid number of copies. Please enter a valid number.");
                Console.ReadKey();
                return;
            }

            var movie = _movieService.GetMovieDetails(title!);
            if (movie != null)
            {
                movie.NumberOfCopies += copies;
                Console.WriteLine($"Added {copies} copies to the movie \"{title}\". Total copies now: {movie.NumberOfCopies}.");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void RemoveMovie()
        {
            Console.Write("Enter the title of the movie to remove: ");
            string? title = Console.ReadLine();
            if (!InputValidation.IsValidString(title, "Movie title"))
            {
                Console.ReadKey();
                return;
            }

            _movieService.RemoveMovie(title!);
            Console.WriteLine("Movie removed successfully. Press any key to continue.");
            Console.ReadKey();
        }

        private void RegisterMember()
        {
            Console.Write("Enter first name: ");
            string? firstName = Console.ReadLine();
            if (!InputValidation.IsValidString(firstName, "First name"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter last name: ");
            string? lastName = Console.ReadLine();
            if (!InputValidation.IsValidString(lastName, "Last name"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter phone number: ");
            string? phoneNumber = Console.ReadLine();
            if (!InputValidation.IsValidString(phoneNumber, "Phone number"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter password: ");
            string? password = Console.ReadLine();
            if (!InputValidation.IsValidString(password, "Password"))
            {
                Console.ReadKey();
                return;
            }

            _memberService.RegisterMember(firstName!, lastName!, phoneNumber!, password!);
            Console.WriteLine("Member registered successfully. Press any key to continue.");
            Console.ReadKey();
        }

        private void RemoveMember()
        {
            Console.Write("Enter first name: ");
            string? firstName = Console.ReadLine();
            if (!InputValidation.IsValidString(firstName, "First name"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter last name: ");
            string? lastName = Console.ReadLine();
            if (!InputValidation.IsValidString(lastName, "Last name"))
            {
                Console.ReadKey();
                return;
            }

            _memberService.RemoveMember(firstName!, lastName!);
            Console.WriteLine("Member removed successfully. Press any key to continue.");
            Console.ReadKey();
        }

        private void FindMemberPhoneNumber()
        {
            Console.Write("Enter first name: ");
            string? firstName = Console.ReadLine();
            if (!InputValidation.IsValidString(firstName, "First name"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter last name: ");
            string? lastName = Console.ReadLine();
            if (!InputValidation.IsValidString(lastName, "Last name"))
            {
                Console.ReadKey();
                return;
            }

            var member = _memberService.FindMemberByName(firstName!, lastName!);
            if (member != null)
            {
                Console.WriteLine($"Phone Number: {member.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void FindMembersRentingMovie()
        {
            Console.Write("Enter the movie title: ");
            string? title = Console.ReadLine();
            if (!InputValidation.IsValidString(title, "Movie title"))
            {
                Console.ReadKey();
                return;
            }

            var rentingMembers = _memberService.FindMembersRentingMovie(title!);
            if (rentingMembers.Count > 0)
            {
                Console.WriteLine("Members currently renting the movie:");
                foreach (var member in rentingMembers)
                {
                    Console.WriteLine($"{member.FirstName} {member.LastName}");
                }
            }
            else
            {
                Console.WriteLine("No members are currently renting this movie or the movie does not exist.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
