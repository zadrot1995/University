using System;
namespace University.Core.Commands
{
    public class RegisterCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
