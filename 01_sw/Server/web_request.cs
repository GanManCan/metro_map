using System.Web;
using Newtonsoft.Json;
using wmata;
using static System.Net.WebRequestMethods;


webInfoLoader loginInfo = JsonConvert.DeserializeObject<webInfoLoader>(System.IO.File.ReadAllText("interface.json"));
MakeRequest(loginInfo.api_key, loginInfo.format);

Console.WriteLine("Press Enter to exit"); //Needs that slight delay to give enough time to finish writing the file
Console.ReadLine();

static async void MakeRequest(string api, string format)
{
    var client = new HttpClient();
    var queryString = HttpUtility.ParseQueryString(string.Empty);
    string responseBody = "";
    // Request headers
    client.DefaultRequestHeaders.Add("api_key", api);
    //var uri = "https://api.wmata.com/TrainPositions/TrainPositions?contentType=" + format + "&" + queryString;
    var uri = "https://api.wmata.com/TrainPositions/StandardRoutes?contentType=" + format + "&" + queryString;
    var response = await client.GetAsync(uri);

    if (response.IsSuccessStatusCode) responseBody = await response.Content.ReadAsStringAsync(); //Console.WriteLine("Response Success");
    else Console.WriteLine("Error");

    //Console.Write(responseBody);
    System.IO.File.WriteAllText("Routes.json", responseBody);
}

public class webInfoLoader
{
    public string? api_key {  get; set; }
    public string? format { get; set;}
}