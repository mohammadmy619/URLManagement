using Domain.UrlModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UrlRepository(UrlManagementDbContext _dbContext) : IUrlRepository
    {
        public async Task<Guid> AddUrlAsync(Url url, CancellationToken cancellationToken)
        {
            // Add the url to the database asynchronously  
            var result = await _dbContext.Url.AddAsync(url, cancellationToken);

            // Return the Id of the newly created url  
            return result.Entity.Id;
        }

        public async Task<Url?> GetAuthorByIdAsync(Guid UrlId, CancellationToken cancellationToken)
        {
            return await _dbContext.Url.Where(Url => Url.Id == UrlId&& Url.IsDeleted==false).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
