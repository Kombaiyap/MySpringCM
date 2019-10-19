using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringCMTests
{
    class TestSettingReader
    {
        public string SprintCMUrl => GetSettingValueByKey("SprintCMUrl");

        public string BrowserName => GetSettingValueByKey("BrowserName");

        private static string GetSettingValueByKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
