using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityLibraryApp_n11521147.Models
{
    public class MovieCollection
    {
        private class MovieNode
        {
            public string Key { get; set; }
            public Movie Value { get; set; }
            public MovieNode Next { get; set; }
        }

        private MovieNode[] movies;
        private int capacity;

        // Constructor
        public MovieCollection(int size)
        {
            movies = new MovieNode[size];
            capacity = size;
        }

        // Hash function
        private int GetHash(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash = (hash * 31 + c) % capacity;
            }
            return hash;
        }

        // Add a movie
        public void AddMovie(Movie movie)
        {
            int index = GetHash(movie.Title);
            MovieNode newNode = new MovieNode { Key = movie.Title, Value = movie, Next = movies[index] };
            movies[index] = newNode;
        }

        // Find a movie by title
        public Movie FindMovie(string title)
        {
            int index = GetHash(title);
            MovieNode current = movies[index];

            while (current != null)
            {
                if (current.Key == title)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        // Remove a movie by title
        public void RemoveMovie(string title)
        {
            int index = GetHash(title);
            MovieNode current = movies[index];
            MovieNode prev = null;

            while (current != null)
            {
                if (current.Key == title)
                {
                    if (prev == null)
                    {
                        movies[index] = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    Console.WriteLine("Movie removed.");
                    return;
                }
                prev = current;
                current = current.Next;
            }
            Console.WriteLine("Movie not found.");
        }
    }
}
