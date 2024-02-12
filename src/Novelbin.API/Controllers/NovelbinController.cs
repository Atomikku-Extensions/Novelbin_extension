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

        //[httpget]
        //public async task<actionresult<output>> getname(input input)
        //{
        //    var title = await _mainprovider.gettitlewithimage(input);
        //    return ok(title);
        //}

        //[HttpGet]
        //[Route("GetBookSearch")]
        //public async Task<ActionResult<LightNovelToSearch>> SearchBook(LightNovelToSearch lightNovelToSearch)
        //{
        //    var books = await _mainProvider.GetSearchBooks(lightNovel);
        //    return Ok(books);
        //}

        //[HttpPost]
        //[Route("GetBook")]
        //public async Task<ActionResult<LightNovel>> GetAllData(LightNovel lightNovel)
        //{
        //    await _mainProvider.GetBookData(lightNovel);
        //    return Ok(lightNovel);
        //}

        //[HttpGet]
        //public Task<ActionResult> GetChapterToDownload(InputToDownload inputToDownload)
        //{
        //    return new OutputToDownload();
        //}
    }
}