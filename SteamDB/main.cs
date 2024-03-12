using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Object;
using System.Globalization;
using System.Net.Http.Headers;


public class Game
{	//public string applist;
	//public string apps;
	public int appid { get; set; }
	public string name { get; set; }
}


class Program
{	static void Main()
	{
        string PrettyJSON(string unPrettyJSON)
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJSON);
            return JsonSerializer.Serialize(jsonElement, options);
        }

        using (WebClient wc = new WebClient())
		{	
            var json = wc.DownloadString("https://api.steampowered.com/ISteamApps/GetAppList/v0002/?format=json"); 
            string pp = PrettyJSON(json);
            Console.WriteLine(pp); 
        }
    }
}