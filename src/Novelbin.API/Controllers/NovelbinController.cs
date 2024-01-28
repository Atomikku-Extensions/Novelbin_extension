using Atomikku.Models.Extension;
using Microsoft.AspNetCore.Mvc;
using Novelbin.Core.Domain.Interfaces;

namespace Novelbin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NovelbinController : ControllerBase
    {
        private readonly ILogger<NovelbinController> _logger;
        private readonly IMainProvider _mainProvider;

        public NovelbinController(
            ILogger<NovelbinController> logger,
            IMainProvider mainProvider
            )
        {
            _logger = logger;
            _mainProvider = mainProvider;
        }

        [HttpGet]
        public async Task<Output> GetName(Input input)
        {
            var title = await _mainProvider.GetTitleWithImage(input);
            return null;
        }

        [HttpGet]
        public Output GetAllData(Input input)
        {
            //return Ok("Success");
            return null;
        }

        [HttpGet]
        public OutputToDownload GetChapterToDownload(InputToDownload inputToDownload)
        {
            //return Ok("Success");
            return null;
        }
    }
}