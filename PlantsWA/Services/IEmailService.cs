namespace Plants.WA.Services
{
    public interface IEmailService
    {
        public Task<bool> CheckEmailExists(string email);
        public Task<HttpResponseMessage> SendEmail(string email);

    }
}
