using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Migrations;


namespace TestLibrary.Fixtures;

public class DbContextFixture : EfDatabaseBaseFixture<UrlManagementDbContext>
{
    protected override UrlManagementDbContext BuildDbContext(DbContextOptions<UrlManagementDbContext> options)
    {
        return new UrlManagementDbContext(options);
    }
}