using Application.Urls.GetUrlByIdQuery;
using Persistence;
using Persistence.Repositories;
using TestLibrary.Fixtures;
using FluentAssertions;
namespace TestLibrary
{

    public class GetBooksHandlerTests: IClassFixture<DbContextFixture>
    {
       
        private readonly DbContextFixture _fixture;

        public GetBooksHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
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
