namespace Plants.WA.Services
{
    public interface ICaptchaService
    {
        Task<string> Verify(string token);
    }
}
