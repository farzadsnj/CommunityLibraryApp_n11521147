using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommunityLibraryApp_n11521147.Utils
{
    internal static class InputValidation
    {
        public static bool IsValidString(string? input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"{fieldName} cannot be empty. Please provide a valid {fieldName.ToLower()}.");
                return false;
            }
            return true;
        }
    }
}