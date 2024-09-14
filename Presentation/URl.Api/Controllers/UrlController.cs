using Application.Urls.AddUrlCommand;
using Application.Urls.GetUrlByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Urls.GetUrlByIdQuery.GetUrlResponse;

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
        public async Task<IActionResult> AddBookCommand(CreateUrlCommand url)
        {
            var Url = await _Mediator.Send(url);
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

            switch (res.Result)
            {
                case UrlResult.Success:
                    return Redirect(res.Path);
                case UrlResult.NotFound:
                    return NotFound();
                case UrlResult.Exception:
                    return StatusCode(500, "An error occurred while processing your request.");
                default:
                    return BadRequest("Unexpected result.");
            }


        }
    }
}

