using Movies.Workshop.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Workshop.V1
{
    public static class StaticDB
    {
        public static List<Models.Movie> Movies = new List<Models.Movie>()
        {
            new Models.Movie()
            {
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Year = 1994,
                Genre = "Drama"
            },
            new Models.Movie()
            {
                Title = "The Godfather",
                Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                Year = 1972,
                Genre = "Drama"
            },
            new Models.Movie()
            {
                Title = "The Dark Knight",
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                Year = 2008,
                Genre = "Action"
            }
        };
    }
}
