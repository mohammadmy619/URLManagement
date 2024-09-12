using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Urls.AddUrlCommand
{
    public class CreateUrlCommandHandler(IUrlRepository UrlRepository) : IRequestHandler<CreateUrlCommand, CreateUrlCommandResponse>
    {
        private readonly IUrlRepository _UrlRepository = UrlRepository;

        public async Task<CreateUrlCommandResponse> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
        {
            var result = await _UrlRepository.AddUrlAsync((Url)request, cancellationToken);

            await _UrlRepository.SaveChangesAsync(cancellationToken);
            return new CreateUrlCommandResponse(result);
        }
    }
}
