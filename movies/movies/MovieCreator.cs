using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace movies
{
    public static class MovieCreator
    {
        public static IEnumerable<Movie> CreateMovies()
        {
            Func<string, IEnumerable<Movie>> func = (x) =>
            {
                List<Movie> movies = new List<Movie>();
                XDocument xdoc = XDocument.Load(x);

                foreach (XElement movieNode in xdoc.Descendants("Movie"))
                {
                    Movie m = new Movie();
                    m.Title = movieNode.Element("Title").Value;
                    m.Genre = movieNode.Element("Genre").Value;
                    m.YearOfRelease = int.Parse(movieNode.Element("YearOfRelease").Value);
                    movies.Add(m);
                }

                return movies;
            };

            return func("https://users.nik.uni-obuda.hu/siposm/db/movies.xml");
        }
    }
}
