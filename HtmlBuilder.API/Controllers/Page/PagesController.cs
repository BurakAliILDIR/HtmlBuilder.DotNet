using HtmlBuilder.API.CQRS.Page.Find;
using HtmlBuilder.API.CQRS.Page.GetAll;
using HtmlBuilder.API.CQRS.Page.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HtmlBuilder.API.Controllers.Page
{
    public class PagesController : BaseController
    {
        private readonly IMediator _mediator;

        public PagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllPageQueryRequest());

            return Ok(response);
        }

        [HttpGet("Find/{id}")]
        public async Task<IActionResult> Find(string id)
        {
            var response = await _mediator.Send(new FindPageQueryRequest { Id = id });

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdatePageCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}