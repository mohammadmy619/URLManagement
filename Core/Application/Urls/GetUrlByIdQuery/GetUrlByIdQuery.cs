using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Urls.GetUrlByIdQuery
{
    public record GetUrlByIdQuery(Guid UrlId) : IRequest<GetUrlResponse>
    {
    }
    
}
