using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityLibraryApp_n11521147.Models
{
    public class Member
    {
        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<string> BorrowedDVDs { get; set; } // List to track borrowed DVDs

        // Constructor
        public Member(string firstName, string lastName, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Password = password;
            BorrowedDVDs = new List<string>();
        }

        // Method to display member information
        public void DisplayMemberInfo()
        {
            Console.WriteLine($"Member: {FirstName} {LastName}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Borrowed DVDs: {string.Join(", ", BorrowedDVDs)}");
        }
    }
}
