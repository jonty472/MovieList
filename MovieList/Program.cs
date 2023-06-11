namespace MovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieList test = new MovieList("my list");
            test.AddMovie(2);
            Console.WriteLine(test.GetMovieList());
        }
    }
}