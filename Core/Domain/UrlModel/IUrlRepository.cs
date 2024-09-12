using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UrlModel
{
    public interface IUrlRepository
    {
        public Task<Url?> GetAuthorByIdAsync(Guid UrlId, CancellationToken cancellationToken);
        public Task<Guid> AddUrlAsync(Url url, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
