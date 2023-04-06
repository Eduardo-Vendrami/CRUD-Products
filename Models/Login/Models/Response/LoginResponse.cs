using CRUD_Products.Models.Base;

namespace CRUD_Products.Models.Login.Models.Response
{
    public class LoginResponse : BaseResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
