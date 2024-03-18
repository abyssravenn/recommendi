using API_Book;
using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Object;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;


//https://wolnelektury.pl/api/

public class Book
{   //public string applist;
    //public string apps;
    public int herf { get; set; }
    public string title { get; set; }
}


class Program
{

    static void Main()
    {
        string PrettyJSON(string unPrettyJSON)
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJSON);
            return JsonSerializer.Serialize(jsonElement, options);
        }

        using (WebClient wc = new WebClient())
        {
            var json = wc.DownloadString("https://wolnelektury.pl/api/books/?format=json");  // link do listy
                                                                                             //Ka¿dy element na tych listach zawiera adres (w atrybucie „href”)pod którym mo¿na znaleŸæ szczegó³owe dane
            string pp = PrettyJSON(json);
            Console.WriteLine(pp);
        }
    }



}