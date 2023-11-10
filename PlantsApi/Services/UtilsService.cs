using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Plants.Api.Services
{
    public class UtilsService : IUtilsService
    {
        private IConfiguration _config;

        public UtilsService(IConfiguration config)
        {
            _config = config;
        }
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

        public async Task<JwtSecurityToken> GenerateJwtToken(string userName)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
                // Puedes incluir otros claims personalizados aquí
        };

            var jwtSettings = new JwtSettings
            {
                JwtSecret = _config.GetSection("JwtSettings")["JwtSecret"],
                JwtIssuer = _config.GetSection("JwtSettings")["JwtIssuer"],
                JwtAudience = _config.GetSection("JwtSettings")["JwtAudience"]
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.JwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings.JwtIssuer,
                audience: jwtSettings.JwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return token;
        }
        public class JwtSettings
        {
            public string JwtSecret { get; set; }
            public string JwtIssuer { get; set; }
            public string JwtAudience { get; set; }
        }
        public async Task<bool> VerifyPassword(string providedPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }

        public async Task<string> HashPassword(string password)
        {
            // Genera un salt aleatorio para la contraseña
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12); // El número 12 representa el costo del algoritmo de hash

            // Hashea la contraseña con el salt
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

    }
}
