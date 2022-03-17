using System;
using System.Collections.Generic;
using System.Linq;

namespace movies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieContext db = new MovieContext();

            foreach (var movie in MovieCreator.CreateMovies())
                db.Movies.Add(movie);

            db.SaveChanges();

            foreach (var movie in db.Movies)
                Console.WriteLine("\t> " + movie);

            // =============================================================================

            foreach (var movie in db.Movies)
            {
                bool result = Validator.IsValid<Movie>("YearOfRelease", movie);
                Console.WriteLine(result);
            }

            // =============================================================================

            var q1 = from x in db.Movies
                     group x by x.Genre into g
                     select new
                     {
                         Genre = g.Key,
                         Number = g.Count()
                     };

            var q2 = from x in db.Movies
                     where x.YearOfRelease < 1994
                     orderby x.Title.Length descending
                     select x;

            var q3 = from x in db.Movies.ToList() // to list needed unfortunately
                     group x by x.Genre into g
                        let longestTitleLength = g.Max(m => m.Title.Length)
                     select new
                     {
                         Genre = g.Key,
                         Title = g.First(y => y.Title.Length == longestTitleLength).Title,
                         YearOfRelease = g.First(y => y.Title.Length == longestTitleLength).YearOfRelease,
                     };

            ;

        }
    }
}