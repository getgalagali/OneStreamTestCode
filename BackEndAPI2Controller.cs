using Microsoft.AspNetCore.Mvc;

namespace BackEndWebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BackEndAPI2Controller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            await Task.Delay(4000);
            return Ok("BackEnd API2 Response: Task completed after delay");
        }
    }
}
