using System;
using System.Threading.Tasks;

namespace University.Core.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string text, string recipient);
    }
}
