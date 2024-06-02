using MediatR;
using Microsoft.AspNetCore.Mvc;
using NowAssessment.API.Controllers.Base;
using NowAssessment.Shared.Request.Auth;
using NowAssessment.Shared.Response.Auth;

namespace NowAssessment.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        [ProducesDefaultResponseType(typeof(LoginResponse))]
        public async Task<IActionResult> Login([FromBody] LoginRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
