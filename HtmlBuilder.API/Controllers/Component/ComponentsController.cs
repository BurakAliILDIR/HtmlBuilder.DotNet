using HtmlBuilder.API.CQRS.Component.Add;
using HtmlBuilder.API.CQRS.Component.Delete;
using HtmlBuilder.API.CQRS.Component.Find;
using HtmlBuilder.API.CQRS.Component.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HtmlBuilder.API.Controllers.Component
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsController : BaseController
    {
        private readonly IMediator _mediator;

        public ComponentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllComponentQueryRequest());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(string id)
        {
            var response = await _mediator.Send(new FindComponentQueryRequest { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddComponentCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new DeleteComponentCommandRequest { Id = id });

            return Ok(response);
        }
    }
}
