using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Urls.GetUrlByIdQuery.GetUrlResponse;

namespace Application.Urls.GetUrlByIdQuery
{
    public record GetUrlResponse(Guid UrlId, string Path, UrlResult Result)
    {

      

        public static explicit operator GetUrlResponse((Url? Url, UrlResult Result) input)
        {
            if (input.Url is null)
            {
                return new GetUrlResponse(Guid.Empty, string.Empty, input.Result);  
            }

            return new GetUrlResponse(input.Url.Id, input.Url.Path, input.Result);
        }



        public enum UrlResult
        {
            NotFound,
            Success, 
            Exception
        }


    }
}
