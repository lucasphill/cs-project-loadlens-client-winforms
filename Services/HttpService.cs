using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Configuration;

namespace LoadLens.Client.Services;

internal class HttpService
{
    string baseUrl = ConfigurationManager.AppSettings.Get("apiAddress")!;

    public async Task<string?> HttpPost(string apiUrl, string serializedData, string? token = null)
    {
        string requestUrl = $"{baseUrl}{apiUrl}";

        using (HttpClient client = new HttpClient())
        {

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            StringContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(requestUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                //MenuLogout.Logout();
            }
        }
        return null;
    }

    public async Task<string?> HttpGet(string apiUrl, string? token = null)
    {
        string requestUrl = $"{baseUrl}{apiUrl}";

        using (HttpClient client = new HttpClient())
        {

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            if (response.StatusCode.Equals(405))
            {
                //await MenuLogin.Login();
            }
        }
        return null;
    }
}
