using Application.Urls.GetUrlByIdQuery;
using Persistence;
using Persistence.Repositories;
using TestUrl.Fixtures;
using FluentAssertions;
using System;
namespace TestUrl
{

    public class GetBooksHandlerTests: IClassFixture<DbContextFixture>
    {
       
        private readonly DbContextFixture _fixture;

        public GetBooksHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_WhenUrlDoesNotExist_ThrowsException()
        {
            // Arrange  
            var urlRepository = new UrlRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
            var sut = new GetUrlHandler(urlRepository);
            var query = new GetUrlByIdQuery(Guid.NewGuid()); // استفاده از یک GUID تصادفی که وجود ندارد  

            // Act & Assert  
            await Assert.ThrowsAsync<GetUrlException>(async () =>
            {
                await sut.Handle(query, CancellationToken.None);
            });
        }

        [Fact]
        public async Task Handle_WhenUrlExists_ReturnsUrl()
        {
            // Arrange  
            var urlRepository = new UrlRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
            var sut = new GetUrlHandler(urlRepository);
            var query = new GetUrlByIdQuery(Guid.Parse("7a46d35d-de6a-4486-b338-08dcd31b5c72"));

          

            // Act  
            var response = await sut.Handle(query, CancellationToken.None);

            // Assert  
            response.Should().NotBeNull(); // Assert that response is not null  
            response.Should().BeOfType<GetUrlResponse>();
         
        }
       
    }
}
