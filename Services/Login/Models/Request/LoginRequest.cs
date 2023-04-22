using Newtonsoft.Json;

namespace CRUD_Products.Models.Login.Models.Request
{
    public class LoginRequest
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("isSeller")]
        public bool IsSeller { get; set; }

        [JsonProperty("isCustomer")]
        public bool IsCustomer { get; set; }

        [JsonProperty("newUsername")]
        public string NewUsername { get; set; }

        [JsonProperty("newEmail")]
        public string NewEmail { get; set; }
    }
}
