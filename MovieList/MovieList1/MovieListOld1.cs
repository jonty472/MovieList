using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

/*
 * MVP:
 * add/remove/clear movies
 * establish rules around what data can be entered (exceptions)
 * display movies in a presentable way
 * have a menu that links to functions
 */
namespace MovieList.MovieList1
{
    public class MovieListOld1
    {
        public List<Movie> ListOfMovies = new List<Movie>();

        public string ListName { get; set; }
        public MovieListOld1(string listname)
        {
            ListName = listname;
        }


        public void AddMovie(int NumberOfMovies)
        {
            for (int i = 0; i < NumberOfMovies; i++)
            {
                try
                {

                    Console.Write("Movie Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Release Date: ");
                    string releasedate = Console.ReadLine();
                    int releasedateyear = Convert.ToInt32(releasedate);

                    Console.Write("Rating: ");
                    string rating = Console.ReadLine();
                    int ratingInt = Convert.ToInt32(rating);

                    Movie movie = new Movie(title, releasedateyear, ratingInt, DateTime.Now);

                    Console.WriteLine("Movie added to list\n");
                    ListOfMovies.Add(movie);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"requries integar {e}");
                }
            }
        }

        public void RemoveMovie(Movie movie)
        {
            ListOfMovies.Remove(movie);
        }
        public void Clear()
        {
            ListOfMovies.Clear();
        }


        public string GetMovieList()
        {
            var report = new StringBuilder();
            report.AppendLine("Title\tReleaseDate\tUserRating\tMovieID");
            foreach (var movie in ListOfMovies)
            {
                report.AppendLine($"{movie.Title}\t{movie.ReleaseDate}\t\t{movie.Rating}\t\t{movie.Name}");
            }
            return report.ToString();
        }
    }

    public class Movie
    {
        public static int MovieID = 1000;
        public string Name { get; }
        public string Title { get; set; }

        private int _releasedate;
        public int ReleaseDate
        {
            get
            { return _releasedate; }
            set
            {
                if (value < 1885 || value > 2025)
                {
                    throw new Exception("Movies release date needs to be within the years 1885 to 2025");
                }
                else
                { _releasedate = value; }
            }
        }

        private double _rating;
        public double Rating
        {
            get
            { return _rating; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new Exception("Movie Ratings are only between 1-10");
                }
                else
                { _rating = value; }
            }
        }
        public DateTime AddedDate { get; set; }


        public Movie(string title, int releaseDate, double rating, DateTime addeddate)
        {
            Name = MovieID.ToString();
            MovieID++;
            Title = title;
            ReleaseDate = releaseDate;
            Rating = rating;
            AddedDate = addeddate;
        }
    }
}


