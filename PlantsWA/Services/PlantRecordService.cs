﻿using Plants.Api.Domain.Dtos;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;


namespace Plants.WA.Services
{
    public class PlantRecordService : IPlantRecordService
    {
        private string URL = "https://localhost:7137";
        private string RESOURCE = "/api/PlantRecord";



        private readonly HttpClient _httpClient;

        public PlantRecordService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task Create(PlantRecordDTO createPlantRecord, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var todoItemJson = new StringContent(JsonSerializer.Serialize<PlantRecordDTO>(createPlantRecord), Encoding.UTF8,
            Application.Json);
            
            using var httpResponseMessage =
                await _httpClient.PostAsync(URL + RESOURCE, todoItemJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task GetPlantByPlantId(string Id,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var httpResponseMessage =
                await _httpClient.GetAsync(URL + RESOURCE);

            httpResponseMessage.EnsureSuccessStatusCode();
        }
        public async Task GetPlantByUserId(string Id,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var httpResponseMessage =
                await _httpClient.GetAsync(URL + RESOURCE);

            httpResponseMessage.EnsureSuccessStatusCode();


        }

        public async Task<PlantRecordDTO> Get(string Id,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var httpResponseMessage =
              await _httpClient.GetAsync(URL + RESOURCE + "/" + Id);

            httpResponseMessage.EnsureSuccessStatusCode();
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PlantRecordDTO>(jsonString);

            return result;
        }
        public async Task<List<PlantDTO>> GetAllPlantsByUserId(string OwnerId,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var httpResponseMessage =
              await _httpClient.GetAsync(URL + RESOURCE + "/User/?OwnerId=" + OwnerId);

            httpResponseMessage.EnsureSuccessStatusCode();
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<PlantDTO>>(jsonString);

            return result;
        }

        public async Task<List<PlantRecordDTO>> GetAllPlantsByPlantId(string PlantId,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var httpResponseMessage =
             await _httpClient.GetAsync(URL + RESOURCE + "/Plant/?plantId=" + PlantId);

            httpResponseMessage.EnsureSuccessStatusCode();
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<PlantRecordDTO>>(jsonString);

            return result;
        }

        public async Task<List<PlantRecordDTO>> GetAllPlantsNominated(string UserId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var httpResponseMessage =
             await _httpClient.GetAsync(URL + RESOURCE + "/PlantsNominated?userId=" + UserId);

            httpResponseMessage.EnsureSuccessStatusCode();
            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<PlantRecordDTO>>(jsonString);

            return result;
        }

        public async Task Update(PlantRecordDTO createPlantRecord,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var todoItemJson = new StringContent(JsonSerializer.Serialize<PlantRecordDTO>(createPlantRecord), Encoding.UTF8,
            Application.Json);

            using var httpResponseMessage =
                await _httpClient.PutAsync(URL + RESOURCE + "/" + createPlantRecord.Id, todoItemJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task Delete(string deletePlantRecordId,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var todoItemJson = new StringContent(JsonSerializer.Serialize<string>(deletePlantRecordId), Encoding.UTF8,
            Application.Json);

            using var httpResponseMessage =
                await _httpClient.DeleteAsync(URL + RESOURCE + "/" + deletePlantRecordId);

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
