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

        //[HttpGet]
        //public async Task<ActionResult<Output>> GetName(Input input)
        //{
        //    var title = await _mainProvider.GetTitleWithImage(input);
        //    return Ok(title);
        //}

        [HttpGet]
        [Route("GetBookSearch")]
        public async Task<ActionResult<List<Output>>> GetBookSearch([FromQuery] string tittle)
        {
            var books = await _mainProvider.GetSearchBooks(tittle);
            return Ok(books);
        }

        //[HttpGet]
        //public Task<ObjectResult> GetAllData(Input input)
        //{
        //    return Ok(new Output());
        //}

        //[HttpGet]
        //public Task<ObjectResult> GetChapterToDownload(InputToDownload inputToDownload)
        //{
        //    return new OutputToDownload();
        //}
    }
}