using FluentAssertions;
using HtmlAgilityPack;
using Novelbin.Core.Domain.Models;
using Novelbin.Core.Handlers;
using Novelbin.Core.Tests.Resources;

namespace Novelbin.Core.Tests.Handlers
{
    public class WebPageHandlerTests : BaseTests
    {
        private readonly WebPageHandler _webPageHandler;
        private readonly HtmlDocument _doc;

        public WebPageHandlerTests()
        {
            _webPageHandler = new WebPageHandler();
            _doc = new HtmlDocument();
        }

        [Fact]
        public async Task GetTitleOfPage_WhenCalled_ReturnsTitle()
        {
            // Arrange
            _doc.LoadHtml(HtmlFiles.SearchTheCursedPrinceHtml);
            var htmlNode = _doc.DocumentNode;

            // Act
            List<BookToSearch> booksFould = await _webPageHandler.GetBooksAfterSearch(htmlNode);

            // Assert
            booksFould.Should().NotBeNullOrEmpty();
            booksFould.Count.Should().Be(2);
            booksFould[0].Tittle.Should().Be("The Cursed Prince");
            booksFould[0].Url.Should().Contain("the-cursed-prince-nov1119906345");
            booksFould[0].UrlImage.Should().Be("https://novelbin.net/media/novel_200_89/the-cursed-prince.jpg");
            booksFould[1].Tittle.Should().Be("The Cursed Prince's Strange Bride");
            booksFould[1].Url.Should().Contain("the-cursed-princes-strange-bride-nov-877285432");
            booksFould[1].UrlImage.Should().Be("https://novelbin.net/media/novel_200_89/the-cursed-princes-strange-bride.jpg");
        }

        [Fact]
        public async Task GetChaptersOfPage_WhenCalled_ReturnsTitle()
        {
            // Arrange
            _doc.LoadHtml(HtmlFiles.TheCursedPrinceHtml);
            HtmlNode htmlNode = _doc.DocumentNode;

            // Act
            var result = await _webPageHandler.GetChaptersOfPage(htmlNode);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(1);
        }
    }
}