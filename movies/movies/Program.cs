using System;

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
        }
    }
}
