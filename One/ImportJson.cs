using System.Collections;
using System.Net;
using System.Text.Json;
using Dawn;
using Newtonsoft.Json;

namespace One;

public class ImportJson
{
    // private string _url;

    public static async Task<dynamic> Loader(string url)
    {
        string path = Guard.Argument(url).NotEmpty().ToString();

        Console.WriteLine(path);
        // Handling port, network, memory manangent to secure application
            // Wait for response and close connection
            var test = await ApiHelper.ApiClient.GetAsync(path);
            Console.WriteLine(test.Content.ReadAsStream());
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(path))
            {
                // Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    dynamic person = await response.Content.ReadAsStreamAsync();
                    Console.WriteLine(person);
                    return person;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            return "";

    }
    
    // public async Task Loader(string url)
    // {
    //     // _url = url;
    //     Console.WriteLine("response");
    //     HttpClient client = new HttpClient();
    //
    //     string response = await client.GetStringAsync(url);
    //     Console.WriteLine(response);
    //
    //     var data = JsonConvert.DeserializeObject<dynamic>(response);
    //     
    //     // string jsonString = new WebClient().DownloadString(url);
    //     var httpClientJson = new HttpClient().GetAsync(url);
    //     // object jsonString = await JsonSerializer.DeserializeAsync<object>(json);
    //     // dynamic dobj = JsonConvert.DeserializeObject<dynamic>(jsonString);
    //     
    //     Console.WriteLine("data", data);
    //     // Console.WriteLine(dobj);
    //     
    //     // Console.WriteLine(jsonString);
    //     // return jsonString;
    //     return data;
    // }

    // public async Task FetchJson()
    // {
    //     throw NotImplementedException("wait for it");
    // }
}