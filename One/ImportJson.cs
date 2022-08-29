using System.Collections;
using System.Net;
using System.Text.Json;
using Dawn;
using Newtonsoft.Json;
using Serilog;

namespace One;

public class ImportJson
{
    // private string _url;

    public static async Task<List<T>> Loader<T>(string url)
    {
        string path = Guard.Argument(url).NotEmpty().ToString();
        
        // Handling port, network, memory manangent to secure application
        // Wait for response and close connection
        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(path))
        {
            if (response.IsSuccessStatusCode)
            {
                List<T> responseContent = await response.Content.ReadAsAsync<List<T>>();

                return responseContent;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
    
}