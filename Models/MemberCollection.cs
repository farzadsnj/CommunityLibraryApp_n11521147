using System;
using System.Collections.Generic;

namespace CommunityLibraryApp_n11521147.Models
{
    public class MemberCollection
    {
        private Member?[] members; // Change to nullable Member array.
        private int count;

        // Constructor
        public MemberCollection(int size)
        {
            members = new Member?[size]; // Initialize with nullable type.
            count = 0;
        }

        // Add a new member
        public void AddMember(Member member)
        {
            if (count < members.Length)
            {
                members[count] = member;
                count++;
            }
            else
            {
                Console.WriteLine("Member collection is full.");
            }
        }

        // Remove a member by name
        public bool RemoveMember(string firstName, string lastName)
        {
            for (int i = 0; i < count; i++)
            {
                if (members[i] != null && members[i]!.FirstName == firstName && members[i]!.LastName == lastName)
                {
                    members[i] = members[count - 1];
                    members[count - 1] = null; // Safe assignment with nullable type.
                    count--;
                    return true;
                }
            }
            return false;
        }

        // Search for a member by name
        public Member? FindMember(string firstName, string lastName)
        {
            foreach (var member in members)
            {
                if (member != null && member.FirstName == firstName && member.LastName == lastName)
                {
                    return member;
                }
            }
            return null;
        }

        // Get all members
        public List<Member> GetAllMembers()
        {
            var allMembers = new List<Member>();
            for (int i = 0; i < count; i++)
            {
                if (members[i] != null)
                {
                    allMembers.Add(members[i]!); // Use null-forgiving operator
                }
            }
            return allMembers;
        }

        // List all members
        public void ListAllMembers()
        {
            Console.WriteLine("Registered Members:");
            for (int i = 0; i < count; i++)
            {
                if (members[i] != null)
                {
                    Console.WriteLine($"{members[i]!.FirstName} {members[i]!.LastName}");
                }
            }
        }
    }
}
