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
 * testing
 */
namespace MovieList
{
    public class MovieList
    {
        public List<Movie> ListOfMovies = new List<Movie>();

        public string ListName { get; set; }
        public MovieList(string listname)
        {
            this.ListName = listname;
        }
        public void AddMovie(int NumberOfMovies)
        {
            for (int i = 0; i < NumberOfMovies; i++)
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
        public int ReleaseDate { get; set; }
        public double Rating { get; set; }
        public DateTime AddedDate { get; set; }

        public int MovieRank { get; set; }

        public Movie(string title, int releaseDate, double rating, DateTime addeddate)
        {
            this.Name = MovieID.ToString();
            MovieID++;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.Rating = rating;
            this.AddedDate = addeddate;
            this.MovieRank = 0;
        }   
    }
}


