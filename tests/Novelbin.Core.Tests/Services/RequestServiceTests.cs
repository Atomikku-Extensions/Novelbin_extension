﻿using FluentAssertions;
using Novelbin.Core.Services;

namespace Novelbin.Core.Tests.Services
{
    public class RequestServiceTests
    {
        private const string EMPTY = "";
        private readonly RequestService _requestService;

        public RequestServiceTests() => _requestService = new RequestService();

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, EMPTY)]
        [InlineData(EMPTY, null)]
        [InlineData(EMPTY, EMPTY)]
        public void GetPageString_WhenURLorPathIsNullOrEmpty_ShouldReturnsStringEmpty(string? url, string? xpath)
        {
            // Act
            var result = _requestService.GetPageStringWithXPath(url, xpath);

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetPageString_WhenURLAndPathIsNotNullOrEmpty_ShouldReturnsText()
        {
            // Arrange
            const string URL = "https://novelbin.net/n/the-cursed-prince/chapter-1";
            const string XPATH = "//*[@id=\"chr-content\"]";

            // Act
            var result = _requestService.GetPageStringWithXPath(URL, XPATH);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Length.Should().BeGreaterThan(0);
        }
    }
}