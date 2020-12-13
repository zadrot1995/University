using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmin.Common.Interfaces
{
    public interface IForgotPasswordService
    {
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> UpdatePasswordAsync(string password, string token);
    }
}
