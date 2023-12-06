using Plants.Domain.Domain.Dtos;

namespace Plants.WA.Services
{
    public interface ICaptchaService
    {
        Task<CaptchaResponseDTO> Verify(string token);
    }
}
