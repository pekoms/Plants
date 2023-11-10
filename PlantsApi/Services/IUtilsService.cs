using System.IdentityModel.Tokens.Jwt;

namespace Plants.Api.Services
{
    public interface IUtilsService
    {
        public Task<string> GetImageFromFile(IFormFile file);
        public Task<JwtSecurityToken> GenerateJwtToken(string userName);
        public Task<bool> VerifyPassword(string providedPassword, string hashedPassword);
        public Task<string> HashPassword(string password);

    }
}
