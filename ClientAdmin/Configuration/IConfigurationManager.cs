using System;
using System.Collections.Generic;
using System.Text;

namespace ClientAdmin.Configuration
{
    public interface IConfigurationManager
    {

        string ApiJson { get; set; }
        string AuthLogin { get; set; }
        void Configure(string reader);
    }
}
