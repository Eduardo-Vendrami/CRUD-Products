using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Products.Controllers.Store
{
    [Route("v1/store")]
    [ApiController]
    public class StoreApiController : ControllerBase
    {
        public StoreApiController() { }

        [Route("register")]
        [HttpGet]
        public async Task<IActionResult> PostStoreRegistrationAsync()
        {
            return null;
        }
    }
}
