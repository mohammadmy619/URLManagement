using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Urls.AddUrlCommand
{
    public record CreateUrlCommandResponse(Guid UrlId)
    {
        public static explicit operator CreateUrlCommandResponse(Guid BookId)
           => new CreateUrlCommandResponse(BookId);
    }
}
