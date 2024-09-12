using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Urls.AddUrlCommand
{

    public record CreateUrlCommand(string Path, string Name, string description) : IRequest<CreateUrlCommandResponse>
    {

        public static explicit operator Url(CreateUrlCommand Url)
    => new Url()
    {
        Path = Url.Path,
        Name = Url.Name,
        description = Url.description,
        IsDeleted = false,

    };
    };
}
