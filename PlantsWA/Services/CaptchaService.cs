using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using Plants.Domain.Domain.Dtos;

namespace Plants.WA.Services
{
    public class CaptchaService:ICaptchaService
    {

        private string URL = "https://localhost:7137";
        private string RESOURCE = "/api/Captcha/verifyCaptcha";



        private readonly HttpClient _httpClient;

        public CaptchaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CaptchaResponseDTO> Verify(string token)
        {
            
            var todoItemJson = new StringContent(JsonSerializer.Serialize<string>(token), Encoding.UTF8,
            Application.Json);

            using var httpResponseMessage =
                await _httpClient.PostAsync(URL + RESOURCE, todoItemJson);

            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CaptchaResponseDTO>(jsonString);

            return result;
        }
    }
}
