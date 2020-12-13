using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Configuration
{
    public interface IConfigurationManager
    {
        string ApiJson { get; set; }
        void Configure(string reader);
    }
}
