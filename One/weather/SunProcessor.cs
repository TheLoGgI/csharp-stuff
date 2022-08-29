namespace One;

public class SunProcessor
{

    public static async Task<SunModel> LoadSun()
    {
        string url = "https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=today";
        
        using (var response = await ApiHelper.ApiClient.GetAsync(url))
        {
            // Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                SunResultModel results = await response.Content.ReadAsAsync<SunResultModel>();
                Console.WriteLine("Results");
                Console.WriteLine(results);
                return results.Results;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}