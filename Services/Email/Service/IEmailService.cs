namespace CRUD_Products.Services.Email.Service
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(
            string address,
            string subject,
            string body);
    }
}
