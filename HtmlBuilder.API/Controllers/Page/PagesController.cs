using HtmlBuilder.API.CQRS.User.GetAll;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllUserQueryRequest());

            return Ok(response);
        }
    }
}
