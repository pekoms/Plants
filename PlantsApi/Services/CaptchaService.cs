using System.Text.Json;

namespace Plants.Api.Services
{
    public class CaptchaService:ICaptchaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CaptchaService(IHttpClientFactory _httpClientFactory) 
        {
            _httpClientFactory = _httpClientFactory;
        }
        public async Task<bool>  VerifyGoogleCaptcha(string secretKey,string recaptchaToken)
        {
            var googleVerificationUrl = $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptchaToken}";
            using (var httpClient = _httpClientFactory.CreateClient())
            {                              
                try
                {
                    var response = await httpClient.GetStringAsync(googleVerificationUrl);
                    var responseObject = JsonSerializer.Deserialize<dynamic>(response);

                    // Verifica si la respuesta de Google indica que el CAPTCHA es válido
                    return responseObject.success;
                }
                catch (HttpRequestException)
                {
                    // Manejo de errores: Si ocurre un error al realizar la solicitud
                    return false;
                }
            }                      
        }
    }
}
