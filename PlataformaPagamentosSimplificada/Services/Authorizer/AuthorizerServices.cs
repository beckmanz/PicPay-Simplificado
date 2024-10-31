namespace PlataformaPagamentosSimplificada.Services.Authorizer;
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
        var response = await _httpClient.GetAsync(_configuration.GetConnectionString("Authorization"));

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        response.EnsureSuccessStatusCode();
        return true; 
    }
}