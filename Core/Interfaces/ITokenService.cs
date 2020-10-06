using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace University.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken(int size = 32);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GetBearerToken(string token);
        string GetUserIdByAccessToken(string token);
    }
}
