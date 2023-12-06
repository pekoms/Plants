using Plants.Domain.Domain.Dtos;

namespace Plants.Api.Services
{
    public interface ICaptchaService
    {
         Task<CaptchaResponseDTO>  VerifyGoogleCaptcha(string secretKey, string recaptchaToken);
    }
}
