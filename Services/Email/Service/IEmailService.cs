namespace CRUD_Products.Services.Email.Service
{
    public interface IEmailService
    {
        public Task<string> SendEmail(
            string address);
    }
}
