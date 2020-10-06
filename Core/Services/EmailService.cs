using System;
using System.Threading.Tasks;
using University.Core.Interfaces;

namespace University.Core.Services
{
    public class EmailService : IEmailService
    {
        public Task<bool> SendAsync(string text, string recipient)
        {
            throw new NotImplementedException();
        }
    }
}
