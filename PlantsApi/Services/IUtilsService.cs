namespace Plants.Api.Services
{
    public interface IUtilsService
    {
        public Task<string> GetImageFromFile(IFormFile file);
    }
}
