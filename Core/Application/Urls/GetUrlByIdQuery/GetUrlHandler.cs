using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Urls.GetUrlByIdQuery.GetUrlResponse;

namespace Application.Urls.GetUrlByIdQuery
{
    public class GetUrlHandler(IUrlRepository UrlRepository) : IRequestHandler<GetUrlByIdQuery, GetUrlResponse>
    {
        private readonly IUrlRepository _UrlRepository = UrlRepository;

        public async Task<GetUrlResponse> Handle(GetUrlByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Url = await _UrlRepository.GetAuthorByIdAsync(request.UrlId, cancellationToken);


                if (Url is null)
                {

                    return (GetUrlResponse)(null, UrlResult.NotFound);

                }
                return (GetUrlResponse)(Url, UrlResult.Success);
            }
            catch (Exception ex)
            {

                throw new GetUrlException(request.UrlId);
            }
        }

    }
}

