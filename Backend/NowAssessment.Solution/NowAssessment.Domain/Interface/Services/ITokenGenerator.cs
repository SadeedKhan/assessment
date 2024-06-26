﻿namespace NowAssessment.Domain.Interface.Services
{
    public interface ITokenGenerator
    {
        public string GenerateJWTToken((string userId, string userName, IList<string> roles) userDetails);
    }
}
