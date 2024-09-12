using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Urls.GetUrlByIdQuery
{
    public record GetUrlResponse(Guid UrlId,string Path,string Name,string description)
    {
        public static explicit operator GetUrlResponse(Url Url)
    => new GetUrlResponse(Url.Id, Url.Path, Url.Name, Url.description);
    }
}
