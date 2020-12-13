using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientAdmin.Common.Interfaces
{
    public interface ILoginService
    {
        Task<bool> AuthAsync(string email, string password);

    }
}
