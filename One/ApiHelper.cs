using System.Net.Http.Headers;

namespace One;

public class ApiHelper
{
    public static HttpClient ApiClient { get; set; } = new HttpClient();

    public static void InitializeClient()
    {
        ApiClient = new HttpClient();
        // ApiClient.BaseAddress = new Uri(url);
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}