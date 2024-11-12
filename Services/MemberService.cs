using CommunityLibraryApp_n11521147.Models;
using System;
using System.Collections.Generic;

namespace CommunityLibraryApp_n11521147.Services
{
    public class MemberService
    {
        private readonly MemberCollection _memberCollection; // Ensure the naming is consistent

        public MemberService(MemberCollection memberCollection)
        {
            _memberCollection = memberCollection ?? throw new ArgumentNullException(nameof(memberCollection));
        }

        public void RegisterMember(string firstName, string lastName, string phoneNumber, string password)
        {
            var member = new Member(firstName, lastName, phoneNumber, password);
            _memberCollection.AddMember(member);
            Console.WriteLine("Member registered successfully.");
        }

        public bool RemoveMember(string firstName, string lastName)
        {
            bool result = _memberCollection.RemoveMember(firstName, lastName);
            Console.WriteLine(result ? "Member removed successfully." : "Member not found.");
            return result;
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

        public List<Member> FindMembersRentingMovie(string movieTitle)
        {
            var rentingMembers = new List<Member>();

            foreach (var member in _memberCollection.GetAllMembers())
            {
                if (member != null && member.BorrowedMovies.Contains(movieTitle))
                {
                    rentingMembers.Add(member);
                }
            }

            return rentingMembers;
        }

        public List<Member> GetAllMembers()
        {
            return _memberCollection.GetAllMembers();
        }
    }
}
