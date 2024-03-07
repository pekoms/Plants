using Plants.Api.Domain.Entities;

namespace Plants.Api.Services
{
    public interface IEmailService
    {
        public Task<User> CheckEmailExists(string email);
        public void SendEmail(string email);

    }
}
