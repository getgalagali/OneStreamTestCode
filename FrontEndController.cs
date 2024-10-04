using Microsoft.AspNetCore.Mvc;

namespace FrontEndWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FrontEndController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public FrontEndController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("invoke-apis")]
        public async Task<IActionResult> InvokeAPIAsync()
        {
            //Asynchronously call BackEndAPI2 and BackEndAPI3
            var api2Task = _httpClient.GetStringAsync("https://localhost:7072/api/BackEndAPI2");
            var api3Task = _httpClient.PostAsJsonAsync("https://localhost:7287/api/BackEndAPI3", new {message = "Hello from API1"});

            await Task.WhenAll(api2Task,api3Task);

            var api2Response = await api2Task;
            var api3Response = await (await api3Task).Content.ReadAsStringAsync();

            return Ok(new {API2Response = api2Response, API3Response = api3Response});
        }

        [HttpPost("invoke-apis")]
        public async Task<IActionResult> InvokeAPIsPostAsync([FromBody] object request)
        {
            //Asynchronously call BackEndAPI2 and BackEndAPI3
            var api2Task = _httpClient.GetStringAsync("https://localhost:5001/api/api2");
            var api3Task = _httpClient.PostAsJsonAsync("https://localhost:5002/api/api3", request);

            await Task.WhenAll(api2Task, api3Task);

            var api2Response = await api2Task;
            var api3Response = await (await api3Task).Content.ReadAsStringAsync();

            return Ok(new { API2Response = api2Response, API3Response = api3Response });
        }


    }
}
