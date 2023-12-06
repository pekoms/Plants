using Amazon.Runtime.Internal;
using Plants.Domain.Domain.Dtos;
using System.Net.Http;
using System.Text.Json;

namespace Plants.Api.Services
{
    public class CaptchaService:ICaptchaService
    {
        private readonly HttpClient _httpClient;

        public CaptchaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CaptchaResponseDTO>  VerifyGoogleCaptcha(string secretKey,string recaptchaToken)
        {                                                
               
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptchaToken}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<CaptchaResponseDTO>(jsonResponse);
                return responseObject;
                            
            }                     
        }
    }


