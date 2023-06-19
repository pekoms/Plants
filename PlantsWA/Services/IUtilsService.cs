using Microsoft.AspNetCore.Http;

namespace Plants.WA.Services
{
    public interface IUtilsService
    {
        public Task<string> GetImageFromFile(IFormFile file);
    }
}
