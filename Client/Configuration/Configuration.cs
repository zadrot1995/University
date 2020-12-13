using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Client.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        private Assembly _assembly;

        public string ApiJson { get; set; }

        public ConfigurationManager()
        {
            _assembly = typeof(ConfigurationManager).GetTypeInfo().Assembly;
        }

        public void Configure(string pathToSettings)
        {
            using (Stream stream = _assembly.GetManifestResourceStream(pathToSettings))
            {
                XDocument doc = XDocument.Load(stream);

                ApiJson = doc.XPathSelectElements($"appsettings/ApiJson").FirstOrDefault().Value;
            }
        }
    }
}
