using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Common.Interfaces
{
    public interface ITokenService
    {
        Task<bool> RefreshTokenAsync(TokensModel tokensModel);
        Task<string> GetTokenFromStorageAsync(TokenType tokenType);
        Task<TokensModel> GetTokensFromStorageAsync();
        Task<bool> SetTokensAsync(TokensModel token);
        void ClearCache();
    }
}
