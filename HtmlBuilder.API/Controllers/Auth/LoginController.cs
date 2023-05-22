using HtmlBuilder.API.CQRS.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HtmlBuilder.API.Controllers.Auth
{
    public class LoginController : BaseController
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}