using Atomikku.Models.Extension;
using Microsoft.AspNetCore.Mvc;

namespace Novelbin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NovelbinController : ControllerBase
    {
        private readonly ILogger<NovelbinController> _logger;
        private readonly Core.Startup _startup;

        public NovelbinController(
            ILogger<NovelbinController> logger
            )
        {
            _logger = logger;
            _startup = new Core.Startup();
        }

        [HttpPost]
        [Route("GetBookSearch")]
        public async Task<ActionResult<LightNovelToSearch>> SearchBook(LightNovelToSearch lightNovelToSearch)
        {
            var books = await _startup.GetSearchBooks(lightNovelToSearch);
            return Ok(books);
        }

        [HttpPost]
        [Route("GetBook")]
        public async Task<ActionResult<LightNovel>> GetAllData(LightNovel lightNovel)
        {
            var result = await _startup.GetBookData(lightNovel);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetChapters")]
        public async Task<ActionResult<LightNovel>> GetChapters(LightNovel lightNovel)
        {
            var result = await _startup.GetChapters(lightNovel);
            return Ok(result);
        }
    }
}