namespace Plants.Api.Services
{
    public interface ICaptchaService
    {
         Task<bool>  VerifyGoogleCaptcha(string secretKey, string recaptchaToken);
    }
}
