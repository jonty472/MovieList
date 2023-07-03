using System.Runtime.CompilerServices;

namespace MovieList.MovieList1
{
    internal class Program
    {
        static void Main(string[] args)
        {



            MovieList mylist = new MovieList("Movie List");

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(mylist);
            }

        }

        private static bool MainMenu(MovieList list)
        {
            Console.Clear();
            Console.WriteLine(list.GetMovieList());
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add movie");
            Console.WriteLine("2) Remove movie");
            Console.WriteLine("3) Clear movie list");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                case "1":
                    list.AddMovie(1);
                    return true;
                case "2":
                    ;
                    return true;
                case "3":
                    list.Clear();
                    return true;
                case "4":
                    return false;

            }
            return true;
        }
    }
}