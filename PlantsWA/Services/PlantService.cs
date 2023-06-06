﻿
using MongoDB.Bson.IO;
using Plants.Api.Domain.Dtos;
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
           
            var todoItemJson = new StringContent(JsonSerializer.Serialize<PlantDTO>(createPlantRecord),Encoding.UTF8,
            Application.Json); 

            using var httpResponseMessage =
                await _httpClient.PostAsync(URL+ RESOURCE, todoItemJson);

            httpResponseMessage.EnsureSuccessStatusCode();


        }

        public async Task GetPlantByPlantId(string Id)
        {
            


          

            using var httpResponseMessage =
                await _httpClient.GetAsync(URL + RESOURCE);

            httpResponseMessage.EnsureSuccessStatusCode();


        }

        public async Task GetPlantByUserId(string Id)
        {       
            using var httpResponseMessage =
                await _httpClient.GetAsync(URL + RESOURCE);

            httpResponseMessage.EnsureSuccessStatusCode();


        }

        public async Task<List<PlantDTO>> GetAllPlantsByUserId(string OwnerId)
        {
            using var httpResponseMessage =
              await _httpClient.GetAsync(URL + RESOURCE+"/User/?OwnerId="+OwnerId);

            httpResponseMessage.EnsureSuccessStatusCode();
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
             var result= JsonSerializer.Deserialize<List<PlantDTO>>(jsonString);

            return result;
        }
    }
}
