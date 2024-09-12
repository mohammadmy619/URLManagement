using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Urls.GetUrlByIdQuery
{
    public class GetUrlHandler(IUrlRepository UrlRepository) : IRequestHandler<GetUrlByIdQuery, GetUrlResponse>
    {
        private readonly IUrlRepository _UrlRepository = UrlRepository;

        public async Task<GetUrlResponse> Handle(GetUrlByIdQuery request, CancellationToken cancellationToken)
        {
            var Url = await _UrlRepository.GetAuthorByIdAsync(request.BookId, cancellationToken);


            if (Url is null)
            {
                throw new GetUrlException(request.BookId);
            }

            return (GetUrlResponse)Url;
        }
    }
}
