using System;
using Microsoft.AspNetCore.Identity;

namespace University.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int VerificationCode { get; set; }

        public string RefreshToken { get; set; }
    }
}
