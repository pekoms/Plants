using Plants.Domain.Domain.Dtos;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;

namespace Plants.WA.Services
{
    public class EmailService:IEmailService
    {
        private string? URL = "https://localhost:7137";
        private readonly IConfiguration _configuration;
        private string RESOURCE = "/api/Email/";



        private readonly HttpClient _httpClient;

        public EmailService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            URL = !string.IsNullOrEmpty(_configuration.GetSection("Services")["Email"])? _configuration.GetSection("Services")["Email"]:"";
        }


        public async Task<bool> CheckEmailExists(string email)
        {
            var todoItemJson = new StringContent(JsonSerializer.Serialize<string>(email), Encoding.UTF8,
            Application.Json);

            using var httpResponseMessage =
                await _httpClient.PostAsync(URL + RESOURCE + "/CheckEmailExists", todoItemJson);
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<bool>(jsonString);

            return result;
        }

        public async Task<HttpResponseMessage> SendEmail(string email)
        {
            var todoItemJson = new StringContent(JsonSerializer.Serialize<string>(email), Encoding.UTF8,
              Application.Json);

            using var httpResponseMessage =
                await _httpClient.PostAsync(URL + RESOURCE + "/SendEmail", todoItemJson);
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<HttpResponseMessage>(jsonString);

            return result;
        }
    }
}
