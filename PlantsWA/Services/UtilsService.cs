using Microsoft.AspNetCore.Http;

namespace Plants.WA.Services
{
    public class UtilsService:IUtilsService
    {
        public async Task<string> GetImageFromFile(IFormFile file)
        {

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                var result = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(content));
                return result;
            }
        }
    }
}
