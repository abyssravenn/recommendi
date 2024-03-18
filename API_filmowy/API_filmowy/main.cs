using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;

class Program
{
    static async Task Main()
    {
        string PrettyJSON(string unPrettyJSON)
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };//format
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJSON);
            return JsonSerializer.Serialize(jsonElement, options);
        }

        using (WebClient wc = new WebClient()) //biblioteka 
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/movie/changes?page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmM2EyZTk5OTM2MzA3NmI2Zjc5M2FhZjE4NGNjOTM2ZCIsInN1YiI6IjY1ZjQyYjZjNWI5NTA4MDE4NTFiZjM5NiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.exWtAOU8aQzSMp_55SCSrntuo1fPAn7jvtpudBfbEUI");
            var response = await client.GetAsync(request);
            string pp = PrettyJSON(response.Content);
            Console.WriteLine(pp);
            //Console.WriteLine("{0}", response.Content);
            string imieUzytkownika = Console.ReadLine();
        }
    }
}