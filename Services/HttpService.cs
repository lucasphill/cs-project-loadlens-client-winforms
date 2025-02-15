
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Configuration;
using LoadLens.Client.Models;

namespace LoadLens.Client.Services;

internal class HttpService
{
    private readonly string baseUrl = ConfigurationManager.AppSettings.Get("apiAddress")!;

    public async Task<ResponseModel<string>> HttpPost(string apiUrl, string serializedData, string? token = null)
    {
        string requestUrl = $"{baseUrl}{apiUrl}";
        var response = new ResponseModel<string>();

        try
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                StringContent content = new(serializedData, Encoding.UTF8, "application/json");
                HttpResponseMessage request = await client.PostAsync(requestUrl, content);
                if (request.IsSuccessStatusCode)
                {
                    string responseBody = await request.Content.ReadAsStringAsync();
                    response.Data = responseBody;
                    response.Message = "Successful request";
                    response.Status = true;
                    return response;
                }
                if (request.StatusCode == HttpStatusCode.MethodNotAllowed)
                {
                    response.Message = "Authentication failed";
                    response.Status = true;
                    return response;
                }
                response.Message = "Internal request error";
                response.Status = true;
                return response;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<string>> HttpGet(string apiUrl, string? token = null)
    {
        string requestUrl = $"{baseUrl}{apiUrl}";

        var response = new ResponseModel<string>();

        try
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage request = await client.GetAsync(requestUrl);
                if (request.IsSuccessStatusCode)
                {
                    string responseBody = await request.Content.ReadAsStringAsync();
                    response.Data = responseBody;
                    response.Message = "Successful request";
                    response.Status = true;
                    return response;
                }
                if (request.StatusCode == HttpStatusCode.MethodNotAllowed)
                {
                    response.Message = "Authentication failed";
                    response.Status = true;
                    return response;
                }
            }
            response.Message = "Internal request error";
            response.Status = true;
            return response;
        }
        catch(Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }
}
