using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace University.Core.Helpers
{
    public static class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "http://localhost:5001/";
        const string KEY = "NLTU_University_secretKey_author_YevhenVolynets";
        public const int LIFETIME = 60;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
