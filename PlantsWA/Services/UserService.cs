using Plants.Api.Domain.Dtos;
using Plants.Domain.Domain.Dtos;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Plants.WA.Services
{
    public class UserService : IUserService
    {
        private string URL = "https://localhost:7137";
        private string RESOURCE = "/api/User";



        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Create(UserDTO loginUser)
        {
            var todoItemJson = new StringContent(JsonSerializer.Serialize<UserDTO>(loginUser), Encoding.UTF8,
            Application.Json);

            using var httpResponseMessage =
                await _httpClient.PostAsync(URL + RESOURCE+"dshfsdkj", todoItemJson);

            return httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<TokenDTO> Login(UserDTO loginUser)
        {
            var todoItemJson = new StringContent(JsonSerializer.Serialize<UserDTO>(loginUser), Encoding.UTF8,
            Application.Json);

            using var httpResponseMessage =
                await _httpClient.PostAsync(URL + RESOURCE + "/Login", todoItemJson);
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TokenDTO>(jsonString);

            return result;
    
        }

        public async Task GetPlantByPlantId(string Id, string token)
        {
            using var httpResponseMessage =
                await _httpClient.GetAsync(URL + RESOURCE);

            httpResponseMessage.EnsureSuccessStatusCode();
        }
        public async Task GetPlantByUserId(string Id,string token)
        {
            using var httpResponseMessage =
                await _httpClient.GetAsync(URL + RESOURCE);

            httpResponseMessage.EnsureSuccessStatusCode();


        }
        public async Task<List<PlantDTO>> GetAllPlantsByUserId(string OwnerId,string token)
        {
            using var httpResponseMessage =
              await _httpClient.GetAsync(URL + RESOURCE + "/User/?OwnerId=" + OwnerId);

            httpResponseMessage.EnsureSuccessStatusCode();
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<PlantDTO>>(jsonString);

            return result;
        }

    }
}
