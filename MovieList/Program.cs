using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace MovieList
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/search/movie?api_key=4cc1b68a07fe5ba265950e85ac96cb2c&query=OldBoy&year=2003");
            response.EnsureSuccessStatusCode();
            string requestBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(requestBody);
        }
    }
}
