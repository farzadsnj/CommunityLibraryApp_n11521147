using CommunityLibraryApp_n11521147.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityLibraryApp_n11521147.Services
{
    public class MemberService
    {
        private MemberCollection _memberCollection;

        public MemberService(MemberCollection memberCollection)
        {
            _memberCollection = memberCollection;
        }

        public void RegisterMember(string firstName, string lastName, string phoneNumber, string password)
        {
            var member = new Member(firstName, lastName, phoneNumber, password);
            _memberCollection.AddMember(member);
            Console.WriteLine("Member registered successfully.");
        }

        public void RemoveMember(string firstName, string lastName)
        {
            bool result = _memberCollection.RemoveMember(firstName, lastName);
            Console.WriteLine(result ? "Member removed successfully." : "Member not found.");
        }

        public Member? FindMemberByName(string firstName, string lastName)
        {
            return _memberCollection.FindMember(firstName, lastName);
        }

        public void ListBorrowedMovies(Member member)
        {
            if (member.BorrowedMovies.Count == 0)
            {
                Console.WriteLine("No borrowed movies.");
                return;
            }

            Console.WriteLine("Borrowed Movies:");
            foreach (var movie in member.BorrowedMovies)
            {
                Console.WriteLine($"- {movie}");
            }
        }
    }
}
