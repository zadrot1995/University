using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ClientAdmin.Common.Interfaces
{
    public interface IRequestProcessor
    {
        string MediaType { get; }
        HttpContent GetContent(object model);
    }
}
