using System.Text.Json;

namespace PicPaySimplificado.Services.Authorizer;

public class AuthorizerServices : IAuthorizerInterface
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    
    public AuthorizerServices(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<bool> Authorize()
    {
            string content = string.Empty;
            var response = await _httpClient.GetAsync(_configuration.GetConnectionString("Authorization"));
            
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();
            content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse>(content);

            return result?.status == "success";
    }
    
    private class ApiResponse
    {
        public string status { get; set; }
        public DataResponse data { get; set; }
    }
    
    private class DataResponse
    {
        public bool authorization { get; set; }
    }
}