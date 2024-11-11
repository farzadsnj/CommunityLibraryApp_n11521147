using CommunityLibraryApp_n11521147.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CommunityLibraryApp_n11521147.Services
{
    public class AuthenticationService
    {
        public bool AuthenticateStaff(string username, string password)
        {
            if (username == "staff" && password == "today123")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid staff credentials.");
                return false;
            }
        }
        
        public bool AuthenticateMember(MemberCollection memberCollection, string firstName, string lastName, string password)
        {
            var member = memberCollection.FindMember(firstName, lastName);
            if (member != null && member.Password == password)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid member credentials.");
                return false;
            }
        }
    }
}
