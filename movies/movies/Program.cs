using System;

namespace movies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieContext context = new MovieContext();
            context.Movies.Add(new Movie()
            {
                Title = "AAA111",
                Genre = "Horror",
                YearOfRelease = 2022
            });
            context.SaveChanges();

            foreach (var movie in context.Movies)
                Console.WriteLine(movie);
        }
    }
}
