using Microsoft.AspNetCore.Mvc;

namespace BackEndWebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BackEndAPI3Controller : ControllerBase
    {
        [HttpPost]
       public async Task<IActionResult> PostAsync([FromBody] object data)
        {
            await Task.Delay(2000);
            return Ok("BackEnd API3 Response: Task completed after delay");
        }
    }
}
