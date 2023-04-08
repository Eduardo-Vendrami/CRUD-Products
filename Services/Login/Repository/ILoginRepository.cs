using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;

namespace CRUD_Products.Models.Login.Repository
{
    public interface ILoginRepository
    {
        public Task<LoginResponse> LoginAsync(
            LoginRequest loginRequest);

        public Task<int> LoginRegisterAsync(
            LoginRequest loginRequest);
    }
}
