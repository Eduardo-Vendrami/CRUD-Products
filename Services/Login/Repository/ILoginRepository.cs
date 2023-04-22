using CRUD_Products.Models.Login.Models;
using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;

namespace CRUD_Products.Models.Login.Repository
{
    public interface ILoginRepository
    {
        public Task<User> LoginAsync(
            LoginRequest loginRequest);

        public Task<int> LoginRegisterAsync(
            LoginRequest loginRequest,
            string profile);
        public Task<User> ValidateUserAsync(
            LoginRequest loginRequest);
        public Task<int> UpdateUserAsync(
            LoginRequest loginRequest);
        public Task<User> ValidateEmailAsync(
            LoginRequest loginRequest);
    }
}
