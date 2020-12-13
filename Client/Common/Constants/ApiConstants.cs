using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Common.Constants
{
    public static class ApiConstants
    {

        public const string Students = "Student";
        public static string GetStudentById(string id) => $"{Students}/{id}";
        public const string SecureAccessTokenName = "MyToken";
        public const string SecureRefreshTokenName = "MyToken";
        public const string Token = "MyToken";
        

    }
}
