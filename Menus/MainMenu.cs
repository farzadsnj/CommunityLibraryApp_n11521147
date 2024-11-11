using CommunityLibraryApp_n11521147.Services;
using CommunityLibraryApp_n11521147.Utils;
using System;
using System.Text;

namespace CommunityLibraryApp_n11521147.Menus
{
    public class MainMenu
    {
        private readonly AuthenticationService _authenticationService;
        private readonly StaffMenu _staffMenu;
        private readonly MemberMenu _memberMenu;

        public MainMenu(AuthenticationService authenticationService, StaffMenu staffMenu, MemberMenu memberMenu)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            _staffMenu = staffMenu ?? throw new ArgumentNullException(nameof(staffMenu));
            _memberMenu = memberMenu ?? throw new ArgumentNullException(nameof(memberMenu));
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("COMMUNITY LIBRARY MOVIE DVD MANAGEMENT SYSTEM");
                Console.WriteLine("=====================================");
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Staff");
                Console.WriteLine("2. Member");
                Console.WriteLine("0. End the program");
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
                        AuthenticateStaff();
                        break;
                    case "2":
                        AuthenticateMember();
                        break;
                    case "0":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AuthenticateStaff()
        {
            Console.Write("Enter staff username: ");
            string? username = Console.ReadLine();
            if (!InputValidation.IsValidString(username, "Username"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter staff password: ");
            string? password = ReadPassword();
            if (!InputValidation.IsValidString(password, "Password"))
            {
                Console.ReadKey();
                return;
            }

            if (_authenticationService.AuthenticateStaff(username!, password!))
            {
                _staffMenu.Display();
            }
            else
            {
                Console.WriteLine("Authentication failed. Press any key to continue.");
                Console.ReadKey();
            }
        }

        private void AuthenticateMember()
        {
            Console.Write("Enter your first name: ");
            string? firstName = Console.ReadLine();
            if (!InputValidation.IsValidString(firstName, "First name"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter your last name: ");
            string? lastName = Console.ReadLine();
            if (!InputValidation.IsValidString(lastName, "Last name"))
            {
                Console.ReadKey();
                return;
            }

            Console.Write("Enter your password: ");
            string? password = ReadPassword();
            if (!InputValidation.IsValidString(password, "Password"))
            {
                Console.ReadKey();
                return;
            }

            if (_authenticationService.AuthenticateMember(_memberMenu.MemberCollection, firstName!, lastName!, password!))
            {
                _memberMenu.Display();
            }
            else
            {
                Console.WriteLine("Authentication failed. Press any key to continue.");
                Console.ReadKey();
            }
        }

        private string ReadPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    password.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return password.ToString();
        }
    }
}
