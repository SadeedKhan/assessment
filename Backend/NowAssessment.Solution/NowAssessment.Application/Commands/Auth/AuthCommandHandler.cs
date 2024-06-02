using MediatR;
using NowAssessment.Domain.Interface.Services;
using NowAssessment.Shared.Request.Auth;
using NowAssessment.Shared.Response.Auth;

namespace NowAssessment.Application.Commands.Auth
{
    public class AuthCommandHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IIdentityService _identityService;

        public AuthCommandHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
        {
            _identityService = identityService;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await _identityService.SigninUserAsync(request.UserName, request.Password);

            if (!result)
            {
                throw new Exception("Invalid username or password");
            }

            var (userId, fullName, userName, email, roles) = await _identityService.GetUserDetailsAsync(await _identityService.GetUserIdAsync(request.UserName));

            string token = _tokenGenerator.GenerateJWTToken((userId, userName, roles));

            return new LoginResponse()
            {
                UserId = userId,
                Name = userName,
                Token = token
            };
        }
    }
}
