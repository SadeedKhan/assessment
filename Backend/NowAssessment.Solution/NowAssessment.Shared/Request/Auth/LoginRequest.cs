using MediatR;
using NowAssessment.Shared.Response.Auth;

namespace NowAssessment.Shared.Request.Auth
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
