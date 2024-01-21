using Microsoft.AspNetCore.Mvc;

namespace Novelbin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NovelbinController : ControllerBase
    {
        private readonly ILogger<NovelbinController> _logger;

        public NovelbinController(ILogger<NovelbinController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success");
        }
    }
}