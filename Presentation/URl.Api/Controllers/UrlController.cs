using Application.Urls.AddUrlCommand;
using Application.Urls.GetUrlByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace URl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _Mediator;
        public UrlController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }


        /// <summary>
        /// CreateUrl
        /// </summary>
        /// <param name="createBook"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBookCommand(CreateUrlCommand CreateUrl)
        {
            var Url = await _Mediator.Send(CreateUrl);
            return Ok(Url);
        }
        



        /// <summary>
        /// GetUrlById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{UrlId}")]
        public async Task<IActionResult> GetUrlById([FromRoute] Guid UrlId)
        {
            var res = await _Mediator.Send(new GetUrlByIdQuery(UrlId));
            return Ok(res);
        }

    }
}

