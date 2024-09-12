using Application.Urls.AddUrlCommand;
using Azure;
using FluentAssertions;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUrl.Fixtures;

namespace TestUrl
{
    public class CreateUrlCommandHandlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public CreateUrlCommandHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public async Task Handle_ShouldCreateArticle_WhenArticleDoesNotExist()
        {
            // Arrange
            var urlRepository = new UrlRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
            var _sut = new CreateUrlCommandHandler(urlRepository);
            var command = new CreateUrlCommand("www,google.com", "google", "googleTest");


            // Act
            var response = await _sut.Handle(command, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();


            var article = urlRepository.GetAuthorByIdAsync(response.UrlId, CancellationToken.None);
            article.Should().NotBeNull();
        }
    }


}

