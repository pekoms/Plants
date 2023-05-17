
using Plants.Api.Domain.Dtos;
using RestSharp;
using System.Threading;

namespace Plants.WA.Services
{
    public class PlantService:IPlantService
    {
        private string URL = "https://localhost:7137/";
        private string RESOURCE = "api/Plant";
        
        public async Task Create(PlantDTO createPlantRecord)
        {
            var client = new RestClient("https://localhost:7137/api/Plant");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            
            var response = client.ExecutePostAsync(request);
        }
    }
}
