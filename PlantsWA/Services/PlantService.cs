
using Plants.Api.Domain.Dtos;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Plants.WA.Services
{
    public class PlantService:IPlantService
    {
        private string URL = "https://localhost:7137";
        private string RESOURCE = "/api/Plant";

        private readonly HttpClient _httpClient;

        public PlantService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        public async Task Create(PlantDTO createPlantRecord)
        {
            var anonymo = new PlantDTO
            {
                Nombre = "Nombre",
               Edad=6,
               Especie="Arborea"
               
            };


            
            var todoItemJson = new StringContent(JsonSerializer.Serialize<PlantDTO>(anonymo),Encoding.UTF8,
            Application.Json); 

            using var httpResponseMessage =
                await _httpClient.PostAsync(URL+ RESOURCE, todoItemJson);

            httpResponseMessage.EnsureSuccessStatusCode();


        }
    }
}
