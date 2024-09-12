using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Urls.GetUrlByIdQuery
{
    public class GetUrlException:Exception
    {
        private const string _messages = "Url with UrlId `{0}` not NotFound.";

        public GetUrlException(Guid UrlId) : base(string.Format(_messages, UrlId)) { }
    }
  
}
